using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Utility;
using SdlDB.Entity;

namespace DBSolution
{
    public partial class StorageType : Form
    {
        public StorageType()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            DataTable dt = Sdl_StorageTypeAdapter.GetSdl_StorageTypeDataSet("").Tables[0];
            dataGridViewDetails.AutoGenerateColumns = false;
            dataGridViewDetails.DataSource = dt;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewDetails.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    if (dt.Rows[i]["TYPENAME"] == null)
                    {
                        dt.Rows[i].Delete();
                        i--;
                    }
                }
                catch
                {
                    //MessageBox.Show(this, "包重应为整数", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            Sdl_StorageTypeAdapter.DeleteSdl_StorageType();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    Sdl_StorageType st = new Sdl_StorageType();
                    st.TYPEID = int.Parse(dt.Rows[i]["TYPEID"].ToString());
                    st.TYPENAME = dt.Rows[i]["TYPENAME"].ToString();
                    st.TYPEDESC = dt.Rows[i]["TYPEDESC"].ToString();
                    Sdl_StorageTypeAdapter.AddSdl_StorageType(st);
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
            dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
            if (column == 0)
            {
                try
                {
                    DataTable dttemp = (DataTable)dataGridViewDetails.DataSource;
                    DataTable dt = new DataSetHelper().GetNewDataTable(dttemp, " 1=1 ", "");
                    dt.Rows[row].Delete();
                    dataGridViewDetails.AutoGenerateColumns = false;
                    dataGridViewDetails.DataSource = dt;
                }
                catch
                {
                }
            }
        }
    }
}
