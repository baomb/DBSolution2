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
    public partial class DataHistoryDetail : Form
    {
        public DataHistoryDetail()
        {
            InitializeComponent();
        }

        public void ShowDialog(IWin32Window parent, string editTime, string tableName)
        {
            DataSet ds = Sdl_DataHistoryAdapter.GetSdl_DataHistoryDataSet("where editTime = '" + editTime + "' and tableName = '" + tableName + "'");
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("Type");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["InsertFlag"].ToString() == "True")
                {
                    dt.Rows[i]["Type"] = "添加";
                }
                else if (dt.Rows[i]["EditFlag"].ToString() == "True")
                {
                    dt.Rows[i]["Type"] = "修改";
                }
                else if (dt.Rows[i]["DeleteFlag"].ToString() == "True")
                {
                    dt.Rows[i]["Type"] = "删除";
                }

                string[] colFields = dt.Rows[i]["ColField"].ToString().Split(';');
                for (int j = 0; j <= colFields.GetUpperBound(0); j++)
                {
                    string colName = CompareModelHelper.GetFieldName(colFields[j]);
                    if (!dt.Columns.Contains(colName))
                    {
                        dt.Columns.Add(colName);
                    }
                    dt.Rows[i][colName] = dt.Rows[i]["col" + (j + 1)].ToString();
                }
            }
            dt.Columns.Remove("InsertFlag");
            dt.Columns.Remove("EditFlag");
            dt.Columns.Remove("DeleteFlag");
            dt.Columns.Remove("Time");
            dataGridViewDetail.DataSource = dt;
            this.ShowDialog(parent);
        }
    }
}
