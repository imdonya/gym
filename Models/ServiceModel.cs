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
    public class ServiceModel
    {

        public Int64 ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        
        public bool NoTaradod { get; set; }   
        public bool IsActive { get; set; }
        public bool ShowInUI { get; set; }
        public ErrorViewModel er { get; set; }

        static string ConUrl = "server=.\\PVSSQL2012; database=nid_Develop3.14;User ID = sa; Password=p@y@vist@123;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";

        public static List<ServiceModel> GetList()
        {

            SqlConnection con = new SqlConnection(ConUrl);
            con.Open();


            SqlCommand command = new SqlCommand("Select * from dyn_979", con);
            Console.WriteLine("cm:" + command);
            SqlDataReader dr = command.ExecuteReader();
            List<ServiceModel> MyList = new List<ServiceModel>();

            while (dr.Read())
            {
                MyList.Add(new ServiceModel
                {
                    ServiceId = Convert.ToInt64(dr["Id"]),
                    ServiceTitle = dr["F1"].ToString(),
                    NoTaradod = Convert.ToBoolean(dr["F18"]),
                    IsActive = Convert.ToBoolean(dr["F28"]),
                    ShowInUI = Convert.ToBoolean(dr["F29"])



                });

            }
            dr.Close();
           
            con.Close();

            return MyList;

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
