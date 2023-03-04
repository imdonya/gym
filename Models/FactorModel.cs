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
    public class FactorModel
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


        public static bool AddBill(FactorModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);

            if (con.State != ConnectionState.Open) con.Open();

            string cm = "insert into dyn_1003( F4, F5, F6, F16, F21, F23, F28, F31, F32, F33, F36, F37, F38, F41, F36_2, F48) values(GETDATE(),@PersonId,-1,1100005500000000103,@FactorName_F21,@PayMethod_F23,@BedehBestan_F28,@Bestankar_F31,@Bedehkar_F32,3,0,0,0,0,0,'FALSE')";
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

      

        //************************************سند******************************

        //public static bool AddSanad(billModel model)
        //{

        //    SqlConnection con = new SqlConnection(ConUrl);

        //    if (con.State != ConnectionState.Open) con.Open();

        //    string cm = "insert into dyn_1030( F1,F2,F3,F4,F5,F6,F7,F8,F9,F11,F12,F13,F14,F15,F16,F17,F18,F19,F20,F21,F22,F23,F24,F25,F26,F28,F28_2, F29,F30,F31, F32, F33,F34,F36, F37,F38,F27 ) values " +
        //        "(@F1_KolHesabdari,@F2_MoeenHesavdari,@F3_TafzilHesabdari,@F4_,F5,F6,F7,F8,F9,F11,F12,F13,F14,F15,F16,F17,F18,F19,F20,F21,F22,F23,F24,F25,F26,F28,F28_2, F29,F30,F31, F32, F33,F34,F36, F37,F38,F27 )";
        //    SqlCommand command = new SqlCommand(cm, con);
        //    command.Parameters.AddWithValue("@gheymat_f5", model.gheymat_f5);
        //    command.Parameters.AddWithValue("darkhastdateTime_F6", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
        //    command.Parameters.AddWithValue("startdateTime_F20", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
        //    command.Parameters.AddWithValue("EndTime_F31", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
        //    command.Parameters.AddWithValue("@PersonId_F9", model.PersonId_F9);
        //    command.Parameters.AddWithValue("@F11", 2);
        //    command.Parameters.AddWithValue("@tedadJalase_F16", 12);
        //    command.Parameters.AddWithValue("@JalasatUse_F17", 0);
        //    command.Parameters.AddWithValue("@Jalasatrem_F18", 12);
        //    command.Parameters.AddWithValue("@unit_F15", model.unit_F15);
        //    command.Parameters.AddWithValue("@tarefeId_F36", model.tarefeId_F36);
        //    command.Parameters.AddWithValue("@Price_F38", model.Price_F38);
        //    command.Parameters.AddWithValue("@ChainId_F43", String.Empty);
        //    command.Parameters.AddWithValue("@KhedmatName_F46", model.KhedmatName_F46);
        //    command.Parameters.AddWithValue("@DefaultEndTime_F53", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
        //    command.Parameters.AddWithValue("@MaxFreezDay_F55", model.MaxFreezDay_F55);
        //    command.Parameters.AddWithValue("@PayAmount_F59", model.PayAmount_F59);
        //    command.Parameters.AddWithValue("@OffPerc_F61", model.OffPerc_F61);
        //    command.Parameters.AddWithValue("@OffAmount_f62", model.OffAmount_f62);
        //    command.Parameters.AddWithValue("@MustPayAmount_F63", model.MustPayAmount_F63);
        //    command.Parameters.AddWithValue("@Bedehkar_F64", model.Bedehkar_F64);
        //    command.Parameters.AddWithValue("@CoachMoney_F68", model.CoachMoney_F68);
        //    command.Parameters.AddWithValue("@Bedehkar_F91", model.Bedehkar_F91);
        //    command.Parameters.AddWithValue("@ArzeshAfzodeh_F133", model.ArzeshAfzodeh_F133);



        //    Console.WriteLine(command.CommandText);

        //    command.ExecuteNonQuery();

        //    con.Close();


        //    return true;


        //}

    }
}
