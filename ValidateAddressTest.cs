namespace AvaTaxCalcSOAP
{
    using System;
    using System.Configuration;
    using Avalara.AvaTax.Adapter;
    using Avalara.AvaTax.Adapter.AddressService;

    public class ValidateAddressTest
    {
        public static void Test()
        {
            string accountNumber = ConfigurationManager.AppSettings["AvaTax:AccountNumber"];
            string licenseKey = ConfigurationManager.AppSettings["AvaTax:LicenseKey"];
            string serviceURL = ConfigurationManager.AppSettings["AvaTax:ServiceUrl"];

            AddressSvc addressSvc = new AddressSvc();

            // Header Level Parameters
            // Required Header Parameters
            addressSvc.Configuration.Security.Account = accountNumber;
            addressSvc.Configuration.Security.License = licenseKey;
            addressSvc.Configuration.Url = serviceURL;
            addressSvc.Configuration.ViaUrl = serviceURL;
            addressSvc.Profile.Client = "AvaTaxSample";

            // Optional Header Parameters
            addressSvc.Profile.Name = "Development";

            ValidateRequest validateRequest = new ValidateRequest();

            Address address = new Address();
            // Required Request Parameters
            address.Line1 = "118 N Clark St";
            address.City = "Chicago";
            address.Region = "IL";

            // Optional Request Parameters
            address.Line2 = "Suite 100";
            address.Line3 = "ATTN Accounts Payable";
            address.Country = "US";
            address.PostalCode = "60602";

            validateRequest.Address = address;
            validateRequest.Coordinates = true;
            validateRequest.Taxability = true;
            validateRequest.TextCase = TextCase.Upper;
            
            ValidateResult validateResult = addressSvc.Validate(validateRequest);

            Console.WriteLine("ValidateAddressTest Result: " + validateResult.ResultCode.ToString());
            if (!validateResult.ResultCode.Equals(SeverityLevel.Success))
            {
                foreach (Message message in validateResult.Messages)
                {
                    Console.WriteLine(message.Summary);
                }
            }
            else
            {
                Console.WriteLine(validateResult.Addresses[0].Line1
                    + " "
                    + validateResult.Addresses[0].City
                    + ", "
                    + validateResult.Addresses[0].Region
                    + " "
                    + validateResult.Addresses[0].PostalCode);
            }
        }
    }
}
