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
    public class SanadModel
    {

        
        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14;User ID = sa; Password=p@y@vist@123;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";
        public Int64  F1_KolHesabdari { get; set; }
        public Int64 F2_MoeenHesabdari { get; set; }
        public Int64 F3_TafzilHesabdari { get; set; }
        public string F4_Sharh { get; set; }
        public Int64 F5_MablaghBedehkar { get; set; }
        public Int64 F6_MablaghBestankar { get; set; }
        public Int64 F7_FactorId { get; set; }
        public Int64 F8_Dyn859ID { get; set; }
        public Int64 F9_Babat0 { get; set; }
        public Int64 F9_Babat { get; set; }
        public Int64 F11_personID731 { get; set; }
        public Int64 F12_SabtKonandeh { get; set; }
        public DateTime F13_Zamansabt { get; set; }
        public string F14_ChainID { get; set; }
        public bool F16_ShowinFac { get; set; }
        public bool F17_sabtshode { get; set; }
        public bool F18_batelshode { get; set; }
        public Int64 F20_bedehkar_bestankar { get; set; }
        public Int64 F23_ArzeshAfsode { get; set; }
        public Int64 F25_KhedmatGroupID { get; set; }
        public bool F26_Tasfieshode { get; set; }
        public int F28_MoeenCodeHesadari { get; set; }
        public int F28_2TafzilCodeHesabdari { get; set; }
        public int F32_kolCodeHesabdari { get; set; }
        public int F33_gorohHesabdari { get; set; }        
        public string F34_markazHazine { get; set; }
     
          
            

        //************************************سند******************************

        public static bool AddSanad(SanadModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);

            if (con.State != ConnectionState.Open) con.Open();

            string cm = "INSERT INTO dyn_1030(Id, F1,F2,F3,F4,F5,F6,F7,F8,F9,F11,F12,F13,F14,F16,F17,F18,F20,F23,F25,F26,F28,F28_2,F32, F33,F34,F37 ) values " +
                "((NEXT VALUE FOR idseq_$1100013500000001030), @F1_KolHesabdari,@F2_MoeenHesavdari," +

                "(SELECT Id as F3_TafzilHesabdari FROM [dbo].[dyn_1029] WHERE F4 = @personId)," +

                "@F4_Sharh,@F5_MablaghBedehkar,@F6_MablaghBestankar,@F7_FactorId,@F8_Dyn859ID,0," +
                "@F11_personID731,@F12_SabtKonandeh,@F13_Zamansabt,@F14_ChainID,@F16_ShowinFac,@F17_sabtshode,@F18_batelshode,@F20_bedehkar_bestankar," +
                "@F23_ArzeshAfsode,@F25_KhedmatGroupID,@F26_Tasfieshode,@F28_MoeenCodeHesadari,@F28_2TafzilCodeHesabdari,@F32_kolCodeHesabdari,@F33_gorohHesabdari," +
                "@F34_markazHazine, '')";
            SqlCommand command = new SqlCommand(cm, con);
            command.Parameters.AddWithValue("@F1_KolHesabdari ", model.F1_KolHesabdari);
            command.Parameters.AddWithValue("@F2_MoeenHesavdari ", model.F2_MoeenHesabdari);
            command.Parameters.AddWithValue("@personId ", model.F11_personID731);
            command.Parameters.AddWithValue("@F4_Sharh ", model.F4_Sharh);
            command.Parameters.AddWithValue("@F5_MablaghBedehkar ", model.F5_MablaghBedehkar);
            command.Parameters.AddWithValue("@F6_MablaghBestankar ", model.F6_MablaghBestankar);
            command.Parameters.AddWithValue("@F7_FactorId ", model.F7_FactorId);
            command.Parameters.AddWithValue("@F8_Dyn859ID ", model.F8_Dyn859ID);
            command.Parameters.AddWithValue("@F9_Babat0 ", 0);
            command.Parameters.AddWithValue("@F11_personID731 ", model.F11_personID731);
            command.Parameters.AddWithValue("@F12_SabtKonandeh ", model.F12_SabtKonandeh);
            command.Parameters.AddWithValue("@F13_Zamansabt", model.F13_Zamansabt);
            command.Parameters.AddWithValue("@F14_ChainID ", model.F14_ChainID);
            command.Parameters.AddWithValue("@F16_ShowinFac ", model.F16_ShowinFac);
            command.Parameters.AddWithValue("@F17_sabtshode ", 1);
            command.Parameters.AddWithValue("@F18_batelshode ", 0);
            command.Parameters.AddWithValue("@F20_bedehkar_bestankar ", model.F6_MablaghBestankar - model.F5_MablaghBedehkar);
            command.Parameters.AddWithValue("@F23_ArzeshAfsode ", -1);  
            command.Parameters.AddWithValue("@F25_KhedmatGroupID ", model.F25_KhedmatGroupID);
            command.Parameters.AddWithValue("@F26_Tasfieshode ", 0);
            command.Parameters.AddWithValue("@F28_MoeenCodeHesadari ", model.F28_MoeenCodeHesadari);
            command.Parameters.AddWithValue("@F28_2TafzilCodeHesabdari ", model.F28_2TafzilCodeHesabdari);
            command.Parameters.AddWithValue("@F32_kolCodeHesabdari ", model.F32_kolCodeHesabdari);
            command.Parameters.AddWithValue("@F33_gorohHesabdari ", model.F33_gorohHesabdari);
            command.Parameters.AddWithValue("@F34_markazHazine ", model.F34_markazHazine);





            Console.WriteLine(command.CommandText);

            command.ExecuteNonQuery();

            con.Close();


            return true;


        }

    }
}
