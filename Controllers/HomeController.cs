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

namespace gym.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public static List<TarefeModel> tarefeModel = new List<TarefeModel>();
        public static Int64 persenId;
        public static PersonModel personInfo;
        public static billModel factorModel;

        public static dynamic mymodel = new ExpandoObject();
        public static bool firstRun;

        public void init()
        {

            persenId = 1037007310000000103;

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














        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


        }


    }
}