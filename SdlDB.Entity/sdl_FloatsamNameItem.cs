using System;
using System.Data;
/// <summary>
/// sdl_FloatsamNameItem 的摘要说明
/// </summary>
[Serializable()]
public class sdl_FloatsamNameItem
{    public sdl_FloatsamNameItem()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
}


/// <summary>
/// 
/// </summary>
public DateTime CreateTime
{
    set
    {
        createTime=value;
    }
    get
    {
        return createTime;
    }
}
private DateTime createTime=DateTime.MinValue;


/// <summary>
/// 
/// </summary>
public string ID
{
    set
    {
        iD=value;
    }
    get
    {
        return iD;
    }
}
private string iD=string.Empty;


/// <summary>
/// 
/// </summary>
public string Code
{
    set
    {
        code=value;
    }
    get
    {
        return code;
    }
}
private string code=string.Empty;


/// <summary>
/// 
/// </summary>
public string Name
{
    set
    {
        name=value;
    }
    get
    {
        return name;
    }
}
private string name=string.Empty;


/// <summary>
/// 
/// </summary>
public string CreateBy
{
    set
    {
        createBy=value;
    }
    get
    {
        return createBy;
    }
}
private string createBy=string.Empty;




}