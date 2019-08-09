using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FurniturefFOB
{

    public class CreateImosXml
    {
        public AddMsg addMsg = null;
        public AddMsg ErrMsg = null;
        //创建XML
        public void CreateXml(List<KJLobject> Kobj, string FileName, string SavePath,int boxcnt)
        {
            string name = FileName;
            string Filepath = SavePath + FileName + ".xml";
            //获取配置对象           
            Kobj = getUserkbj(Kobj);
            //孔位判断进板顺序
            Kobj = getHoleInfo(Kobj);
            addMsg(DateTime.Now.ToString() + "：开始调整进板顺序...");
            //有孔板件
            List<KJLobject> list1 = new List<KJLobject>();
            list1 = Kobj.Where(l => l.LevelSeq < 6).ToList();
            list1 = list1.OrderBy(s => s.HoleGroup).ToList();
            //无孔板件
            List<KJLobject> list2 = new List<KJLobject>();
            list2 = Kobj.Where(l => l.LevelSeq >= 6).ToList();
            List<BoxList> boxLists = new List<BoxList>();

            List<KJLobject> EndList = new List<KJLobject>();
            //有孔板件顺序
            for(int i= 1; i<=boxcnt;i++)
            {
                List<KJLobject> tempList = new List<KJLobject>();
                tempList = list1.Where(l => l.HoleGroup==i.ToString()).ToList();
                tempList = tempList.OrderBy(s => s.LevelSeq).ToList();
                if (tempList.Count != 0)
                {
                    BoxList bxlist = new BoxList();
                    bxlist.boxlist = tempList;
                    bxlist.maxz = tempList[0].boxPostion.z;
                    boxLists.Add(bxlist);
                }
            }
            boxLists = boxLists.OrderByDescending(s => s.maxz).ToList();
            for(int i=0;i<boxLists.Count;i++)
            {
                EndList.AddRange(boxLists[i].boxlist);
            }
            EndList.AddRange(list2);
            addMsg(DateTime.Now.ToString() + "：调整进板顺序完成!");
            addMsg(DateTime.Now.ToString() + "：开始生成XML数据...");
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "GB2312", null);
            xmlDocument.AppendChild(newChild);
            XmlElement xmlElement = xmlDocument.CreateElement("XML");
            xmlElement.SetAttribute("Type", "ListBuilder");
            xmlDocument.AppendChild(xmlElement);
            XmlElement xmlElement2 = xmlDocument.CreateElement("Order");
            xmlElement2.SetAttribute("Basket", name);
            xmlElement2.SetAttribute("DispDate", DateTime.Now.ToString("dd.MM.yyyy"));
            xmlElement2.SetAttribute("No", name);
            xmlElement.AppendChild(xmlElement2);
            XmlElement xmlElement3 = xmlDocument.CreateElement("Head");
            xmlElement3.InnerXml = GetHeadStr();
            xmlElement2.AppendChild(xmlElement3);
            XmlElement xmlElement4 = xmlDocument.CreateElement("BuilderList");
            for (int i = 0; i < EndList.Count; i++)
            {
                XmlElement xmlElement5 = xmlDocument.CreateElement("Set");
                xmlElement5.SetAttribute("LineNo", string.Concat(i + 1));                
                string text = "";
                text = text + "<Pname>" + EndList[i].newCode + EndList[i].holeStart + "</Pname>";
                text = text + "<Count>1</Count>";
                text = text + "<PVarString>" + GetParmeteSts(EndList[i]) + "</PVarString>";

                text += "<ARTICLE_TEXT_INFO1></ARTICLE_TEXT_INFO1>";
                text += "<ARTICLE_TEXT_INFO2></ARTICLE_TEXT_INFO2>";
                text += "<ARTICLE_PRICE_INFO1></ARTICLE_PRICE_INFO1>";
                text += "<ARTICLE_PRICE_INFO2></ARTICLE_PRICE_INFO2>";
                text = text + "<PInsertion>"+ Math.Round(double.Parse(EndList[i].absP.x.ToString())).ToString() + ","
                                + Math.Round(double.Parse(EndList[i].absP.y.ToString())).ToString() + ","
                                + Math.Round(double.Parse(EndList[i].absP.z.ToString())).ToString() + "</PInsertion>";
                text = text + "<POrntation>" + EndList[i].absR.x.ToString() + ","
                                + EndList[i].absR.y.ToString() + "," + EndList[i].absR.z.ToString() + "</POrntation>";
                xmlElement5.InnerXml = text;
                xmlElement4.AppendChild(xmlElement5);
            }
            xmlElement2.AppendChild(xmlElement4);
            try
            {


                xmlDocument.Save(Filepath);
                addMsg(DateTime.Now.ToString() + "：生成XML数据源完成！");
            }
            catch (Exception e)
            {
                ErrMsg(DateTime.Now.ToString() + "：创建XML失败!" +
                    "错误信息为：" + e.ToString());
            }
        }
        //xml头部文件
        private string GetHeadStr()
        {
            string str = "";
            str += "<COMM>";
            str += "</COMM>";
            str += "<ARTICLENO>";
            str += "</ARTICLENO>";
            str += "<CUSTOMER>";
            str += "</CUSTOMER>";
            str += "<CLIENT>";
            str += "</CLIENT>";
            str += "<PROGRAM>";
            str += "</PROGRAM>";
            str += "<EMPLOYEE>";
            str += "</EMPLOYEE>";
            str += "<TEXT_LONG>";
            str += "</TEXT_LONG>";
            str += "<TEXT_SHORT>";
            str += "</TEXT_SHORT>";
            str += "<COLOUR1>";
            str += "</COLOUR1>";
            str += "<COLOUR2>";
            str += "</COLOUR2>";
            str += "<COLOUR3>";
            str += "</COLOUR3>";
            str += "<COLOUR4>";
            str += "</COLOUR4>";
            str += "<COLOUR5>";
            str += "</COLOUR5>";
            str += "<INFO1>";
            str += "</INFO1>";
            str += "<INFO2>";
            str += "</INFO2>";
            str += "<INFO3>";
            str += "</INFO3>";
            str += "<INFO4>";
            str += "</INFO4>";
            str += "<INFO5>";
            str += "</INFO5>";
            str += "<INFO6>";
            str += "</INFO6>";
            str += "<INFO7>";
            str += "</INFO7>";
            str += "<INFO8>";
            str += "</INFO8>";
            str += "<INFO9>";
            str += "</INFO9>";
            str += "<INFO10>";
            str += "</INFO10>";
            str += "<ADDRESS1>";
            str += "</ADDRESS1>";
            str += "<ADDRESS2>";
            str += "</ADDRESS2>";
            str += "<ADDRESS3>";
            str += "</ADDRESS3>";
            str += "<ADDRESS4>";
            str += "</ADDRESS4>";
            str += "<ADDRESS5>";
            str += "</ADDRESS5>";
            str += "<ADDRESS6>";
            str += "</ADDRESS6>";
            str += "<BILLING_ADDRESS1>";
            str += "</BILLING_ADDRESS1>";
            str += "<BILLING_ADDRESS2>";
            str += "</BILLING_ADDRESS2>";
            str += "<BILLING_ADDRESS3>";
            str += "</BILLING_ADDRESS3>";
            str += "<BILLING_ADDRESS4>";
            str += "</BILLING_ADDRESS4>";
            str += "<BILLING_ADDRESS5>";
            str += "</BILLING_ADDRESS5>";
            str += "<BILLING_ADDRESS6>";
            str += "</BILLING_ADDRESS6>";
            str += "<SHIPPING_ADDRESS1>";
            str += "</SHIPPING_ADDRESS1>";
            str += "<SHIPPING_ADDRESS2>";
            str += "</SHIPPING_ADDRESS2>";
            str += "<SHIPPING_ADDRESS3>";
            str += "</SHIPPING_ADDRESS3>";
            str += "<SHIPPING_ADDRESS4>";
            str += "</SHIPPING_ADDRESS4>";
            str += "<SHIPPING_ADDRESS5>";
            str += "</SHIPPING_ADDRESS5>";
            str += "<SHIPPING_ADDRESS6>";
            str += "</SHIPPING_ADDRESS6>";
            str += "<ORDER_PRICE_INFO1>";
            str += "</ORDER_PRICE_INFO1>";
            str += "<ORDER_PRICE_INFO2>";
            str += "</ORDER_PRICE_INFO2>";
            str += "<ORDER_PRICE_INFO3>";
            str += "</ORDER_PRICE_INFO3>";
            str += "<ORDER_PRICE_INFO4>";
            str += "</ORDER_PRICE_INFO4>";
            str += "<ORDER_PRICE_INFO5>";
            str += "</ORDER_PRICE_INFO5>";
            str += "<CUSTOM_INFO1>";
            str += "</CUSTOM_INFO1>";
            str += "<CUSTOM_INFO2>";
            str += "</CUSTOM_INFO2>";
            str += "<CUSTOM_INFO3>";
            str += "</CUSTOM_INFO3>";
            str += "<CUSTOM_INFO4>";
            str += "</CUSTOM_INFO4>";
            str += "<CUSTOM_INFO5>";
            str += "</CUSTOM_INFO5>";
            str += "<CUSTOM_INFO6>";
            str += "</CUSTOM_INFO6>";
            str += "<CUSTOM_INFO7>";
            str += "</CUSTOM_INFO7>";
            str += "<CUSTOM_INFO8>";
            str += "</CUSTOM_INFO8>";
            str += "<CUSTOM_INFO9>";
            str += "</CUSTOM_INFO9>";
            str += "<CUSTOM_INFO10>";
            return str + "</CUSTOM_INFO10>";
        }
        //配置对象
        private List<KJLobject> getUserkbj(List<KJLobject> kJ)
        {
            addMsg(DateTime.Now.ToString() + "：开始获取数据库配置信息");
            string sql = "select * from boardinfo";
            List<KJLobject> Klist = new List<KJLobject>();
            DataTable dt = new DataTable();
            dt = OleHeper.Query(sql).Tables[0];
            foreach (KJLobject k in kJ)
            {
                bool flag = false;
                //门板
                if (IsDoor(k) == true)
                {
                    List<KJLobject> lsObj = new List<KJLobject>();
                    List<KJLobject> LSXH = new List<KJLobject>();
                    lsObj = kJ.Where(l => l.parentid == k.parentid).ToList();
                    lsObj = lsObj.Where(l => l.modelTypeId == 2).ToList();
                    LSXH.AddRange(lsObj);
                    lsObj = kJ.Where(l => l.id == k.parentid).ToList();
                    lsObj = lsObj.Where(l => l.modelTypeId == 2).ToList();
                    LSXH.AddRange(lsObj);
                    lsObj = kJ.Where(l => l.parentid == k.id).ToList();
                    lsObj = lsObj.Where(l => l.modelTypeId == 2).ToList();
                    LSXH.AddRange(lsObj);
                    for (int i = 0; i < LSXH.Count; i++)
                    {
                        parameter parameter = new parameter();
                        parameter.parmName = "LSXH";
                        parameter.parmValue = LSXH[i].modelNumber;
                        k.parameters.Add(parameter);
                    }

                }
                foreach (DataRow dr in dt.Rows)
                {

                    try
                    {

                        if (k.modelNumber == dr["Code"].ToString())
                        {
                            k.LevelSeq = int.Parse(dr["LevelSeq"].ToString());
                            k.newCode = k.modelNumber;
                            string holeFx =dr["HoleFx"].ToString();
                            k.holeFx = holeFx == "" ? 0 : k.holeFx = double.Parse(holeFx);
                            Klist.Add(k);
                            flag = true;
                        }
                    }
                    catch (Exception e)
                    {
                        ErrMsg(DateTime.Now.ToString() + "：获取配置信息失败!" +
                    "错误信息为：" + e.ToString());
                    }
                }
                if (flag == false)
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
            addMsg(DateTime.Now.ToString() + "：获取数据库配置信息完成!");
            return Klist;
        }
        //判断是否是门板
        private bool IsDoor(KJLobject k)
        {
            bool Door = false;
            for (int i = 0; i < k.parameters.Count; i++)
            {
                if (k.parameters[i].parmName == "KMFX")
                {
                    Door = true;
                    return Door;
                }
            }
            return Door;
        }
        //变量
        private string GetParmeteSts(KJLobject kJ)
        {
            string str = "";
            string sql = "select * from Paramss p inner join boardinfo o";
            sql = sql + " on o.id=p.boardid where o.Code= '" + kJ.modelNumber + "'";
            List<KJLobject> Klist = new List<KJLobject>();
            DataTable dt = new DataTable();
            dt = OleHeper.Query(sql).Tables[0];
            string sqlsys = "select * from SysPram";
            DataTable dtsys = new DataTable();
            dtsys = OleHeper.Query(sqlsys).Tables[0];
            string orderTy;
            orderTy = kJ.OrderType == 1 ? "衣柜" : "橱柜";
            foreach (parameter parm in kJ.parameters)
            {

                foreach (DataRow drs in dtsys.Rows)
                {
                    if (parm.parmName == drs["Kname"].ToString() &&
                        drs["OrderType"].ToString() == orderTy)
                    {
                        str = str + drs["Iname"] + ":=" + parm.parmValue + "|";
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    string Kname = dr["Kname"].ToString();
                    if (parm.parmName == Kname)
                    {
                        str = str + dr["Iname"] + ":=" + parm.parmValue + "|";
                    }
                }

            }
            return str;
        }

        //判断孔
        //double fx = 0.2;
        private List<KJLobject> getHoleInfo(List<KJLobject> Kobj)
        {
            List<KJLobject> Hboardlist = new List<KJLobject>();//水平板
            List<KJLobject> Vboardlist = new List<KJLobject>();//垂直板
            List<KJLobject> Otherboardlist = new List<KJLobject>();//其他
            string sql = "select * from boardinfo";
            DataTable dt = new DataTable();
            dt = OleHeper.Query(sql).Tables[0];
            foreach (KJLobject kj in Kobj)
            {
                bool flag = false;
                foreach (DataRow dr in dt.Rows)
                {
                    if (kj.modelNumber == dr["Code"].ToString())
                    {
                        flag = true;
                        if (dr["BoardFX"].ToString() == "横向"
                        && bool.Parse(dr["hole"].ToString()) == true)
                        {
                            Hboardlist.Add(kj);
                        }
                        else if (dr["BoardFX"].ToString() == "竖向"
                        && bool.Parse(dr["hole"].ToString()) == true)
                        {
                            Vboardlist.Add(kj);
                        }
                        else
                        {
                            Otherboardlist.Add(kj);
                        }

                    }
                }
                if (flag == false)
                {
                    Otherboardlist.Add(kj);
                }

            }
            List<KJLobject> Allkjl = new List<KJLobject>();
            //先判断横向板件
            addMsg(DateTime.Now.ToString() + "：开始判断横向板件孔位...");
            for (int i = 0; i < Hboardlist.Count; i++)
            {
                string str = getSHoleInfo(Hboardlist[i], Vboardlist);
                Hboardlist[i].newCode = Hboardlist[i].newCode + str;
                Allkjl.Add(Hboardlist[i]);
            }
            addMsg(DateTime.Now.ToString() + "：判断横向板件孔位完成!");
            //再判断竖向板件
            addMsg(DateTime.Now.ToString() + "：开始判断竖向板件孔位...");
            for (int i = 0; i < Vboardlist.Count; i++)
            {
                string str = "";
                str = getCHoleInfo(Vboardlist[i], Hboardlist);
                if (Vboardlist[i].modelNumber.Contains("KSPL"))
                {
                    Vboardlist[i].holeStart = "";
                }
                else if (Vboardlist[i].modelNumber.Contains("KSPR"))
                {
                    Vboardlist[i].holeStart = "";
                }
                //如果竖板有孔，往后调整竖板优先级
                if (str != "")
                {
                    Vboardlist[i].LevelSeq += 2;
                }
                Vboardlist[i].newCode = Vboardlist[i].newCode + str;
                Allkjl.Add(Vboardlist[i]);
            }
            addMsg(DateTime.Now.ToString() + "：判断竖向板件孔位完成!");

            Allkjl.AddRange(Otherboardlist);
            return Allkjl;

        }
        private string getSHoleInfo(KJLobject board, List<KJLobject> Clist)
        {
            //判断板件方向
            bool lk = false;
            bool rk = false;
            double holeStart = 100;
            double holeStart1 = 100;
            double vholeStart = 100;
            string holeinfo = "";
            double Fangxiang = board.absR.z;
            double fx = 0;
            fx = board.holeFx;
            //获取Z轴方向是否有支撑板件
            List<KJLobject> kszy = new List<KJLobject>();
            List<KJLobject> ksz = new List<KJLobject>();
            List<KJLobject> ksy = new List<KJLobject>();
            kszy = Clist.Where(l => System.Math.Abs(board.caulModel.minZ - l.caulModel.maxZ) <= fx
                                ||  System.Math.Abs(board.caulModel.maxZ - l.caulModel.minZ) <= fx).ToList();
            //孔位距边
            for (int j = 0; j < Clist.Count; j++)
            {
                double ZPC = 10;
                double YPC = 10;
                if (board.caulModel.maxZ <= Clist[j].caulModel.minZ
                    || board.caulModel.minZ >= Clist[j].caulModel.maxZ)
                {
                    continue;
                }
                //获取横板上下方是否有板件连接
                if (Fangxiang == 0 || Fangxiang == 180)
                {
                    ZPC = System.Math.Abs(board.caulModel.minX - Clist[j].caulModel.maxX);
                    YPC = System.Math.Abs(board.caulModel.maxX - Clist[j].caulModel.minX);
                    ksz = kszy.Where(l => System.Math.Abs(board.caulModel.minX - l.caulModel.minX) <= fx).ToList();
                    ksy = kszy.Where(l => System.Math.Abs(board.caulModel.maxX - l.caulModel.maxX) <= fx).ToList();
                }
                else if (Fangxiang == -180)
                {
                    ZPC = System.Math.Abs(board.caulModel.maxX - Clist[j].caulModel.minX);
                    YPC = System.Math.Abs(board.caulModel.minX - Clist[j].caulModel.maxX);
                    ksz = kszy.Where(l => System.Math.Abs(board.caulModel.maxX - l.caulModel.maxX) <= fx).ToList();
                    ksy = kszy.Where(l => System.Math.Abs(board.caulModel.minX - l.caulModel.minX) <= fx).ToList();
                }
                else if (Fangxiang == 90)
                {
                    ZPC = System.Math.Abs(board.caulModel.minY - Clist[j].caulModel.maxY);
                    YPC = System.Math.Abs(board.caulModel.maxY - Clist[j].caulModel.minY);
                    ksz = kszy.Where(l => System.Math.Abs(board.caulModel.minY - l.caulModel.minY) <= fx).ToList();
                    ksy = kszy.Where(l => System.Math.Abs(board.caulModel.maxY - l.caulModel.maxY) <= fx).ToList();
                }
                else if (Fangxiang == -90)
                {
                    ZPC = System.Math.Abs(board.caulModel.maxY - Clist[j].caulModel.minY);
                    YPC = System.Math.Abs(board.caulModel.minY - Clist[j].caulModel.maxY);
                    ksz = kszy.Where(l => System.Math.Abs(board.caulModel.maxY - l.caulModel.maxY) <= fx).ToList();
                    ksy = kszy.Where(l => System.Math.Abs(board.caulModel.minY - l.caulModel.minY) <= fx).ToList();
                }


                if (ZPC <= fx)
                {
                    //if (Clist[j].modelName.Contains("右侧"))
                    //{
                    //    continue;
                    //}
                    if(ksz.Count>0)
                    {
                        continue;
                    }
                    lk = true;
                }
                if (YPC <= fx)
                {
                    //if (Clist[j].modelName.Contains("左侧"))
                    //{
                    //    continue;
                    //}
                    if (ksy.Count > 0)
                    {
                        continue;
                    }
                    rk = true;
                }
                //判断孔距
                if (lk == true || rk == true)
                {
                    if (board.OrderType == 1)
                    {
                        if (Fangxiang == 0 || Fangxiang == 180 || Fangxiang == -180)
                        {
                            holeStart = System.Math.Abs(board.absP.y - board.boxPostion.y);
                            double k=0;
                            k = System.Math.Abs(board.absP.y - Clist[j].absP.y);
                            holeStart1 = holeStart1 >= k ? k : holeStart1;
                            vholeStart = System.Math.Abs(Clist[j].absP.y - Clist[j].boxPostion.y);
                        }
                        else
                        {
                            holeStart = System.Math.Abs(board.absP.x - board.boxPostion.x);
                            double k = 0;
                            k = System.Math.Abs(board.absP.x - Clist[j].absP.x);
                            holeStart1 = holeStart1 >= k ? k : holeStart1;
                        }
                        if (holeStart < 1)
                        {
                            if(holeStart1<1)
                            {
                                board.holeStart = "_69";
                            }
                            else
                            {
                                board.holeStart = "_39";
                            }

                            //board.holeStart = "_69";
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
                    if (board.OrderType == 2)
                    {
                        if (Clist[j].holeStart != "_69")
                        {
                            Clist[j].holeStart = "_39";
                        }
                    }
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
        }
      
            return holeinfo;
    }
        private string getCHoleInfo(KJLobject board, List<KJLobject> slist)
        {
            //判断板件方向           
            bool sk = false;
            bool xk = false;
            string holeinfo = "";
            double holeStart = -19;
            double Fangxiang = board.absR.z;
            double fx = 0;
            fx = board.holeFx;
            //竖向板件是否有顶底版
            //获取底部板件
            List<KJLobject> ksx = new List<KJLobject>();
            ksx = slist.Where(l => l.caulModel.minZ - board.caulModel.minZ<=200
                                    && l.caulModel.minZ >= board.caulModel.minZ).ToList();
            //获取顶部板件
            List<KJLobject> kss = new List<KJLobject>();
            kss = slist.Where(l => System.Math.Abs(l.caulModel.maxZ -board.caulModel.maxZ)<=fx).ToList();
            //根据方向获取顶底版            
            if (Fangxiang == 0 || Fangxiang == 180 || Fangxiang == -180)
            {
                kss = kss.Where(l => System.Math.Abs(l.caulModel.maxX - board.caulModel.minX) <= fx
                || System.Math.Abs(l.caulModel.minX - board.caulModel.maxX) <= fx ).ToList();
                kss = kss.Where(l => l.modelName.Contains("顶板")).ToList();
                ksx = ksx.Where(l => System.Math.Abs(l.caulModel.maxX - board.caulModel.minX) <= fx
                 || System.Math.Abs(l.caulModel.minX - board.caulModel.maxX) <= fx ).ToList();
                ksx = ksx.Where(l => l.modelName.Contains("底板")).ToList();
            }
            else if (Fangxiang == 90 || Fangxiang == -90)
            {
                kss = kss.Where(l => System.Math.Abs(l.caulModel.maxY - board.caulModel.minY) <= fx
                        || System.Math.Abs(l.caulModel.minY - board.caulModel.maxY) <= fx).ToList();
                kss = kss.Where(l => l.modelName.Contains("顶板")).ToList();
                ksx = ksx.Where(l => System.Math.Abs(l.caulModel.maxY - board.caulModel.minY) <= fx
                        || System.Math.Abs(l.caulModel.minY - board.caulModel.maxY) <= fx).ToList();
                ksx = ksx.Where(l => l.modelName.Contains("底板")).ToList();
            }
            for (int j = 0; j < slist.Count; j++)
            {
                double SPC = 10;
                double XPC = 10;
                if ((slist[j].caulModel.minZ >= board.caulModel.minZ
                    && slist[j].caulModel.maxZ <= board.caulModel.maxZ ))
                {
                    continue;
                }
 
                SPC = System.Math.Abs(board.caulModel.maxZ - slist[j].caulModel.minZ);
                XPC = System.Math.Abs(board.caulModel.minZ - slist[j].caulModel.maxZ);
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
                if(sk==true || xk==true)
                {
                    if (board.OrderType == 1)
                    {
                        if (Fangxiang == 0 || Fangxiang == 180 || Fangxiang == -180)
                        {
                            holeStart = System.Math.Abs(board.absP.y - board.boxPostion.y);
                        }
                        else
                        {
                            holeStart = System.Math.Abs(board.absP.x - board.boxPostion.x);
                        }
                        if (holeStart < 1)
                        {
                            board.holeStart = "_69";
                        }
                        else
                        {
                            board.holeStart = "_39";
                        }
                    }
                }

                if (sk == false && xk == false)
                {
                    holeinfo = "";
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
            }
            return holeinfo;

        }

    }


}
