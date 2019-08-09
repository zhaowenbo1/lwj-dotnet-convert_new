using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public delegate void AddMsg(string msg);
    public delegate void jxjson(string str1, string str2, string str3);
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ApplicationInitbs application = new ApplicationInitbs();
            int i = application.Applicatbs();
            if (i == 0 || i < 0)
            {
                MessageBox.Show("应用程序已过期!!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                this.Text = "酷家乐解析_by 五竹" + "_有效期至" + DateTime.Now.AddDays(i).ToString("D");
            }
        }
        public static string _SavePath;
        string jsontxt;
        private void main_Load(object sender, EventArgs e)
        {
            Startjxbtn.BackColor = Color.Silver;
            string sql = "select * from Savepath where id=1";
            _SavePath = OleHeper.Query(sql).Tables[0].Rows[0][1].ToString();
            if (_SavePath.EndsWith(@"\") == false)
            {
                _SavePath = _SavePath + "\\";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logtxt.Clear();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "选取Json文件";
            fileDialog.Filter = "json文件|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filepathtxt.Text = fileDialog.FileName;
                proMsg(DateTime.Now.ToString() + ":开始读入Json文件...");
                jsontxt = File.ReadAllText(filepathtxt.Text, Encoding.UTF8);
                this.logtxt.Text = jsontxt;
                proMsg(DateTime.Now.ToString() + ":读入Json文件完成！");
                PorcessMsg.Clear();
                string fileName = fileDialog.SafeFileName;
                filepathtxt.ReadOnly = true;
                orderNotxt.Focus();
            }
        }
        private void CreateXmnbtn_Click(object sender, EventArgs e)
        {
            logtxt.Clear();
            CreateXML();
        }

        private void CreateXML()
        {
            List<KuModel> kJLobjects = new List<KuModel>();
            KuJsonReader createobj = new KuJsonReader();
            createobj.log = proMsg;
            createobj.errorlog = ErrMsg;
            string fileName = "";
            if (orderNotxt.Text.Length == 0)
            {
                fileName = Path.GetFileNameWithoutExtension(filepathtxt.Text);
            }
            else
            {
                fileName = orderNotxt.Text.Trim();
            }

            kJLobjects = createobj.readKujialeModels(jsontxt);
            int bxcnt = createobj.getBoxCount();
            ImosXmlWriter createImosXml = new ImosXmlWriter();
            createImosXml.addMsg = proMsg;
            createImosXml.ErrMsg = ErrMsg;
            createImosXml.CreateXml(kJLobjects, fileName, _SavePath);
        }


        private void orderNotxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateXML();
            }
        }
        private void proMsg(string str)
        {
            if (PorcessMsg.Text.Length > 0)
            {
                PorcessMsg.Text += "\r\n" + str;
            }
            else
            {
                PorcessMsg.Text += str;
            }
        }
        private void logMsg(string str)
        {
            if (logtxt.Text.Length > 0)
            {
                logtxt.Text += "\r\n" + str;
            }
            else
            {
                logtxt.Text += str;
            }
        }
        private void ErrMsg(string str)
        {
            if (Errortxt.Text.Length > 0)
            {
                Errortxt.Text += "\r\n" + str;
            }
            else
            {
                Errortxt.Text += str;
            }
        }
        string Orignpath;
        string Savepath;
        string bakpath;
        bool jccheak = false;
        private void Startjxbtn_Click(object sender, EventArgs e)
        {
            string Orignpath1 = "select * from SavePath where id=2";
            string Savepath1 = "select * from SavePath where id=1";
            string bakpath1 = "select * from SavePath where id=3";
            Orignpath = OleHeper.Query(Orignpath1).Tables[0].Rows[0][1].ToString();
            Savepath = OleHeper.Query(Savepath1).Tables[0].Rows[0][1].ToString();
            bakpath = OleHeper.Query(bakpath1).Tables[0].Rows[0][1].ToString();
            if (Orignpath.EndsWith(@"\") == false)
            {
                Orignpath = Orignpath + "\\";
            }
            if (Savepath.EndsWith(@"\") == false)
            {
                Savepath = Savepath + "\\";
            }
            if (bakpath.EndsWith("\\") == false)
            {
                bakpath = bakpath + "\\";
            }
            this.label3.Text = "监测路径:" + Orignpath;
            this.label4.Text = "输出路径:" + Savepath;
            Thread thread = new Thread(jx);
            thread.IsBackground = true;
            if (Startjxbtn.Text == "正在自动转化...")
            {
                Startjxbtn.Text = "开始监测";
                Startjxbtn.BackColor = Color.Silver;
                jccheak = false;
                thread.Start();
            }
            else
            {
                Startjxbtn.Text = "正在自动转化...";
                Startjxbtn.BackColor = Color.Red;
                jccheak = true;
                thread.Start();
            }

        }


        private void jx()
        {

            while (true)
            {
                if (jccheak == false)
                {
                    Startjxbtn.Text = "开始监测";
                    Startjxbtn.BackColor = Color.Silver;
                    return;
                }
                if (Directory.Exists(Orignpath) == false)
                {
                    MessageBox.Show("监视路径不存在！", "提示！！！",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Startjxbtn.Text = "开始监测";
                    Startjxbtn.BackColor = Color.Silver;
                    return;
                }
                DirectoryInfo folder = new DirectoryInfo(Orignpath);
                FileInfo[] files = folder.GetFiles("*.json");
                if (files.Length == 0)
                {
                    continue;
                }
                else
                {
                    System.Threading.Thread.Sleep(5000);
                }

                for (int i = 0; i < files.Length; i++)
                {
                    //解析
                    string fileName = Path.GetFileNameWithoutExtension(files[i].ToString());
                    jsontxt = File.ReadAllText(Orignpath + files[i].ToString(), Encoding.UTF8);
                    try
                    {
                        logtxt.Text += "开始解析：" + fileName + "  " + DateTime.Now.ToString() + "\r\n"; ;
                        AutoCreateXML(jsontxt, fileName, Savepath);
                        logtxt.Text += "解析成功：" + fileName + "  " + DateTime.Now.ToString() + "\r\n" + "\r\n";
                    }
                    catch
                    {
                        logtxt.Text += "解析失败：" + fileName + "  " + DateTime.Now.ToString() + "\r\n" + "\r\n";
                    }
                    //移动
                    string opath = Orignpath + files[i].ToString();
                    string bakpath1 = bakpath + files[i].ToString();
                    File.Delete(bakpath1);
                    FileInfo fi1 = new FileInfo(opath);
                    FileInfo fi2 = new FileInfo(bakpath1);
                    fi1.CopyTo(bakpath1);
                    File.Delete(opath);
                }

            }


        }

        private void AutoCreateXML(string json, string fileName, string OutPath)
        {
            List<KuModel> kJLobjects = new List<KuModel>();
            KuJsonReader createobj = new KuJsonReader();
            createobj.log = proMsg;
            createobj.errorlog = ErrMsg;
            kJLobjects = createobj.readKujialeModels(json);
            int boxcnt = createobj.getBoxCount();
            ImosXmlWriter createImosXml = new ImosXmlWriter();
            createImosXml.addMsg = proMsg;
            createImosXml.ErrMsg = ErrMsg;
            createImosXml.CreateXml(kJLobjects, fileName, OutPath);
        }


   
        //菜单栏
        private void ToolStrip1_Click(object sender, EventArgs e)
        {
            FrmBoardManger frm = new FrmBoardManger();
            frm.ShowDialog();
        }

        private void ToolStrip2_Click(object sender, EventArgs e)
        {
            FrmFilePath frm = new FrmFilePath();
            frm.ShowDialog();
        }

        private void ToolStrip3_Click(object sender, EventArgs e)
        {
            FrmSyspram frm = new FrmSyspram();
            frm.ShowDialog();
        }

        private void ToolStrip7_Click(object sender, EventArgs e)
        {
            Frmhelp frmhelp = new Frmhelp();
            string str = File.ReadAllText("DESP.txt", Encoding.UTF8);
            frmhelp.Text = "更新说明";
            frmhelp.richTextBox1.Text = str;
            frmhelp.richTextBox1.ReadOnly = true;
            frmhelp.ShowDialog();
        }

        private void ToolStrip8_Click(object sender, EventArgs e)
        {
            Frmhelp frmhelp = new Frmhelp();
            string str = File.ReadAllText("Hp.txt", Encoding.UTF8);
            frmhelp.Text = "功能说明";
            frmhelp.richTextBox1.Text = str;
            frmhelp.richTextBox1.ReadOnly = true;
            frmhelp.ShowDialog();

        }
    }
}
