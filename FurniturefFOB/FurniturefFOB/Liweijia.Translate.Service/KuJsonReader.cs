using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public class KuJsonReader
    {

        public AddMsg log = null;
        public AddMsg errorlog = null;
        List<KuModel> kobj = new List<KuModel>();
        int boxseq = 0;
        public static bool isPropertyExist(JObject obj, string propertyName)
        {
            return obj.Property(propertyName) != null;
        }
        public static JArray getPropertyValueAsJarray(JObject obj, string propertyName)
        {
            return obj[propertyName] == null ? new JArray() : (JArray)obj[propertyName];
        }
        public static JObject getPropertyValueAsJobj(JObject obj, string propertyName)
        {
            return obj[propertyName] == null ? new JObject() : (JObject)obj[propertyName];
        }
        public static string getPropertyValueAsString(JObject obj, string propertyName)
        {
            return obj[propertyName] == null ? "" : obj[propertyName].ToString();
        }
        public static void setPropertyValueAsStringIfNotEmpty(KuModel target, JObject source, String sourcePropertyName)
        {
            if (isPropertyExist(source, sourcePropertyName))
            {
                string v = getPropertyValueAsString(source, sourcePropertyName);
                PropertyInfo property = target.GetType().GetProperty(sourcePropertyName);
                Type t = property.PropertyType;
                if (t.Name == "Boolean")
                {
                    property.SetValue(target, Convert.ToBoolean(v), null);
                }
                else if (t.Name == "Double")
                {
                    property.SetValue(target, Convert.ToDouble(v), null);
                }
                else if (t.Name.StartsWith("Int"))
                {
                    property.SetValue(target, Convert.ToInt32(v), null);
                }
                else
                {
                    property.SetValue(target, v, null);
                }
            }
        }
        public static void setDimensionValue(Dimension dim, Parameter p)
        {
            if (p.name == "H")
            {
                dim.h = double.Parse(p.value);
            }
            else if (p.name == "W")
            {
                dim.w = double.Parse(p.value);
            }
            else if (p.name == "D")
            {
                dim.d = double.Parse(p.value);
            }
        }
        public int getBoxCount()
        {
            return boxseq;
        }
        public List<KuModel> readKujialeModels(string js)
        {
            kobj.Clear();
            DateTime timeStart = DateTime.Now;
            log("【"+timeStart.ToString() + "】：开始创建酷家乐对象...");
            if (js == null)
            {
                return kobj;
            }
            JObject jon = JObject.Parse(js);
            int ordertype;
            ordertype = jon["toolTypes"].ToString().Contains("0") ? 0 : 1;
            if (!isPropertyExist(jon, "paramModel"))
            {
                return kobj;
            }
            readModels(getPropertyValueAsJarray(jon, "paramModel"), ordertype,null);

            DateTime timeEnd = DateTime.Now;
            log("【"+timeEnd + "】: 耗时 " + (timeEnd - timeStart).TotalSeconds + "秒创建酷家乐对象完成！");
            return kobj;
        }
        private void readModels(JArray modelsJarray, int type,Position parentAbsPostion)
        {
            foreach (JObject jsonObject in modelsJarray)
            {
                KuModel kModel = new KuModel();
                kModel.modelTypeId = int.Parse(jsonObject["modelTypeId"].ToString());
                kModel.orderType = type;
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "modelName");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "customCode");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "modelNumber");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "obsBrandGoodId");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "modelAvailable");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "needQuotation");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "displayInCostList");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "textureName");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "textureBrandGoodCode");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "textureAvailable");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "obsTextureAccountId");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "id");
                setPropertyValueAsStringIfNotEmpty(kModel, jsonObject, "parentId");
                List<Parameter> paramList = new List<Parameter>();
                Dimension dim = new Dimension();
                JArray paramJarray = new JArray();
                JArray ignoreParamJarrray = new JArray();
                if (isPropertyExist(jsonObject, "parameters"))
                {
                    paramJarray = getPropertyValueAsJarray(jsonObject, "parameters");
                }
                if (isPropertyExist(jsonObject, "ignoreParameters"))
                {
                    ignoreParamJarrray = getPropertyValueAsJarray(jsonObject, "ignoreParameters");
                }
                foreach (JObject paramJobj in paramJarray)
                {
                    if (!isPropertyExist(paramJobj, "name"))
                    {
                        continue;
                    }
                    Parameter pr = new Parameter();
                    pr.name = getPropertyValueAsString(paramJobj, "name");
                    pr.value = getPropertyValueAsString(paramJobj, "value");
                    if (pr.name != "")
                    {
                        paramList.Add(pr);
                    }
                    setDimensionValue(dim, pr);
                }
                foreach (JObject ignoreParamJobj in ignoreParamJarrray)
                {
                    if (!isPropertyExist(ignoreParamJobj, "name"))
                    {
                        continue;
                    }
                    Parameter pr = new Parameter();
                    pr.name = getPropertyValueAsString(ignoreParamJobj, "name");
                    pr.value = getPropertyValueAsString(ignoreParamJobj, "value");
                    if (pr.name != "")
                    {
                        paramList.Add(pr);
                    }
                    setDimensionValue(dim, pr);
                }
                double RZ_Degree;
                kModel.parameters = paramList;
                kModel.parameters.Add(new Parameter("color", kModel.textureBrandGoodCode + "H"));
                kModel.ImosPosition = getPosition(getPropertyValueAsJobj(jsonObject, "absPosition"));
                kModel.absRotation = getRotation(getPropertyValueAsJobj(jsonObject, "absRotation"),out RZ_Degree);
                kModel.absPosition = getbeforRoatePostion(kModel.ImosPosition, RZ_Degree);
                kModel.caulModel = Caul.newCaul(kModel.absPosition, dim.d, dim.w, dim.h);
                kModel.boxPostion = kModel.absPosition;
                if (kModel.customCode == "F")
                {
                    boxseq += 1;
                    kModel.boxPostion = kModel.absPosition;
                    kModel.holeGroup = boxseq.ToString();
                }
                else
                {
                    if (parentAbsPostion == null)
                    {
                        kModel.boxPostion = kModel.absPosition;
                    }
                    else
                    {
                        kModel.boxPostion = parentAbsPostion;
                    }
                    kModel.holeGroup = boxseq.ToString();
                }
               
                if (kModel.modelNumber != null && kModel.modelNumber != "0")
                {
                    kobj.Add(kModel);
                }
                if (isPropertyExist(jsonObject, "subModels"))
                {
                    readModels(getPropertyValueAsJarray(jsonObject, "subModels"), type, kModel.absPosition);
                }
            }
        }
        private Position getPosition(JObject jObject)
        {
            Position abs = new Position();
            abs.x = double.Parse(jObject["x"].ToString());
            abs.y = double.Parse(jObject["y"].ToString());
            abs.z = double.Parse(jObject["z"].ToString());
            return abs;
        }

        private Rotation getRotation(JObject jObject, out double rz)
        {
            Rotation abs = new Rotation();
            rz = double.Parse(jObject["z"].ToString());
            abs.x = Math.Round(double.Parse(jObject["x"].ToString()) * 180 / System.Math.PI);
            abs.y = Math.Round(double.Parse(jObject["y"].ToString()) * 180 / System.Math.PI);
            abs.z = Math.Round(rz * 180 / System.Math.PI);
            return abs;
        }
        //坐标转换为水平方向
        private Position getbeforRoatePostion(Position abs, double rz)
        {
            Position position = new Position();
            double x = abs.x;
            double y = abs.y;
            double x1 = 0;
            double y1 = 0;
            double jd = -rz;
            position.x = (x - x1) * Math.Cos(jd) - (y - y1) * Math.Sin(jd) + x1;
            position.y = (x - x1) * Math.Sin(jd) + (y - y1) * Math.Cos(jd) + y1;
            position.z = abs.z;
            return position;
        }
    }
}
