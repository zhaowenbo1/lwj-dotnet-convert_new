using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static FurniturefFOB.myDataSet;

namespace FurniturefFOB
{
    public partial class FrmBoardManger : Form
    {
        public FrmBoardManger()
        {
            InitializeComponent();
        }
        
        private void FrmBoardManger_Load(object sender, EventArgs e)
        {
            this.parametersTableAdapter.Fill(this.myDataSet.Paramss);
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.boardgrid.ReadOnly = true;
            this.dgvpram.ReadOnly = true;
        }
        //条件查询
        private DataTable getBoaard(DataTable dt)
        {
            string str= this.textBox1.Text.Trim();
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            if(str.Length==0)
            {
                return dt;
            }
            else
            {
                foreach(DataRow dr in dt.Rows)
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
        private void boardaddbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.boardgrid.ReadOnly = false;
            this.dgvpram.ReadOnly = false;
            this.boardgrid.AllowUserToAddRows = true;
            this.dgvpram.AllowUserToAddRows = true;
            boardaddbtn.Caption = "正在编辑...";
        }
      
        //保存
        private void SaveData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            boardaddbtn.Caption = "修改";
            this.boardgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            boardgrid.AllowUserToDeleteRows = true;
            if (boardgrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("您确定要删除选中行吗？", "提示",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                {
                    return;
                }
            }
            foreach (DataGridViewRow ro in boardgrid.SelectedRows)
            {
                try
                {
                    boardgrid.Rows.Remove(ro);
                }
                catch
                {
                }
            }
            
            this.boardInfoTableAdapter.Update(this.myDataSet);
            this.myDataSet.AcceptChanges();
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.boardgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            boardaddbtn.Caption = "修改";
            boardgrid.ReadOnly = true;
            dgvpram.ReadOnly = true;
            this.boardgrid.AllowUserToAddRows = true;
            this.dgvpram.AllowUserToAddRows = true;
            this.boardInfoTableAdapter.Fill(this.myDataSet.BoardInfo);
            this.boardgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvpram_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<int> lst = new List<int>();
            foreach (DataGridViewRow dr in boardgrid.SelectedRows)
            {
              string strid=  dr.Cells[0].Value.ToString();
                lst.Add(int.Parse(strid));
            }
            FrmPramAdd frm = new FrmPramAdd();
            frm.Listid = lst;
            frm.ac = search;
            frm.ShowDialog();

          

        }
    }
}
