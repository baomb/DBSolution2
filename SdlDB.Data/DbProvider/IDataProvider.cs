using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SdlDB.Entity;

namespace SdlDB.Data
{
    public interface IDataProvider
    {
        #region DemoTable

        DataSet GetDemoTableDataSet(string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsDemoTable(int id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddDemoTable(DemoTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateDemoTable(DemoTable model);

        int AmendDemoTable(int id, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteDemoTable(int id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DemoTable GetDemoTable(int id);

        DemoTable GetDemoTableByID(int id);

        List<DemoTable> GetDemoTableList(System.Data.DataTable table);

        #endregion

        #region sdl_FloatsamEnter

        DataSet Getsdl_FloatsamEnterSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Addsdl_FloatsamEnter(sdl_FloatsamEnter model);

        int GetMaxSortNum(string TimeFlag);

        sdl_FloatsamEnter Getsdl_FloatsamEnter(string truckNum, string timeFlag);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Updatesdl_FloatsamEnter(sdl_FloatsamEnter model);

        int Getsdl_FloatsamEnterExitFlag(string trucknum);

        /// <summary>
        /// 增加一条数据
        /// </summary>

        DataSet Getsdl_FloatsamEnterPageData(string pageNum, int PageSize, string where);

        DataSet Getsdl_FlotsamDetailSearchSet(string where);

        int Getsdl_FlotsamEnterCount(string where);

        DataSet Getsdl_FloatsamEnterData(string where);

        #endregion

        #region Sdl_FloatsamNameItem

        DataSet GetSdl_FloatsamNameItemDataSet(string where);

        bool ExistsFloatsamNameItem(string code);

        bool AddFloatsamNameItem(sdl_FloatsamNameItem model);

        sdl_FloatsamNameItem Getsdl_FloatsamNameItem(string code);

        void Updatesdl_FloatsamNameItem(sdl_FloatsamNameItem model);

        void Deletesdl_FloatsamNameItem(string ID);

        #endregion

        #region Sdl_SysSetting

        Sdl_SysSetting LoadSdl_SysSetting();

        bool SaveSdl_SysSetting(Sdl_SysSetting model);

        Sdl_SysSetting GetSdl_SysSetting(string model);

        DataTable GetSdl_SysSettingDataTable();

        bool GetSdl_Tray(string WERKS);

        bool ExistsSdl_Tray(string WERKS);

        void SaveSdl_Tray(string WERKS, string TRAYFLAG);

        void AddSdl_Tray(string WERKS, string TRAYFLAG);

        #endregion

        #region SQLServerHelper

        string GetContent(string table, string code, string content, string codevalue);

        object ExecuteSql(string sql);

        int GetMaxID(string fieldName, string tableName);

        #endregion

        #region sdl_WareHouse

        DataSet GetSdl_WarehouseSet(string where);


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_Warehouse(string werks, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_Warehouse(Sdl_Warehouse model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_Warehouse(Sdl_Warehouse model);

        int AmendSdl_Warehouse(string id, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_Warehouse(string werks, string lgort);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_Warehouse GetSdl_Warehouse(string werks, string lgort);


        List<Sdl_Warehouse> GetSdl_WarehouseList(System.Data.DataTable table);

        #endregion

        #region Sdl_Company

        DataSet GetSdl_CompanyDataSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_Company(string bukrs);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_Company(Sdl_Company model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_Company(Sdl_Company model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_Company(string bukrs);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_Company GetSdl_Company(string bukrs);

        #endregion

        #region Sdl_Factory

        DataSet GetSdl_FactoryDataSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_Factory(string werks);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_Factory(Sdl_Factory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_Factory(Sdl_Factory model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_Factory(string werks);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_Factory GetSdl_Factory(string werks);

        #endregion

        #region Sdl_Delivery_Type

        DataSet GetSdl_Delivery_TypeDataSet(string where);


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_Delivery_Type(string bukrs, string vkorg, string vtweg);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_Delivery_Type(Sdl_Delivery_Type model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_Delivery_Type(Sdl_Delivery_Type model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_Delivery_Type(string bukrs, string vkorg, string vtweg);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_Delivery_Type GetSdl_Delivery_Type(string bukrs, string vkorg, string vtweg);

        #endregion

        #region Sdl_FinishedProductsSale

        DataSet GetSdl_FinishedProductsSaleSet(string where);

        DataSet GetSdl_FinishedProductsSaleSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_FinishedProductsSale(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_FinishedProductsSale(Sdl_FinishedProductsSale model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model);

        void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model, Sdl_FinishedProductsSale oldModel);

        void UpdateSdl_FinishedProductsSale(Sdl_FinishedProductsSale model, string vbeln, string lgort, string posnr);

        int AmendSdl_FinishedProductsSale(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_FinishedProductsSale(string timeFlag, string vbeln);

        void DeleteSdl_FinishedProductsSale(string timeFlag, string vbeln, string lgort, string posnr);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_FinishedProductsSale GetSdl_FinishedProductsSale(string timeFlag, string vbeln);

        Sdl_FinishedProductsSale GetSdl_FinishedProductsSale(string timeFlag, string vbeln, string posnr, string lgort);

        List<Sdl_FinishedProductsSale> GetSdl_FinishedProductsSaleList(System.Data.DataTable table);

        #endregion

        #region Sdl_FinishedProductsSaleTitle

        DataSet GetSdl_FinishedProductsSaleTitleSet(string where);

        DataSet GetSdl_FinishedProductsSaleTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_FinishedProductsSaleTitleExcelData(string where);

        DataSet GetSdl_FinishedProductsSaleTitleSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model);

        void UpdateSdl_FinishedProductsSaleTitle(Sdl_FinishedProductsSaleTitle model, string vbeln, string trucknum);

        void UpdateSdl_FinishedProductsSaleTitle_S(Sdl_FinishedProductsSaleTitle model);

        int AmendSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_FinishedProductsSaleTitle(string timeFlag, string vbeln);

        void DeleteSdl_FinishedProductsSaleTitle(string truckNum, string timeFlag, string vbeln);

        Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string truckNum, string timeFlag);

        Sdl_FinishedProductsSaleTitle GetSdl_FinishedProductsSaleTitle(string truckNum, string vbeln, string timeFlag);

        DataTable GetSdl_FinishedProductsSaleTitleDataTable(string truckNum, string timeFlag);

        List<Sdl_FinishedProductsSaleTitle> GetSdl_FinishedProductsSaleTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_RawMaterialReturnTitle

        DataSet GetSdl_RawMaterialReturnTitleSet(string where);


        DataSet GetSdl_RawMaterialReturnTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_RawMaterialReturnTitleSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_RawMaterialReturnTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model);

        void UpdateSdl_RawMaterialReturnTitle(Sdl_RawMaterialReturnTitle model, string ebeln, string truckNum);

        void UpdateSdl_RawMaterialReturnTitleByTimeFlag(Sdl_RawMaterialReturnTitle model);

        int AmendSdl_RawMaterialReturnTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_RawMaterialReturnTitle(string timeFlag, string vbeln);

        void DeleteSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string truckNum);

        Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string truckNum, string timeFlag);

        Sdl_RawMaterialReturnTitle GetSdl_RawMaterialReturnTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_RawMaterialReturnTitle> GetSdl_RawMaterialReturnTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_RawMaterialReturnDetail

        DataSet GetSdl_RawMaterialReturnDetailSet(string where);

        double GetSdl_RawMaterialReturnDetailOverNum(string where);


        DataSet GetSdl_RawMaterialReturnDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_RawMaterialReturnDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_RawMaterialReturnDetail(Sdl_RawMaterialReturnDetail model, string ebeln, string ebelp, string lgort);

        int AmendSdl_RawMaterialReturnDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_RawMaterialReturnDetail(string timeFlag, string vbeln);

        void DeleteSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetail(string timeFlag, string ebeln);

        Sdl_RawMaterialReturnDetail GetSdl_RawMaterialReturnDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        List<Sdl_RawMaterialReturnDetail> GetSdl_RawMaterialReturnDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_RawMaterialsProcurement

        DataSet GetSdl_RawMaterialsProcurementDataSet(string where);

        int AddSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model);

        void UpdateSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model, string vbeln, string lgort, string nkey, string bktxt, string posnr);

        void DeleteSdl_RawMaterialsProcurement(string timeFlag, string vbeln);

        Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln, string posnr);

        Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln);

        List<Sdl_RawMaterialsProcurement> GetSdl_RawMaterialsProcurementList(System.Data.DataTable table);

        #endregion

        #region Sdl_RawMaterialsProcurementTitle

        DataSet GetSdl_RawMaterialsProcurementTitleDataSet(string where);

        DataSet GetSdl_RawMaterialsProcurementAndTitleDataSet(string where);

        DataSet GetSdl_RawMaterialsProcurementTitlePageData(string pageNum, int pageSize, string where);

        DataSet GetSdl_RawMaterialsProcurementAndTitlePageData(string pageNum, int pageSize, string where);

        DataSet GetSdl_RawMaterialsProcurementTitleSetByField(string[] fieldNames, string where);

        bool AddSdl_RawMaterialsProcurementTitle(Sdl_RawMaterialsProcurementTitle model);

        void UpdateSdl_RawMaterialsProcurementTitle(Sdl_RawMaterialsProcurementTitle model, string vbeln, string truckNum);

        void UpdateSdl_RawMaterialsProcurementTitleByTimeFlag(Sdl_RawMaterialsProcurementTitle model);

        Sdl_RawMaterialsProcurementTitle GetSdl_RawMaterialsProcurementTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_RawMaterialsProcurementTitle> GetSdl_RawMaterialsProcurementTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_Manual

        DataSet GetSdl_ManualDataSet(string where);

        Sdl_Manual GetSdl_Manual(string type);

        int AddSdl_Manual(Sdl_Manual model);

        int UpdateSdl_Manual(Sdl_Manual model);

        void DeleteSdl_Manual(string type);

        #endregion

        #region Sdl_RawMaterialsSale

        DataSet GetSdl_RawMaterialsSaleDataSet(string where);

        int AddSdl_RawMaterialsSale(Sdl_RawMaterialsSale model);

        void UpdateSdl_RawMaterialsSale(Sdl_RawMaterialsSale model, string vbeln, string lgort, string posnr);

        void DeleteSdl_RawMaterialsSale(string timeFlag, string vbeln);

        Sdl_RawMaterialsSale GetSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr);

        Sdl_RawMaterialsSale GetSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr, string lgort);

        List<Sdl_RawMaterialsSale> GetSdl_RawMaterialsSaleList(System.Data.DataTable table);

        #endregion

        #region Sdl_RawMaterialsSaleTitle

        DataSet GetSdl_RawMaterialsSaleTitleDataSet(string where);

        DataSet GetSdl_RawMaterialsSaleTitlePageData(string pageNum, int pageSize, string where);

        DataSet GetSdl_RawMaterialsSaleTitleDataSetByField(string[] fieldNames, string where);

        int AddSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model);

        void UpdateSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model);

        void UpdateSdl_RawMaterialsSaleTitle(Sdl_RawMaterialsSaleTitle model, string truckNum, string vbeln);

        void DeleteSdl_RawMaterialsSaleTitle(string timeFlag, string vbeln, string trucknum);

        Sdl_RawMaterialsSaleTitle GetSdl_RawMaterialsSaleTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_RawMaterialsSaleTitle> GetSdl_RawMaterialsSaleTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_PackWeight

        DataSet GetSdl_PackWeightDataSet(string where);

        bool AddSdl_PackWeight(Sdl_PackWeight model);

        void DeleteSdl_PackWeight();

        #endregion

        #region Sdl_Station

        DataSet GetSdl_StationDataSet(string where, string field);

        bool AddSdl_Station(Sdl_Station model);

        void DeleteSdl_Station();

        #endregion

        #region Sdl_Users

        DataSet GetSdl_UsersDataSet(string where);

        bool AddSdl_Users(Sdl_Users model);

        Sdl_Users GetSdl_Users(string username);

        bool ExistsSdl_User(string username);

        bool ValidateSdl_Users(string username, string password);

        void UpdateSdl_Users(Sdl_Users model);

        void ChangePasswordSdl_Users(string username, string password);

        void DeleteSdl_Users(string userid);

        bool IsExistUserInFun(string roleId);

        #endregion

        #region Sdl_Roles

        DataSet GetSdl_RolesDataSet(string where);

        bool AddSdl_Roles(Sdl_Roles model);

        void UpdateSdl_Roles(Sdl_Roles model);

        void DeleteSdl_Roles(string roleid);

        Sdl_Roles GetSdl_Roles(string roleid);

        Sdl_Roles GetSdl_RolesByRoleName(string rolename);

        #endregion

        #region Sdl_Functions

        DataSet GetSdl_FunctionsDataSet(string where);

        bool AddSdl_Functions(Sdl_Functions model);

        void UpdateSdl_Functions(Sdl_Functions model);

        void DeleteSdl_Functions(string functionid);

        Sdl_Functions GetSdl_Functions(string funId);

        bool IsExistChildFunction(string functionId);

        #endregion

        #region Sdl_FunctionsInRoles

        DataSet GetSdl_FunctionsInRolesDataSet(string roleid);

        DataSet GetSdl_FunctionsInRolesDataSetWhere(string where);

        bool AddSdl_FunctionsInRoles(Sdl_FunctionsInRoles model);

        void DeleteSdl_FunctionsInRoles(string functionid, string roleid);

        void DeleteSdl_FunctionsInRoles(string roleid);

        bool IsExistFunction(string functionId);
        #endregion

        #region Sdl_ProductReturnMerchant

        DataSet GetSdl_ProductReturnMerchantSet(string where);
        DataSet GetSdl_ProductReturnMerchantPageData(string pageNum, int PageSize, string where);
        DataSet GetSdl_ProductReturnMerchantSearchSet(string where);
        DataSet GetSdl_ProductReturnMerchantSetByField(string[] fieldNames, string where);

        DataTable GetSdl_ProductReturnMerchantDataTable(string truckNum, string timeFlag);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_ProductReturnMerchant(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_ProductReturnMerchant(Sdl_ProductReturnMerchant model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_ProductReturnMerchant(Sdl_ProductReturnMerchant model);

        void UpdateSdl_ProductReturnMerchant(Sdl_ProductReturnMerchant model, string vbeln1, string truckNum1);

        int AmendSdl_ProductReturnMerchant(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_ProductReturnMerchant(string timeFlag, string vbeln);

        void DeleteSdl_ProductReturnMerchant(string truckNum, string timeFlag, string vbeln);

        void DeleteSdl_ProductReturnMerchantByTimeFlag(string timeFlag, string truckNum);

        Sdl_ProductReturnMerchant GetSdl_ProductReturnMerchant(string truckNum, string timeFlag);

        Sdl_ProductReturnMerchant GetSdl_ProductReturnMerchant(string truckNum, string vbeln, string timeFlag);



        List<Sdl_ProductReturnMerchant> GetSdl_ProductReturnMerchantList(System.Data.DataTable table);

        #endregion

        #region Sdl_ProductReturnRailway

        DataSet GetSdl_ProductReturnRailwaySet(string where);
        DataSet GetSdl_ProductReturnRailwayPageData(string pageNum, int PageSize, string where);
        DataSet GetSdl_ProductReturnRailwaySearchSet(string where);
        DataSet GetSdl_ProductReturnRailwaySetByField(string[] fieldNames, string where);

        DataTable GetSdl_ProductReturnRailwayDataTable(string truckNum, string timeFlag);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_ProductReturnRailway(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_ProductReturnRailway(Sdl_ProductReturnRailway model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_ProductReturnRailway(Sdl_ProductReturnRailway model);

        void UpdateSdl_ProductReturnRailway(Sdl_ProductReturnRailway model, string vbeln1, string truckNum1);

        int AmendSdl_ProductReturnRailway(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_ProductReturnRailway(string timeFlag, string vbeln);

        void DeleteSdl_ProductReturnRailway(string truckNum, string timeFlag, string vbeln);

        void DeleteSdl_ProductReturnRailwayByTimeFlag(string timeFlag, string truckNum);

        Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string truckNum, string timeFlag);

        Sdl_ProductReturnRailway GetSdl_ProductReturnRailway(string truckNum, string vbeln, string timeFlag);



        List<Sdl_ProductReturnRailway> GetSdl_ProductReturnRailwayList(System.Data.DataTable table);

        #endregion

        #region Sdl_ProductReturnMerchantDetail

        DataSet GetSdl_ProductReturnMerchantDetailSet(string where);


        DataSet GetSdl_ProductReturnMerchantDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model);

        void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model, string vbeln1, string lgort1, string posnr1);

        void UpdateSdl_ProductReturnMerchantDetail(Sdl_ProductReturnMerchantDetail model, Sdl_ProductReturnMerchantDetail oldModel);

        int AmendSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln);

        void DeleteSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string lgort, string posnr);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln);

        Sdl_ProductReturnMerchantDetail GetSdl_ProductReturnMerchantDetail(string timeFlag, string vbeln, string posnr, string lgort);

        List<Sdl_ProductReturnMerchantDetail> GetSdl_ProductReturnMerchantDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_ProductReturnRailwayDetail

        DataSet GetSdl_ProductReturnRailwayDetailSet(string where);


        DataSet GetSdl_ProductReturnRailwayDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model);

        void UpdateSdl_ProductReturnRailwayDetail(Sdl_ProductReturnRailwayDetail model, string vbeln1, string lgort1, string posnr1);

        int AmendSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln);

