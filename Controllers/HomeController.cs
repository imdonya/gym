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

namespace gym.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public static List<TarefeModel> tarefeModel = new List<TarefeModel>();



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {

            tarefeModel = TarefeModel.GetList();

            return RedirectToAction("tariff");
        }
        public IActionResult tariff()
        {


            return View(tarefeModel);

        }
        public IActionResult bill()
        {


            return View(tarefeModel);

        }

        public IActionResult SelectBtn(TarefeModel model)
        {
            Int64 id = model.TarefeId;

            FlagBtn(id);

            return Ok();

        }

        public IActionResult ClearAllBtn()
        {

            ClearAllFlags();

            return RedirectToAction("tariff");

        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


        }



        private void FlagBtn(Int64 id)
        {

            foreach (var model in tarefeModel)
            {
                if (model.TarefeId == id)
                    model.Selected = true;

            }

        }

        private void ClearAllFlags()
        {
            foreach (var model in tarefeModel)
            {
                model.Selected = false;

            }
        }

    }
}