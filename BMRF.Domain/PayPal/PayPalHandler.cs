using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMRF.Domain.DonateModels;
using PayPal.Api;

namespace BMRF.Domain.PayPal
{
    public class PayPalHandler
    {
        public static string CreatePaymentFromDonation(Donation don, string domain)
        {
            // Get a reference to the config
            var config = ConfigManager.Instance.GetProperties();

            // Use OAuthTokenCredential to request an access token from PayPal
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            var profile = new WebProfile()
            {
                name = Guid.NewGuid().ToString(),
                presentation = new Presentation()
                {
                    brand_name = "BMRF.ME",
                    locale_code = "CA",
                    logo_image = "https://bmrf.me/Content/img/mini_logo.png"
                },
                input_fields = new InputFields()
                {
                    address_override = 1,
                    allow_note = true,
                    no_shipping = 1
                }
            };

            var profileResponse = profile.Create(apiContext);
            var retrievedProfile = WebProfile.Get(apiContext, profileResponse.id);

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = don.Amount.ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = don.Amount.ToString(),
                details = details
            };

            var transList = new List<Transaction>
            {
                new Transaction()
                {
                    description = "BMRF.ME - DayZ Server Donation",
                    amount = amount,
                }
            };

            var payer = new Payer() { payment_method = "paypal" };

            var redirects = new RedirectUrls
            {
                cancel_url = domain + @"/donate/cancel",
                return_url = domain + @"/donate/process"
            };

            var payment = new Payment 
            {
                intent = "sale",
                payer = payer,
                transactions = transList,
                redirect_urls = redirects,
                experience_profile_id = profileResponse.id
            };

            var createdPayment = payment.Create(apiContext);

            var links = createdPayment.links.GetEnumerator();
            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    retrievedProfile.Delete(apiContext);
                    return link.href;
                }
            }
            retrievedProfile.Delete(apiContext);
            return null;
        }

        public static void ExecutePayment(string paymentId, string payerId)
        {
            // Get a reference to the config
            var config = ConfigManager.Instance.GetProperties();

            // Use OAuthTokenCredential to request an access token from PayPal
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            var paymentExecution = new PaymentExecution() {payer_id = payerId};
            var payment = new Payment() {id = paymentId};

            payment.Execute(apiContext, paymentExecution);
        }
    }
}
