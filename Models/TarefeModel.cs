using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace gym.Models
{
    public class TarefeModel
    {

        public Int64 TarefeId { get; set; }
        public Int64 TarefePrice { get; set; }
        public string TarefeTitle { get; set; }
        public Int64 khedmatId { get; set; }
        public string service_name { get; set; }
        public Int64 service_id { get; set; }
        public bool Selected { get; set; }
        public ErrorViewModel er { get; set; }
        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14; integrated security=true;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";

        public static List<TarefeModel> GetList()
        {

            SqlConnection con = new SqlConnection(ConUrl);
            con.Open();


            SqlCommand command = new SqlCommand("Select * from dyn_743", con);
            Console.WriteLine("cm:" + command);
            SqlDataReader dr = command.ExecuteReader();
            List<TarefeModel> MyList = new List<TarefeModel>();

            while (dr.Read())
            {
                MyList.Add(new TarefeModel
                {
                    service_id = -1,
                    TarefeId = Convert.ToInt64(dr["Id"]),
                    TarefePrice = Convert.ToInt64(dr["F40"]),
                    khedmatId = dr["F66"].ToString() != string.Empty ? Convert.ToInt64(dr["F66"]) : 0,
                    TarefeTitle = dr["F35"].ToString(),
                    Selected = false
                });

            }
            dr.Close();
            command = new SqlCommand("Select * from dyn_979", con);
            Console.WriteLine("cm:" + command);
            SqlDataReader dr1 = command.ExecuteReader();


            while (dr1.Read())
            {
                MyList.Add(new TarefeModel
                {
                    service_id = Convert.ToInt64(dr1["Id"]),
                    service_name = dr1["F1"].ToString()
                });

            }

            dr1.Close();
            con.Close();

            return MyList;

        }
        //public static List<Tariffdyn743Model> GetServiceList()
        //{

        //    SqlConnection con = new SqlConnection(ConUrl);
        //    con.Open();


        //    SqlCommand command = new SqlCommand("Select * from dyn_979", con);
        //    Console.WriteLine("cm:" + command);
        //    SqlDataReader dr = command.ExecuteReader();
        //    List<Tariffdyn743Model> dyn_979 = new List<Tariffdyn743Model>();

        //    while (dr.Read())
        //    {
        //        dyn_979.Add(new Tariffdyn743Model
        //        {
        //            service_id = Convert.ToDouble(dr["Id"]),
        //            service_F1 = dr["F1"].ToString()
        //        });

        //    }

        //    con.Close();

        //    return dyn_979;

        //}
        public static TarefeModel Select()
        {
            return Select();
        }
        public static TarefeModel GreetingBtn_Click(TarefeModel model)
        {
            return model;
        }
        //public static Tariffdyn743Model AddStudent(Tariffdyn743Model model)
        //{
        //    SqlConnection con = new SqlConnection(ConUrl);
        //    SqlCommand command = new SqlCommand("insert into Students values (@name, @family, @mobile)", con);
        //    command.Parameters.AddWithValue("@name", model.F40);
        //    command.Parameters.AddWithValue("@price", model.F40);
        //    command.Parameters.AddWithValue("@cat", model.F40);
        //    con.Open();
        //    command.ExecuteNonQuery();
        //    con.Close();
        //    return model;
        //}
    }


}
