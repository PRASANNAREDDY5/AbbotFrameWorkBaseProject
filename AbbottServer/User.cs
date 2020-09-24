using AbbottFrameWork;
using AbbottVO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using static AbbottFrameWork.StatusInfo;

namespace AbbottServer
{
    public class User
    {
        public StatusInfo status;
        public User(UserInfo uinfo)
        {
            status = new StatusInfo(uinfo);
        }
        public DataTable UserLogin(string UserName, string Password)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();

                string query = "select user_name, password from user_info where user_name = @uname and password = @pwd";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uname", UserName);
                cmd.Parameters.AddWithValue("@pwd", Password);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                status.errcode = 1;
                status.errmesg = ex.Message;
                status.rowcount = -1;
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public string CreateUser(UserVO uVO)
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                String query = "insert into user_info (user_name, email_id, phone_number, city) values(@uname, @eid, @gender, @pnumber, @city)";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@uname", uVO.user_name);
                cmd.Parameters.AddWithValue("@eid", uVO.email_id);
                cmd.Parameters.AddWithValue("@gender", uVO.gender);
                cmd.Parameters.AddWithValue("@pnumber", uVO.phone_number);
                cmd.Parameters.AddWithValue("@city", uVO.city);
                Int32 count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return "Inserted";
                }
                else
                {
                    return "Not Inserted";
                }
            }
            catch (Exception ex)
            {
                status.errcode = 1;
                status.errmesg = ex.Message;
                status.rowcount = -1;
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
        public DataTable GetServeyQuestions()
        {
            MySqlConnection Conn = Connection.GetConnection();
            try
            {
                Conn.Open();
                String query = "select sq.servey_questions_id, q.question_desc, ao.select_options, s.section_dec, av.score_yes from servey_questions sq, questions q, abbott_options ao, sections s, abbott_values av where sq.questions_id = q.questions_id and sq.option_id = ao.option_id and sq.section_id = s.section_id and sq.value_id = av.value_id;";
                MySqlCommand cmd = new MySqlCommand(query, Conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception ex)
            {
                status.errcode = 1;
                status.errmesg = ex.Message;
                status.rowcount = -1;
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
