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
    public partial class FrmSyspram : Form
    {
        public FrmSyspram()
        {
            InitializeComponent();
        }

        private void FrmSyspram_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myDataSet.SysPram”中。您可以根据需要移动或删除它。
            this.sysPramTableAdapter.Fill(this.myDataSet.SysPram);
            xiugai.Caption = "编辑";
            sysgrid.ReadOnly = true;
            this.sysgrid.AllowUserToAddRows = false;
        }

        private void xiugai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xiugai.Caption = "正在编辑...";
            sysgrid.ReadOnly = false;
            this.sysgrid.AllowUserToAddRows = true;
        }

        private void save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sysgrid.EndEdit();
            this.sysPramBindingSource.EndEdit();
            if (this.myDataSet.GetChanges() == null)
            {
                return;
            }
            this.sysPramTableAdapter.Update(this.myDataSet);
            this.myDataSet.AcceptChanges();
            this.sysPramTableAdapter.Fill(this.myDataSet.SysPram);
            this.sysgrid.ReadOnly = true;
            this.sysgrid.AllowUserToAddRows = false;
            xiugai.Caption = "编辑";
            MessageBox.Show("保存成功！", "提示！！！",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
