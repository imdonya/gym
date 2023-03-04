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


        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14; integrated security=true;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;"
        public Int64  F1_KolHesabdari { get; set; }
        public Int64 F2_MoeenHesavdari { get; set; }
        public Int64 F3_TafzilHesabdari { get; set; }
        public string F4_Sharh { get; set; }
        public Int64 F5_MablaghBedehkar { get; set; }
        public Int64 F6_MablaghBestankar { get; set; }
        public Int64 F7_FactorNum { get; set; }
        public Int64 F8_Dyn859ID { get; set; }
        public Int64 F9_Babat0 { get; set; }
        public Int64 F9_Babat { get; set; }
        public Int64 F11_Dyn731ID { get; set; }
        public Int64 F12_SabtKonandeh { get; set; }
        public DateTime F13_Zamansabt { get; set; }
        public string F14_ChainID { get; set; }
        public bool F16_ShowinFac { get; set; }
        public bool F17_sabtshode { get; set; }
        public bool F18_batelshode { get; set; }
        public Int64 F20_bedehkar_bestankar { get; set; }
        public Int64 F23_ArzeshAfsode { get; set; }
        public Int64 F25_Xapp247ID { get; set; }
        public bool F26_Tasfieshode { get; set; }
        public Int64 F28_MoeenHesadari { get; set; }
        public Int64 F28_2TafzilHesabdari { get; set; }
        public Int64 F32_kolHesabdari { get; set; }
        public Int64 F33_gorohHesabdari { get; set; }        
        public Int64 F34_markazHazine { get; set; }
     
          
            

        //************************************سند******************************

        public static bool AddSanad(SanadModel model)
        {

            SqlConnection con = new SqlConnection(ConUrl);

            if (con.State != ConnectionState.Open) con.Open();

            string cm = "insert into dyn_1030( F1,F2,F3,F4,F5,F6,F7,F8,F9,F11,F12,F13,F14,F16,F17,F18,F20,F23,F25,F26,F28,F28_2,F32, F33,F34,F36,F27 ) values " +
                "(@F1_KolHesabdari,@F2_MoeenHesavdari,@F3_TafzilHesabdari,@F4_Sharh,@F5_MablaghBedehkar,@F6_MablaghBestankar,@F7_FactorNum,@F8_Dyn859ID,0," +
                "@F11_Dyn731ID,@F12_SabtKonandeh,@F13_Zamansabt,@F14_ChainID,@F16_ShowinFac,@F17_sabtshode,@F18_batelshode,@F20_bedehkar_bestankar," +
                "@F23_ArzeshAfsode,@F25_Xapp247ID,@F26_Tasfieshode,@F28_MoeenHesadari,@F28_2TafzilHesabdari,@F32_kolHesabdari,@F33_gorohHesabdari," +
                "@F34_markazHazine )";
            SqlCommand command = new SqlCommand(cm, con);
            command.Parameters.AddWithValue("@F1_KolHesabdari ", model.F1_KolHesabdari);
            command.Parameters.AddWithValue("@F2_MoeenHesavdari ", model.F2_MoeenHesavdari);
            command.Parameters.AddWithValue("@F3_TafzilHesabdari ", model.F3_TafzilHesabdari);
            command.Parameters.AddWithValue("@F4_Sharh ", model.F4_Sharh);
            command.Parameters.AddWithValue("@F5_MablaghBedehkar ", model.F5_MablaghBedehkar);
            command.Parameters.AddWithValue("@F6_MablaghBestankar ", model.F6_MablaghBestankar);
            command.Parameters.AddWithValue("@F7_FactorNum ", model.F7_FactorNum);
            command.Parameters.AddWithValue("@F8_Dyn859ID ", model.F8_Dyn859ID);
            command.Parameters.AddWithValue("@F9_Babat0 ", model.F9_Babat0);
            command.Parameters.AddWithValue("@F11_Dyn731ID ", model.F11_Dyn731ID);
            command.Parameters.AddWithValue("@F12_SabtKonandeh ", model.F12_SabtKonandeh);
            command.Parameters.AddWithValue("@F13_Zamansabt", DateTime.Now.ToString("yyyy/mm/dd HH:mm"));
            command.Parameters.AddWithValue("@F14_ChainID ", model.F14_ChainID);
            command.Parameters.AddWithValue("@F16_ShowinFac ", model.F16_ShowinFac);
            command.Parameters.AddWithValue("@F17_sabtshode ", model.F17_sabtshode);
            command.Parameters.AddWithValue("@F18_batelshode ", model.F18_batelshode);
            command.Parameters.AddWithValue("@F20_bedehkar_bestankar ", model.F20_bedehkar_bestankar);
            command.Parameters.AddWithValue("@F23_ArzeshAfsode ", model.F25_Xapp247ID);
            command.Parameters.AddWithValue("@F25_Xapp247ID ", model.F25_Xapp247ID);
            command.Parameters.AddWithValue("@F26_Tasfieshode ", model.F26_Tasfieshode);
            command.Parameters.AddWithValue("@F28_MoeenHesadari ", model.F28_MoeenHesadari);
            command.Parameters.AddWithValue("@F28_2TafzilHesabdari ", model.F28_2TafzilHesabdari);
            command.Parameters.AddWithValue("@F32_kolHesabdari ", model.F32_kolHesabdari);
            command.Parameters.AddWithValue("@F33_gorohHesabdari ", model.F33_gorohHesabdari);
            command.Parameters.AddWithValue("@F34_markazHazine ", model.F34_markazHazine);





            Console.WriteLine(command.CommandText);

            command.ExecuteNonQuery();

            con.Close();


            return true;


        }

    }
}
