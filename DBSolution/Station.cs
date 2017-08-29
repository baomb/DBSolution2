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
    public partial class Station : Form
    {
        public Station()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            DataTable dt = Sdl_StationAdapter.GetSdl_StationDataSet("","*").Tables[0];
            dataGridViewDetails.DataSource = dt;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataGridViewDetails.CurrentCell = dataGridViewDetails.Rows[0].Cells[0];
            DataTable dt = (DataTable)dataGridViewDetails.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    string temp = dt.Rows[i]["BUKRS"].ToString();
                    temp = temp.Replace("。", ".").Replace(",", "").Replace(" ", "");
                    temp = SdlDB.Utility.TypeConverter.ToDBC(temp);
                    int bukrs = Convert.ToInt16(temp);
                    dt.Rows[i]["BUKRS"] = bukrs.ToString();
                }
                catch
                {
                    MessageBox.Show(this, "公司代码应为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            Sdl_StationAdapter.DeleteSdl_Station();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    Sdl_Station s = new Sdl_Station();
                    s.BUKRS = dt.Rows[i]["BUKRS"].ToString();
                    s.CITY = dt.Rows[i]["CITY"].ToString();
                    s.STATION = dt.Rows[i]["STATION"].ToString();
                    s.STATIONDESC = dt.Rows[i]["STATIONDESC"].ToString();
                    Sdl_StationAdapter.AddSdl_Station(s);
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
                    DataTable dttemp = (DataTable)dataGridViewDetails.DataSource;
                    DataTable dt = new DataSetHelper().GetNewDataTable(dttemp, " 1=1 ", "");
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
