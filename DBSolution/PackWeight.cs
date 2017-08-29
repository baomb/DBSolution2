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
    public partial class PackWeight : Form
    {
        public PackWeight()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            DataTable dt = Sdl_PackWeightAdapter.GetSdl_PackWeightDataSet("").Tables[0];
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
                    if (dt.Rows[i]["包重"] != null)
                    {
                        string temp = dt.Rows[i]["包重"].ToString();
                        temp = temp.Replace("。", ".").Replace(",", "").Replace(" ", "");
                        double weight = Convert.ToDouble(temp);
                        dt.Rows[i]["包重"] = weight.ToString();
                    }
                    else
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
            Sdl_PackWeightAdapter.DeleteSdl_PackWeight();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    Sdl_PackWeight pw = new Sdl_PackWeight();
                    pw.WEIGHT = dt.Rows[i]["包重"].ToString();
                    pw.PACKDESC = dt.Rows[i]["说明"].ToString();
                    pw.ORDERID = Int16.Parse(dt.Rows[i]["排序"].ToString());
                    Sdl_PackWeightAdapter.AddSdl_PackWeight(pw);
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
