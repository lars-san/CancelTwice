namespace AvaTaxCalcSOAP
{
    using System;
    using System.Configuration;
    using Avalara.AvaTax.Adapter;
    using Avalara.AvaTax.Adapter.TaxService;

    public class PingTest
    {
       public static void Test()
        {
            string accountNumber = ConfigurationManager.AppSettings["AvaTax:AccountNumber"];
            string licenseKey = ConfigurationManager.AppSettings["AvaTax:LicenseKey"];
            string serviceURL = ConfigurationManager.AppSettings["AvaTax:ServiceUrl"];

            TaxSvc taxSvc = new TaxSvc();

            // Header Level Parameters
            // Required Header Parameters
            taxSvc.Configuration.Security.Account = accountNumber;
            taxSvc.Configuration.Security.License = licenseKey;
            taxSvc.Configuration.Url = serviceURL;
            taxSvc.Configuration.ViaUrl = serviceURL;
            taxSvc.Profile.Client = "AvaTaxSample";

            // Optional Header Parameters
            taxSvc.Profile.Name = "Development";

            PingResult pingResult = taxSvc.Ping(string.Empty);

            Console.WriteLine("PingTest Result: " + pingResult.ResultCode.ToString());
            if (!pingResult.ResultCode.Equals(SeverityLevel.Success))
            {
                foreach (Message message in pingResult.Messages)
                {
                    Console.WriteLine(message.Summary);
                }
            }
        }
    }
}
