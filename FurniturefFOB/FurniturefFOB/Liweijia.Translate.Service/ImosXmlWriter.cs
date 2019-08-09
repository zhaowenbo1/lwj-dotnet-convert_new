using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace FurniturefFOB
{
    class ImosXml
    {
        private static StringBuilder headStr = new StringBuilder("");

        private static StringBuilder setFixStr = new StringBuilder("");
        static ImosXml()
        {
            headStr.Append("<COMM>");
            headStr.Append("</COMM>");
            headStr.Append("<ARTICLENO>");
            headStr.Append("</ARTICLENO>");
            headStr.Append("<CUSTOMER>");
            headStr.Append("</CUSTOMER>");
            headStr.Append("<CLIENT>");
            headStr.Append("</CLIENT>");
            headStr.Append("<PROGRAM>");
            headStr.Append("</PROGRAM>");
            headStr.Append("<EMPLOYEE>");
            headStr.Append("</EMPLOYEE>");
            headStr.Append("<TEXT_LONG>");
            headStr.Append("</TEXT_LONG>");
            headStr.Append("<TEXT_SHORT>");
            headStr.Append("</TEXT_SHORT>");
            headStr.Append("<COLOUR1>");
            headStr.Append("</COLOUR1>");
            headStr.Append("<COLOUR2>");
            headStr.Append("</COLOUR2>");
            headStr.Append("<COLOUR3>");
            headStr.Append("</COLOUR3>");
            headStr.Append("<COLOUR4>");
            headStr.Append("</COLOUR4>");
            headStr.Append("<COLOUR5>");
            headStr.Append("</COLOUR5>");
            headStr.Append("<INFO1>");
            headStr.Append("</INFO1>");
            headStr.Append("<INFO2>");
            headStr.Append("</INFO2>");
            headStr.Append("<INFO3>");
            headStr.Append("</INFO3>");
            headStr.Append("<INFO4>");
            headStr.Append("</INFO4>");
            headStr.Append("<INFO5>");
            headStr.Append("</INFO5>");
            headStr.Append("<INFO6>");
            headStr.Append("</INFO6>");
            headStr.Append("<INFO7>");
            headStr.Append("</INFO7>");
            headStr.Append("<INFO8>");
            headStr.Append("</INFO8>");
            headStr.Append("<INFO9>");
            headStr.Append("</INFO9>");
            headStr.Append("<INFO10>");
            headStr.Append("</INFO10>");
            headStr.Append("<ADDRESS1>");
            headStr.Append("</ADDRESS1>");
            headStr.Append("<ADDRESS2>");
            headStr.Append("</ADDRESS2>");
            headStr.Append("<ADDRESS3>");
            headStr.Append("</ADDRESS3>");
            headStr.Append("<ADDRESS4>");
            headStr.Append("</ADDRESS4>");
            headStr.Append("<ADDRESS5>");
            headStr.Append("</ADDRESS5>");
            headStr.Append("<ADDRESS6>");
            headStr.Append("</ADDRESS6>");
            headStr.Append("<BILLING_ADDRESS1>");
            headStr.Append("</BILLING_ADDRESS1>");
            headStr.Append("<BILLING_ADDRESS2>");
            headStr.Append("</BILLING_ADDRESS2>");
            headStr.Append("<BILLING_ADDRESS3>");
            headStr.Append("</BILLING_ADDRESS3>");
            headStr.Append("<BILLING_ADDRESS4>");
            headStr.Append("</BILLING_ADDRESS4>");
            headStr.Append("<BILLING_ADDRESS5>");
            headStr.Append("</BILLING_ADDRESS5>");
            headStr.Append("<BILLING_ADDRESS6>");
            headStr.Append("</BILLING_ADDRESS6>");
            headStr.Append("<SHIPPING_ADDRESS1>");
            headStr.Append("</SHIPPING_ADDRESS1>");
            headStr.Append("<SHIPPING_ADDRESS2>");
            headStr.Append("</SHIPPING_ADDRESS2>");
            headStr.Append("<SHIPPING_ADDRESS3>");
            headStr.Append("</SHIPPING_ADDRESS3>");
            headStr.Append("<SHIPPING_ADDRESS4>");
            headStr.Append("</SHIPPING_ADDRESS4>");
            headStr.Append("<SHIPPING_ADDRESS5>");
            headStr.Append("</SHIPPING_ADDRESS5>");
            headStr.Append("<SHIPPING_ADDRESS6>");
            headStr.Append("</SHIPPING_ADDRESS6>");
            headStr.Append("<ORDER_PRICE_INFO1>");
            headStr.Append("</ORDER_PRICE_INFO1>");
            headStr.Append("<ORDER_PRICE_INFO2>");
            headStr.Append("</ORDER_PRICE_INFO2>");
            headStr.Append("<ORDER_PRICE_INFO3>");
            headStr.Append("</ORDER_PRICE_INFO3>");
            headStr.Append("<ORDER_PRICE_INFO4>");
            headStr.Append("</ORDER_PRICE_INFO4>");
            headStr.Append("<ORDER_PRICE_INFO5>");
            headStr.Append("</ORDER_PRICE_INFO5>");
            headStr.Append("<CUSTOM_INFO1>");
            headStr.Append("</CUSTOM_INFO1>");
            headStr.Append("<CUSTOM_INFO2>");
            headStr.Append("</CUSTOM_INFO2>");
            headStr.Append("<CUSTOM_INFO3>");
            headStr.Append("</CUSTOM_INFO3>");
            headStr.Append("<CUSTOM_INFO4>");
            headStr.Append("</CUSTOM_INFO4>");
            headStr.Append("<CUSTOM_INFO5>");
            headStr.Append("</CUSTOM_INFO5>");
            headStr.Append("<CUSTOM_INFO6>");
            headStr.Append("</CUSTOM_INFO6>");
            headStr.Append("<CUSTOM_INFO7>");
            headStr.Append("</CUSTOM_INFO7>");
            headStr.Append("<CUSTOM_INFO8>");
            headStr.Append("</CUSTOM_INFO8>");
            headStr.Append("<CUSTOM_INFO9>");
            headStr.Append("</CUSTOM_INFO9>");
            headStr.Append("<CUSTOM_INFO10>");
            headStr.Append("</CUSTOM_INFO10>");

            setFixStr.Append("<ARTICLE_TEXT_INFO1></ARTICLE_TEXT_INFO1>");
            setFixStr.Append("<ARTICLE_TEXT_INFO2></ARTICLE_TEXT_INFO2>");
            setFixStr.Append("<ARTICLE_PRICE_INFO1></ARTICLE_PRICE_INFO1>");
            setFixStr.Append("<ARTICLE_PRICE_INFO2></ARTICLE_PRICE_INFO2>");
        }
        public static string headerString()
        {
            return headStr.ToString();
        }
        public static string sFixStr()
        {
            return setFixStr.ToString();
        }
    }

    public class ImosXmlWriter
    {

        public AddMsg addMsg = null;
        public AddMsg ErrMsg = null;
        private static string BOAD_INFO_SQL = "select * from boardinfo";
        private Dictionary<String, DataRow> boardInfoCodeIndex = new Dictionary<string, DataRow>();
        private static string SYS_PARAM_SQL = "select * from SysPram";
        private Dictionary<String, DataRow> sysParamKnameTypeIndex = new Dictionary<string, DataRow>();
        private static string BORAD_SYS_JOIN_SQL = "select p.*, o.code from Paramss p inner join boardinfo o on o.id=p.boardid";
        private Dictionary<String, DataRow> sysBoardKnameIndex = new Dictionary<string, DataRow>();
        private void reBuildBoardInfoCodeIndex()
        {
            boardInfoCodeIndex.Clear();
            DataTable biTable = OleHeper.Query(BOAD_INFO_SQL).Tables[0];
            DataRowCollection rows = biTable.Rows;
            if (rows.Count <= 0)
            {
                return;
            }
            foreach (DataRow dr in rows)
            {
                string code = dr["Code"] == null ? "" : dr["Code"].ToString();
                boardInfoCodeIndex.Add(code, dr);
            }
        }

        private void reBuildSysParamKnameTypeIndex()
        {
            sysParamKnameTypeIndex.Clear();
            DataTable sysParamTable = OleHeper.Query(SYS_PARAM_SQL).Tables[0];
            DataRowCollection rows = sysParamTable.Rows;
            if (rows.Count <= 0)
            {
                return;
            }
            foreach (DataRow dr in rows)
            {
                string kName = dr["Kname"] == null ? "" : dr["Kname"].ToString();
                string orderType = dr["OrderType"] == null ? "" : dr["OrderType"].ToString();
                sysParamKnameTypeIndex.Add(kName + orderType, dr);
            }
        }
        private void reBuildSysBoardKnameIndex()
        {
            sysBoardKnameIndex.Clear();
            DataTable bs = OleHeper.Query(BORAD_SYS_JOIN_SQL).Tables[0];
            DataRowCollection rows = bs.Rows;
            if (rows.Count <= 0)
            {
                return;
            }
            foreach (DataRow dr in rows)
            {
                string kName = dr["Kname"] == null ? "" : dr["Kname"].ToString();
                string code = dr["code"] == null ? "" : dr["code"].ToString();
                string key = kName + code;
                if (!sysBoardKnameIndex.ContainsKey(key))
                {
                    sysBoardKnameIndex.Add(key, dr);
                }
            }
        }
        //创建XML
        public void CreateXml(List<KuModel> kModels, string FileName, string SavePath)
        {
            string name = FileName;
            string Filepath = SavePath + FileName + ".xml";
            DateTime startTime = DateTime.Now;
            //重建boadinfo索引
            reBuildBoardInfoCodeIndex();
            reBuildSysParamKnameTypeIndex();
            reBuildSysBoardKnameIndex();
            //获取配置对象           
            kModels = getUserkbj(kModels);
            //孔位判断进板顺序
            kModels = getHoleInfo(kModels);
            addMsg("【"+DateTime.Now.ToString() + "】：开始调整进板顺序...");
            //有孔板件
            List<KuModel> holeModels = new List<KuModel>();
            holeModels = kModels.Where(l => l.LevelSeq <=10 ).ToList();
            holeModels = holeModels.OrderBy(s => s.holeGroup).ToList();
            //无孔板件
            List<KuModel> noHoleModels = new List<KuModel>();
            noHoleModels = kModels.Where(l => l.LevelSeq > 10).ToList();
            List<BoxList> boxLists = new List<BoxList>();
            List<KuModel> EndList = new List<KuModel>();
            //有孔板件顺序
            for (int i = 1; i <= kModels.Count; i++)
            {
                List<KuModel> tempList = new List<KuModel>();
                tempList = holeModels.Where(l => l.holeGroup == i.ToString()).ToList();
                tempList = tempList.OrderBy(s => s.LevelSeq).ToList();
                if(tempList.Count == 0)
                {
                    continue;
                }
                BoxList bxlist = new BoxList();
                bxlist.boxlist = tempList;
                bxlist.maxz = tempList[0].boxPostion.z;
                boxLists.Add(bxlist);
            }
            boxLists = boxLists.OrderByDescending(s => s.maxz).ToList();
            for (int i = 0; i < boxLists.Count; i++)
            {
                EndList.AddRange(boxLists[i].boxlist);
            }
            EndList.AddRange(noHoleModels);
            addMsg("【"+DateTime.Now.ToString() + "】：调整进板顺序完成!");
            addMsg("【"+DateTime.Now.ToString() + "】：开始生成XML数据...");
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDocument.AppendChild(declaration);
            XmlElement xmlrootEle = xmlDocument.CreateElement("XML");
            xmlrootEle.SetAttribute("Type", "ListBuilder");
            xmlDocument.AppendChild(xmlrootEle);
            XmlElement orderEle = xmlDocument.CreateElement("Order");
            orderEle.SetAttribute("Basket", name);
            orderEle.SetAttribute("DispDate", DateTime.Now.ToString("dd.MM.yyyy"));
            orderEle.SetAttribute("No", name);
            xmlrootEle.AppendChild(orderEle);
            XmlElement headEle = xmlDocument.CreateElement("Head");
            headEle.InnerXml = ImosXml.headerString();
            orderEle.AppendChild(headEle);
            XmlElement builderListEle = xmlDocument.CreateElement("BuilderList");
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < EndList.Count; i++)
            {
                text.Clear();
                XmlElement setEle = xmlDocument.CreateElement("Set");
                setEle.SetAttribute("LineNo", string.Concat(i + 1));
                text.Append("<Pname>" + EndList[i].newCode + EndList[i].holeStart + "</Pname>");
                text.Append("<Count>1</Count>");
                text.Append("<PVarString>" + GetParmeteSts(EndList[i]) + "</PVarString>");
                text.Append(ImosXml.sFixStr());
                text.Append("<PInsertion>" + Math.Round(double.Parse(EndList[i].ImosPosition.x.ToString())).ToString() + ","
                                + Math.Round(double.Parse(EndList[i].ImosPosition.y.ToString())).ToString() + ","
                                + Math.Round(double.Parse(EndList[i].ImosPosition.z.ToString())).ToString() + "</PInsertion>");
                text.Append("<POrntation>" + EndList[i].absRotation.x.ToString() + ","
                                + EndList[i].absRotation.y.ToString() + "," + EndList[i].absRotation.z.ToString() + "</POrntation>");
                setEle.InnerXml = text.ToString();
                builderListEle.AppendChild(setEle);
            }
            orderEle.AppendChild(builderListEle);
            try
            {
                xmlDocument.Save(Filepath);
                DateTime endTime = DateTime.Now;
                addMsg("【"+DateTime.Now.ToString() + "】：耗时" + (endTime -startTime).TotalSeconds + "秒" + "生成XML数据源完成！");
            }
            catch (Exception e)
            {
                ErrMsg(DateTime.Now.ToString() + "：创建XML失败!" +
                    "错误信息为：" + e.ToString());
            }
        }

        //配置对象
        private List<KuModel> getUserkbj(List<KuModel> kJ)
        {
            addMsg("【" + DateTime.Now.ToString() + "】：开始获取数据库配置信息");
            List<KuModel> Klist = new List<KuModel>();
            foreach (KuModel k in kJ)
            {
                //门板
                if (k.isDoor())
                {
                    List<KuModel> lsObj = new List<KuModel>();
                    List<KuModel> LSXH = new List<KuModel>();
                    lsObj = kJ.Where(l => l.parentId == k.parentId).ToList();
                    lsObj = lsObj.Where(l => l.modelTypeId == 2).ToList();
                    LSXH.AddRange(lsObj);
                    lsObj = kJ.Where(l => l.id == k.parentId).ToList();
                    lsObj = lsObj.Where(l => l.modelTypeId == 2).ToList();
                    LSXH.AddRange(lsObj);
                    lsObj = kJ.Where(l => l.parentId == k.id).ToList();
                    lsObj = lsObj.Where(l => l.modelTypeId == 2).ToList();
                    LSXH.AddRange(lsObj);
                    for (int i = 0; i < LSXH.Count; i++)
                    {
                        Parameter parameter = new Parameter();
                        parameter.name = "LSXH";
                        parameter.value = LSXH[i].modelNumber;
                        k.parameters.Add(parameter);
                    }
                }
                if (boardInfoCodeIndex.ContainsKey(k.modelNumber))
                {
                    DataRow dr = null;
                    boardInfoCodeIndex.TryGetValue(k.modelNumber, out dr);
                    k.LevelSeq = int.Parse(dr["LevelSeq"].ToString());
                    k.newCode = k.modelNumber;
                    string holeFx = dr["HoleFx"].ToString();
                    k.holeFx = holeFx == "" ? 0 : k.holeFx = double.Parse(holeFx);
                    Klist.Add(k);
                }
                else
                {
                    k.newCode = k.modelNumber;
                    k.LevelSeq = 100;
                    Klist.Add(k);
                    if (k.modelTypeId != 2)
                    {
                        ErrMsg(k.modelNumber + "：在数据库找不到配置信息!");
                    }
                }
            }
            addMsg("【" + DateTime.Now.ToString() + "】：获取数据库配置信息完成!");
            return Klist;
        }
        //变量
        private string GetParmeteSts(KuModel kJ)
        {
            string str = "";
            string orderTy;
            orderTy = kJ.orderType == 1 ? "衣柜" : "橱柜";
            foreach (Parameter parm in kJ.parameters)
            {
                string ktName = parm.name + orderTy;
                if (sysParamKnameTypeIndex.ContainsKey(ktName))
                {
                    DataRow drs = null;
                    sysParamKnameTypeIndex.TryGetValue(ktName, out drs);
                    str = str + drs["Iname"] + ":=" + parm.value + "|";
                }
                string kmName = parm.name + kJ.modelNumber;
                if (sysBoardKnameIndex.ContainsKey(kmName))
                {
                    DataRow dr = null;
                    sysBoardKnameIndex.TryGetValue(kmName, out dr);
                    str = str + dr["Iname"] + ":=" + parm.value + "|";
                }
            }
            return str;
        }

        //判断孔
        //double fx = 0.2;
        private List<KuModel> getHoleInfo(List<KuModel> Kobj)
        {
            List<KuModel> hBoardlist = new List<KuModel>();//水平板
            List<KuModel> vBoardlist = new List<KuModel>();//垂直板
            List<KuModel> hBoardlist_TTM = new List<KuModel>();//榻榻米水平板
            List<KuModel> vBoardlist_TTM = new List<KuModel>();//榻榻米垂直板
            List<KuModel> otherboardlist = new List<KuModel>();//其他
            foreach (KuModel kj in Kobj)
            {
                if (boardInfoCodeIndex.ContainsKey(kj.modelNumber))
                {
                    DataRow dr = null;
                    boardInfoCodeIndex.TryGetValue(kj.modelNumber, out dr);
                    if (dr["BoardFX"].ToString() == "横向"
                        && bool.Parse(dr["hole"].ToString()) == true
                        && (dr["Code"].ToString().Contains("TTM") == false))
                    {
                        hBoardlist.Add(kj);
                    }
                    else if (dr["BoardFX"].ToString() == "竖向"
                    && bool.Parse(dr["hole"].ToString()) == true
                    && (dr["Code"].ToString().Contains("TTM") == false))
                    {
                        vBoardlist.Add(kj);
                    }
                    else if (dr["BoardFX"].ToString() == "横向"
                        && bool.Parse(dr["hole"].ToString()) == true
                        && (dr["Code"].ToString().Contains("TTM") == true))
                    {
                        hBoardlist_TTM.Add(kj);
                    }
                    else if (dr["BoardFX"].ToString() == "竖向"
                    && bool.Parse(dr["hole"].ToString()) == true
                    && (dr["Code"].ToString().Contains("TTM") == true))
                    {
                        vBoardlist_TTM.Add(kj);
                    }
                    else
                    {
                        otherboardlist.Add(kj);
                    }               
                }
            }
            List<KuModel> Allkjl = new List<KuModel>();
            //先判断横向板件
            addMsg("【"+DateTime.Now.ToString() + "】：开始判断横向板件孔位...");
            for (int i = 0; i < hBoardlist.Count; i++)
            {
                string str = getSHoleInfo(hBoardlist[i], vBoardlist);
                hBoardlist[i].newCode = hBoardlist[i].newCode + str;
                Allkjl.Add(hBoardlist[i]);
            }
            //榻榻米横向板件
            for (int i = 0; i < hBoardlist_TTM.Count; i++)
            {
                string str = getSHoleInfo_TTM(hBoardlist_TTM[i], vBoardlist_TTM);
                hBoardlist_TTM[i].newCode = hBoardlist_TTM[i].newCode + str;
                Allkjl.Add(hBoardlist_TTM[i]);
            }
            addMsg("【"+DateTime.Now.ToString() + "】：判断横向板件孔位完成!");
            //再判断竖向板件
            addMsg("【"+DateTime.Now.ToString() + "】：开始判断竖向板件孔位...");
            for (int i = 0; i < vBoardlist.Count; i++)
            {
                string str = "";
                str = getCHoleInfo(vBoardlist[i], hBoardlist);
                if (vBoardlist[i].modelNumber.Contains("SPL"))
                {
                    vBoardlist[i].holeStart = "";
                }
                else if (vBoardlist[i].modelNumber.Contains("SPR"))
                {
                    vBoardlist[i].holeStart = "";
                }
                //如果竖板有孔，往后调整竖板优先级
                if (str != "")
                {
                    vBoardlist[i].LevelSeq += 2;
                }
                vBoardlist[i].newCode = vBoardlist[i].newCode + str;
                Allkjl.Add(vBoardlist[i]);
            }
            //榻榻米竖向板件
            for (int i = 0; i < vBoardlist_TTM.Count; i++)
            {
                string str = "";
                str = getCHoleInfo_TTM(vBoardlist_TTM[i], hBoardlist_TTM);
                if (vBoardlist_TTM[i].modelNumber.Contains("SPL"))
                {
                    vBoardlist_TTM[i].holeStart = "";
                }
                else if (vBoardlist_TTM[i].modelNumber.Contains("SPR"))
                {
                    vBoardlist_TTM[i].holeStart = "";
                }
                //如果竖板有孔，往后调整竖板优先级
                if (str != "")
                {
                    vBoardlist_TTM[i].LevelSeq += 2;
                }
                vBoardlist_TTM[i].newCode = vBoardlist_TTM[i].newCode + str;
                Allkjl.Add(vBoardlist_TTM[i]);
            }
            addMsg("【"+DateTime.Now.ToString() + "】：判断竖向板件孔位完成!");

            Allkjl.AddRange(otherboardlist);
            return Allkjl;
        }
        //榻榻米横板孔位
        private string getSHoleInfo_TTM(KuModel board, List<KuModel> Clist)
        {

            //判断板件方向
            bool lk = false;
            bool rk = false;
            string holeinfo = "";
            double fx = board.holeFx;
            //判断横板是否有连接件
            List<KuModel> kszy = new List<KuModel>();
            List<KuModel> ksz = new List<KuModel>();
            List<KuModel> ksy = new List<KuModel>();

            kszy = Clist.Where(l => System.Math.Abs(board.caulModel.minY - l.caulModel.maxY) <= fx
                                || System.Math.Abs(board.caulModel.maxY - l.caulModel.minY) <= fx).ToList();
            for (int j = 0; j < Clist.Count; j++)
            {
                double ZPC = 10;
                double YPC = 10;
                if (board.caulModel.minY >= Clist[j].caulModel.maxY
                    || board.caulModel.maxY <= Clist[j].caulModel.minY
                    || board.absRotation.z != Clist[j].absRotation.z)
                {
                    continue;
                }
                ZPC = System.Math.Abs(board.caulModel.minX - Clist[j].caulModel.maxX);
                YPC = System.Math.Abs(board.caulModel.maxX - Clist[j].caulModel.minX);
                ksz = kszy.Where(l => System.Math.Abs(board.caulModel.minX - l.caulModel.minX) <= fx).ToList();
                ksy = kszy.Where(l => System.Math.Abs(board.caulModel.maxX - l.caulModel.maxX) <= fx).ToList();
                if (ZPC <= fx)
                {
                    if (ksz.Count > 0)
                    {
                        continue;
                    }
                    lk = true;
                }
                if (YPC <= fx)
                {
                    if (ksy.Count > 0)
                    {
                        continue;
                    }
                    rk = true;
                }

            }
            if(lk==true || rk==true)
            {
                board.holeStart = "_69";
            }
            if (lk == false && rk == false)
            {
                holeinfo = "";
            }
            else if (lk == true && rk == false)
            {
                holeinfo = "_L";
            }
            else if (lk == false && rk == true)
            {
                holeinfo = "_R";
            }
            else
            {
                return "_LR";
            }
            return holeinfo;
        }
        //榻榻米竖板孔位
        private string getCHoleInfo_TTM(KuModel board, List<KuModel> Clist)
        {
            //判断板件方向
            bool sk = false;
            bool xk = false;
            string holeinfo = "";
            double fx = board.holeFx;
            //获取顶底相连的板件
            List<KuModel> kssx = new List<KuModel>();
            kssx = Clist.Where(l => System.Math.Abs(l.caulModel.minX - board.caulModel.maxX) <= fx
                                || System.Math.Abs(l.caulModel.maxX - board.caulModel.minX) <= fx).ToList();
            //获取底部板件
            List<KuModel> ksx = new List<KuModel>();
            //获取顶部板件
            List<KuModel> kss = new List<KuModel>();
            for (int j=0;j<Clist.Count;j++)
            {
                double SPC = 10;
                double XPC = 10;
                if ((Clist[j].caulModel.maxY<= board.caulModel.maxY
                    && Clist[j].caulModel.minY >= board.caulModel.minY)
                    || board.absRotation.z != Clist[j].absRotation.z)
                {
                    continue;
                }
                SPC = System.Math.Abs(board.caulModel.maxY - Clist[j].caulModel.minY);
                XPC = System.Math.Abs(board.caulModel.minY - Clist[j].caulModel.maxY);
                kss = kssx.Where(l => System.Math.Abs(l.caulModel.maxY - board.caulModel.maxY) <= fx ).ToList();
                ksx = kssx.Where(l => System.Math.Abs(l.caulModel.minY - board.caulModel.minY) <= fx).ToList();
                if (SPC <= fx)
                {
                    if(kss.Count>0)
                    {
                        continue;
                    }
                    sk = true;
                }
                if (XPC <= fx)
                {
                    if (ksx.Count > 0)
                    {
                        continue;
                    }
                    xk = true;
                }

            }
            if (sk == true || xk == true)
            {
                board.holeStart = "_69";
            }
            if (sk == false && xk == false)
            {
                holeinfo = "";
                board.holeStart = "";
            }
            else if (sk == true && xk == false)
            {
                holeinfo = "_S";
            }
            else if (sk == false && xk == true)
            {
                holeinfo = "_X";
            }
            else
            {
                return "_SX";
            }
            return holeinfo;
        }
        private string getSHoleInfo(KuModel board, List<KuModel> Clist)
        {
            //判断板件方向
            bool lk = false;
            bool rk = false;
            //水平板与父项插入点差值
            double holeStart = 100;
            //横板与竖板插入点差值
            double holeStart1 = 100;
            double vholeStart = 100;
            string holeinfo = "";
            double Fangxiang = board.absRotation.z;
            double fx = 0;
            fx = board.holeFx;
            //获取Z轴方向支撑板件
            List<KuModel> kszy = new List<KuModel>();
            List<KuModel> ksz  = new List<KuModel>();
            List<KuModel> ksy  = new List<KuModel>();
            kszy = Clist.Where(l => System.Math.Abs(board.caulModel.minZ - l.caulModel.maxZ) <= fx
                                || System.Math.Abs(board.caulModel.maxZ - l.caulModel.minZ) <= fx).ToList();
            //孔位距边
            for (int j = 0; j < Clist.Count; j++)
            {
                double ZPC = 10;
                double YPC = 10;
                if (board.caulModel.maxZ <= Clist[j].caulModel.minZ
                    || board.caulModel.minZ >= Clist[j].caulModel.maxZ
                    || board.absRotation.z != Clist[j].absRotation.z)
                {
                    continue;
                }
                //获取横板上下方是否有板件连接
                    ZPC = System.Math.Abs(board.caulModel.minX - Clist[j].caulModel.maxX);
                    YPC = System.Math.Abs(board.caulModel.maxX - Clist[j].caulModel.minX);
                    ksz = kszy.Where(l => System.Math.Abs(board.caulModel.minX - l.caulModel.minX) <= fx).ToList();
                    ksy = kszy.Where(l => System.Math.Abs(board.caulModel.maxX - l.caulModel.maxX) <= fx).ToList();
                if (ZPC <= fx)
                {
                    if (ksz.Count > 0)
                    {
                        continue;
                    }
                    lk = true;
                }
                if (YPC <= fx)
                {
                    if (ksy.Count > 0)
                    {
                        continue;
                    }
                    rk = true;
                }
                //判断孔距
                if (lk == true || rk == true)
                {
                    if (board.orderType == 1)
                    {
                        holeStart = System.Math.Abs(board.absPosition.y - board.boxPostion.y);
                        double k = 0;
                        k = System.Math.Abs(board.absPosition.y - Clist[j].absPosition.y);
                        holeStart1 = holeStart1 >= k ? k : holeStart1;
                        vholeStart = System.Math.Abs(Clist[j].absPosition.y - Clist[j].boxPostion.y);
                        if (holeStart < 1)
                        {
                            if (holeStart1 < 1)
                            {
                                board.holeStart = "_69";
                            }
                            else
                            {
                                board.holeStart = "_39";
                            }
                        }
                        else
                        {
                            board.holeStart = "_39";
                        }
                        if (vholeStart < 1)
                        {
                            Clist[j].holeStart = "_69";
                        }
                    }
                    else 
                    {
                        board.holeStart = "_69";
                    }
                }
               
            }
            if (lk == false && rk == false)
            {
                holeinfo = "";
                board.holeStart = "";
            }
            else if (lk == true && rk == false)
            {
                holeinfo = "_L";
            }
            else if (lk == false && rk == true)
            {
                holeinfo = "_R";
            }
            else
            {
                return "_LR";
            }
            return holeinfo;
        }
        private string getCHoleInfo(KuModel board, List<KuModel> slist)
        {
            //判断板件方向           
            bool sk = false;
            bool xk = false;
            string holeinfo = "";
            double holeStart = 100;
            double Fangxiang = board.absRotation.z;
            double fx = 0;
            fx = board.holeFx;
            //竖向板件是否有顶底版
            //获取底部板件
            List<KuModel> ksx = new List<KuModel>();
            ksx = slist.Where(l => l.caulModel.minZ - board.caulModel.minZ <= 200
                                    && l.caulModel.minZ >= board.caulModel.minZ).ToList();
            //获取顶部板件
            List<KuModel> kss = new List<KuModel>();
            kss = slist.Where(l => System.Math.Abs(l.caulModel.maxZ - board.caulModel.maxZ) <= fx).ToList();
            //根据方向获取顶底版            
                kss = kss.Where(l => System.Math.Abs(l.caulModel.maxX - board.caulModel.minX) <= fx
                || System.Math.Abs(l.caulModel.minX - board.caulModel.maxX) <= fx).ToList();
                kss = kss.Where(l => l.modelName.Contains("顶板")).ToList();
                ksx = ksx.Where(l => System.Math.Abs(l.caulModel.maxX - board.caulModel.minX) <= fx
                 || System.Math.Abs(l.caulModel.minX - board.caulModel.maxX) <= fx).ToList();
                ksx = ksx.Where(l => l.modelName.Contains("底板")).ToList();

            for (int j = 0; j < slist.Count; j++)
            {
                double SPC = 10;
                double XPC = 10;
                if ((slist[j].caulModel.minZ >= board.caulModel.minZ
                    && slist[j].caulModel.maxZ <= board.caulModel.maxZ)
                     || board.absRotation.z != slist[j].absRotation.z)
                {
                    continue;
                }
                SPC = System.Math.Abs(board.caulModel.maxZ - slist[j].caulModel.minZ);
                XPC = System.Math.Abs(board.caulModel.minZ - slist[j].caulModel.maxZ);
                if (SPC <= fx)
                {
                    if (kss.Count > 0)
                    {
                        continue;
                    }
                    sk = true;
                }
                if (XPC <= fx)
                {
                    if (ksx.Count > 0)
                    {
                        continue;
                    }
                    xk = true;
                }
                if (sk == true || xk == true)
                {
                    if (board.orderType == 1)
                    {
                        holeStart = System.Math.Abs(board.absPosition.y - board.boxPostion.y);
                        if (holeStart < 1)
                        {
                            board.holeStart = "_69";
                        }
                        else
                        {
                            board.holeStart = "_39";
                        }
                    }
                    else
                    {
                        board.holeStart = "_69";
                    }
                }
               
            }
            if (sk == false && xk == false)
            {
                holeinfo = "";
                board.holeStart = "";
            }
            else if (sk == true && xk == false)
            {
                holeinfo = "_S";
            }
            else if (sk == false && xk == true)
            {
                holeinfo = "_X";
            }
            else
            {
                return "_SX";
            }
            return holeinfo;
        }
    }
}
