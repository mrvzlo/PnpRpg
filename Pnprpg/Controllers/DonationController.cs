using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;
using Pnprpg.Web.Helpers;

namespace Pnprpg.Web.Controllers
{
    public class DonationController : BaseController
    {
        private readonly IDonationService _donationService;

        public DonationController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        public ActionResult Index()
        {
            var list = _donationService.GetAll();
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit()
        {
            var list = _donationService.GetEditModels();
            return View(list);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "Admin")]
        public ActionResult Edit(List<DonationEditModel> list)
        {
            _donationService.SaveAll(list);
            return Edit();
        }
    }
}