using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SdlDB.Data;
using SdlDB.Entity;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace SdlDB.Utility
{
    public class CompareModelHelper
    {
        public enum EditType
        {
            Insert,
            Update,
            Delete
        }

        public enum SdlDB_Modules
        {
            [Description("sdl_FinishedProductsSaleTitle")]
            FinishedProductsSaleTitle,
            [Description("sdl_FinishedProductsSale")]
            FinishedProductsSale,
            [Description("sdl_RawMaterialsProcurementTitle")]
            RawMaterialsProcurementTitle,
            [Description("sdl_RawMaterialsProcurement")]
            RawMaterialsProcurement,
            [Description("sdl_ProductReturnMerchant")]
            ProductReturnMerchant,
            [Description("sdl_ProductReturnMerchantDetail")]
            ProductReturnMerchantDetail,
            [Description("sdl_ProductReturnRailway")]
            ProductReturnRailway,
            [Description("sdl_ProductReturnRailwayDetail")]
            ProductReturnRailwayDetail,
            [Description("sdl_FinishedProductsPresentationTitle")]
            FinishedProductsPresentationTitle,
            [Description("sdl_FinishedProductsPresentation")]
            FinishedProductsPresentation,
            [Description("sdl_RawMaterialsSale")]
            RawMaterialsSale,
            [Description("sdl_RawMaterialsSaleTitle")]
            RawMaterialsSaleTitle,
            [Description("sdl_AllotDetail")]
            AllotDetail,
            [Description("sdl_AllotTitle")]
            AllotTitle,
            [Description("sdl_RawMaterialReturnDetail")]
            RawMaterialReturnDetail,
            [Description("sdl_RawMaterialReturnTitle")]
            RawMaterialReturnTitle,
            [Description("sdl_AccessoryAllotInDetail")]
            AccessoryAllotInDetail,
            [Description("sdl_AccessoryAllotInTitle")]
            AccessoryAllotInTitle,
            [Description("sdl_AccessoryAllotOutDetail")]
            AccessoryAllotOutDetail,
            [Description("sdl_AccessoryAllotOutTitle")]
            AccessoryAllotOutTitle,
            [Description("sdl_AccessoryProcurementDetail")]
            AccessoryProcurementDetail,
            [Description("sdl_AccessoryProcurementTitle")]
            AccessoryProcurementTitle,
            [Description("sdl_AccessoryReturnDetail")]
            AccessoryReturnDetail,
            [Description("sdl_AccessoryReturnTitle")]
            AccessoryReturnTitle,
            [Description("sdl_AllotDetail")]
            AllotInDetail,
            [Description("sdl_AllotTitle")]
            AllotInTitle
        }

        public static string GetModuleName(string module)
        {
            string moduleName = string.Empty;
            switch (module)
            {
                case "Sdl_AccessoryAllotInDetail":
                    moduleName = "配件调拨调入";
                    break;
                case "Sdl_AccessoryAllotInTitle":
                    moduleName = "配件调拨调入";
                    break;
                case "Sdl_AccessoryAllotOutDetail":
                    moduleName = "配件调拨调出";
                    break;
                case "Sdl_AccessoryAllotOutTitle":
                    moduleName = "配件调拨调出";
                    break;
                case "Sdl_AccessoryProcurementDetail":
                    moduleName = "配件采购";
                    break;
                case "Sdl_AccessoryProcurementTitle":
                    moduleName = "配件采购";
                    break;
                case "Sdl_AccessoryReturnDetail":
                    moduleName = "配件退货";
                    break;
                case "Sdl_AccessoryReturnTitle":
                    moduleName = "配件退货";
                    break;
                case "Sdl_AllotDetail":
                    moduleName = "原材料调拨调出";
                    break;
                case "Sdl_AllotInDetail":
                    moduleName = "原材料调拨调入";
                    break;
                case "Sdl_AllotInTitle":
                    moduleName = "原材料调拨调入";
                    break;
                case "Sdl_AllotTitle":
                    moduleName = "原材料调拨调出";
                    break;
                case "Sdl_FinishedProductsPresentation":
                    moduleName = "产成品赠送";
                    break;
                case "Sdl_FinishedProductsPresentationTitle":
                    moduleName = "产成品赠送";
                    break;
                case "Sdl_FinishedProductsSale":
                    moduleName = "产成品销售";
                    break;
                case "Sdl_FinishedProductsSaleTitle":
                    moduleName = "产成品销售";
                    break;
                case "Sdl_ProductReturnMerchant":
                    moduleName = "产成品经销商退货";
                    break;
                case "Sdl_ProductReturnMerchantDetail":
                    moduleName = "产成品经销商退货";
                    break;
                case "Sdl_ProductReturnRailway":
                    moduleName = "产成品铁运退货";
                    break;
                case "Sdl_ProductReturnRailwayDetail":
                    moduleName = "产成品铁运退货";
                    break;
                case "Sdl_RawMaterialReturnDetail":
                    moduleName = "原材料退货";
                    break;
                case "Sdl_RawMaterialReturnTitle":
                    moduleName = "原材料退货";
                    break;
                case "Sdl_RawMaterialsProcurement":
                    moduleName = "原材料采购";
                    break;
                case "Sdl_RawMaterialsProcurementTitle":
                    moduleName = "原材料采购";
                    break;
                case "Sdl_RawMaterialsSale":
                    moduleName = "原材料销售";
                    break;
                case "Sdl_RawMaterialsSaleTitle":
                    moduleName = "原材料销售";
                    break;
                default:
                    break;
            }
            return moduleName;
        }

        public static string GetFieldName(string field)
        {
            string fieldName = string.Empty;
            switch (field.ToUpper())
            {
                case "VBELN":
                    fieldName = "单号";
                    break;
                case "TRUCKNUM":
                    fieldName = "车牌号";
                    break;
                case "TIMEFLAG":
                    fieldName = "入厂时间";
                    break;
                case "LGORT":
                    fieldName = "仓库";
                    break;
                case "POSNR":
                    fieldName = "行项目";
                    break;
                case "BKTXT":
                    fieldName = "产地品牌";
                    break;
                case "EBELN":
                    fieldName = "单号";
                    break;
                case "EBELP":
                    fieldName = "行项目";
                    break;
                case "NKEY":
                    fieldName = "车皮序号";
                    break;
                case "RSNUM":
                    fieldName = "预留";
                    break;
                case "RSPOS":
                    fieldName = "行项目";
                    break;
                case "MATNR":
                    fieldName = "物料编码";
                    break;
                default:
                    break;
            }
            return fieldName;
        }

        public static void CompareModel(object oldModel, object newModel, EditType type, string tableName)
        {
            Type t = oldModel.GetType();
            Hashtable ht = new Hashtable();
            string oldValue = string.Empty;
            string newValue = string.Empty;
            foreach (PropertyInfo pi in t.GetProperties())
            {
                ht.Add(pi.Name, pi.GetValue(oldModel, null).ToString());
            }
            foreach (PropertyInfo pi in t.GetProperties())
            {
                Sdl_DataHistory dh = new Sdl_DataHistory();
                if (type == EditType.Insert)
                {
                    newValue = pi.GetValue(newModel, null).ToString();
                    dh.InsertFlag = true;
                }
                else if (type == EditType.Update)
                {
                    oldValue = pi.GetValue(oldModel, null).ToString();
                    newValue = pi.GetValue(newModel, null).ToString();
                    if (oldValue == newValue)
                    {
                        continue;
                    }
                    else
                    {
                        dh.EditFlag = true;
                    }
                }
                else if (type == EditType.Delete)
                {
                    oldValue = pi.GetValue(oldModel, null).ToString();
                    dh.DeleteFlag = true;
                }
                dh.OldValue = oldValue;
                dh.NewValue = newValue;
                dh.EditTime = GetServerDate();
                dh.Field = pi.Name;
                dh.TableName = t.Name;
                dh.Time = DateTime.Parse(dh.EditTime);
                StringBuilder sb = new StringBuilder();
                DataColumn[] dc = GetTableKey(tableName);
                if (dc.Length >= 1)
                {
                    dh.Col1 = ht[dc[0].ColumnName].ToString();
                    sb.Append(dc[0].ColumnName + ";");
                }
                if (dc.Length >= 2)
                {
                    dh.Col2 = ht[dc[1].ColumnName].ToString();
                    sb.Append(dc[1].ColumnName + ";");
                }
                if (dc.Length >= 3)
                {
                    dh.Col3 = ht[dc[2].ColumnName].ToString();
                    sb.Append(dc[2].ColumnName + ";");
                }
                if (dc.Length >= 4)
                {
                    dh.Col4 = ht[dc[3].ColumnName].ToString();
                    sb.Append(dc[3].ColumnName + ";");
                }
                if (dc.Length >= 5)
                {
                    dh.Col5 = ht[dc[4].ColumnName].ToString();
                    sb.Append(dc[4].ColumnName + ";");
                }
                if (dc.Length >= 6)
                {
                    dh.Col6 = ht[dc[5].ColumnName].ToString();
                    sb.Append(dc[5].ColumnName + ";");
                }
                dh.ColField = sb.ToString().TrimEnd(';');
                dh.Module = GetModuleName(t.Name);
                dh.UserName = System.Threading.Thread.CurrentPrincipal.Identity.Name.ToString();
                dh.Random = Guid.NewGuid().ToString();
                Sdl_DataHistoryAdapter.AddSdl_DataHistory(dh);
            }
        }

        public static DataColumn[] GetTableKey(string tableName)
        {
            DataSet ds = SQLServerHelper.QueryWithKey("select top 1 * from " + tableName);
            DataColumn[] columns = ds.Tables[0].PrimaryKey;
            return columns;
        }

        public static string GetServerDate()
        {
            return DateTime.Parse(((DataSet)CommonOper.ExecuteSql("select getdate()")).Tables[0].Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
