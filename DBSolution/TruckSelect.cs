using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDB.Data;
using SdlDB.Utility;

namespace DBSolution
{
    public partial class TruckSelect : Form
    {
        private string[] child;
        private string flagShow;
        
        public TruckSelect(string[] father, string flag)
        {
            InitializeComponent();
            this.dataGridViewTruckSelect.DefaultCellStyle.Font = new Font("宋体", 15);
            this.child = father;
            flagShow = flag;
            switch (flagShow)
            {
                case "ProductSale":
                    BindProductSaleData();
                    break;
                case "RawMaterialReturn":
                    BindRawMaterialReturnData();
                    break;
                case "RawMaterialsProcurement":
                    BindRawMaterialsProcurementData();
                    break;
                case "RawMaterialsSale":
                    BindRawMaterialsSaleData();
                    break;
                case "FinishedProductsPresentation":
                    BindFinishedProductsPresentationData();
                    break;
                case "AccessoryProcurement":
                    BindAccessoryProcurementData();
                    break;
                case "AccessoryReturn":
                    BindAccessoryReturnData();
                    break;
                case "ProductReturnMerchant":
                    BindProductReturnMerchantData();
                    break;
                case "ProductReturnRailway":
                    BindProductReturnRailwayData();
                    break;
                case "AllotTransferIn":
                    BindAllotTransferInData();
                    break;
                case "AllotTransferOutAndIn":
                    BindAllotTransferOutAndIn();
                    break;
                case "AllotTransferOutToIn":
                    BindAllotTransferOutToIn();
                    break;
                case "AccessoryAllotTransferOut":
                    BindAccessoryAllotTransferOut();
                    break;
                case "AccessoryAllotTransferOutAndIn":
                    BindAccessoryAllotTransferOutAndIn();
                    break;
                case "AccessoryAllotTransferIn":
                    BindAccessoryAllotTransferIn();
                    break;
                case "FlotsamExit":
                    BindFlotsamExit();
                    break;
                case "ContractSale":
                    BindContractSales();
                    break;
                case "RawMaterialsContract":
                    BindRawMaterialsContract();
                    break;
                case "ProductExchange":
                    BindProductExchange();
                    break;
                case "ProductExchangeOut":
                    BindProductExchangeOut();
                    break;
            }
        }

        public TruckSelect(string[] father, string flag, string werks)
        {
            InitializeComponent();
            this.dataGridViewTruckSelect.DefaultCellStyle.Font = new Font("宋体", 15);
            this.child = father;
            flagShow = flag;
            switch (flagShow)
            {
                case "RawMaterialsSale":
                    BindRawMaterialsSaleData(werks);
                    break;

            }
        }

