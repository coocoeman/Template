using SudokuWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ()
            {
                if (Request.Form["account"] != null && Request.Form["email"] != null)
                {
                    InquireTrigger();
                }
            }
        }


        /// <summary>
        /// 判斷登入的帳號與密碼
        /// </summary>
        private string inquire_account, inquire_email;

        /// <summary>
        /// 登入資料來源確認是否正確
        /// </summary>
        /// <returns></returns>
        private bool InquireData()
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
            inquire_account = $"" + Request.Form["account"];
            inquire_email = $"" + Request.Form["email"];
        }

        /// <summary>
        /// 判斷登入資料是否為空或空白
        /// </summary>
        /// <returns></returns>
        private bool DataEmpty()
        {
            if (inquire_account == string.Empty) return true;
            if (inquire_email == string.Empty) return true;
            return false;
        }

        public void InquireTrigger()
        {
            //輸入資料確認
            if (InquireData())
            {
                //確認資料庫連接物件建立
                SqlTool sqlTool = new SqlTool();
                //來源與資料庫比對
                if (sqlTool.InquireBool(inquire_account, inquire_email))
                {
                    System.Diagnostics.Debug.WriteLine("查詢成功");
                    sqlTool.SendAutomatedEmail(inquire_email);
                    Response.Write("<script>alert('郵件已寄出');</script>");
                    Response.Redirect("Login");
                }
                else
                {
                    Response.Write("<script>alert('查詢失敗');</script>");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("查詢資料未填完整");
            }
        }
    }
}