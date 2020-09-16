using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SudokuWeb
{
    public class SqlTool
    {
        
        #region 資料庫
        /// <summary>
        /// 資料庫串聯字串
        /// </summary>
        const string connect = "TConnectionString";
        #region 會員資料

        const string dataSheet = "memberData";//"dbo.member";

        public const string account = "account";//"username";
        const string password =  "password";
        public const string username = "username";//"name";
        public const string email = "email";
        const string address = "address";
        const string num = "num";//integral
        const string authority = "GM";//authority

        #endregion

        #endregion

        public SqlTool()
        {
            JoinData();
        }

        private SqlConnection connection;
        
        /// <summary>
        /// 資料庫連接物件建立
        /// </summary>
        public void JoinData()
        {
            //是否已經有建立過物件
            if (connection != null) return;
            //是否有連接字串
            if (connect == string.Empty) return;
            //取得資料庫的連接資串
            string s_data = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[connect].ConnectionString;
            //建立資料庫的連接物件
            connection = new SqlConnection(s_data);
        }
        
        /// <summary>
        /// 檢查資料是否存在
        /// </summary>
        /// <param name="field">欄位名稱</param>
        /// <param name="data">檢查的資料</param>
        /// <returns></returns>
        public bool Check(string field,string data)
        {
            //回傳用布林
            bool isOk = false;
            //SQL資料庫語法
            string s_sql = 
                $"SELECT "+ field + 
                " FROM " + SqlTool.dataSheet + 
                " WHERE " + field + "='" + data + "'";
            
            try
            {
                //輸入命令給資料庫
                SqlCommand command = new SqlCommand(s_sql, connection);
                //開啟資料庫連接
                connection.Open();
                //讀取資料庫命令結果的資料
                SqlDataReader reader = command.ExecuteReader();

                //判斷是否有一筆或多筆資料
                if (reader.HasRows)
                    //取得第一列或下一列資料
                    if (reader.Read())
                        isOk = true;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("資料庫查詢錯誤");
                isOk = false;
            }
            connection.Close();
            return isOk;
        }
        /// <summary>
        /// 登入資料比對
        /// </summary>
        /// <param name="account">帳號資料來源</param>
        /// <param name="password">密碼資料來源</param>
        /// <returns>相同=true;不相同=false</returns>
        public bool LoginBool(string account, string password)
        {
            //回傳用布林值
            bool isOk = false;
            //SQL資料庫語法 查詢登入帳號資料
            string s_sql =
                $"SELECT " + SqlTool.account + "," + SqlTool.password
                + " FROM " + SqlTool.dataSheet
                + " WHERE " + SqlTool.account + "='" + account + "'";

            try
            {
                //輸入命令給資料庫
                SqlCommand command = new SqlCommand(s_sql, connection);

                //開啟資料庫連接
                connection.Open();
                //讀取資料庫命令結果的資料
                SqlDataReader reader = command.ExecuteReader();

                //判斷是否有一筆或多筆資料
                if (reader.HasRows)
                    //取得第一列或下一列資料
                    if (reader.Read())
                        //判斷密碼資料是否相同
                        if (reader[SqlTool.password].ToString() == password)
                            isOk = true;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("資料庫查詢錯誤");
                isOk = false;
            }

            //關閉資料庫連接
            connection.Close();

            return isOk;
        }

        /// <summary>
        /// 新增會員資料
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool RegisteredBool(string account, string password, string name, string email,string address)
        {
            bool isOk = false;

            if (account == string.Empty && password == string.Empty && name == string.Empty && email == string.Empty)
                return isOk;

            string s_sql =
                $"insert into " + SqlTool.dataSheet + "(" + SqlTool.account + "," + SqlTool.password + ","  + SqlTool.username + "," + SqlTool.email + "," + SqlTool.address + ", " + SqlTool.num + ", "  + SqlTool.authority + ")" +
                "values(@" + SqlTool.account + ",@" + SqlTool.password + ",@" + SqlTool.username + ",@" + SqlTool.email + ",@" + SqlTool.address + ",@" + SqlTool.num + ",@" + SqlTool.authority + ")";

            try
            {
                isOk = true;
                SqlCommand command = new SqlCommand(s_sql, connection);
                connection.Open();

                command.Parameters.Add("@"+ SqlTool.account, SqlDbType.NVarChar);
                command.Parameters["@"+ SqlTool.account].Value = account;

                command.Parameters.Add("@"+ SqlTool.password, SqlDbType.NVarChar);
                command.Parameters["@"+ SqlTool.password].Value = password;

                command.Parameters.Add("@"+ SqlTool.username, SqlDbType.NVarChar);
                command.Parameters["@"+ SqlTool.username].Value = name;

                command.Parameters.Add("@"+ SqlTool.email, SqlDbType.NVarChar);
                command.Parameters["@"+ SqlTool.email].Value = email;

                command.Parameters.Add("@" + SqlTool.address, SqlDbType.NVarChar);
                command.Parameters["@" + SqlTool.address].Value = address;

                command.Parameters.Add("@"+ SqlTool.num, SqlDbType.Int);
                command.Parameters["@"+ SqlTool.num].Value = 1;

                command.Parameters.Add("@"+ SqlTool.authority, SqlDbType.Bit);
                command.Parameters["@"+ SqlTool.authority].Value = true;

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                isOk = false;
            }
            return isOk;
        }

        public static bool InquireBool(string account, string email)
        {
            //回傳用布林值
            bool isOk = false;
            //SQL資料庫語法 查詢登入帳號資料
            string s_sql =
                $"SELECT " + SqlTool.account + "," + SqlTool.email
                + " FROM " + SqlTool.dataSheet
                + " WHERE " + SqlTool.account + "='" + account + "'";

            try
            {
                //輸入命令給資料庫
                SqlCommand command = new SqlCommand(s_sql, connection);

                //開啟資料庫連接
                connection.Open();
                //讀取資料庫命令結果的資料
                SqlDataReader reader = command.ExecuteReader();

                //判斷是否有一筆或多筆資料
                if (reader.HasRows)
                    //取得第一列或下一列資料
                    if (reader.Read())
                        //判斷密碼資料是否相同
                        if (reader[SqlTool.email].ToString() == email)
                            isOk = true;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("資料庫查詢錯誤");
                isOk = false;
            }

            //關閉資料庫連接
            connection.Close();

            return isOk;
        }

        public static void SendAutomatedEmail(string ReceiveMail)
        {
            System.Net.Mail.MailMessage MyMail = new System.Net.Mail.MailMessage();
            MyMail.From = new System.Net.Mail.MailAddress("寄件者信箱");
            MyMail.To.Add(ReceiveMail); //設定收件者Email
            //MyMail.Bcc.Add("密件副本的收件者Mail"); //加入密件副本的Mail          
            MyMail.Subject = "Email Test";
            MyMail.Body = "<h1>HIHI</h1>"; //設定信件內容
            MyMail.IsBodyHtml = true; //是否使用html格式
            System.Net.Mail.SmtpClient MySMTP = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            MySMTP.Credentials = new System.Net.NetworkCredential("寄件者信箱帳號", "寄件者信箱密碼");
            try
            {
                MySMTP.EnableSsl = true;
                MySMTP.Send(MyMail);
                MyMail.Dispose(); //釋放資源
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}