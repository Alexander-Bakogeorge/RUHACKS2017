using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public static class GlobalVariables
{
    public static string SomeGlobalUnsecureString = "";
    public static int SomeGlobalInt = 0;
}

namespace AlexaHandler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Uri myUri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("data");
            if (param1 != null)
            {
                if (GlobalVariables.SomeGlobalInt == 0)
                    GlobalVariables.SomeGlobalInt = 1;
                else
                    GlobalVariables.SomeGlobalInt = 0;
                GlobalVariables.SomeGlobalUnsecureString = GlobalVariables.SomeGlobalInt + "+" + param1;
            }
            else
                Response.Write(GlobalVariables.SomeGlobalUnsecureString);
         

        }
    }
}