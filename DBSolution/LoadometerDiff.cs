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
using SdlDB.Utility;

namespace DBSolution
{
    public partial class LoadometerDiff : Form
    {
        public LoadometerDiff()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            DataTable dt = Sdl_LoadometerDiffAdapter.GetSdl_LoadometerDiffDataSet("").Tables[0];
            dataGridViewDetails.DataSource = dt;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataGridViewDetails.CurrentCell = null;
            DataTable dttemp = (DataTable)dataGridViewDetails.DataSource;
            DataTable dt = new DataSetHelper().GetNewDataTable(dttemp, " 1=1 ", "");
            Sdl_LoadometerDiffAdapter.DeleteSdl_LoadometerDiff();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    Sdl_LoadometerDiff s = new Sdl_LoadometerDiff();
                    s.ID = dt.Rows[i]["ID"].ToString();
                    s.WERKS = dt.Rows[i]["WERKS"].ToString();
                    s.DESC = dt.Rows[i]["DESCRIPTION"].ToString();
                    s.DIFF = dt.Rows[i]["DIFF"].ToString();
                    Sdl_LoadometerDiffAdapter.AddSdl_LoadometerDiff(s);
                }
                catch
                {
                }
            }
            MessageBox.Show(this, "保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void dataGridViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            if (column == 0)
            {
                try
                {
                    DataTable dt = (DataTable)dataGridViewDetails.DataSource;
                    dt.Rows[row].Delete();
                    dataGridViewDetails.DataSource = dt;
                }
                catch
                {
                }
            }
        }
    }
}
