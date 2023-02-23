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

namespace gym.Models
{
    public class billModel
    {
        public Int64 PersonId { get; set; }
        public Int64 PayMethod_F23 { get; set; }
        public string BillNum_F21 { get; set; }
        public float debtor_F31 { get; set; }
        public float creditor_F32 { get; set; }
        public DateTime dateTime_F4 { get; set; }
        public Int64 user_F16 { get; set; }
        public ErrorViewModel er { get; set; }


        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14; integrated security=true;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";
        

        public static billModel AddBill(billModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);
            con.Open();
            SqlCommand command = new SqlCommand("insert into dyn_1003 values (@PersonId, @PayMethod_F23, @BillNum_F21,@debtor_F31, @creditor_F32, @dateTime_F4, @user_F16)", con);
            command.Parameters.AddWithValue("@PersonId_F5", model.PersonId);
            command.Parameters.AddWithValue("@PayMethod_F23", model.PayMethod_F23);
            command.Parameters.AddWithValue("@BillNum_F21", model.BillNum_F21);
            command.Parameters.AddWithValue("@debtor_F31", model.debtor_F31);
            command.Parameters.AddWithValue("@creditor_F32", model.creditor_F32);
            command.Parameters.AddWithValue("@dateTime_F4", model.dateTime_F4);
            command.Parameters.AddWithValue("@user_F16", model.user_F16);



            con.Open();

            con.Close();
            return AddBill(model);


        }
    }
}
