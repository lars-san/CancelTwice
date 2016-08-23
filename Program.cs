namespace AvaTaxCalcSOAP
{
    using System;
    using System.IO;                    // File read/write
    using Microsoft.VisualBasic.FileIO; // Text Field Parser

    public class Program
    {
        public static void Main()
        {
            bool exit = false;
            ConsoleKeyInfo keypress; // ready the variable used for accepting user input
            string AccountNum;
            string LicenseKey;
            string ServiceURL;
            string CompanyCode;
            string DocType;

            Console.WriteLine("This application will delete (not locked) documents from the Avalara AvaTax Admin Console. Please be cautious using this. To that end, there is no way to pre-load this applications configuration. You must enter the account number, license key, and service URL each time you use it. Then, you will need to confirm the data before it will execute.");
            Console.WriteLine("Please begin by entering the...");
            Console.WriteLine("Account Number: ");
            AccountNum = Console.ReadLine();
            Console.WriteLine("License Key: ");
            LicenseKey = Console.ReadLine();
            Console.WriteLine("Service URL: ");
            ServiceURL = Console.ReadLine();
            Console.WriteLine("Company Code: ");
            CompanyCode = Console.ReadLine();
            Console.WriteLine("Document Type (Return or Invoice): ");
            DocType = Console.ReadLine();

            Console.WriteLine("Please verify the following details are correct.");
            Console.WriteLine("Press 'Y' to continue, or 'Esc' to close.");
            while (!exit) // This is the main loop and will end when the user presses the Esc key.
            {
                keypress = Console.ReadKey(true); //This is listed with true so the key press is not shown.
                if (keypress.Key == ConsoleKey.Y)
                {
                    string filename = "DocCodes.csv"; // Note this file must be in the same directory as the exe
                    Console.WriteLine("Reading " + filename);
                    int lineCount = File.ReadAllLines(filename).Length;
                    TextFieldParser parser = new TextFieldParser(filename);
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(",");
                    string[,] DocCodeData = new string[lineCount, 1];
                    string[] fields;
                    int row = 0;
                    int column = 0;
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            DocCodeData[row, column] = field;
                            column = column + 1;
                        }
                        column = 0;
                        row = row + 1;
                    }
                    parser.Close();
                    // End - Grab DocCodes to act on
                    try
                    {
                        // Each test is managed in its own class 
                        // Make sure you enter your valid credentials in that test class.
                        //PingTest.Test();
                        //GetTaxTest.Test();
                        //AdjustTaxTest.Test();
                        //PostTaxTest.Test();
                        //CommitTaxTest.Test();
                        row = 0;
                        while (row < lineCount)
                        {
                            CancelTaxTest.Test(AccountNum, LicenseKey, ServiceURL, CompanyCode, DocCodeData[row, 0]);
                            CancelTaxTest.Test(AccountNum, LicenseKey, ServiceURL, CompanyCode, DocCodeData[row, 0]);
                            row++;
                        }
                        //GetTaxHistoryTest.Test();
                        //ValidateAddressTest.Test();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An Exception Occured: " + ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Done. Press 'Esc'");
                    }
                }
                if (keypress.Key == ConsoleKey.Escape) // This checks to see if the key pressed was Esc
                { exit = true; } // This variable change will end the main loop and close the program.
            }
            // Start - Grab DocCodes to act on
            
        }
    }
}