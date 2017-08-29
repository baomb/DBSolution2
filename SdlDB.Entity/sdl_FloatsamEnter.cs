using System;
using System.Data;
/// <summary>
/// sdl_FloatsamEnter 的摘要说明
/// </summary>
[Serializable()]
public class sdl_FloatsamEnter
{    public sdl_FloatsamEnter()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
}


/// <summary>
/// 
/// </summary>
public int ExitFlag
{
    set
    {
        exitFlag=value;
    }
    get
    {
        return exitFlag;
    }
}
private int exitFlag=0;


/// <summary>
/// 
/// </summary>
public int SortNum
{
    set
    {
        sortNum=value;
    }
    get
    {
        return sortNum;
    }
}
private int sortNum=0;


/// <summary>
/// 
/// </summary>
public DateTime EnterTime
{
    set
    {
        enterTime=value;
    }
    get
    {
        return enterTime;
    }
}
private DateTime enterTime=DateTime.MinValue;


/// <summary>
/// 
/// </summary>
public DateTime ExitTime
{
    set
    {
        exitTime=value;
    }
    get
    {
        return exitTime;
    }
}
private DateTime exitTime=DateTime.MinValue;


/// <summary>
/// 
/// </summary>
public double Tare
{
    set
    {
        tare=value;
    }
    get
    {
        return tare;
    }
}
private double tare=0;


/// <summary>
/// 
/// </summary>
public double Gross
{
    set
    {
        gross=value;
    }
    get
    {
        return gross;
    }
}
private double gross=0;


/// <summary>
/// 
/// </summary>
public double Stuff
{
    set
    {
        stuff=value;
    }
    get
    {
        return stuff;
    }
}
private double stuff=0;


/// <summary>
/// 
/// </summary>
public double Net
{
    set
    {
        net=value;
    }
    get
    {
        return net;
    }
}
private double net=0;


/// <summary>
/// 
/// </summary>
public string FloatsamID
{
    set
    {
        floatsamID=value;
    }
    get
    {
        return floatsamID;
    }
}
private string floatsamID=string.Empty;


/// <summary>
/// 
/// </summary>
public string TruckNum
{
    set
    {
        truckNum=value;
    }
    get
    {
        return truckNum;
    }
}
private string truckNum=string.Empty;


/// <summary>
/// 
/// </summary>
public string Werks
{
    set
    {
        werks=value;
    }
    get
    {
        return werks;
    }
}
private string werks=string.Empty;


/// <summary>
/// 
/// </summary>
public string Buyer
{
    set
    {
        buyer=value;
    }
    get
    {
        return buyer;
    }
}
private string buyer=string.Empty;


/// <summary>
/// 
/// </summary>
public string FloatsamName
{
    set
    {
        floatsamName=value;
    }
    get
    {
        return floatsamName;
    }
}
private string floatsamName=string.Empty;


/// <summary>
/// 
/// </summary>
public string Unit
{
    set
    {
        unit=value;
    }
    get
    {
        return unit;
    }
}
private string unit=string.Empty;


/// <summary>
/// 
/// </summary>
public string Lgort
{
    set
    {
        lgort=value;
    }
    get
    {
        return lgort;
    }
}
private string lgort=string.Empty;


/// <summary>
/// 
/// </summary>
public string Passer
{
    set
    {
        passer=value;
    }
    get
    {
        return passer;
    }
}
private string passer=string.Empty;


/// <summary>
/// 
/// </summary>
public string EnterWeightMan
{
    set
    {
        enterWeightMan=value;
    }
    get
    {
        return enterWeightMan;
    }
}
private string enterWeightMan=string.Empty;


/// <summary>
/// 
/// </summary>
public string EnterDBNum
{
    set
    {
        enterDBNum=value;
    }
    get
    {
        return enterDBNum;
    }
}
private string enterDBNum=string.Empty;


/// <summary>
/// 
/// </summary>
public string TimeFlag
{
    set
    {
        timeFlag=value;
    }
    get
    {
        return timeFlag;
    }
}
private string timeFlag=string.Empty;


/// <summary>
/// 
/// </summary>
public string SaleMan
{
    set
    {
        saleMan=value;
    }
    get
    {
        return saleMan;
    }
}
private string saleMan=string.Empty;


/// <summary>
/// 
/// </summary>
public string ExitWeightMan
{
    set
    {
        exitWeightMan=value;
    }
    get
    {
        return exitWeightMan;
    }
}
private string exitWeightMan=string.Empty;


/// <summary>
/// 
/// </summary>
public string Remarks
{
    set
    {
        remarks=value;
    }
    get
    {
        return remarks;
    }
}
private string remarks=string.Empty;


/// <summary>
/// 
/// </summary>
public string IsEmptyOut
{
    set
    {
        isEmptyOut=value;
    }
    get
    {
        return isEmptyOut;
    }
}
private string isEmptyOut=string.Empty;




}