using Microsoft.Scripting.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Data;

namespace gym.Models
{
    public class billModel
    {
        public DateTime dateTime_F4 { get; set; }
        public Int64 PersonId { get; set; }
        public float F6 { get; set; }
        public Int64 user_F16 { get; set; }
        public string PersonShowName_F21 { get; set; }
        public Int64 PayMethod_F23 { get; set; }
        public Int64 BedehBestan_F28 { get; set; }
        public float Bestankar_F31 { get; set; }
        public float Bedehkar_F32 { get; set; }
        public Int64 F33 { get; set; }
        public Int64 F36 { get; set; }
        public Int64 F37 { get; set; }
        public Int64 F38 { get; set; }
        public Int64 F41 { get; set; }
        public Int64 F36_2 { get; set; }
        public BinderType F48 { get; set; }
        public ErrorViewModel er { get; set; }


        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14; integrated security=true;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";
        

        public static bool AddBill(billModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);

            if(con.State != ConnectionState.Open) con.Open();

            string cm= "insert into dyn_1003( F4, F5, F6, F16, F21, F23, F28, F31, F32, F33, F36, F37, F38, F41, F36_2, F48) values(GETDATE(),@PersonId,-1,1100005500000000103,@FactorName_F21,@PayMethod_F23,@BedehBestan_F28,@Bestankar_F31,@Bedehkar_F32,3,0,0,0,0,0,'FALSE')";
            SqlCommand command = new SqlCommand(cm, con);
            command.Parameters.AddWithValue("@PersonId", model.PersonId);
            //command.Parameters.AddWithValue("@user_F16", 1100005500000000103);
            command.Parameters.AddWithValue("@FactorName_F21", model.PersonShowName_F21 + " - " + DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
            command.Parameters.AddWithValue("@PayMethod_F23", 2);
            command.Parameters.AddWithValue("@BedehBestan_F28", model.Bedehkar_F32 - model.Bestankar_F31);
            command.Parameters.AddWithValue("@Bestankar_F31", model.Bestankar_F31);
            command.Parameters.AddWithValue("@Bedehkar_F32", model.Bedehkar_F32);


            Console.WriteLine(command.CommandText);

            command.ExecuteNonQuery();

            con.Close();


            return true;


        }
    }
}
