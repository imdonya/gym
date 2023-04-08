using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Scripting.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;


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
        public int Color { get; set; }
        public DateTime StartTime_F23 { get; set; }
        public DateTime EndTime_F25 { get; set; }
        public DateTime Zaman_F88 { get; set; }
        public string morabiName_F53 { get; set; }

        public int durationCount_F24 { get; set; }

        public int durationUnit_F30 { get; set; }

        public int jalaseCount_F28 { get; set; }

        public string tarefeCode { get; set; }

        public ErrorViewModel er { get; set; }

        static string ConUrl = "server=.\\PVSSQL2012; database=nid_Develop3.14;User ID = sa; Password=p@y@vist@123;";
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
                    service_name = dr["F51"].ToString(),
                    TarefeTitle = dr["F35"].ToString(),
                   
                    durationUnit_F30 = Convert.ToInt32(dr["F30"]),
                    durationCount_F24 = Convert.ToInt32(dr["F24"]),
                    jalaseCount_F28 = Convert.ToInt32(dr["F28"]),

                    tarefeCode = dr["F87"].ToString(),
                    //EndTime_F25 = Convert.ToDateTime(dr["F25"]),
                    //Zaman_F88 = Convert.ToDateTime(dr["F88"]),
                    //morabiName_F53 = dr["F53"].ToString(),
                    Selected = false,
                    Color= 0


                });

            }
            dr.Close();

            con.Close();

            return MyList;

        }


        public static List<TarefeModel> GetListJalasat(Int64 tarefeid)
        {

            SqlConnection con = new SqlConnection(ConUrl);
            con.Open();


            SqlCommand command = new SqlCommand("Select * from dyn_743_1 WHERE F91 = "+tarefeid, con);
            Console.WriteLine("cm:" + command);
            SqlDataReader dr = command.ExecuteReader();
            List<TarefeModel> MyList = new List<TarefeModel>();

            while (dr.Read())
            {
                MyList.Add(new TarefeModel
                {

                    //TarefeId = Convert.ToInt64(dr["Id"]),
                    TarefePrice = Convert.ToInt64(dr["F40"]),
                    //khedmatId = dr["F66"].ToString() != string.Empty ? Convert.ToInt64(dr["F66"]) : 0,
                    //service_name = dr["F51"].ToString(),
                    //TarefeTitle = dr["F35"].ToString(),

                    durationUnit_F30 = Convert.ToInt32(dr["F30"]),
                    durationCount_F24 = Convert.ToInt32(dr["F24"]),
                    jalaseCount_F28 = Convert.ToInt32(dr["F28"]),

                    //tarefeCode = dr["F87"].ToString(),
                    //EndTime_F25 = Convert.ToDateTime(dr["F25"]),
                    //Zaman_F88 = Convert.ToDateTime(dr["F88"]),
                    //morabiName_F53 = dr["F53"].ToString(),


                });

            }
            dr.Close();

            con.Close();

            return MyList;

        }



        public static TarefeModel Select()
        {
            return Select();
        }
        public static TarefeModel GreetingBtn_Click(TarefeModel model)
        {
            return model;
        }





        public class AccountMetaData
        {
            [ModelBinder(BinderType = typeof(CustomDateTimeModelBinder))]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Birthday { get; set; }
        }
        public class CustomDateTimeModelBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                var displayFormatString = bindingContext.ModelMetadata.DisplayFormatString;
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (!string.IsNullOrEmpty(displayFormatString) && !string.IsNullOrEmpty(value.FirstValue))
                {
                    displayFormatString = displayFormatString.Replace("{0:", "").Replace("}", "");
                    var date = DateTime.ParseExact(value.FirstValue, displayFormatString, CultureInfo.InvariantCulture);
                    bindingContext.Result = ModelBindingResult.Success(date);
                }
                return Task.CompletedTask;
            }
        }


    }


}
