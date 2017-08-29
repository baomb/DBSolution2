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
    public partial class FormFunctionsAdd : Form
    {
        public FormFunctionsAdd()
        {
            InitializeComponent();
        }

        public string FunctionParent
        {
            set
            {
                functionParent = value;
            }
            get
            {
                return functionParent;
            }
        }
        private string functionParent = string.Empty;

        public string FunctionID
        {
            set
            {
                functionID = value;
            }
            get
            {
                return functionID;
            }
        }
        private string functionID = string.Empty;

        public bool IsModify
        {
            set
            {
                isModify = value;
            }
            get
            {
                return isModify;
            }
        }
        private bool isModify = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            Sdl_Functions functions = new Sdl_Functions();
            functions.FUNCTIONNAME = tbFunctionName.Text;
            functions.FUNCTIONKEY = tbFunctionKey.Text;
            functions.FUNCTIONDESC = tbDescription.Text;
            functions.FUNCTIONPARENT = cmbFunctionParent.SelectedValue.ToString();
            if (isModify)
            {
                functions.FUNCTIONID= functionID;
                Sdl_FunctionsAdapter.UpdateSdl_Functions(functions);


            }
            else
            {
                functions.FUNCTIONID = Guid.NewGuid().ToString();
                Sdl_FunctionsAdapter.AddSdl_Functions(functions);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormFunctionsAdd_Load(object sender, EventArgs e)
        {
            DataTable dt = Sdl_FunctionsAdapter.GetSdl_FunctionsDataSet("").Tables[0];
            DataRow dr = dt.NewRow();
            dr["FunctionName"] = "所有功能";
            dr["FunctionID"] = "Root";
            dt.Rows.InsertAt(dr, 0);
            cmbFunctionParent.DisplayMember = "FunctionName";
            cmbFunctionParent.ValueMember = "FunctionID";
            cmbFunctionParent.DataSource = dt;
            cmbFunctionParent.SelectedValue = functionParent;

            if (isModify)
            {
                Sdl_Functions functions = Sdl_FunctionsAdapter.GetSdl_Functions(functionID);
                tbFunctionName.Text = functions.FUNCTIONNAME;
                tbFunctionKey.Text = functions.FUNCTIONKEY;
                tbDescription.Text = functions.FUNCTIONDESC;
            }
        }
    }
}
