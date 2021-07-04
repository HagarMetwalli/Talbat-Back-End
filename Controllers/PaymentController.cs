using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Talbat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
     //       [HttpPost]
    //public JsonResult Post([FromBody]StripePaymentRequest paymentRequest)
    //{
    //    StripeConfiguration.SetApiKey("sk_test_51HgvmgFAfdf2YRBxum24eeWWRWSsu07km9JCxfeyNlmoxDbfeXT0dycLdddjbFTjgU8Bb15kCLf1UhR4o0CgfMNu00vtYXmiCA");

    //    var myCharge = new StripeChargeCreateOptions();
    //    myCharge.SourceTokenOrExistingSourceId = paymentRequest.tokenId;
    //    myCharge.Amount = paymentRequest.amount;
    //    myCharge.Currency = "gbp";
    //    myCharge.Description = paymentRequest.productName;
    //    myCharge.Metadata = new Dictionary<string, string>();
    //    myCharge.Metadata["OurRef"] = "OurRef-" + Guid.NewGuid().ToString();

    //    var chargeService = new StripeChargeService();
    //    StripeCharge stripeCharge = chargeService.Create(myCharge);

    //    return (stripeCharge);
    //}

    //public class StripePaymentRequest
    //{
    //    public string tokenId { get; set; }
    //    public string productName { get; set; }
    //    public int amount { get; set; }
   // }
    }
}


