using System;
using System.Data;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Entity;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class TrayWeight : Form
    {
        public TrayWeight()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            DataTable dt = Sdl_SweightAdapter.GetSdl_SweightDataSet("").Tables[0];
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
                    if (dt.Rows[i]["SWEIGHT"] != null)
                    {
                        string temp = dt.Rows[i]["SWEIGHT"].ToString();
                        temp = temp.Replace("。", ".").Replace(",", "").Replace(" ", "");
                        double weight = Convert.ToDouble(temp);
                        dt.Rows[i]["SWEIGHT"] = weight.ToString();
                    }
                    else
                    {
                        dt.Rows[i].Delete();
                        i--;
                    }
                }
                catch
                {
                    return;
                }
            }
            Sdl_SweightAdapter.DeleteAllSdl_Sweight();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    Sdl_Sweight sw = new Sdl_Sweight();
                    sw.SWEIGHT = dt.Rows[i]["SWEIGHT"].ToString();
                    sw.STEXT = dt.Rows[i]["STEXT"].ToString();
                    //sw.ID = dt.Rows[i]["ID"].ToString();
                    Sdl_SweightAdapter.AddSdl_Sweight(sw);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
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
