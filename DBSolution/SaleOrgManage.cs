using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Utility;
using SdlDB.Entity;
using System.Collections.Specialized;
using SdlDB.Data;

namespace DBSolution
{
    public partial class SaleOrgManage : Form
    {
        public SaleOrgManage()
        {
            InitializeComponent();
            GetCompanyData();
            GetFactoryData();
            GetLgortData();
            GetSaleTypeData();
        }

        private void GetCompanyData()
        {
            dataCompany.AutoGenerateColumns = true;
            DataTable dt=Sdl_CompanyAdapter.GetSdl_CompanyDataSet("").Tables[0];
            dataCompany.DataSource =dt;

            DataTable dtCombox = new DataSetHelper().GetNewDataTable(dt, " 1=1 ", "");
            DataRow dr = dtCombox.NewRow();
            dr["bukrs"] = "";
            dr["butxt"] = "全部";
            dtCombox.Rows.Add(dr);
            comboBoxCompany.DisplayMember = "butxt";
            comboBoxCompany.ValueMember = "bukrs";
            comboBoxCompany.DataSource = dtCombox;
            comboBoxCompany.SelectedValue = "";
        }

        private void GetFactoryData()
        {
            dataFactory.AutoGenerateColumns = true;
            DataTable dt = Sdl_FactoryAdapter.GetSdl_FactoryDataSet("").Tables[0];
            dataFactory.DataSource = dt;

            DataTable dtCombox = new DataSetHelper().GetNewDataTable(dt, " 1=1 ", "");
            DataRow dr = dtCombox.NewRow();
            dr["werks"] = "";
            dr["name1"] = "全部";
            dtCombox.Rows.Add(dr);
            comboBoxFactory.DisplayMember = "name1";
            comboBoxFactory.ValueMember = "werks";
            comboBoxFactory.DataSource = dtCombox;
            comboBoxFactory.SelectedValue = "";
        }

        private void GetLgortData()
        {
            dataLgort.AutoGenerateColumns = true;
            dataLgort.DataSource = Sdl_WarehouseAdapter.GetSdl_WarehouseSet("").Tables[0];
        }

