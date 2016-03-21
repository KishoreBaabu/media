using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StripeCustomer current = GetCustomer();
       // int? days = getaTraildays();
        //if (days != null)
        //{
        int chargetotal = 100;//Convert.ToInt32((3.33*Convert.ToInt32(days)*100));
            var mycharge = new StripeChargeCreateOptions();
            mycharge.AmountInCents=chargetotal;
            mycharge.Currency = "USD";
            mycharge.CustomerId = current.Id;
            string key = "sk_test_8mJVFLGFPWX1PfjVFzTFn8t9";
            var chargeservice = new StripeChargeService(key);
            StripeCharge currentcharge = chargeservice.Create(mycharge);
        //}
    }
    private StripeCustomer GetCustomer()
    {
        var mycust =new  StripeCustomerCreateOptions();
        mycust.Email = "test@gmail.com";
        mycust.Description = "Rahul Pandey(rahul@gmail.com)";
        mycust.CardNumber = "4012888888881881";
        mycust.CardExpirationMonth = "05";
        mycust.CardExpirationYear = "2015";
       // mycust.PlanId = "100";
        mycust.CardName = "Rahul Pandey";
        mycust.CardAddressCity = "ABC";
        mycust.CardAddressCountry = "USA";
        mycust.CardAddressLine1="asbcd";
        //mycust.TrialEnd = getrialend();

        var customerservice = new StripeCustomerService("sk_test_8mJVFLGFPWX1PfjVFzTFn8t9");
        return customerservice.Create(mycust);
    }
  

}