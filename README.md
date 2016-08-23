AvaTax-SOAP-csharp
=====================
[Other Samples](http://developer.avalara.com/api-docs/api-sample-code)

This is a C# sample demonstrating the [AvaTax SOAP API](http://developer.avalara.com/api-docs/soap) methods:

For more information on the use of these methods and the AvaTax product, please visit our [developer site](http://developer.avalara.com/) or [homepage](http://www.avalara.com/)
 

Dependencies:
-----------
- .NET 2.0 or later
- Avalara.AvaTax.Adapter.DLL (included in sample)


Requirements:
----------
- Some versions of Visual Studio have trouble finding the included Avalara.AvaTax.Adapter.dll - you may need to re-add this file to your project references after downloading the sample.
- Authentication requires an valid **Account Number** and **License Key**, which should be entered in the application configuration (app.config) file.
- If you do not have an AvaTax account, a free trial account can be acquired through our [developer site](http://developer.avalara.com/api-get-started)
 
Contents:
----------
 
<table>
<th colspan="2" align=left>Sample Files</th>
<tr><td>CancelTaxTest.cs</td><td>Demonstrates the CancelTax method used to <a href="http://developer.avalara.com/api-docs/api-reference/canceltax">void a document</a>.</td></tr>
<tr><td>GetTaxHistoryTest.cs</td><td>Demonstrates a GetTaxHistory call to retrieve document details for a saved transaction.</td></tr>
<tr><td>GetTaxTest.cs</td><td>Demonstrates the GetTax method used for product- and line- specific <a href="http://developer.avalara.com/api-docs/api-reference/gettax">calculation</a>.</td></tr>
<tr><td>PingTest.cs</td><td>Demonstrates a ping call to verify connectivity and credentials.</td></tr>
<tr><td>PostTaxTest.cs</td><td>Demonstrates the PostTax method used to <a href="http://developer.avalara.com/api-docs/api-reference/posttax-and-committax">commit</a> a previously recorded document.</td></tr>
<tr><td>Program.cs</td><td>Provides and entry point to call the actual samples.</td></tr>
<tr><td>ValidateAddressTest.cs</td><td>Demonstrates the ValidateAddress method to <a href="http://developer.avalara.com/api-docs/api-reference/address-validation">normalize an address</a>.</td></tr>
<th colspan="2" align=left>Core Classes</th>
<tr><td>Avalara.AvaTax.Adapter.chm</td><td>-</td></tr>
<tr><td>Avalara.AvaTax.Adapter.dll</td><td>-</td></tr>
<tr><td>Avalara.AvaTax.Adapter.dll.config</td><td>-</td></tr> 
<th colspan="2" align=left>Other Files</th>
<tr><td>.gitattributes</td><td>-</td></tr>
<tr><td>.gitignore</td><td>-</td></tr>
<tr><td>app.config</td><td>Contains AvaTax credentials used to run individual tests.</td></tr>
<tr><td>AvaTaxCalcSOAP.csproj</td><td>-</td></tr>
<tr><td>AvaTaxCalcSOAP.sln</td><td>-</td></tr>
<tr><td>LICENSE.md</td><td>-</td></tr>
<tr><td>README.md</td><td>-</td></tr>
</table>
