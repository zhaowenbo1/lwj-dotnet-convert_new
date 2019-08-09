using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public partial class FrmPramAdd : Form
    {
        public Action ac = null;
        public FrmPramAdd()
        {
            InitializeComponent();
        }
        public List<int> Listid = null;
        private void FrmPramAdd_Load(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (Knametxt.Text.Trim().Length != 0 &&
                Inametxt.Text.Trim().Length != 0)
            {
                try
                {
                    int count = 0;
                    for (int i = 0; i < Listid.Count; i++)
                    {
                        string sql = "insert into Paramss(BoardId,Iname,Kname,Remark) values (";
                        sql = sql + Listid[i] + ",'" + Inametxt.Text.Trim() + "',";
                        sql = sql + "'" + Knametxt.Text.Trim() + "',";
                        sql = sql + "'" + remarktxt.Text.Trim() + "'" + ")";
                        count = count + OleHeper.ExecuteSql(sql);
                    }
                    if (count == Listid.Count)
                    {
                        MessageBox.Show("新增成功！", "提示！！！",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (checkBox1.Checked == true)
                        {
                            this.Close();
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("变量名未填写完整", "提示！！！",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPramAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            ac();
        }
    }
}
