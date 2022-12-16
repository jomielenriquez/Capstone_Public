using CAPSTONE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace CAPSTONE.Controllers.Repository
{
    public class SystemsRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["CAPSTONEEntities"].ConnectionString;
        public List<Menu> GetMenu(string acnttype)
        {
            var menu = new List<Menu>();
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_get_menu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                cmd.Parameters.AddWithValue("@acnttype", acnttype);
                da.Fill(dt);
                con.Close();
            }
            foreach(DataRow dr in dt.Rows)
            {
                menu.Add(
                    new Menu
                    {
                        Text = Convert.ToString(dr["Text"]),
                        icon = Convert.ToString(dr["icon"]),
                        tagid = Convert.ToString(dr["tagid"]),
                        action = Convert.ToString(dr["action"]),
                        controller = Convert.ToString(dr["controller"])
                    }
                );
            }

            return menu;
        }
        public CurrentUser GetCurrentUser(string acntuid)
        {
            var user = new CurrentUser();

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("prop_get_current_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@acntuid", acntuid);
                    da.Fill(dt);
                    con.Close();
                }

                user.fullname = Convert.ToString(dt.Rows[0]["fullname"]);
                user.acnttype = Convert.ToString(dt.Rows[0]["acnttype"]);
                user.uid= Convert.ToString(dt.Rows[0]["uid"]);
            }
            catch (Exception ex)
            {

            }

            return user;
        }
        public string LoginUser(string username, string password, string acnttype)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_login_user", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@acnttype", acnttype);
                da.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 0) return "Error";

            return Convert.ToString(dt.Rows[0]["uid"]);
        }
        public string getreport()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_get_report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string getdailyreport()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_get_daily_report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string get_total()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_total_violators", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            string Mess = dt.Rows[0]["return"].ToString();
            DataTable dt_list = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_total_violators_list", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt_list);
                con.Close();
            }

            string returnObject = "{\"Message\":\"" + Mess + "\", \"List\": " + JsonConvert.SerializeObject(dt_list) + "}";
            return returnObject;
        }
        public string get_total_today()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_total_violators_today", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            string Mess = dt.Rows[0]["return"].ToString();
            DataTable dt_list = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_total_violators_today_list", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt_list);
                con.Close();
            }

            string returnObject = "{\"Message\":\"" + Mess + "\", \"List\": " + JsonConvert.SerializeObject(dt_list) + "}";
            return returnObject;
        }

        public string get_violation()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_violation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string insert_ticketcitation(
            int tid,
            string fname,
            string address,
            string licenseno,
            string vehicletype,
            string placeofviolation,
            int violationid
            )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_insert_ticketcitation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@tid",tid );
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@licenseno", licenseno);
                    cmd.Parameters.AddWithValue("@vehicletype", vehicletype);
                    cmd.Parameters.AddWithValue("@placeofviolation", placeofviolation);
                    cmd.Parameters.AddWithValue("@violationid", violationid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
        public string insert_account(
            string fname,
            string mname,
            string lname,
            string username,
            string password,
            string acnttype
        )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("prop_insert_account", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@fname", fname );
                    cmd.Parameters.AddWithValue("@mname", mname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@acnttype", acnttype);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
        public string insert_citation(
            string fname,
            string address,
            string licneseno,
            string birthdate,
            string dateofapprehension,
            string placeofviolation,
            string violationid,
            string vehicletype,
            string classification,
            string plateno
        )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_insert_citation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@licneseno", licneseno);
                    cmd.Parameters.AddWithValue("@birthdate", birthdate);
                    cmd.Parameters.AddWithValue("@dateofapprehension", dateofapprehension);
                    cmd.Parameters.AddWithValue("@placeofviolation", placeofviolation);
                    cmd.Parameters.AddWithValue("@violationid", violationid);
                    cmd.Parameters.AddWithValue("@vehicletype", vehicletype);
                    cmd.Parameters.AddWithValue("@classification", classification);
                    cmd.Parameters.AddWithValue("@plateno", plateno);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
        public string delete_citation(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_delete_citation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
        public string GetUserFullName(string acntuid)
        {
            string fname = "";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("prop_get_current_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@acntuid", acntuid);
                    da.Fill(dt);
                    con.Close();
                }

                fname = Convert.ToString(dt.Rows[0]["fullname"]);
            }
            catch (Exception ex)
            {
                return "ERROR";
            }

            return fname;
        }
        public string proc_get_statistics()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_statistics", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string prop_get_confiscated_license()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_get_confiscated_license", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string proc_get_setteled_apprehensions()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_setteled_apprehensions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string proc_clear_citation(
            string tid,
            string clearedby
        )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_clear_citation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@tid", tid);
                    cmd.Parameters.AddWithValue("@clearedby", clearedby);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }

        public string proc_get_all_enforcer_account()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_all_enforcer_account", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }

        public string proc_update_account(
            string acntid,
            string fname,
            string mname,
            string lname,
            string username,
            string password

        )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_update_account", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@acntid", acntid);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@mname", mname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }

        public string prop_get_record_by_plateno(string platenumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_get_record_by_plateno", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@platenumber", platenumber);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }

        public string prop_get_compound()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("prop_get_compound", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string proc_get_monthly_report()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_monthly_report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string proc_get_weekly_report()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_weekly_report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string proc_get_daily_report()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_daily_report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }
        public string proc_update_user_location(string uid, string lat, string longi)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_update_user_location", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@lat", lat);
                    cmd.Parameters.AddWithValue("@long", longi);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
        public string proc_get_pda_location()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_get_pda_location", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        
        }
        public string proc_update_confiscated_clerk(
            string name,
            string licenseno,
            string dateofapprehension,
            string platenumber,
            string violationid,
            string editid
        )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_update_confiscated_clerk", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@licenseno", licenseno);
                    cmd.Parameters.AddWithValue("@dateofapprehension", dateofapprehension);
                    cmd.Parameters.AddWithValue("@platenumber", platenumber);
                    cmd.Parameters.AddWithValue("@violationid", violationid);
                    cmd.Parameters.AddWithValue("@editid", editid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
        public string proc_update_impounded_vehicle(
            string name,
            string dateofapprehension,
            string vehicle,
            string violationid,
            string editid
        )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_update_impounded_vehicle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dateofapprehension", dateofapprehension);
                    cmd.Parameters.AddWithValue("@vehicle", vehicle);
                    cmd.Parameters.AddWithValue("@violationid", violationid);
                    cmd.Parameters.AddWithValue("@editid", editid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
            return "SUCCESS";
        }
    }
}