        void DeleteSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string lgort, string posnr);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln);

        Sdl_ProductReturnRailwayDetail GetSdl_ProductReturnRailwayDetail(string timeFlag, string vbeln, string posnr, string lgort);

        List<Sdl_ProductReturnRailwayDetail> GetSdl_ProductReturnRailwayDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_FinishedProductsPresentation

        DataSet GetSdl_FinishedProductsPresentationDataSet(string where);

        int AddSdl_FinishedProductsPresentation(Sdl_FinishedProductsPresentation model);

        void UpdateSdl_FinishedProductsPresentation(Sdl_FinishedProductsPresentation model, string rsnum, string rspos, string lgort);

        void DeleteSdl_FinishedProductsPresentation(string timeFlag, string rsnum);

        void DeleteSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos, string lgort);

        Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string posnr);

        Sdl_FinishedProductsPresentation GetSdl_FinishedProductsPresentation(string timeFlag, string rsnum, string rspos, string lgort);

        List<Sdl_FinishedProductsPresentation> GetSdl_FinishedProductsPresentationList(System.Data.DataTable table);

        double GetSdl_FinishedProductsPresentationOverNum(string where);


        #endregion

        #region Sdl_FinishedProductsPresentationTitle

        DataSet GetSdl_FinishedProductsPresentationTitleDataSet(string where);

        DataSet GetSdl_FinishedProductsPresentationTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_FinishedProductsPresentationTitleDataSetByField(string[] fieldNames, string where);

        int AddSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model);

        void UpdateSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model);

        void UpdateSdl_FinishedProductsPresentationTitle(Sdl_FinishedProductsPresentationTitle model, string truckNum, string rsnum);

        void UpdateSdl_FinishedProductsPresentationTitleByTimeFlag(Sdl_FinishedProductsPresentationTitle model);

        void DeleteSdl_FinishedProductsPresentationTitle(string timeFlag, string rsnum, string truckNum);

        Sdl_FinishedProductsPresentationTitle GetSdl_FinishedProductsPresentationTitle(string truckNum, string rsnum, string timeFlag);

        List<Sdl_FinishedProductsPresentationTitle> GetSdl_FinishedProductsPresentationTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_LoadometerDiff

        DataSet GetSdl_LoadometerDiffDataSet(string where);

        bool AddSdl_LoadometerDiff(Sdl_LoadometerDiff model);

        double GetSdl_LoadometerDiff(string id);

        void DeleteSdl_LoadometerDiff();

        #endregion

        #region Sdl_Feedback

        DataSet GetSdl_FeedbackDataSet(string where);

        Sdl_Feedback GetSdl_Feedback(int id);

        bool AddSdl_Feedback(Sdl_Feedback model);

        void UpdateSdl_Feedback(Sdl_Feedback model);

        void DeleteSdl_Feedback(int id);

        #endregion

        #region Sdl_AccessoryProcurementTitle

        DataSet GetSdl_AccessoryProcurementTitleSet(string where);

        DataSet GetSdl_AccessoryProcurementTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_AccessoryProcurementTitleSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryProcurementTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryProcurementTitle(Sdl_AccessoryProcurementTitle model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryProcurementTitle(Sdl_AccessoryProcurementTitle model);

        void UpdateSdl_AccessoryProcurementTitle(Sdl_AccessoryProcurementTitle model, string truckNum, string ebeln);

        void UpdateSdl_AccessoryProcurementTitleByTimeFlag(Sdl_AccessoryProcurementTitle model);

        int AmendSdl_AccessoryProcurementTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryProcurementTitle(string timeFlag, string vbeln);

        Sdl_AccessoryProcurementTitle GetSdl_AccessoryProcurementTitle(string truckNum, string timeFlag);

        Sdl_AccessoryProcurementTitle GetSdl_AccessoryProcurementTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_AccessoryProcurementTitle> GetSdl_AccessoryProcurementTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryProcurementDetail

        DataSet GetSdl_AccessoryProcurementDetailSet(string where);

        double GetSdl_AccessoryProcurementDetailOverNum(string where);

        DataSet GetSdl_AccessoryProcurementDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryProcurementDetail(string timeFlag, string vbeln, string posnr);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model);

        void UpdateSdl_AccessoryProcurementDetail(Sdl_AccessoryProcurementDetail model, string ebeln, string ebelp, string matnr);

        int AmendSdl_AccessoryProcurementDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryProcurementDetail(string timeFlag, string vbeln);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetail(string timeFlag, string vbeln);

        List<Sdl_AccessoryProcurementDetail> GetSdl_AccessoryProcurementDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryReturnTitle

        DataSet GetSdl_AccessoryReturnTitleSet(string where);

        DataSet GetSdl_AccessoryReturnTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_AccessoryReturnTitleSetByField(string[] fieldNames, string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryReturnTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryReturnTitle(Sdl_AccessoryReturnTitle model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryReturnTitle(Sdl_AccessoryReturnTitle model);

        void UpdateSdl_AccessoryReturnTitle(Sdl_AccessoryReturnTitle model, string ebeln, string truckNum);

        void UpdateSdl_AccessoryReturnTitleByTimeFlag(Sdl_AccessoryReturnTitle model);

        int AmendSdl_AccessoryReturnTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryReturnTitle(string timeFlag, string vbeln);

        void DeleteSdl_AccessoryReturnTitle(string timeFlag, string ebeln, string trucknum);

        Sdl_AccessoryReturnTitle GetSdl_AccessoryReturnTitle(string truckNum, string timeFlag);

        Sdl_AccessoryReturnTitle GetSdl_AccessoryReturnTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_AccessoryReturnTitle> GetSdl_AccessoryReturnTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryReturnDetail

        DataSet GetSdl_AccessoryReturnDetailSet(string where);

        double GetSdl_AccessoryReturnDetailOverNum(string where);

        DataSet GetSdl_AccessoryReturnDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryReturnDetail(string timeFlag, string vbeln, string posnr);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryReturnDetail(Sdl_AccessoryReturnDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryReturnDetail(Sdl_AccessoryReturnDetail model);

        void UpdateSdl_AccessoryReturnDetail(Sdl_AccessoryReturnDetail model, string ebeln, string ebelp);

        int AmendSdl_AccessoryReturnDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryReturnDetail(string timeFlag, string vbeln);

        void DeleteSdl_AccessoryReturnDetail(string timeFlag, string ebeln, string ebelp);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_AccessoryReturnDetail GetSdl_AccessoryReturnDetail(string timeFlag, string vbeln);

        List<Sdl_AccessoryReturnDetail> GetSdl_AccessoryReturnDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_AllotTitle

        DataSet GetSdl_AllotTitleSet(string where);

        DataSet GetSdl_AllotTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_AllotTitleSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AllotTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AllotTitle(Sdl_AllotTitle model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AllotTitle(Sdl_AllotTitle model);

        void UpdateSdl_AllotTitle(Sdl_AllotTitle model, string ebeln, string truckNum);

        void UpdateSdl_AllotTitleByTimeFlag(Sdl_AllotTitle model);

        int AmendSdl_AllotTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AllotTitle(string timeFlag, string vbeln);

        void DeleteSdl_AllotTitle(string timeFlag, string ebeln, string truckNum);

        Sdl_AllotTitle GetSdl_AllotTitle(string truckNum, string timeFlag);

        Sdl_AllotTitle GetSdl_AllotTitle(string truckNum, string ebeln, string timeFlag);

        DataTable GetSdl_AllotTitleDataTable(string truckNum, string timeFlag);

        List<Sdl_AllotTitle> GetSdl_AllotTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_AllotDetail

        DataSet GetSdl_AllotDetailSet(string where);

        double GetSdl_AllotDetailOverNum(string where);

        DataTable GetSdl_AllotDetailMengeAndSfimg(string where);

        DataSet GetSdl_AllotDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AllotDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AllotDetail(Sdl_AllotDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AllotDetail(Sdl_AllotDetail model);

        void UpdateSdl_AllotDetail(Sdl_AllotDetail model, string ebeln, string ebelp, string lgort);

        int AmendSdl_AllotDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AllotDetail(string timeFlag, string vbeln);

        void DeleteSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_AllotDetail GetSdl_AllotDetail(string timeFlag, string vbeln);

        Sdl_AllotDetail GetSdl_AllotDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        List<Sdl_AllotDetail> GetSdl_AllotDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_AllotInTitle

        DataSet GetSdl_AllotInTitleSet(string where);

        DataSet GetSdl_AllotInTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_AllotInTitleSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AllotInTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AllotInTitle(Sdl_AllotInTitle model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AllotInTitle(Sdl_AllotInTitle model);

        void UpdateSdl_AllotInTitle(Sdl_AllotInTitle model, string ebeln, string truckNum);

        void UpdateSdl_AllotInTitleByTimeFlag(Sdl_AllotInTitle model);

        int AmendSdl_AllotInTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AllotInTitle(string timeFlag, string vbeln);

        Sdl_AllotInTitle GetSdl_AllotInTitle(string truckNum, string timeFlag);

        Sdl_AllotInTitle GetSdl_AllotInTitle(string truckNum, string vbeln, string timeFlag);

        DataTable GetSdl_AllotInTitleDataTable(string truckNum, string timeFlag);

        List<Sdl_AllotInTitle> GetSdl_AllotInTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_AllotInDetail

        DataSet GetSdl_AllotInDetailSet(string where);

        double GetSdl_AllotInDetailOverNum(string where);

        DataSet GetSdl_AllotInDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AllotInDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AllotInDetail(Sdl_AllotInDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AllotInDetail(Sdl_AllotInDetail model);

        void UpdateSdl_AllotInDetail(Sdl_AllotInDetail model, string ebeln, string ebelp, string lgort);

        int AmendSdl_AllotInDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AllotInDetail(string timeFlag, string vbeln);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_AllotInDetail GetSdl_AllotInDetail(string timeFlag, string vbeln);

        List<Sdl_AllotInDetail> GetSdl_AllotInDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryAllotOutTitle

        DataSet GetSdl_AccessoryAllotOutTitleSet(string where);

        DataSet GetSdl_AccessoryAllotOutTitlePageData(string pageNum, int PageSize, string where);

        DataSet GetSdl_AccessoryAllotOutTitleSetByField(string[] fieldNames, string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryAllotOutTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryAllotOutTitle(Sdl_AccessoryAllotOutTitle model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryAllotOutTitle(Sdl_AccessoryAllotOutTitle model);

        void UpdateSdl_AccessoryAllotOutTitle(Sdl_AccessoryAllotOutTitle model, string ebeln, string truckNum);

        void UpdateSdl_AccessoryAllotOutTitleByTimeFlag(Sdl_AccessoryAllotOutTitle model);

        int AmendSdl_AccessoryAllotOutTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryAllotOutTitle(string timeFlag, string vbeln);

        void DeleteSdl_AccessoryAllotOutTitle(string timeFlag, string ebeln, string truckNum);

        DataTable GetSdl_AccessoryAllotOutTitleDataTable(string truckNum, string timeFlag);

        Sdl_AccessoryAllotOutTitle GetSdl_AccessoryAllotOutTitle(string truckNum, string timeFlag);

        Sdl_AccessoryAllotOutTitle GetSdl_AccessoryAllotOutTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_AccessoryAllotOutTitle> GetSdl_AccessoryAllotOutTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryAllotOutDetail

        DataSet GetSdl_AccessoryAllotOutDetailSet(string where);

        DataSet GetSdl_AccessoryAllotInTitlePageData(string pageNum, int PageSize, string where);

        double GetSdl_AccessoryAllotOutDetailOverNum(string where);

        DataTable GetSdl_AccessoryAllotOutDetailMengeAndSfimg(string where);

        DataSet GetSdl_AccessoryAllotOutDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryAllotOutDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model);

        void UpdateSdl_AccessoryAllotOutDetail(Sdl_AccessoryAllotOutDetail model, string ebeln, string ebelp, string lgort);

        int AmendSdl_AccessoryAllotOutDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryAllotOutDetail(string timeFlag, string vbeln);

        void DeleteSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetail(string timeFlag, string vbeln);

        Sdl_AccessoryAllotOutDetail GetSdl_AccessoryAllotOutDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        List<Sdl_AccessoryAllotOutDetail> GetSdl_AccessoryAllotOutDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryAllotInTitle

        DataSet GetSdl_AccessoryAllotInTitleSet(string where);

        DataSet GetSdl_AccessoryAllotInTitleSetByField(string[] fieldNames, string where);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryAllotInTitle(string timeFlag, string vbeln);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryAllotInTitle(Sdl_AccessoryAllotInTitle model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryAllotInTitle(Sdl_AccessoryAllotInTitle model);

        void UpdateSdl_AccessoryAllotInTitle(Sdl_AccessoryAllotInTitle model, string ebeln, string truckNum);

        void UpdateSdl_AccessoryAllotInTitleByTimeFlag(Sdl_AccessoryAllotInTitle model);

        int AmendSdl_AccessoryAllotInTitle(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryAllotInTitle(string timeFlag, string vbeln);

        void DeleteSdl_AccessoryAllotInTitle(string timeFlag, string ebeln, string truckNum);

        DataTable GetSdl_AccessoryAllotInTitleDataTable(string truckNum, string timeFlag);

        Sdl_AccessoryAllotInTitle GetSdl_AccessoryAllotInTitle(string truckNum, string timeFlag);

        Sdl_AccessoryAllotInTitle GetSdl_AccessoryAllotInTitle(string truckNum, string vbeln, string timeFlag);

        List<Sdl_AccessoryAllotInTitle> GetSdl_AccessoryAllotInTitleList(System.Data.DataTable table);

        #endregion

        #region Sdl_AccessoryAllotInDetail

        DataSet GetSdl_AccessoryAllotInDetailSet(string where);

        double GetSdl_AccessoryAllotInDetailOverNum(string where);


        DataSet GetSdl_AccessoryAllotInDetailSearchSet(string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_AccessoryAllotInDetail(string timeFlag, string vbeln, string posnr, string lgort);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_AccessoryAllotInDetail(Sdl_AccessoryAllotInDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryAllotInDetail(Sdl_AccessoryAllotInDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_AccessoryAllotInDetail(Sdl_AccessoryAllotInDetail model, string ebeln, string ebelp, string lgort);

        int AmendSdl_AccessoryAllotInDetail(string timeFlag, string vbeln, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryAllotInDetail(string timeFlag, string vbeln);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteSdl_AccessoryAllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_AccessoryAllotInDetail GetSdl_AccessoryAllotInDetail(string timeFlag, string vbeln);

        Sdl_AccessoryAllotInDetail GetSdl_AccessoryAllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort);

        List<Sdl_AccessoryAllotInDetail> GetSdl_AccessoryAllotInDetailList(System.Data.DataTable table);

        #endregion

        #region Sdl_TruckWeight

        DataSet GetSdl_TruckWeightDataSet(string where);

        bool AddSdl_TruckWeight(Sdl_TruckWeight model);

        void DeleteSdl_TruckWeight(string where);

        #endregion

        void DeleteSdl_RawMaterialsSale(string timeFlag, string vbeln, string posnr, string lgort);

        #region Sdl_DataHistory

        DataSet GetSdl_DataHistoryDataSet(string where);

        DataSet GetSdl_DataHistoryPageData(string pageNum, int PageSize, string where);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ExistsSdl_DataHistory(string editTime, string tableName, string field);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int AddSdl_DataHistory(Sdl_DataHistory model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void UpdateSdl_DataHistory(Sdl_DataHistory model);

        /// <summary>
        /// 删除一条数据
        /// </summary>        
        void DeleteSdl_DataHistory(string editTime, string tableName, string field);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sdl_DataHistory GetSdl_DataHistory(string editTime, string tableName, string field);

        #endregion

        bool ExistsSdl_RawMaterialsProcurement(string timeflag, string vbeln, string posnr, string lgort, string bktxt, int nkey);

        void DeleteSdl_RawMaterialsProcurement(string timeflag, string vbeln, string posnr, string lgort, string bktxt, int nkey);

        void DeleteSdl_RawMaterialsProcurementTitle(string timeFlag, string vbeln, string trucknum);

        Sdl_RawMaterialsProcurement GetSdl_RawMaterialsProcurement(string timeFlag, string vbeln, string posnr, string lgort, string bktxt, int nkey);

        bool ExistsSdl_RawMaterialsProcurementTitle(string timeFlag, string vbeln, string truckNum);

        DataSet GetSdl_RawMaterialReturnTitleSetByField(string where);

        bool ExistsSdl_RawMaterialReturnTitle(string timeFlag, string ebeln, string trucknum);

        bool ExistsSdl_AccessoryProcurementTitle(string timeFlag, string ebeln, string trucknum);

        bool ExistsSdl_AccessoryReturnTitle(string timeFlag, string ebeln, string trucknum);

        bool ExistsSdl_AllotInTitle(string timeFlag, string ebeln, string trucknum);

        void DeleteSdl_AllotInDetail(string timeFlag, string vbeln, string ebelp, string lgort);

        void DeleteSdl_AllotInTitle(string timeFlag, string ebeln, string trucknum);

        bool ExistsSdl_AllotTitle(string timeFlag, string ebeln, string trucknum);

        bool ExistsSdl_AccessoryAllotInTitle(string timeFlag, string ebeln, string trucknum);

        void UpdateSdl_RawMaterialsProcurement(Sdl_RawMaterialsProcurement model);

        bool ExistsSdl_RawMaterialsSaleTitle(string timeFlag, string vbeln, string truckNum);

        void UpdateSdl_RawMaterialsSale(Sdl_RawMaterialsSale model);

        bool ExistsSdl_RawMaterialsSale(string timeflag, string vbeln, string posnr, string lgort);

        Sdl_AccessoryReturnDetail GetSdl_AccessoryReturnDetail(string timeFlag, string ebeln, string ebelp);

        Sdl_AccessoryProcurementDetail GetSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string ebelp, string matnr);

        void DeleteSdl_AccessoryProcurementDetail(string timeFlag, string ebeln, string ebelp, string matnr);

        Sdl_AllotInDetail GetSdl_AllotInDetail(string timeFlag, string ebeln, string ebelp, string lgort);

    #region Sdl_Sweight
        DataSet GetSdl_SweightDataSet(string where);

        bool ExistsSdl_Sweight(string ID);

        int AddSdl_Sweight(Sdl_Sweight model);

        void UpdateSdl_Sweight(Sdl_Sweight model);

        void DeleteSdl_Sweight(string ID);

        void DeleteAllSdl_Sweight();

        Sdl_Sweight GetSdl_Sweight(string ID);

        List<Sdl_Sweight> GetSdl_SweightList(System.Data.DataTable table);

        #endregion

        #region Sdl_StorageType

        DataSet GetSdl_StorageTypeDataSet(string where);

        bool AddSdl_StorageType(Sdl_StorageType model);

        void DeleteSdl_StorageType();

        #endregion


        #region Sdl_FinishedProductedExchangeIn
        DataSet GetSdl_FinishedProductsExchangeInDataSet(string where);
        int AddSdl_FinishedProductsExchangeIn(Sdl_FinishedProductsExchange model);
        void UpdateSdl_FinishedProductsExchangeIn(Sdl_FinishedProductsExchange model, string id);
        void UpdateSdl_FinishedProductsExchangeIn(Sdl_FinishedProductsExchange model, string timeFlag, string oanum, string posnr);
        Sdl_FinishedProductsExchange GetSdl_FinishedProductsExchangeIn(string timeFlag, string oanum, string posnr);
        void DeleteSdl_FinishedProductsExchangeIn(string timeFlag, string id);
        void DeleteSdl_FinishedProductsExchangeIn(string timeFlag, string oanum, string posnr);
        List<Sdl_FinishedProductsExchange> GetSdl_FinishedProductsExchangeInList(System.Data.DataTable table);
        #endregion

        #region Sdl_FinishedProductedExchangeInTittle
        DataSet GetSdl_FinishedProductsExchangeInTitleDataSet(string where);
        DataSet GetSdl_FinishedProductsExchangeInTitlePageData(string pageNum, int PageSize, string where);
        DataSet GetSdl_FinishedProductsExchangeInTitleDataSetByField(string[] fieldNames, string where);
        bool ExistsSdl_FinishedProductsExchangeInTitle(string timeFlag, string oanum, string truckNum);
        int AddSdl_FinishedProductsExchangeInTitle(Sdl_FinishedProductsExchangeTitle model);
        void UpdateSdl_FinishedProductsExchangeInTitle(Sdl_FinishedProductsExchangeTitle model);
        void UpdateSdl_FinishedProductsExchangeInTitleByTimeFlag(Sdl_FinishedProductsExchangeTitle model);
        void UpdateSdl_FinishedProductsExchangeInTitle(Sdl_FinishedProductsExchangeTitle model, string truckNum, string oanum);
        Sdl_FinishedProductsExchangeTitle GetSdl_FinishedProductsExchangeInTitle(string truckNum, string oanum, string timeFlag);
        void DeleteSdl_FinishedProductsExchangeInTitle(string timeFlag, string oanum, string truckNum);
        List<Sdl_FinishedProductsExchangeTitle> GetSdl_FinishedProductsExchangeInTitleList(System.Data.DataTable table);
        #endregion

        #region Sdl_FinishedProductedExchangeOut
        DataSet GetSdl_FinishedProductsExchangeOutDataSet(string where);
        int AddSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model);
        void UpdateSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model, string id);
        void UpdateSdl_FinishedProductsExchangeOut(Sdl_FinishedProductsExchange model, string timeFlag, string oanum, string posnr);
        Sdl_FinishedProductsExchange GetSdl_FinishedProductsExchangeOut(string timeFlag, string oanum, string posnr);
        void DeleteSdl_FinishedProductsExchangeOut(string timeFlag, string id);
        void DeleteSdl_FinishedProductsExchangeOut(string timeFlag, string oanum, string posnr);
        List<Sdl_FinishedProductsExchange> GetSdl_FinishedProductsExchangeOutList(System.Data.DataTable table);
        #endregion

        #region Sdl_FinishedProductedExchangeOutTittle
        DataSet GetSdl_FinishedProductsExchangeOutTitleDataSet(string where);
        DataSet GetSdl_FinishedProductsExchangeOutTitlePageData(string pageNum, int PageSize, string where);
        DataSet GetSdl_FinishedProductsExchangeOutTitleDataSetByField(string[] fieldNames, string where);
        bool ExistsSdl_FinishedProductsExchangeOutTitle(string timeFlag, string oanum, string truckNum);
        int AddSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model);
        void UpdateSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model);
        void UpdateSdl_FinishedProductsExchangeOutTitleByTimeFlag(Sdl_FinishedProductsExchangeTitle model);
        void UpdateSdl_FinishedProductsExchangeOutTitle(Sdl_FinishedProductsExchangeTitle model, string truckNum, string oanum);
        Sdl_FinishedProductsExchangeTitle GetSdl_FinishedProductsExchangeOutTitle(string truckNum, string oanum, string timeFlag);
        void DeleteSdl_FinishedProductsExchangeOutTitle(string timeFlag, string oanum, string truckNum);
        List<Sdl_FinishedProductsExchangeTitle> GetSdl_FinishedProductsExchangeOutTitleList(System.Data.DataTable table);
        #endregion

        #region Sdl_SlpsEnter
        DataSet GetSdl_SlpsEnterList(string where);
        bool ExistSdl_SlpsEnter(string qrcodeScanResult);
        int AddSdl_SlpsEnter(Sdl_SlpsEnter model);
        void UpdateSdl_SlpsEnter(Sdl_SlpsEnter model);
        void DeleteSdl_SlpsEnter(string qrcodeScanResult);
        Sdl_SlpsEnter GetSdl_SlpsEnter(string qrcodeScanResult);
        List<Sdl_SlpsEnter> GetSdl_SlpsEnterList(System.Data.DataTable table);

        #endregion

        #region Sdl_SlpsEnterDetail
        DataSet GetSdl_SlpsEnterDetailList(string where);
        bool ExistSdl_SlpsEnterDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        int AddSdl_SlpsEnterDetail(Sdl_SlpsEnterDetail model);
        void UpdateSdl_SlpsEnterDetail(Sdl_SlpsEnterDetail model);
        void DeleteSdl_SlpsEnterDetail(string qrcodeScanResult);
        #endregion

        #region Sdl_SlpsExit
        DataSet GetSdl_SlpsExitList(string where);
        bool ExistSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo);
        int AddSdl_SlpsExit(Sdl_SlpsExit model);
        void UpdateSdl_SlpsExit(Sdl_SlpsExit model);
        void DeleteSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo, string carNo);
        Sdl_SlpsExit GetSdl_SlpsExit(string qrcodeScanResult, string sapOrderNo, string carNo);
        List<Sdl_SlpsExit> GetSdl_SlpsExitList(System.Data.DataTable table);
        #endregion

        #region Sdl_SlpsExitDetail
        DataSet GetSdl_SlpsExitDetailList(string where);
        DataSet GetSdl_SlpsEnterDetailList(string qrcodeScanResult, string sapOrderNo);
        bool ExistSdl_SlpsExitDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        int AddSdl_SlpsExitDetail(Sdl_SlpsExitDetail model);
        void UpdateSdl_SlpsExitDetail(Sdl_SlpsExitDetail model);
        void DeleteSdl_SlpsExitDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        #endregion

        #region Slps_FinishedProductsSale
        DataSet GetSlps_FinishedProductsSaleDataSet(string where);
        bool ExistSlps_FinishedProductsSale(string qrcodeScanResult, string carNo);
        int AddSlps_FinishedProductsSale(Slps_FinishedProductsSale model);
        void UpdateSlps_FinishedProductsSale(Slps_FinishedProductsSale model);
        void DeleteSlps_FinishedProductsSale(string timeFlag, string carNo);
        Slps_FinishedProductsSale GetSlps_FinishedProductsSale(string qrcodeScanResult, string carNo);
        List<Slps_FinishedProductsSale> GetSlps_FinishedProductsSaleList(System.Data.DataTable table);
        #endregion

        #region Slps_FinishedProductsSaleDetail
        DataSet GetSlps_FinishedProductsSaleDetailList(string where);
        DataSet GetSlps_FinishedProductsSaleDetailList(string qrcodeScanResult, string sapOrderNo);
        bool ExistSlps_FinishedProductsSaleDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        int AddSlps_FinishedProductsSaleDetail(Slps_FinishedProductsSaleDetail model);
        void UpdateSlps_FinishedProductsSaleDetail(Slps_FinishedProductsSaleDetail model);
        void DeleteSlps_FinishedProductsSaleDetail(string qrcodeScanResult);
        #endregion

        #region Slps_RawMaterialsProcurement
        DataSet GetSlps_RawMaterialsProcurementDataSet(string where);
        bool ExistSlps_RawMaterialsProcurement(string qrcodeScanResult, string carNo);
        int AddSlps_RawMaterialsProcurement(Slps_RawMaterialsProcurement model);
        void UpdateSlps_RawMaterialsProcurement(Slps_RawMaterialsProcurement model);
        void DeleteSlps_RawMaterialsProcurement(string timeFlag, string carNo);
        Slps_RawMaterialsProcurement GetSlps_RawMaterialsProcurement(string qrcodeScanResult, string carNo);
        List<Slps_RawMaterialsProcurement> GetSlps_RawMaterialsProcurementList(System.Data.DataTable table);
        #endregion

        #region Slps_RawMaterialsProcurementDetail
        DataSet GetSlps_RawMaterialsProcurementDetailList(string where);
        DataSet GetSlps_RawMaterialsProcurementDetailList(string qrcodeScanResult, string sapOrderNo);
        bool ExistSlps_RawMaterialsProcurementDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        int AddSlps_RawMaterialsProcurementDetail(Slps_RawMaterialsProcurementDetail model);
        void UpdateSlps_RawMaterialsProcurementDetail(Slps_RawMaterialsProcurementDetail model);
        void DeleteSlps_RawMaterialsProcurementDetail(string timeFlag);
        Slps_RawMaterialsProcurementDetail GetSlps_RawMaterialsProcurementDetail(string timeFlag, string lineItemNo);
        List<Slps_RawMaterialsProcurementDetail> GetSlps_RawMaterialsProcurementDetailList(DataTable table);
        #endregion

        #region Slps_ProductsReturn
        DataSet GetSlps_ProductsReturnDataSet(string where);
        bool ExistSlps_ProductsReturn(string timeFlag, string carNo);
        int AddSlps_ProductsReturn(Slps_ProductsReturn model);
        void UpdateSlps_ProductsReturn(Slps_ProductsReturn model);
        void DeleteSlps_ProductsReturn(string timeFlag, string carNo);
        Slps_ProductsReturn GetSlps_ProductsReturn(string timeFlag, string lineItemNo);
        List<Slps_ProductsReturn> GetSlps_ProductsReturnList(DataTable table);
        #endregion

        #region Slps_ProductsReturnDetail
        DataSet GetSlps_ProductsReturnDetailDataSet(string where);
        DataSet GetSlps_ProductsReturnDetailList(string qrcodeScanResult, string sapOrderNo);
        bool ExistSlps_ProductsReturnDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        int AddSlps_ProductsReturnDetail(Slps_ProductsReturnDetail model);
        void UpdateSlps_ProductsReturnDetail(Slps_ProductsReturnDetail model);
        void DeleteSlps_ProductsReturnDetail(string timeFlag);
        Slps_ProductsReturnDetail GetSlps_ProductsReturnDetail(string timeFlag, string lineItemNo);
        List<Slps_ProductsReturnDetail> GetSlps_ProductsReturnDetailList(DataTable table);
        #endregion

        #region Slps_RawMaterialsReturn
        DataSet GetSlps_RawMaterialsReturnDataSet(string where);
        bool ExistSlps_RawMaterialsReturn(string timeFlag, string carNo);
        int AddSlps_RawMaterialsReturn(Slps_RawMaterialsReturn model);
        void UpdateSlps_RawMaterialsReturn(Slps_RawMaterialsReturn model);
        void DeleteSlps_RawMaterialsReturn(string timeFlag, string carNo);
        Slps_RawMaterialsReturn GetSlps_RawMaterialsReturn(string timeFlag, string lineItemNo);
        List<Slps_RawMaterialsReturn> GetSlps_RawMaterialsReturnList(DataTable table);
        #endregion

        #region Slps_RawMaterialsReturnDetail
        DataSet GetSlps_RawMaterialsReturnDetailDataSet(string where);
        DataSet GetSlps_RawMaterialsReturnDetailList(string qrcodeScanResult, string sapOrderNo);
        bool ExistSlps_RawMaterialsReturnDetail(string qrcodeScanResult, string sapOrderNo, string lineItemNo);
        int AddSlps_RawMaterialsReturnDetail(Slps_RawMaterialsReturnDetail model);
        void UpdateSlps_RawMaterialsReturnDetail(Slps_RawMaterialsReturnDetail model);
        void DeleteSlps_RawMaterialsReturnDetail(string timeFlag);
        Slps_RawMaterialsReturnDetail GetSlps_RawMaterialsReturnDetail(string timeFlag, string lineItemNo);
        List<Slps_RawMaterialsReturnDetail> GetSlps_RawMaterialsReturnDetailList(DataTable table);
        #endregion

    }
}
