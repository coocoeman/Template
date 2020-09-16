using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginState"] != null)
            {
                isLogin.IH = "<a href='/Logout' class='section-toggle'>登出</a>";
            }
            else
            {
                isLogin.IH = "<a href='/Login' class='section-toggle' data-section='login' >登入</a><a href='/Signup' class='section-toggle' data-section='signup' >註冊</a>";

            }
        }
    }
}