using BankAccountForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace BankAccountForm.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var list = new List<CreateAccount>();
            var userData = _context.Accounts.ToList();
            if (userData?.Any() != null)
            {
                foreach (var user in userData)
                {
                    list.Add(new CreateAccount()
                    {
                        Id = user.Id,
                        Title = user.Title,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DateOfBirth = user.DateOfBirth,
                        MobileNumber = user.MobileNumber,
                        Email = user.Email,
                        Sex = user.Sex,
                        AccountType = user.AccountType,
                        StdCode = user.StdCode,
                        Telephone = user.Telephone,
                        StateId = user.StateId,
                        CityId = user.CityId,
                        BranchId = user.BranchId,
                        LanguageId = user.LanguageId

                    });
                }
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
      
        public JsonResult GetCurrentDtTime()
        {
            DateTime dt = DateTime.Now;
            string[] dtTime = new string[] { dt.ToString("dd/MM/yyyy"), dt.ToString("hh : mm :ss") };
            return Json(dtTime);
        }
        public IActionResult CreateAccountForm()
        {
            
            ViewBag.Id = _context.Accounts.Max(x => x.Id)+1;
            var dateTime = DateTime.Now;
           
           
            DateTime myTime = default(DateTime).Add(dateTime.TimeOfDay);
           
          
            var stateData = _context.States.ToList();

            ViewBag.StateList = new SelectList(stateData, "StateCode", "StateName");
            //var branchData = _context.Branches.ToList();
            //ViewBag.BranchList = new SelectList(branchData, "Branch_code", "Branch_name");

            var languageData = _context.Languages.ToList();
            ViewBag.LanguageList = new SelectList(languageData, "Laanguage_Code", "Language_Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAccount model)
        {
            if (ModelState.IsValid)
            {

                var newuser = new AccountModel()
                {
                    Id = model.Id,
                    FormFillDate = model.FormFillDate,
                    FormFillTime = model.FormFillTime,
                    Title = model.Title,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Age = model.Age,
                    MobileNumber = model.MobileNumber,
                    Email = model.Email,
                    Sex = model.Sex,
                    AccountType = model.AccountType,
                    StdCode = model.StdCode,
                    Telephone = model.Telephone,
                    StateId = model.StateId,
                    CityId = model.CityId,
                    BranchId = model.BranchId,
                    LanguageId = model.LanguageId

                };
                _context.Accounts.Add(newuser);

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("CreateAccountForm");
        }
        public void Exit()
        {
            Environment.Exit(1);

        }

        [HttpGet]
        public ActionResult CalulateAgeFromDob(DateTime dateOfBirth)
        {
            var age = CalculateAge(dateOfBirth);
            return Json(age);
        }

        public object CalculateAge(DateTime dateOfBirth)
        {

            DateTime birth = dateOfBirth;
            DateTime today = DateTime.Now;
            TimeSpan span = today - birth;
            DateTime age = DateTime.MinValue + span;


            int months = age.Month - 1;
            int days = age.Day - 1;


            var ageInYMD = string.Format("{0} years, {1} months, {2} days", age.Year, months, days);
            var ageInY = string.Format("{0} years", age.Year);
            return age.Year;
        }

        public JsonResult GetCityList(string StateCode)
        {
            List<City> selectList = _context.Cities.Where(x => x.City_Stat_Code == StateCode).ToList();
            ViewBag.Citylist = new SelectList(selectList, "CityCode", "CityName");
            return Json(selectList);

        }

		public JsonResult GetBranch(int citycode)
		{
			List<Branch> selectList = _context.Branches.Where(x => x.Branch_City_code == citycode).ToList();
			ViewBag.Branch = new SelectList(selectList, "Branch_code", "Branch_name");
			return Json(selectList);

		}

	}
}