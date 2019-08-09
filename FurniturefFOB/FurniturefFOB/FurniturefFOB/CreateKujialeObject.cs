using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public   class CreateKujialeObject
    {
        public AddMsg addMsg = null;
        public AddMsg ErrMsg = null;
        public  List<KJLobject> kobj=null ;
        public  List<KJLobject> GetKujialeObject(string js,out int boxcount)
        {
            addMsg(DateTime.Now.ToString()+"：开始创建酷家乐对象...");
            kobj = new List<KJLobject>();
            JObject jon = JObject.Parse(js);
            string ParJar = "";
            int ordertype;
            ParJar = jon["paramModel"].ToString();
            ordertype = jon["toolTypes"].ToString().Contains("0") ? 0 : 1;
            //getFurnitureObj(ParJar,ordertype,"",null);
            getF(ParJar, ordertype);
            addMsg(DateTime.Now.ToString() + "：创建酷家乐对象完成！");
            boxcount = boxseq;
            return kobj;           
        }
        int boxseq=0;

        private void getF(string str, int Type)
        {
            JArray jar = JArray.Parse(str);
            int count = jar.Count;
            for(int i=0;i<count;i++)
            {
                string jstr = jar[i].ToString();
                JObject jss = new JObject();
                jss = JObject.Parse(jstr);
                KJLobject kJLobject = new KJLobject();
                kJLobject.modelTypeId = int.Parse(jss["modelTypeId"].ToString());
                kJLobject.OrderType = Type;
                if (jss.Property("modelName") != null)
                {
                    kJLobject.modelName = jss["modelName"].ToString();
                }
                if (jss.Property("customCode") != null)
                {
                    kJLobject.customCode = jss["customCode"].ToString();
                }
                if (jss.Property("modelNumber") != null)
                {
                    kJLobject.modelNumber = jss["modelNumber"].ToString();
                }
                if (jss.Property("obsBrandGoodId") != null)
                {
                    kJLobject.obsBrandGoodId = jss["obsBrandGoodId"].ToString();
                }
                if (jss.Property("obsModelAccountId") != null)
                {
                    kJLobject.obsModelAccountId = jss["obsModelAccountId"].ToString();
                }
                if (jss.Property("modelAvailable") != null)
                {
                    kJLobject.modelAvailable = jss["modelAvailable"].ToString();
                }
                if (jss.Property("needQuotation") != null)
                {
                    kJLobject.needQuotation = bool.Parse(jss["needQuotation"].ToString());
                }
                if (jss.Property("displayInCostList") != null)
                {
                    kJLobject.displayInCostList = bool.Parse(jss["displayInCostList"].ToString());
                }
                if (jss.Property("textureName") != null)
                {
                    kJLobject.textureName = jss["textureName"].ToString();
                }
                if (jss.Property("textureBrandGoodCode") != null)
                {
                    kJLobject.textureBrandGoodCode = jss["textureBrandGoodCode"].ToString();
                }
                if (jss.Property("textureAvailable") != null)
                {
                    kJLobject.textureAvailable = bool.Parse(jss["textureAvailable"].ToString());
                }
                if (jss.Property("obsTextureAccountId") != null)
                {
                    kJLobject.obsTextureAccountId = jss["obsTextureAccountId"].ToString();
                }
                if (jss.Property("id") != null)
                {
                    kJLobject.id = jss["id"].ToString();
                }
                if (jss.Property("parentId") != null)
                {
                    kJLobject.parentid = jss["parentId"].ToString();
                }
                List<parameter> lstParm = new List<parameter>();
                double W = 0;
                double H = 0;
                double D = 0;
                if (jss.Property("parameters") != null)
                {
                    string parmstrs = jss["parameters"].ToString();
                    JArray parmJar = JArray.Parse(parmstrs);
                    foreach (JObject js in parmJar)
                    {
                        parameter pr = new parameter();
                        if (js.Property("simpleName") != null)
                        {
                            try
                            {
                                pr.parmName = js["simpleName"].ToString();
                                pr.parmValue = js["value"].ToString();
                            }
                            catch
                            {

                            }

                        }
                        if (pr.parmName == "")
                        {
                            pr.parmName = js["name"].ToString();
                            pr.parmValue = js["value"].ToString();
                        }
                        if (pr.parmName != "")
                        {
                            lstParm.Add(pr);
                        }
                        if (pr.parmName == "H")
                        {
                            H = double.Parse(pr.parmValue);
                        }
                        else if (pr.parmName == "W")
                        {
                                W = double.Parse(pr.parmValue);
                        }
                        else if (pr.parmName == "D")
                        {
                            D = double.Parse(pr.parmValue);
                        }
                    }
                }
                if (jss.Property("ignoreParameters") != null)
                {
                    string ignoreparmstrs = jss["ignoreParameters"].ToString();
                    JArray ignoreparmJar = JArray.Parse(ignoreparmstrs);
                    foreach (JObject js in ignoreparmJar)
                    {
                        parameter pr = new parameter();
                        if (js.Property("simpleName") != null)
                        {
                            pr.parmName = js["simpleName"].ToString();
                            pr.parmValue = js["value"].ToString();
                        }
                        if (pr.parmName == "")
                        {
                            pr.parmName = js["name"].ToString();
                            pr.parmValue = js["value"].ToString();
                        }
                        if (pr.parmName != "")
                        {
                            lstParm.Add(pr);
                        }
                        if (pr.parmName == "H")
                        {
                            H = double.Parse(pr.parmValue);
                        }
                        else if (pr.parmName == "W")
                        {
                            W = double.Parse(pr.parmValue);
                        }

                        else if (pr.parmName == "D")
                        {
                            D = double.Parse(pr.parmValue);
                        }
                    }
                }
                kJLobject.parameters = lstParm;
                kJLobject.parameters.Add(new parameter("color", kJLobject.textureBrandGoodCode + "H|"));
                kJLobject.absP = getabsP(jss["absPosition"].ToString());
                kJLobject.absR = getabsR(jss["absRotation"].ToString());
                CaulModel caul = new CaulModel();
                caul = caul.getCaulModel(kJLobject.absP, kJLobject.absR, D, W, H);
                kJLobject.caulModel = caul;
                if (kJLobject.customCode == "F")
                {
                    boxseq += 1;
                    kJLobject.boxPostion = kJLobject.absP;
                    kJLobject.HoleGroup = boxseq.ToString();
                }
                else
                {
                    kJLobject.boxPostion = kJLobject.absP;
                    kJLobject.HoleGroup = boxseq.ToString();
                }

                if (kJLobject.modelNumber != null && kJLobject.modelNumber != "0")
                {
                    kobj.Add(kJLobject);
                }
                if (jss.Property("subModels") != null)
                {
                    string jschid = jss["subModels"].ToString();
                    getFurnitureObj(jschid, Type, kJLobject.absP);
                }
                else
                {
                    continue;
                }
            }
        }
        private void getFurnitureObj(string str, int Type, absPostion absPostion)
        {
            JArray jar = JArray.Parse(str);
            int count = jar.Count;
            foreach (JObject jss in jar)
            {
                KJLobject kJLobject = new KJLobject();
                kJLobject.modelTypeId = int.Parse(jss["modelTypeId"].ToString());
                kJLobject.OrderType = Type;
                if (jss.Property("modelName") != null)
                {
                    kJLobject.modelName = jss["modelName"].ToString();
                }
                if (jss.Property("customCode") != null)
                {
                    kJLobject.customCode = jss["customCode"].ToString();
                }
                if (jss.Property("modelNumber") != null)
                {
                    kJLobject.modelNumber = jss["modelNumber"].ToString();
                }
                if (jss.Property("obsBrandGoodId") != null)
                {
                    kJLobject.obsBrandGoodId = jss["obsBrandGoodId"].ToString();
                }
                if (jss.Property("obsModelAccountId") != null)
                {
                    kJLobject.obsModelAccountId = jss["obsModelAccountId"].ToString();
                }
                if (jss.Property("modelAvailable") != null)
                {
                    kJLobject.modelAvailable = jss["modelAvailable"].ToString();
                }
                if (jss.Property("needQuotation") != null)
                {
                    kJLobject.needQuotation = bool.Parse(jss["needQuotation"].ToString());
                }
                if (jss.Property("displayInCostList") != null)
                {
                    kJLobject.displayInCostList = bool.Parse(jss["displayInCostList"].ToString());
                }
                if (jss.Property("textureName") != null)
                {
                    kJLobject.textureName = jss["textureName"].ToString();
                }
                if (jss.Property("textureBrandGoodCode") != null)
                {
                    kJLobject.textureBrandGoodCode = jss["textureBrandGoodCode"].ToString();
                }
                if (jss.Property("textureAvailable") != null)
                {
                    kJLobject.textureAvailable = bool.Parse(jss["textureAvailable"].ToString());
                }
                if (jss.Property("obsTextureAccountId") != null)
                {
                    kJLobject.obsTextureAccountId = jss["obsTextureAccountId"].ToString();
                }
                if (jss.Property("id") != null)
                {
                    kJLobject.id = jss["id"].ToString();
                }
                if (jss.Property("parentId") != null)
                {
                    kJLobject.parentid = jss["parentId"].ToString();
                }
                List<parameter> lstParm = new List<parameter>();
                double W = 0;
                double H = 0;
                double D = 0;
                if (jss.Property("parameters") != null)
                {
                    string parmstrs = jss["parameters"].ToString();
                    JArray parmJar = JArray.Parse(parmstrs);
                    foreach (JObject js in parmJar)
                    {
                        parameter pr = new parameter();
                        if (js.Property("simpleName") != null)
                        {
                            pr.parmName = js["simpleName"].ToString();
                            pr.parmValue = js["value"].ToString();

                        }
                        if (pr.parmName == "")
                        {
                            pr.parmName = js["name"].ToString();
                            pr.parmValue = js["value"].ToString();
                        }
                        if (pr.parmName != "")
                        {
                            lstParm.Add(pr);
                        }
                        if (pr.parmName == "H")
                        {
                            H = double.Parse(pr.parmValue);
                        }
                        else if (pr.parmName == "W")
                        {
                            W = double.Parse(pr.parmValue);
                        }

                        else if (pr.parmName == "D")
                        {
                            D = double.Parse(pr.parmValue);
                        }
                    }
                }
                if (jss.Property("ignoreParameters") != null)
                {
                    string ignoreparmstrs = jss["ignoreParameters"].ToString();
                    JArray ignoreparmJar = JArray.Parse(ignoreparmstrs);
                    foreach (JObject js in ignoreparmJar)
                    {
                        parameter pr = new parameter();
                        if (js.Property("simpleName") != null)
                        {
                            pr.parmName = js["simpleName"].ToString();
                            pr.parmValue = js["value"].ToString();
                        }
                        if (pr.parmName == "")
                        {
                            pr.parmName = js["name"].ToString();
                            pr.parmValue = js["value"].ToString();
                        }
                        if (pr.parmName != "")
                        {
                            lstParm.Add(pr);
                        }
                        if (pr.parmName == "H")
                        {
                            H = double.Parse(pr.parmValue);
                        }
                        else if (pr.parmName == "W")
                        {
                            W = double.Parse(pr.parmValue);
                        }

                        else if (pr.parmName == "D")
                        {
                            D = double.Parse(pr.parmValue);
                        }
                    }
                }

                kJLobject.parameters = lstParm;
                kJLobject.parameters.Add(new parameter("color", kJLobject.textureBrandGoodCode + "H|"));
                kJLobject.absP = getabsP(jss["absPosition"].ToString());
                kJLobject.absR = getabsR(jss["absRotation"].ToString());
                CaulModel caul = new CaulModel();
                caul = caul.getCaulModel(kJLobject.absP, kJLobject.absR, D, W, H);
                kJLobject.caulModel = caul;
                    if (kJLobject.customCode == "F")
                    {
                        boxseq +=1;
                        kJLobject.boxPostion = kJLobject.absP;
                        kJLobject.HoleGroup = boxseq.ToString();
                    }
                    else
                    {
                        kJLobject.boxPostion = absPostion;
                        kJLobject.HoleGroup = boxseq.ToString();
                    }
    

                if (kJLobject.modelNumber != null && kJLobject.modelNumber != "0")
                {
                    kobj.Add(kJLobject);
                }
                count += -1;
                if (jss.Property("subModels") != null)
                {
                    string jschid = jss["subModels"].ToString();
                    getFurnitureObj(jschid, Type, kJLobject.boxPostion);
                }
                else
                {
                    if (count == 0)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private  absPostion getabsP(string str)
        {
            JObject jObject = JObject.Parse(str);
            absPostion abs = new absPostion();
            abs.x = double.Parse(jObject["x"].ToString());
            abs.y = double.Parse(jObject["y"].ToString());
            abs.z = double.Parse(jObject["z"].ToString());
            return abs;
        }
        private absRotation getabsR(string str)
        {
            JObject jObject = JObject.Parse(str);
            absRotation abs = new absRotation();
            abs.x = Math.Round(double.Parse(jObject["x"].ToString()) * 180 / System.Math.PI);
            abs.y = Math.Round(double.Parse(jObject["y"].ToString()) * 180 / System.Math.PI);
            abs.z = Math.Round(double.Parse(jObject["z"].ToString()) * 180 / System.Math.PI);
            return abs;
        }


    }
}
