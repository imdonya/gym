using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Scripting.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace gym.Models
{
    public class RequestServicModel
    {

        //************************************خدمات درخواستی******************************
        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14; User ID = sa; Password=p@y@vist@123;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";

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
        public string ChainId_F43 { get; set; }
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

        public static Int64 AddRequestServic(RequestServicModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);

            if (con.State != ConnectionState.Open) con.Open();

            string cm = "insert into dyn_859(Id, F5,F6, F9,  F11,F12, F15, F16, F17, F18, F20 , F27, F29, F31, F33, F35, F36,  F38, F43, F46, F49, F52 , F53, F54, F55, F59, F61, F62, F63, F64 ,F68,F72,F73,F75, F85,F86,F87,F88,F91, F127, F133 ) " +
                " OUTPUT Inserted.Id " +
                " values ((NEXT VALUE FOR idseq_$1100013500000000859),@gheymat_f5,@darkhastdateTime_F6 ,@PersonId_F9,2,'True',@unit_F15,@tedadJalase_F16,0,@JalasatRem_F18,@startdateTime_F20 ,1100005500000000103, 1100008830000000004, @EndTime_F31,1,1,@tarefeId_F36, @Price_F38, @ChainId_F43, @KhedmatName_F46, 0, 0, @DefaultEndTime_F53, 0, @MaxFreezDay_F55, @PayAmount_F59, @OffPerc_F61, @OffAmount_f62, @MustPayAmount_F63, @Bedehkar_F64, @CoachMoney_F68, 0,0,0,0,0,0,0, @Bedehkar_F91,@TaradodTime_F127 , @ArzeshAfzodeh_F133 )";
            SqlCommand command = new SqlCommand(cm, con);
            command.Parameters.AddWithValue("@gheymat_f5", model.gheymat_f5);
            command.Parameters.AddWithValue("@darkhastdateTime_F6", model.darkhastdateTime_F6);
            command.Parameters.AddWithValue("@startdateTime_F20", model.startdateTime_F20);
            command.Parameters.AddWithValue("@EndTime_F31", model.EndTime_F31);
            command.Parameters.AddWithValue("@PersonId_F9", model.PersonId_F9);
            command.Parameters.AddWithValue("@F11", 2);
            command.Parameters.AddWithValue("@tedadJalase_F16", 12);
            command.Parameters.AddWithValue("@JalasatUse_F17", 0);
            command.Parameters.AddWithValue("@Jalasatrem_F18", 12);
            command.Parameters.AddWithValue("@unit_F15", model.unit_F15);
            command.Parameters.AddWithValue("@tarefeId_F36", model.tarefeId_F36);
            command.Parameters.AddWithValue("@Price_F38", model.Price_F38);
            command.Parameters.AddWithValue("@ChainId_F43", model.ChainId_F43);
            command.Parameters.AddWithValue("@KhedmatName_F46", model.KhedmatName_F46);
            command.Parameters.AddWithValue("@DefaultEndTime_F53", model.EndTime_F31);
            command.Parameters.AddWithValue("@MaxFreezDay_F55", model.MaxFreezDay_F55);
            command.Parameters.AddWithValue("@PayAmount_F59", model.PayAmount_F59);
            command.Parameters.AddWithValue("@OffPerc_F61", model.OffPerc_F61);
            command.Parameters.AddWithValue("@OffAmount_f62", model.OffAmount_f62);
            command.Parameters.AddWithValue("@MustPayAmount_F63", model.MustPayAmount_F63);
            command.Parameters.AddWithValue("@Bedehkar_F64", model.Bedehkar_F64);
            command.Parameters.AddWithValue("@CoachMoney_F68", model.CoachMoney_F68);
            command.Parameters.AddWithValue("@Bedehkar_F91", model.Bedehkar_F91); 
            command.Parameters.AddWithValue("@TaradodTime_F127", DateTime.Now.ToString("yyyy/mm/dd H:m")); 
            command.Parameters.AddWithValue("@ArzeshAfzodeh_F133", model.ArzeshAfzodeh_F133);

            Console.WriteLine(command.CommandText);

            object obj = command.ExecuteScalar();

            con.Close();




            if (obj != null)
                return Convert.ToInt64(obj);
            else
                return -1;

        }



    }


}