        private void GetSaleTypeData()
        {
            dataSaleType.AutoGenerateColumns = true;
            dataSaleType.DataSource = Sdl_Delivery_TypeAdapter.GetSdl_Delivery_TypeDataSet("").Tables[0];
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonUpdateOrg_Click(object sender, EventArgs e)
        {
            UpdateOrgData();
            MessageBox.Show("更新成功！");
        }

        private void UpdateOrgData()
        {
            try
            {
                //传参
                ListDictionary la = new ListDictionary();
                //Table
                ListDictionary lt = new ListDictionary();
                lt.Add("ZORG", "BUKRS,BUTXT,WERKS,NAME1,LGORT,LGOBE,VKORG,VTWEG,ZTEXT");
                //结果
                ListDictionary lr = new ListDictionary();

                //使用SAP通信
                DataTable dt = SAPHelper.InvokSAPFun("Z_SDL_ORGANIZATION", la, lt, ref lr).Tables[0];

                //公司信息
                DataTable dtCompany = new DataSetHelper().SelectDistinct("Company", dt, new string[] { "BUKRS", "BUTXT" });
                Sdl_Company company;
                foreach (DataRow row in dtCompany.Rows)//开始比对
                {
                    company = Sdl_CompanyAdapter.GetSdl_Company(row["BUKRS"].ToString());
                    if (company != null && company.BUKRS != string.Empty)
                    {
                        company.BUTXT = row["BUTXT"].ToString();
                        Sdl_CompanyAdapter.UpdateSdl_Company(company);
                    }
                    else
                    {
                        company = new Sdl_Company();
                        company.BUKRS = row["BUKRS"].ToString();
                        company.BUTXT = row["BUTXT"].ToString();
                        Sdl_CompanyAdapter.AddSdl_Company(company);
                    }
                }

                //工厂信息
                DataTable dtFactory = new DataSetHelper().SelectDistinct("factory", dt, new string[] { "BUKRS", "WERKS", "NAME1" });
                Sdl_Factory factory;
                foreach (DataRow row in dtFactory.Rows)//开始比对
                {
                    factory = Sdl_FactoryAdapter.GetSdl_Factory(row["WERKS"].ToString());
                    if (factory != null && factory.WERKS != string.Empty)
                    {
                        factory.BUKRS = row["BUKRS"].ToString();
                        factory.NAME1 = row["NAME1"].ToString();
                        Sdl_FactoryAdapter.UpdateSdl_Factory(factory);
                    }
                    else
                    {
                        factory = new Sdl_Factory();
                        factory.BUKRS = row["BUKRS"].ToString();
                        factory.NAME1 = row["NAME1"].ToString();
                        factory.WERKS = row["WERKS"].ToString();
                        Sdl_FactoryAdapter.AddSdl_Factory(factory);
                    }
                }

                //库存地
                DataTable dtHouse = new DataSetHelper().SelectDistinct("house", dt, new string[] { "BUKRS","WERKS", "LGORT", "LGOBE" });
                Sdl_Warehouse house;
                foreach (DataRow row in dtHouse.Rows)//开始比对
                {
                    house = Sdl_WarehouseAdapter.GetSdl_Warehouse(row["WERKS"].ToString(), row["LGORT"].ToString());
                    if (house != null && house.Werks != string.Empty)
                    {
                        house.Bukrs = row["BUKRS"].ToString();
                        house.Werks = row["WERKS"].ToString();
                        house.Lgort = row["LGORT"].ToString();
                        house.Lgobe = row["LGOBE"].ToString();
                        house.House_Keeper = string.Empty;
                        Sdl_WarehouseAdapter.UpdateSdl_Warehouse(house);
                    }
                    else
                    {
                        house = new Sdl_Warehouse();
                        house.Bukrs = row["BUKRS"].ToString();
                        house.Werks = row["WERKS"].ToString();
                        house.Lgort = row["LGORT"].ToString();
                        house.Lgobe = row["LGOBE"].ToString();
                        house.House_Keeper = string.Empty;
                        Sdl_WarehouseAdapter.AddSdl_Warehouse(house);
                    }
                }

                //销售组织分销渠道
                DataTable dtSalesOrg = new DataSetHelper().SelectDistinct("salesorg", dt, new string[] { "BUKRS", "VKORG", "VTWEG", "ZTEXT" });
                Sdl_Delivery_Type dType;
                foreach (DataRow row in dtSalesOrg.Rows)//开始比对
                {
                    dType = Sdl_Delivery_TypeAdapter.GetSdl_Delivery_Type(row["BUKRS"].ToString(), row["VKORG"].ToString(), row["VTWEG"].ToString());
                    if (dType != null && dType.BUKRS != string.Empty)
                    {
                        dType.BUKRS = row["BUKRS"].ToString();
                        dType.VKORG = row["VKORG"].ToString();
                        dType.VTWEG = row["VTWEG"].ToString();
                        dType.ZTEXT = row["ZTEXT"].ToString();
                        Sdl_Delivery_TypeAdapter.UpdateSdl_Delivery_Type(dType);
                    }
                    else
                    {
                        dType = new Sdl_Delivery_Type();
                        dType.BUKRS = row["BUKRS"].ToString();
                        dType.VKORG = row["VKORG"].ToString();
                        dType.VTWEG = row["VTWEG"].ToString();
                        dType.ZTEXT = row["ZTEXT"].ToString();
                        Sdl_Delivery_TypeAdapter.AddSdl_Delivery_Type(dType);
                    }
                }
            }
            catch
            {

            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string whereCondition = " where 1=1 ";

            if (txtLgortName.Text != "")
            {
                whereCondition += " and lgobe like '%" + txtLgortName.Text + "%'";
            }
            if (comboBoxFactory.SelectedValue.ToString() != "")
            {
                whereCondition += " and werks='" + comboBoxFactory.SelectedValue + "'";
            }
            dataLgort.AutoGenerateColumns = true;
            dataLgort.DataSource = Sdl_WarehouseAdapter.GetSdl_WarehouseSet(whereCondition).Tables[0];
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((dataFactory.CurrentRow != null) && (dataFactory.CurrentRow.Cells["WERKS"].Value != null))
            {
                Sdl_Factory factory = Sdl_FactoryAdapter.GetSdl_Factory(dataFactory.CurrentRow.Cells["WERKS"].Value.ToString());
                if (factory != null)
                {
                    factory.ZBUKRS = "2000";
                    factory.ZLGOBE = textBoxZlgobe.Text;
                    factory.ZLGORT=textBoxZlgort.Text;
                    factory.ZWERKS = "2004";
                    Sdl_FactoryAdapter.UpdateSdl_Factory(factory);
                    MessageBox.Show("修改成功！");
                }
            }
        }

        private void dataFactory_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((dataFactory.CurrentRow != null) && (dataFactory.CurrentRow.Cells["WERKS"].Value != null))
            {
                Sdl_Factory factory = Sdl_FactoryAdapter.GetSdl_Factory(dataFactory.CurrentRow.Cells["WERKS"].Value.ToString());
                if (factory != null)
                {
                    textBoxBukrs.Text = factory.BUKRS;
                    textBoxWerks.Text = factory.WERKS;
                    textBoxName1.Text = factory.NAME1;
                    textBoxZlgobe.Text = factory.ZLGOBE;
                    textBoxZlgort.Text = factory.ZLGORT;
                    textBoxZwerks.Text = factory.ZWERKS;
                }
            }
        }

        private void comboBoxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCompany.SelectedValue.ToString() != "")
            {
                DataTable dt = Sdl_FactoryAdapter.GetSdl_FactoryDataSet(" where bukrs='" + comboBoxCompany.SelectedValue + "'").Tables[0];
                DataRow dr = dt.NewRow();
                dr["werks"] = "";
                dr["name1"] = "全部";
                dt.Rows.Add(dr);
                comboBoxFactory.DisplayMember = "name1";
                comboBoxFactory.ValueMember = "werks";
                comboBoxFactory.DataSource = dt;
                comboBoxFactory.SelectedValue = "";
            }
        }

        
    }
}
