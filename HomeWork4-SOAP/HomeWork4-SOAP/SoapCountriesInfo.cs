using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork4_SOAP
{
    [TestClass]
    public class SoapCountriesInfo
    {
        //Global Variable Declarations 
        private readonly CountryInformation.CountryInfoServiceSoapTypeClient Test_CountryListings =
            new CountryInformation.CountryInfoServiceSoapTypeClient(CountryInformation.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);                                                                                                                                                                                                                  //crated by justin salazar 3/22/2033

        [TestMethod]
        public void CountryCodeAscendingOrder()
        {
            //Checking the return value of ListOfCountryNamesByCode and via ascending order
            var countryCode = Test_CountryListings.ListOfCountryNamesByCode();
            var countryCodeAscending = countryCode.OrderBy(isoCode => isoCode.sISOCode);

            //Assertion of the values for countryCode and countryCodeAscending
            Assert.IsNotNull(countryCode, "Returns Null value");
            Assert.IsNotNull(countryCodeAscending, "Returns Null Value");
            Assert.IsTrue(Enumerable.SequenceEqual(countryCodeAscending, countryCode), "Not in Ascending Order");

        }                                                                                                                                                                                                                                                                                                                                                                                           //crated by justin salazar 3/22/2033

        [TestMethod]
        public void CountryCodeInvalid()
        {
            //Creating a variable that holds the passing of the invalid country Code 
            var countryCode = "JP"; //change the value to japoy to hit the error message
            var newCountryCode = Test_CountryListings.CountryName(countryCode);

            //Assertion of the correct Country Code versus the correct country name
            Assert.AreEqual("Japan", newCountryCode, "Country not found in the database");
            //change japan to jopay to hit the error message

        }

        [TestMethod]
        public void IsEqualCountryCodeAndName()
        {
            //initializing the variables that will hold the country names and codes of the prev APIs
            var lastCountryCode = Test_CountryListings.ListOfCountryNamesByCode().Last();
            var countryName = Test_CountryListings.CountryName(lastCountryCode.sISOCode);                                                                                                                                                                                                                                                                                                           //crated by justin salazar 3/22/2033

            //Assertion for the lastCountryCode and CountryName if the same
            Assert.AreEqual(lastCountryCode.sName, countryName, "Country Code and Country Name are not the same");
        
        }

    }
}