using SudokuWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["account"] != null && Request.Form["password"] != null && Request.Form["ispassword"] != null && Request.Form["username"] != null && Request.Form["email"] != null && Request.Form["address"] != null)
            {
                SignupData();
            }
        }

        #region 註冊資料設定
        /// <summary>
        /// 會員資料
        /// </summary>
        private string signup_account, signup_password, signup_ispassword, signup_username, signup_email, signup_address;
        private bool SignupData()
        {
            SetData();
            if (DataEmpty()) return false;
            if (!DataOnly()) return false;
            return true;
        }
        /// <summary>
        /// 設定資料來源並判斷是否有值
        /// </summary>
        private void SetData()
        {
            signup_account = $"" + Request.Form["account"];
            signup_password = $"" + Request.Form["password"];
            signup_ispassword = $"" + Request.Form["ispassword"];
            signup_username = $"" + Request.Form["username"];
            signup_email = $"" + Request.Form["email"];
            signup_address = $"" + Request.Form["address"];
        }
        /// <summary>
        /// 判斷註冊資料是否為空或空白
        /// </summary>
        private bool DataEmpty()
        {
            if (signup_account == string.Empty) return true;
            if (signup_password == string.Empty) return true;
            if (signup_ispassword == string.Empty) return true;
            if (signup_username == string.Empty) return true;
            if (signup_email == string.Empty) return true;
            if (signup_address == string.Empty) return true;
            return false;
        }
        /// <summary>
        /// 判斷資料的唯一
        /// </summary>
        /// <returns>沒有重複=true</returns>
        private bool DataOnly()
        {
            SqlTool sqlTool = new SqlTool();
            if (sqlTool.Check(SqlTool.account, signup_account)) return false;
            if (sqlTool.Check(SqlTool.username, signup_username)) return false;
            if (sqlTool.Check(SqlTool.email, signup_email)) return false;
            return true;
        }

        #endregion
    
        /// <summary>
        /// 註冊的觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SignupTrigger(object sender, EventArgs e)
        {
            //輸入資料確認
            if (SignupData())
            {
                //確認資料庫連接物件建立
                SqlTool sqlTool = new SqlTool();
                //將輸入資料寫入資料庫
                if (sqlTool.RegisteredBool(signup_account, signup_password, signup_username, signup_email, signup_address))
                {
                    System.Diagnostics.Debug.WriteLine("資料庫寫入成功");
                    Response.Write("<script>alert('註冊成功');history.back();</script>");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("資料庫寫入失敗");
                    Response.Write("<script>alert('註冊失敗');</script>");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("資料有誤");
                Response.Write("<script>alert('資料有誤');</script>");
            }
        }


    }
}