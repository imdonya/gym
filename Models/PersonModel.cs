using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace gym.Models
{
    public class PersonModel
    {

        public Int64 PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonCode { get; set; }

        static string ConUrl = "server=DESKTOP-CE0SVTO\\PVSSQL2012; database=nid_Develop3.14; integrated security=true;";
        //static string ConUrl = "server=.\\ELCAMSQLSERVER; database=nid_Develop3.14; integrated security=true;";

        public static PersonModel GetInfo(Int64 personId)
        {

            SqlConnection con = new SqlConnection(ConUrl);
            con.Open();


            SqlCommand command = new SqlCommand("Select * from dyn_731 WHERE ID =" + personId, con);
            Console.WriteLine("cm:" + command);
            SqlDataReader dr = command.ExecuteReader();

            dr.Read();

            PersonModel _personModel = new PersonModel();

            _personModel.PersonId = personId;
            _personModel.PersonName = dr["F27"].ToString();
            _personModel.PersonCode = dr["F7"].ToString();


            dr.Close();
            con.Close();

            return _personModel;

        }
    }


}
