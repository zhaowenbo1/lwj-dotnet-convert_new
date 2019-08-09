using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
                this.datetxt.Caption = "应用程序剩余使用时间：" + i.ToString() + "天";
            }

        }
        public  static string _SavePath;
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
            richprotxt.Clear();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "选取Json文件";
            fileDialog.Filter = "json文件|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filepathtxt.Text = fileDialog.FileName;
                proMsg(DateTime.Now.ToString() + ":开始读入Json文件...");
                jsontxt = File.ReadAllText(filepathtxt.Text, Encoding.UTF8);
                this.jsonRchtxt.Text = jsontxt;
                proMsg(DateTime.Now.ToString() + ":读入Json文件完成！");
                richprotxt.Clear();
                Errortxt.Clear();
                string fileName = fileDialog.SafeFileName;
                filepathtxt.Enabled = false;
                orderNotxt.Focus();
            }
        }

        private void boardbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBoardManger frm = new FrmBoardManger();
            frm.ShowDialog();
        }

        private void CreateXmnbtn_Click(object sender, EventArgs e)
        {

            WaitDialogForm wait = new WaitDialogForm();
            wait.Caption = "正在解析...";
            wait.Text = " ";
            richprotxt.Clear();
            CreateXML();
            wait.Close();
        }

        private void CreateXML()
        {
            List<KJLobject> kJLobjects = new List<KJLobject>();
            CreateKujialeObject createobj = new CreateKujialeObject();
            createobj.addMsg = proMsg;
            createobj.ErrMsg = ErrMsg;
            string fileName = "";          
            if (orderNotxt.Text.Length == 0)
            {
                fileName = Path.GetFileNameWithoutExtension(filepathtxt.Text);
            }
            else
            {
                fileName = orderNotxt.Text.Trim();
            }
            int bxcnt = 0;
            kJLobjects = createobj.GetKujialeObject(jsontxt,out bxcnt);
            CreateImosXml createImosXml = new CreateImosXml();
            createImosXml.addMsg = proMsg;
            createImosXml.ErrMsg = ErrMsg;
            createImosXml.CreateXml(kJLobjects, fileName, _SavePath,bxcnt);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string _path = dialog.SelectedPath;
                string sql = "update Savepath set savefilepath='" + _path + "' where id=3";
                if (OleHeper.ExecuteSql(sql) > 0)
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _SavePath = _path;
                }
            }
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
            if (richprotxt.Text.Length > 0)
            {
                richprotxt.Text += "\r\n" + str;
            }
            else
            {
                richprotxt.Text += str;
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
                if(Orignpath.EndsWith(@"\")==false)
                {
                    Orignpath= Orignpath + "\\";
                }
                if (Savepath.EndsWith(@"\") == false)
                {
                    Savepath = Savepath + "\\";
                }
                if (bakpath.EndsWith("\\") == false)
                {
                    bakpath = bakpath + "\\";
                }
                this.label3.Text ="监测路径:" +Orignpath;
                this.label4.Text ="输出路径:" + Savepath;
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
                    if(jccheak==false)
                    {
                    Startjxbtn.Text = "开始监测";
                    Startjxbtn.BackColor = Color.Silver;
                    return;
                    } 
                    if(Directory.Exists(Orignpath)==false)
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
                        jsonRchtxt.Text += "开始解析：" + fileName + "  " + DateTime.Now.ToString() +"\r\n"; ;
                        AutoCreateXML(jsontxt, fileName, Savepath);
                        jsonRchtxt.Text += "解析成功：" + fileName + "  " + DateTime.Now.ToString() + "\r\n";
                    }
                    catch
                    {
                        jsonRchtxt.Text += "解析失败：" + fileName + "  " + DateTime.Now.ToString() + "\r\n";
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
            List<KJLobject> kJLobjects = new List<KJLobject>();
            CreateKujialeObject createobj = new CreateKujialeObject();
            createobj.addMsg = proMsg;
            createobj.ErrMsg = ErrMsg;
            int boxcnt = 0;
            kJLobjects = createobj.GetKujialeObject(json,out boxcnt);
            CreateImosXml createImosXml = new CreateImosXml();
            createImosXml.addMsg = proMsg;
            createImosXml.ErrMsg = ErrMsg;
            createImosXml.CreateXml(kJLobjects, fileName, OutPath,boxcnt);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFilePath frm = new FrmFilePath();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSyspram frm = new FrmSyspram();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frmhelp frmhelp = new Frmhelp();
            string str = File.ReadAllText("DESP.txt", Encoding.UTF8);
            frmhelp.Text = "更新说明";
            frmhelp.richTextBox1.Text = str;
            frmhelp.richTextBox1.ReadOnly = true;
            frmhelp.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
