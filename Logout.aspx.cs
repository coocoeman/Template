using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginState"] != null)
            {
                Session["loginState"] = null;
            }
            Response.Write("<script>alert('NO~別走');history.back();</script>");
        }
    }
}