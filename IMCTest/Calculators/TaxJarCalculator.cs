using IMCTest.Data;
using IMCTest.Values;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IMCTest.Calculators
{
    public class TaxJarCalculator : ITaxCalculator
    {
		// Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private const string apiKey = "5da2f821eee4035db4771edab942a4cc";
		private const string baseURI = "https://api.taxjar.com/v2/";
        private const string calculateTaxURI = baseURI + "taxes";
		private const string getTaxRateURI = baseURI + "rates";

		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static readonly HttpClient client = new HttpClient();

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // POST https://api.taxjar.com/v2/taxes
        public async Task<(bool success, string message, TaxModel tax)> CalculateTax(TaxRequestModel _request)
		{
            (bool success, string message, TaxModel tax) ret;
            var json = JsonConvert.SerializeObject(_request);

            var message = new HttpRequestMessage(HttpMethod.Post, calculateTaxURI);
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.SendAsync(message);
            var resString = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
			{
                try
                {
                    var tax = JsonConvert.DeserializeObject<TaxModelParse>(resString);
                    ret = (true, string.Empty, tax.Tax);
                }
                catch (Exception e)
                {
                    ret = (false, Translations.UnexpectedError, null);
                }
            }
            else
			{
                try
				{
                    var error = JsonConvert.DeserializeObject<HttpErrorParse>(resString);
                    ret = (false, error.Detail, null);
				}
                catch (Exception e)
				{
                    ret = (false, Translations.UnexpectedError, null);
				}
			}

            return ret;
		}

        // GET https://api.taxjar.com/v2/rates/:zip
        public async Task<(bool success, string message, RateModel rate)> GetTaxRate(TaxRateRequestModel _request)
		{
            (bool success, string message, RateModel rate) ret;
            var json = JsonConvert.SerializeObject(_request);

			var message = new HttpRequestMessage(HttpMethod.Post, getTaxRateURI);
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.SendAsync(message);
            var resString = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                try
                {
					var rate = JsonConvert.DeserializeObject<RateModelParse>(resString);
					ret = (true, string.Empty, rate.Rate);
                }
                catch (Exception e)
                {
                    ret = (false, Translations.UnexpectedError, null);
                }
            }
            else
            {
                try
                {
                    var error = JsonConvert.DeserializeObject<HttpErrorParse>(resString);
                    ret = (false, error.Detail, null);
                }
                catch (Exception e)
                {
                    ret = (false, Translations.UnexpectedError, null);
                }
            }

            return ret;
        }
    }
}
