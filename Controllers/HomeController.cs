using gym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Http.Extensions;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using Microsoft.VisualBasic;

namespace gym.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public static List<TarefeModel> tarefeModel = new List<TarefeModel>();
        public static Int64 persenId;
        public static PersonModel personInfo;
        public static billModel factorModel;
        public DateAndTime DateAndTime;

        public static dynamic mymodel = new ExpandoObject();
        public static bool firstRun;
        public static TarefeModel servisInfo;
        public void init()
        {

            persenId = 1037007310000000103;
            DateTime.Now.ToString("yyyy/mm/dd HH:mm");
            
            tarefeModel = TarefeModel.GetList();
            personInfo = PersonModel.GetInfo(persenId);
            



            mymodel.tarefeList = tarefeModel;
            mymodel.personInfo = personInfo;

            
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {

            init();

            return RedirectToAction("tariff");
            //return View("tariff",mymodel);
        }
        public IActionResult tariff()
        {



            //mymodel = new ExpandoObject();



            

            return View(mymodel);

        }
        public IActionResult bill()
        {


            return View(mymodel);

        }
        [HttpPost]
        public IActionResult SelectBtn()
        {

            //Int64 id = model.TarefeId;

            Int64 id = Convert.ToInt64(Request.Form["BtnId"].ToString());

            //TarefeModel mm = mymodel.tarefeList;

            FlagBtn(id);

            return Ok();

        }

        public IActionResult ClearAllBtn()
        {

            ClearAllFlags();

            return RedirectToAction("tariff");

        }




        public void FlagBtn(Int64 id)
        {

            foreach (var model in mymodel.tarefeList)
            {
                if (model.TarefeId == id)
                    model.Selected = true;

            }

        }

        private void ClearAllFlags()
        {
            foreach (var model in mymodel.tarefeList)
            {
                model.Selected = false;

            }
        }


        public void SaveFactor()
        {
            Int64 id = Convert.ToInt64(Request.Form["PersonId"].ToString());


            foreach (var model in mymodel.tarefeList)
            {
                if (model.Selected)
                {
                    factorModel = new billModel();
                    factorModel.Bedehkar_F32 = model.TarefePrice;
                    factorModel.Bestankar_F31 = model.TarefePrice;
                    factorModel.PersonId = id;
                    factorModel.PersonShowName_F21 = mymodel.personInfo.PersonName;





                    billModel.AddBill(factorModel);
                }
            }

        }
        public void ServiceFile()
        {
            Int64 id = Convert.ToInt64(Request.Form["PersonId"].ToString());
            string servis_name = Request.Form["PersonId"].ToString();
           
            
            foreach (var model in mymodel.tarefeList)
            {
                if (model.Selected)
                {
                    factorModel = new billModel();
                    factorModel.gheymat_f5 = model.TarefePrice;
                    factorModel.PersonId_F9 = id;
                    factorModel.KhedmatName_F46 = model.service_name;
                    factorModel.unit_F15 = "جلسه";
                    factorModel.tarefeId_F36 = model.TarefeId;
                    factorModel.EndTime_F31 = model.EndTime_F25;
                    factorModel.MaxFreezDay_F55 = 0;  //!!!!!!!!!!
                    factorModel.PayAmount_F59 = model.TarefePrice;
                    factorModel.OffPerc_F61 = 0; //!!!
                    factorModel.OffAmount_f62 = 0;
                    factorModel.MustPayAmount_F63 = 0;
                    factorModel.Bedehkar_F64 = 0;
                    factorModel.CoachMoney_F68 = "0";  //!!!!!!!!!!!!
                    factorModel.Bedehkar_F91 = 0;
                    factorModel.ArzeshAfzodeh_F133 = 0;
                    factorModel.PersonShowName_F21 = mymodel.personInfo.PersonName;

                    billModel.AddServiceFile(factorModel);


                }
            }
            

        }

        private static void NewMethod(dynamic model)
        {
            factorModel.KhedmatName_F46 = model.service_name;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


        }


    }
}