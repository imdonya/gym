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
        public static FactorModel factorModel;
        public static RequestServicModel requestServicModel;
        public static SanadModel sanadModel;
        public DateAndTime DateAndTime;

        public static dynamic mymodel = new ExpandoObject();
        public static bool firstRun;
        public static TarefeModel servisInfo;
        public static int PayMethod_NAGHD = 1;
        public static int PayMethod_POS = 2;
        public string chainId;
        public void init()
        {

            persenId = 1037007310000000101; // 1037007310000000103;    1036007310000000100
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

        public string GetNextColor(int index)
        {
            int n = 9;
            int R = 255;
            int G = 255;
            int B = 255;
            int step = n / 3;
            string colorCode;

                if (index <= n / 3 )
                {
                    R = -(index - n / 3) * step;
                    G = 0;
                    B = (index - n / 3) * step;

                }
                else if(index > n / 3 & index <= 2 * n / 3)
                {
                    R = 0;
                    G =  ( index - n / 3) * step;
                    B = -(index - n / 3) * step;
                }
                else if ( index > 2 * n / 3)
                {
                    R = (index - n / 3) * step;
                    G = -(index - n / 3) * step;
                    B = 0;

                }
                colorCode = R.ToString("X") + B.ToString("X") + G.ToString("X");

                return colorCode;
            
        }

        #region Methods

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

        public void CRUD()
        {
            Int64 personId = Convert.ToInt64(Request.Form["PersonId"].ToString());
            Int64 factorId;
            Int64 requestServiceId;
            chainId = Guid.NewGuid().ToString();

            factorId = SaveFactor(personId);

            requestServiceId = SaveRequestService(personId);

            SaveSanad(personId, factorId, requestServiceId);

        }


        public Int64 SaveFactor(Int64 personId)
        {
            Int64 factorId = -1;

            foreach (var model in mymodel.tarefeList)
            {
                if (model.Selected)
                {
                    factorModel = new FactorModel();
                    factorModel.Bedehkar_F32 = model.TarefePrice;
                    factorModel.Bestankar_F31 = model.TarefePrice;
                    factorModel.PersonId = personId;
                    factorModel.PersonShowName_F21 = mymodel.personInfo.PersonName;

                    factorId = FactorModel.AddBill(factorModel);
                }
            }

            return factorId;
        }

        public Int64 SaveRequestService(Int64 personId)
        {
          
            Int64 requestServiceId = -1;
            
            foreach (var model in mymodel.tarefeList)
            {
                if (model.Selected)
                {
                    requestServicModel = new RequestServicModel();
                    requestServicModel.PersonId_F9 = personId;
                    requestServicModel.gheymat_f5 = model.TarefePrice;
                    requestServicModel.KhedmatName_F46 = model.service_name;
                    requestServicModel.unit_F15 = "جلسه";
                    requestServicModel.tarefeId_F36 = model.TarefeId;
                    requestServicModel.startdateTime_F20 = DateTime.Now;
                    requestServicModel.darkhastdateTime_F6 = DateTime.Now;
                    requestServicModel.EndTime_F31 = CalculateEndTime(model.durationUnit_F30, model.durationCount_F24, DateTime.Now);
                    requestServicModel.ChainId_F43 = chainId;
                    requestServicModel.MaxFreezDay_F55 = 0;  //!!!!!!!!!!
                    requestServicModel.PayAmount_F59 = model.TarefePrice;
                    requestServicModel.OffPerc_F61 = 0; //!!!
                    requestServicModel.OffAmount_f62 = 0; 
                    requestServicModel.MustPayAmount_F63 = model.TarefePrice;
                    requestServicModel.Bedehkar_F64 = 0;
                    requestServicModel.CoachMoney_F68 = "0";  //!!!!!!!!!!!!
                    requestServicModel.Bedehkar_F91 = 0;
                    requestServicModel.ArzeshAfzodeh_F133 = 0;

                    requestServiceId = RequestServicModel.AddRequestServic(requestServicModel);


                }
            }

            return requestServiceId;
        }

        public void SaveSanad(Int64 personId, Int64 factorId, Int64 requestServiceId)
        {

            foreach (var model in mymodel.tarefeList)
            {
                if (model.Selected)
                {
                    
                    sanadModel = new SanadModel();
                    sanadModel.F11_personID731 = personId;
                    sanadModel.F1_KolHesabdari = 1100010260000000001;  // حساب کل: دارایی - از جدول 1028 (حسابهای معین
                    sanadModel.F2_MoeenHesabdari = 1100010280000000009;  // معین: بانک - از جدول 1028 (حسابهای معین
                    sanadModel.F4_Sharh = model.TarefeTitle;
                    sanadModel.F5_MablaghBedehkar = model.TarefePrice;
                    sanadModel.F6_MablaghBestankar = 0;
                    sanadModel.F7_FactorId = factorId;
                    sanadModel.F8_Dyn859ID = requestServiceId;
                    sanadModel.F12_SabtKonandeh = 1100005500000000103;   // راهبر
                    sanadModel.F13_Zamansabt = DateTime.Now;
                    sanadModel.F14_ChainID = chainId; 
                    sanadModel.F16_ShowinFac = true;
                    sanadModel.F25_KhedmatGroupID = 1018002470000000101;  // گروه خدمت: عمومی
                    sanadModel.F28_MoeenCodeHesadari = 1131;   // کد معین: بانک - از جدول 1028 (حسابهای معین
                    sanadModel.F28_2TafzilCodeHesabdari = 110101; // F11 from 1028
                    sanadModel.F32_kolCodeHesabdari = 100;  // F9 from 1028
                    sanadModel.F33_gorohHesabdari = 1; // F10 from 1028
                    sanadModel.F34_markazHazine = "0"; // !!!
                    SanadModel.AddSanad(sanadModel);


                    sanadModel.F1_KolHesabdari = 1100010260000000002;  //  حساب کل : بدهی
                    sanadModel.F2_MoeenHesabdari = 1019010280000000102;  //  معین:  دابل صندوق-بجاي پيش دريافت
                    sanadModel.F5_MablaghBedehkar = 0;
                    sanadModel.F6_MablaghBestankar = model.TarefePrice;
                    sanadModel.F16_ShowinFac = false;
                    sanadModel.F28_MoeenCodeHesadari = 3612;
                    sanadModel.F28_2TafzilCodeHesabdari = 123; // F11 from 1028
                    sanadModel.F32_kolCodeHesabdari = 0;  // F9 from 1028
                    sanadModel.F33_gorohHesabdari = 0; // F10 from 1028
                    sanadModel.F34_markazHazine = "0"; // !!!
                    SanadModel.AddSanad(sanadModel);

                    sanadModel.F1_KolHesabdari = 1100010260000000002;  //  حساب کل : بدهی
                    sanadModel.F2_MoeenHesabdari = 1019010280000000102;  //  معین:  دابل صندوق-بجاي پيش دريافت
                    sanadModel.F5_MablaghBedehkar = model.TarefePrice;
                    sanadModel.F6_MablaghBestankar = 0;
                    sanadModel.F16_ShowinFac = false;
                    sanadModel.F28_MoeenCodeHesadari = 3612;
                    sanadModel.F28_2TafzilCodeHesabdari = 123; // F11 from 1028
                    sanadModel.F32_kolCodeHesabdari = 0;  // F9 from 1028
                    sanadModel.F33_gorohHesabdari = 0; // F10 from 1028
                    sanadModel.F34_markazHazine = "0"; // !!!
                    SanadModel.AddSanad(sanadModel);


                    sanadModel.F1_KolHesabdari = 1100010260000000004;  //  حساب کل : درآمدها
                    sanadModel.F2_MoeenHesabdari = 1100010280000000006;  //  معین:  خدمات ورزشی
                    sanadModel.F5_MablaghBedehkar = 0;
                    sanadModel.F6_MablaghBestankar = model.TarefePrice;
                    sanadModel.F16_ShowinFac = true;
                    sanadModel.F28_MoeenCodeHesadari = 0;
                    sanadModel.F28_2TafzilCodeHesabdari = 0; // F11 from 1028
                    sanadModel.F32_kolCodeHesabdari = 400;  // F9 from 1028
                    sanadModel.F33_gorohHesabdari = 4; // F10 from 1028
                    sanadModel.F34_markazHazine = model.tarefeCode; // !!!
                    SanadModel.AddSanad(sanadModel);

                }
            }


        }


        public DateTime CalculateEndTime(int timeUnit, int count, DateTime startTime)
        {

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            DateTime endTime = startTime;

            if (timeUnit == 3)   // day
            {
                endTime = endTime.AddDays(count).AddDays(-1);
            }
            else if (timeUnit == 4) //week
            {
                endTime = endTime.AddDays(count * 7).AddDays(-1);
            }
            else if (timeUnit == 5)   //month
            {
                int year = pc.GetYear(startTime);
                int month = pc.GetMonth(startTime);
                int day = pc.GetDayOfMonth(startTime);
                int mc = (month + count);

                if (mc % 12 == 0)
                {
                    year = year + (mc / 12) - 1;
                }
                else
                //	(mc != 12)
                {
                    year = year + (mc / 12);
                }

                month = (month + count) % 12;
                if (month == 0)
                    month = 12;
                if (month >= 7 && day == 31)
                    day = day - 1;
                if (month == 12 && day == 30)
                    day = day - 1;

                DateTime dt = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                endTime = dt.AddDays(-1);

            }
            else if (timeUnit == 6)  // year
            {
                int year = pc.GetYear(startTime);
                int month = pc.GetMonth(startTime);
                int day = pc.GetDayOfMonth(startTime);
                DateTime dt = pc.ToDateTime((year + count), month, day, 0, 0, 0, 0);
                endTime = dt.AddDays(-1);
            }

            return endTime;
        }

        private static void NewMethod(dynamic model)
        {
            //factorModel.KhedmatName_F46 = model.service_name;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


        }

        #endregion
    }
}