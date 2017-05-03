using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using YouHoo.DataBll.REBATE;
using System.Configuration;
using Newtonsoft.Json;

/// <summary>
/// PolicyService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class PolicyService : System.Web.Services.WebService
{
    private string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    public PolicyService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void GetBrandAndItemList()
    {
        using (KechangDataContext kc = new KechangDataContext(ConnStr))
        {
            var brandRet = kc.youhoo_BasicArchive_brand.Select(x => x);
            var itemRet = kc.youhoo_BasicArchive_item.Select(x => x);


            Context.Response.Write(JsonConvert.SerializeObject(new { brandList = brandRet, itemList = itemRet }));

        }
    }
    [WebMethod]
    public void GetChartsSource()
    {
        Dictionary<string, double> dic = new Dictionary<string, double>() {
            {"小明",20 },
            {"小红",10 },
            {"小刚",40 },
            {"小李",50 },
            {"小王",60 },
            {"小燕",10 },

        };



        List<Dictionary<string, double>> dd = new List<Dictionary<string, double>>();
        dd.Add(dic);

        Context.Response.Write(JsonConvert.SerializeObject(new[] { new { name="小红",value="50"}, new { name = "小刚", value = "50" } }));

    }



}
