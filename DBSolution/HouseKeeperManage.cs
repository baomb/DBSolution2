using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;

namespace DBSolution
{
    public partial class HouseKeeperManage : Form
    {
        private int rowsNum=0;
        public HouseKeeperManage()
        {
            InitializeComponent();
            InitDataBind();
        }

        private void InitDataBind()
        {
            DataTable dt = Sdl_WarehouseAdapter.GetSdl_WarehouseSet("").Tables[0];
            dataGridViewLgort.DataSource = dt;
            dataGridViewLgort.AutoGenerateColumns = false;
            rowsNum = dt.Rows.Count;
        }

        private void dataGridViewLgort_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridViewLgort.Rows.Count < rowsNum)
            //{
            //    return;
            //}
            //string werks = dataGridViewLgort.CurrentRow.Cells["werks"].ToString();
            //string lgort = dataGridViewLgort.CurrentRow.Cells["lgort"].ToString();
            //Sdl_Warehouse model = Sdl_WarehouseAdapter.GetSdl_Warehouse(werks, lgort);
            //if (model != null)
            //{
            //    model.House_Keeper = dataGridViewLgort.CurrentRow.Cells["house_keeper"].ToString();
            //}
            //Sdl_WarehouseAdapter.UpdateSdl_Warehouse(model);

            //MessageBox.Show("保存成功！");
        }

       
    }
}
