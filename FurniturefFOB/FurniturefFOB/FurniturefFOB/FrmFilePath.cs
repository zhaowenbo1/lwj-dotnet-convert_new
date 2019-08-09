using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public partial class FrmFilePath : Form
    {
        public FrmFilePath()
        {
            InitializeComponent();
        }


        //监测
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string _path = dialog.SelectedPath;
                jcpath.Text = _path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string _path = dialog.SelectedPath;
                expath.Text = _path;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string _path = dialog.SelectedPath;
                bkpath.Text = _path;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //保存
        private void button4_Click(object sender, EventArgs e)
        {
            if(System.IO.Directory.Exists(jcpath.Text)==false)
            {
                MessageBox.Show("监测路径不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (System.IO.Directory.Exists(expath.Text) == false)
            {
                MessageBox.Show("XML导出路径不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (System.IO.Directory.Exists(bkpath.Text) == false)
            {
                MessageBox.Show("Json备份路径不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqljc = "update Savepath set savefilepath='" + jcpath.Text + "' where id=2";
            string sqlsa = "update Savepath set savefilepath='" + expath.Text + "' where id=1";
            string sqlbk = "update Savepath set savefilepath='" + bkpath.Text + "' where id=3";
            try
            {
                OleHeper.ExecuteSql(sqljc);
                OleHeper.ExecuteSql(sqlsa);
                OleHeper.ExecuteSql(sqlbk);
                main._SavePath = expath.Text;
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(checkBox1.Checked==true)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmFilePath_Load(object sender, EventArgs e)
        {
            string sql = "select * from Savepath";
            DataTable dt = new DataTable();
            dt = OleHeper.Query(sql).Tables[0];
            jcpath.Text = dt.Rows[1][1].ToString();
            expath.Text = dt.Rows[0][1].ToString();
            bkpath.Text = dt.Rows[2][1].ToString();
            this.jcpath.Select(this.jcpath.TextLength, 0);


        }
    }
}
