using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using RestAPI.Models;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Http;

namespace RestAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List <Users> Get()
        {
            DB db = new DB();
            DataTable dt = new DataTable();

            List<Users> userDetails = new List<Users>();
            Users userModel = new Users();


            using (SqlConnection sqlConn = db.DBConnection())
            {
                sqlConn.Open();

                String qry = "SELECT * FROM users";
                SqlDataAdapter SqlData_UserList = new SqlDataAdapter(qry, sqlConn);
                SqlData_UserList.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    userDetails.Add(new Users
                    {
                        UserID = Convert.ToInt32(dt.Rows[i][0].ToString()),
                        UserName = dt.Rows[i][1].ToString(),
                        UserEmail = dt.Rows[i][2].ToString(),
                        UserMobile = dt.Rows[i][3].ToString(),
                        UserDepartment = dt.Rows[i][6].ToString(),
                        UserType = dt.Rows[i][7].ToString()

                    });
                }


                return userDetails;
            }
        }

        // GET api/values/5
        public List<Users> Get(int id)
        {

            DB db = new DB();
            DataTable dt = new DataTable();

            List<Users> userDetails = new List<Users>();
            Users userModel = new Users();


            using (SqlConnection sqlConn = db.DBConnection())
            {
                sqlConn.Open();

                String qry = "SELECT * FROM users WHERE UserID = "+id;
                SqlDataAdapter SqlData_UserList = new SqlDataAdapter(qry, sqlConn);
                SqlData_UserList.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    userDetails.Add(new Users
                    {
                        UserID = Convert.ToInt32(dt.Rows[0][0].ToString()),
                        UserName = dt.Rows[0][1].ToString(),
                        UserEmail = dt.Rows[0][2].ToString(),
                        UserMobile = dt.Rows[0][3].ToString(),
                        UserDepartment = dt.Rows[0][6].ToString(),
                        UserType = dt.Rows[0][7].ToString()

                    });
                }


                return userDetails;
            }


            
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Users users)
        {

            DB db = new DB();
            List<Users> ForgotDetails = new List<Users>();

            try
            {
                using (SqlConnection sqlConn = db.DBConnection())
                {
                    sqlConn.Open();
                    String qry = "INSERT INTO users(UserName,UserEmail,UserMobile,Password,ConfirmPassword,UserDepartment,UserType,SecretKey,Validation,UserImage) VALUES(@UserName,@UserEmail,@UserMobile,@Password,@ConfirmPassword,@UserDepartment,@UserType,@SecretKey,@Validation,@UserImage)";
                    SqlCommand mySqlcmd = new SqlCommand(qry, sqlConn);

                    mySqlcmd.Parameters.AddWithValue("@UserName", users.UserName);
                    mySqlcmd.Parameters.AddWithValue("@UserEmail", users.UserEmail);
                    mySqlcmd.Parameters.AddWithValue("@UserMobile", users.UserMobile);
                    mySqlcmd.Parameters.AddWithValue("@UserDepartment", users.UserDepartment);
                    mySqlcmd.Parameters.AddWithValue("@UserType", users.UserType);
                    mySqlcmd.Parameters.AddWithValue("@Password", "abc");
                    mySqlcmd.Parameters.AddWithValue("@ConfirmPassword", "abc");
                    mySqlcmd.Parameters.AddWithValue("@SecretKey", users.SecretKey);
                    mySqlcmd.Parameters.AddWithValue("@Validation", "true");
                    mySqlcmd.Parameters.AddWithValue("@UserImage", "NULL");

                    mySqlcmd.ExecuteNonQuery();

                    HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.Created, users);
                    responseMessage.Headers.Location = Request.RequestUri;

                    return responseMessage;

                }

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Data not inserted");
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