        private void BindFlotsamExit()
        {
            DataSet ds = sdl_FloatsamEnterAdapter.Getsdl_FloatsamEnterSetByFeild(new string[] { "TruckNum as 车牌号 ", "EnterTime as 时间 ", "EnterDBNum as 入厂地磅编号", "FloatsamName as 货物编码", "Buyer as 购买商", "Tare as 皮重" }, " where ExitFlag = 0 and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "时间" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindProductSaleData()
        {
            DataSet ds = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号 ", "TIMEFLAG as 时间 ", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and ( CONTRACT = '' or CONTRACT is NULL ) ");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "时间" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindRawMaterialReturnData()
        {
            DataSet ds = Sdl_RawMaterialReturnTitleAdapter.GetSdl_RawMaterialReturnTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号 ", "TIMEFLAG as 时间 ", "EBELN as 退货单 ", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "时间", "退货单" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindRawMaterialsProcurementData()
        {
            DataSet ds = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 采购订单", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and ( CONTRACT = '' or CONTRACT is NULL or CONTRACT = '2' ) ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindRawMaterialsSaleData()
        {
            DataSet ds = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 销售订单", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindRawMaterialsSaleData(string werksSr)
        {
            DataSet ds = Sdl_RawMaterialsSaleTitleAdapter.GetSdl_RawMaterialsSaleTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 销售订单", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + werksSr + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindFinishedProductsPresentationData()
        {
            DataSet ds = Sdl_FinishedProductsPresentationTitleAdapter.GetSdl_FinishedProductsPresentationTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "RSNUM as 预留号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAccessoryProcurementData()
        {
            DataSet ds = Sdl_AccessoryProcurementTitleAdapter.GetSdl_AccessoryProcurementTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 采购订单", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAccessoryReturnData()
        {
            DataSet ds = Sdl_AccessoryReturnTitleAdapter.GetSdl_AccessoryReturnTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 采购订单", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindProductReturnMerchantData()
        {
            DataSet ds = Sdl_ProductReturnMerchantAdapter.GetSdl_ProductReturnMerchantSetByFeild(new string[] { "TRUCKNUM as 车牌号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "进厂时间" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindProductReturnRailwayData()
        {
            DataSet ds = Sdl_ProductReturnRailwayAdapter.GetSdl_ProductReturnRailwaySetByFeild(new string[] { "TRUCKNUM as 车牌号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "进厂时间" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindAllotTransferInData()
        {
            DataSet ds = Sdl_AllotTitleAdapter.GetSdl_AllotTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 调拨单号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and RESWK='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAllotTransferOutAndIn()
        {
            DataSet ds = Sdl_AllotTitleAdapter.GetSdl_AllotTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 调拨单号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'S' and Allotflag='0' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAllotTransferOutToIn()
        {
            DataSet ds = Sdl_AllotInTitleAdapter.GetSdl_AllotInTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 调拨单号", "TIMEFLAG as 进厂时间", "OUTTIMEFLAG as 时间标识", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAccessoryAllotTransferOut()
        {
            DataSet ds = Sdl_AccessoryAllotOutTitleAdapter.GetSdl_AccessoryAllotOutTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 调拨单号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and RESWK='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAccessoryAllotTransferOutAndIn()
        {
            DataSet ds = Sdl_AccessoryAllotOutTitleAdapter.GetSdl_AccessoryAllotOutTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 调拨单号", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'S' and Allotflag='0' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindAccessoryAllotTransferIn()
        {
            DataSet ds = Sdl_AccessoryAllotInTitleAdapter.GetSdl_AccessoryAllotInTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号", "EBELN as 调拨单号", "TIMEFLAG as 进厂时间", "OUTTIMEFLAG as 时间标识", "DBNUM as 入厂地磅编号" }, " where HSFLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void BindContractSales()
        {
            DataSet ds = Sdl_FinishedProductsSaleTitleAdapter.GetSdl_FinishedProductsSaleTitleSetByFeild(new string[] { "TRUCKNUM as 车牌号 ", "TIMEFLAG as 时间 ", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and CONTRACT = '1' ");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "时间" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindRawMaterialsContract()
        {
            DataSet ds = Sdl_RawMaterialsProcurementTitleAdapter.GetSdl_RawMaterialsProcurementTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号", "VBELN as 采购订单", "TIMEFLAG as 进厂时间", "DBNUM as 入厂地磅编号" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "' and CONTRACT = '1' ");
            dataGridViewTruckSelect.DataSource = ds.Tables[0];
        }

        private void dataGridViewTruckSelect_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewTruckSelect.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请选择车牌号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i <= child.GetUpperBound(0); i++)
            {
                child[i] = dataGridViewTruckSelect.SelectedRows[0].Cells[i].Value.ToString();
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindProductExchange() {
            DataSet ds = Sdl_FinishedProductsExchangeInTitleAdapter.GetSdl_FinishedProductsExchangeInTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号 ", "TIMEFLAG as 时间 ", "OANUM as OA申请单" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS +"'");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "时间", "OA申请单" });
            dataGridViewTruckSelect.DataSource = dt;
        }

        private void BindProductExchangeOut()
        {
            DataSet ds = Sdl_FinishedProductsExchangeOutTitleAdapter.GetSdl_FinishedProductsExchangeOutTitleDataSetByField(new string[] { "TRUCKNUM as 车牌号 ", "TIMEFLAG as 时间 ", "OANUM as OA申请单" }, " where HS_FLAG = 'H' and WERKS='" + Sdl_SysSettingAdapter.LoadSdl_SysSetting().WERKS + "'");
            DataTable dt = new DataSetHelper().Distinct("newTb", ds.Tables[0], new string[] { "车牌号", "时间", "OA申请单" });
            dataGridViewTruckSelect.DataSource = dt;
        }
    }
}
