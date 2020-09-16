using SudokuWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判斷是否是以登入過的客戶端
            if (Session["loginState"] != null)
            {   //是的話跳回上一頁
                Response.Write("<script>alert('已有登入紀錄');history.back();</script>");
            }
            else
            {
                if (Request.Form["account"]!=null && Request.Form["password"]!= null)
                {
                    LoginTrigger();
                }
                //不是的話留在目前頁面不動作
            }
        }

        #region 登入資料設定

        /// <summary>
        /// 判斷登入的帳號與密碼
        /// </summary>
        private string login_account, login_password;

        /// <summary>
        /// 登入資料來源確認是否正確
        /// </summary>
        /// <returns></returns>
        private bool LoginData()
        {
            SetData();
            if (DataEmpty()) return false;
            return true;
        }

        /// <summary>
        /// 設定資料來源並判斷是否有值
        /// </summary>
        private void SetData()
        {
            login_account = $""+Request.Form["account"].ToString();
            login_password = $"" + Request.Form["password"].ToString();
        }

        /// <summary>
        /// 判斷登入資料是否為空或空白
        /// </summary>
        /// <returns></returns>
        private bool DataEmpty()
        {
            if (login_account == string.Empty) return true;
            if (login_password == string.Empty) return true;
            return false;
        }

        #endregion

        /// <summary>
        /// 登入的觸發事件
        /// </summary>
        public void LoginTrigger()
        {
            //輸入資料確認
            if (LoginData())
            {
                //確認資料庫連接物件建立
                SqlTool sqlTool = new SqlTool();
                //來源與資料庫比對
                if (sqlTool.LoginBool(login_account,login_password))
                {
                    System.Diagnostics.Debug.WriteLine("登入成功");
                    Session["loginState"] = login_account;
                    Response.Write("<script>alert('登入成功');history.back();</script>");
                }
                else
                {
                    Response.Write("<script>alert('登入失敗');</script>");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("登入資料未填完整");
            }
        }



    }
}