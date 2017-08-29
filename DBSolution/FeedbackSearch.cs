using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Entity;
using SdlDB.Data;

namespace DBSolution
{
    public partial class FeedbackSearch : Form
    {
        string condition = string.Empty;

        public FeedbackSearch()
        {
            InitializeComponent();
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            condition = " where 1=1 ";
            if (textBoxUsername.Text != string.Empty)
            {
                condition += " and username like '%" + textBoxUsername.Text + "%'";
            }
            if (textBoxTitle.Text != string.Empty)
            {
                condition += " and title like '%" + textBoxTitle.Text + "%'";
            }
            if (textBoxID.Text != string.Empty)
            {
                condition += " and id = " + textBoxID.Text;
            }
            if (comboBoxResolved.Text == "已解决")
            {
                condition += " and resolved = 1";
            }
            else if (comboBoxResolved.Text == "未解决")
            {
                condition += " and resolved = 0";
            }
            if (comboBoxResult.Text == "已关闭")
            {
                condition += " and result = 1";
            }
            else if (comboBoxResult.Text == "未关闭")
            {
                condition += " and result = 0";
            }
            if (TimePickerEnd.Text != string.Empty)
            {
                condition += " and datetime < '" + Common.AddOneDay(TimePickerEnd.Text) + "'";
            }
            SearchDataBind(condition);
        }

        private void SearchDataBind(string condition)
        {
            DataTable dt = Sdl_FeedbackAdapter.GetSdl_FeedbackDataSet(condition).Tables[0];
            dataGridViewComments.AutoGenerateColumns = false;
            dataGridViewComments.DataSource = dt;
        }

        private void dataGridViewDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            if (column == 0)
            {
                dataGridViewComments.Columns["SAVE"].Visible = true;
                dataGridViewComments.Columns["CANCEL"].Visible = true;
                dataGridViewComments.Columns["EDIT"].Visible = false;
                dataGridViewComments.Columns["RESPNAME"].Visible = false;
                dataGridViewComments.Columns["RESPTIME"].Visible = false;
                dataGridViewComments.Columns["RESPONSE"].ReadOnly = false;
                dataGridViewComments.Columns["RESOLVED"].ReadOnly = false;
                dataGridViewComments.Columns["RESULT"].ReadOnly = false;
                //dataGridViewComments.ReadOnly = false;
            }
            else if (column == 1)
            {
                dataGridViewComments.CurrentCell = dataGridViewComments.Rows[0].Cells[0];
                UpdateFeedback(row);
                dataGridViewComments.Columns["SAVE"].Visible = false;
                dataGridViewComments.Columns["CANCEL"].Visible = false;
                dataGridViewComments.Columns["EDIT"].Visible = true;
                dataGridViewComments.Columns["RESPNAME"].Visible = true;
                dataGridViewComments.Columns["RESPTIME"].Visible = true;
                dataGridViewComments.Columns["RESPONSE"].ReadOnly = true;
                dataGridViewComments.Columns["RESOLVED"].ReadOnly = true;
                dataGridViewComments.Columns["RESULT"].ReadOnly = true;
                //dataGridViewComments.ReadOnly = true;
                SearchDataBind(condition);
            }
            else if (column == 2)
            {
                dataGridViewComments.Columns["SAVE"].Visible = false;
                dataGridViewComments.Columns["CANCEL"].Visible = false;
                dataGridViewComments.Columns["EDIT"].Visible = true;
                dataGridViewComments.Columns["RESPNAME"].Visible = true;
                dataGridViewComments.Columns["RESPTIME"].Visible = true;
                dataGridViewComments.Columns["RESPONSE"].ReadOnly = true;
                dataGridViewComments.Columns["RESOLVED"].ReadOnly = true;
                dataGridViewComments.Columns["RESULT"].ReadOnly = true;
                //dataGridViewComments.ReadOnly = true;
                SearchDataBind(condition);
            }
        }

        private void UpdateFeedback(int row)
        {
            int id = Convert.ToInt32(dataGridViewComments.Rows[row].Cells["ID"].Value);
            Sdl_Feedback feedback = Sdl_FeedbackAdapter.GetSdl_Feedback(id);
            feedback.RESOLVED = Convert.ToBoolean(dataGridViewComments.Rows[row].Cells["RESOLVED"].Value);
            string name = feedback.RESPNAME + "," + System.Threading.Thread.CurrentPrincipal.Identity.Name.ToString();
            feedback.RESPNAME = name.TrimStart(',');
            feedback.RESPONSE = dataGridViewComments.Rows[row].Cells["RESPONSE"].Value.ToString();
            feedback.RESPTIME = DateTime.Parse(Common.GetServerDate());
            feedback.RESULT = Convert.ToBoolean(dataGridViewComments.Rows[row].Cells["RESULT"].Value);
            Sdl_FeedbackAdapter.UpdateSdl_Feedback(feedback);
        }

        private void toolStripButtonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
