namespace AvaTaxCalcSOAP
{
    using System;
    using System.Configuration;
    using Avalara.AvaTax.Adapter;
    using Avalara.AvaTax.Adapter.TaxService;

    public class CancelTaxTest // Modified to delete documents
    {
        public static void Test(string AccountNum, string LicenseKey, string ServiceURL, string CompanyCode, string DocumentCode)
        {
            string accountNumber = AccountNum; // "1100001249";//"larswhite";//"1100001249";//ConfigurationManager.AppSettings["AvaTax:AccountNumber"];
            string licenseKey = LicenseKey; // "53A1E773EF48EF2E";//"G0.AvaTax";//"53A1E773EF48EF2E";//ConfigurationManager.AppSettings["AvaTax:LicenseKey"];
            string serviceURL = ServiceURL; // "https://avatax.avalara.net";// ConfigurationManager.AppSettings["AvaTax:ServiceUrl"];

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

            CancelTaxRequest cancelTaxRequest = new CancelTaxRequest();

            // Required Request Parameters
            cancelTaxRequest.CompanyCode = CompanyCode;
            cancelTaxRequest.DocType = DocumentType.ReturnInvoice;
            cancelTaxRequest.DocCode = DocumentCode;
            cancelTaxRequest.CancelCode = CancelCode.DocDeleted;

            CancelTaxResult cancelTaxResult = taxSvc.CancelTax(cancelTaxRequest);

            Console.WriteLine("CancelTaxTest Result: " + cancelTaxResult.ResultCode.ToString());
            if (!cancelTaxResult.ResultCode.Equals(SeverityLevel.Success))
            {
                foreach (Message message in cancelTaxResult.Messages)
                {
                    Console.WriteLine(message.Summary);
                }
            }
        }
    }
}