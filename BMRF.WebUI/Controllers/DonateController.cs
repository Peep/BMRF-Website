using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BMRF.Domain.DonateModels;
using BMRF.Domain.HomepageModels;
using BMRF.Domain.PayPal;

namespace BMRF.WebUI.Controllers
{
    public class DonateController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DayZ()
        {
            return View();
        }

        public RedirectResult Process(string paymentId, string payerId)
        {
            PayPalHandler.ExecutePayment(paymentId, payerId);

            return Redirect("/Donate");
        }

        [HttpPost]
        public RedirectResult Submit(Donation donation)
        {
            if (ModelState.IsValid)
            {
                if (HomeController.ForumUser != null)
                    donation.User = HomeController.ForumUser;

                var domain = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host +
                             (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                string paypalLink = PayPalHandler.CreatePaymentFromDonation(donation, domain);
                if (paypalLink != null)
                    return Redirect(paypalLink);
            }
            return Redirect("Home/Index");
        }
    }
}