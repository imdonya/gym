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

        //************************************خدمات درخواستی******************************


        public Int64 gheymat_f5 { get; set; }
        public Int64 PersonId_F9 { get; set; }
        public DateTime darkhastdateTime_F6 { get; set; }
        public Int64 F11 { get; set; }
        public BinderType F12 { get; set; }
        public string unit_F15 { get; set; }
        public Int64 tedadJalase_F16 { get; set; }
        public Int64 JalasatUse_F17 { get; set; }
        public Int64 Jalasatrem_F18 { get; set; }
        public DateTime startdateTime_F20 { get; set; }
        public Int64 rahbarId_F27 { get; set; }
        public Int64 dyn883Id_F29 { get; set; }
        public DateTime EndTime_F31 { get; set; }
        public Int64 tdaddarkhast_F33 { get; set; }
        public Int64 tedadrem_F35 { get; set; }
        public Int64 tarefeId_F36 { get; set; }      
        public Int64 Price_F38 { get; set; }
        public string ChainId_F43{ get; set; }
        public string KhedmatName_F46 { get; set; }
        
        public Int64 MaxFreezDay_F55 { get; set; }
        public DateTime DefaultEndTime_F53 { get; set; }

        public Int64 PayAmount_F59 { get; set; }
        public Int64 OffPerc_F61 { get; set; }
        public Int64 OffAmount_f62 { get; set; }
        public Int64 MustPayAmount_F63 { get; set; }
        public Int64 Bedehkar_F64 { get; set; }
        public string CoachMoney_F68 { get; set; }
       
        public Int64 Bedehkar_F91 { get; set; }
        public Int64 ArzeshAfzodeh_F133 { get; set; }

        public static bool AddServiceFile(billModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);

            if (con.State != ConnectionState.Open) con.Open();

            string cm = "insert into dyn_859(  F5, F9,  F11,F12, F15, F16, F17, F18, F20 , F27, F29, F31, F33, F35, F36,  F38, F43, F46, F49, F52 , F53, F54, F55, F59, F61, F62, F63, F64 ,F68,F72,F73,F75, F85,F86,F87,F88,F91, F133 ) values " +
                "(@gheymat_f5,@PersonId_F9,2,'True',@unit_F15,@tedadJalase_F16,0,@JalasatRem_F18,@startdateTime_F20 ,1100005500000000103, 1100008830000000004, @EndTime_F31,1,1,@tarefeId_F36, @Price_F38, @ChainId_F43, @KhedmatName_F46, 0, 0, @DefaultEndTime_F53, 0, @MaxFreezDay_F55, @PayAmount_F59, @OffPerc_F61, @OffAmount_f62, @MustPayAmount_F63, @Bedehkar_F64, @CoachMoney_F68, 0,0,0,0,0,0,0, @Bedehkar_F91, @ArzeshAfzodeh_F133 )";
            SqlCommand command = new SqlCommand(cm, con);
            command.Parameters.AddWithValue("@gheymat_f5", model.gheymat_f5);
            command.Parameters.AddWithValue("darkhastdateTime_F6", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
            command.Parameters.AddWithValue("startdateTime_F20", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
            command.Parameters.AddWithValue("EndTime_F31", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
            command.Parameters.AddWithValue("@PersonId_F9", model.PersonId_F9);
            command.Parameters.AddWithValue("@F11", 2);
            command.Parameters.AddWithValue("@tedadJalase_F16", 12);
            command.Parameters.AddWithValue("@JalasatUse_F17", 0);
            command.Parameters.AddWithValue("@Jalasatrem_F18", 12);
            command.Parameters.AddWithValue("@unit_F15", model.unit_F15);
            command.Parameters.AddWithValue("@tarefeId_F36", model.tarefeId_F36);
            command.Parameters.AddWithValue("@Price_F38", model.Price_F38);
            command.Parameters.AddWithValue("@ChainId_F43", String.Empty);
            command.Parameters.AddWithValue("@KhedmatName_F46", model.KhedmatName_F46);
            command.Parameters.AddWithValue("@DefaultEndTime_F53", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
            command.Parameters.AddWithValue("@MaxFreezDay_F55", model.MaxFreezDay_F55);
            command.Parameters.AddWithValue("@PayAmount_F59", model.PayAmount_F59);
            command.Parameters.AddWithValue("@OffPerc_F61", model.OffPerc_F61);
            command.Parameters.AddWithValue("@OffAmount_f62", model.OffAmount_f62);
            command.Parameters.AddWithValue("@MustPayAmount_F63", model.MustPayAmount_F63);            
            command.Parameters.AddWithValue("@Bedehkar_F64", model.Bedehkar_F64);
            command.Parameters.AddWithValue("@CoachMoney_F68", model.CoachMoney_F68);
            command.Parameters.AddWithValue("@Bedehkar_F91", model.Bedehkar_F91);
            command.Parameters.AddWithValue("@ArzeshAfzodeh_F133", model.ArzeshAfzodeh_F133);



            Console.WriteLine(command.CommandText);

            command.ExecuteNonQuery();

            con.Close();


            return true;


        }

    }
}
