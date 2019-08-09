using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FurniturefFOB
{
    public partial class FrmBoardManger : Form
    {
        public FrmBoardManger()
        {
            InitializeComponent();
        }
        string filePath;
        private void FrmBoardManger_Load(object sender, EventArgs e)
        {
            filePath = System.IO.Directory.GetCurrentDirectory();
            filePath = filePath + "\\UserRemark";
            this.richTextBox1.Text = File.ReadAllText(filePath, Encoding.UTF8);
            this.parametersTableAdapter.Fill(this.myDataSet.Paramss);
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.boardgrid.ReadOnly = true;
            this.dgvpram.ReadOnly = true;
        }
        //条件查询
        private DataTable getBoaard(DataTable dt)
        {
            string str = this.textBox1.Text.Trim();
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            if (str.Length == 0)
            {
                return dt;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Code"].ToString().Contains(str) ||
                        dr["cname"].ToString().Contains(str))
                    {
                        newdt.Rows.Add(dr.ItemArray);
                    }
                }
                return newdt;
            }
        }


        //查询
        private void button1_Click(object sender, EventArgs e)
        {

            search();
        }
        private void search()
        {
            this.boardgrid.ReadOnly = true;
            this.dgvpram.ReadOnly = true;
            string str = string.Format("code like '%{0}%' or cname like  '%{1}%'",
                this.textBox1.Text.Trim(), this.textBox1.Text.Trim());
            this.boardInfoBindingSource.Filter = str;
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.boardgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.boardgrid.ReadOnly = false;
            this.dgvpram.ReadOnly = false;
            this.boardgrid.AllowUserToAddRows = true;
            this.dgvpram.AllowUserToAddRows = true;
            boardaddbtn.Text = "正在编辑...";
        }

        // 保存
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, this.richTextBox1.Text);
            boardgrid.EndEdit();
            dgvpram.EndEdit();
            this.boardInfoBindingSource.EndEdit();
            this.boardInfoparametersBindingSource.EndEdit();
            if (this.myDataSet.GetChanges() == null)
            {
                return;
            }
            this.boardInfoTableAdapter.Update(this.myDataSet);
            this.parametersTableAdapter.Update(this.myDataSet);
            this.myDataSet.AcceptChanges();
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.parametersTableAdapter.Fill(this.myDataSet.Paramss);
            this.boardgrid.ReadOnly = true;
            this.dgvpram.ReadOnly = true;
            this.boardgrid.AllowUserToAddRows = true;
            this.dgvpram.AllowUserToAddRows = true;
            boardaddbtn.Text = "修改";
            this.boardgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }
        //保存之前检查是否有相同的参数名

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            boardaddbtn.Text = "修改";
            boardgrid.ReadOnly = true;
            dgvpram.ReadOnly = true;
            this.boardgrid.AllowUserToAddRows = true;
            this.dgvpram.AllowUserToAddRows = true;
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.boardgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            List<int> lst = new List<int>();
            foreach (DataGridViewRow dr in boardgrid.SelectedRows)
            {
                string strid = dr.Cells[0].Value.ToString();
                lst.Add(int.Parse(strid));
            }
            FrmPramAdd frm = new FrmPramAdd();
            frm.Listid = lst;
            frm.ac = search;
            frm.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                search();
            }
        }

    }
}
