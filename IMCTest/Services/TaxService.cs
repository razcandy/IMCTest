using IMCTest.Calculators;
using IMCTest.Data;
using System.Threading.Tasks;

namespace IMCTest.Services
{
	public class TaxService
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ITaxCalculator TaxCalculator;

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TaxService()
		{
            TaxCalculator = new TaxJarCalculator();
        }

        public TaxService(ITaxCalculator _taxCalculator)
		{
            TaxCalculator = _taxCalculator ?? new TaxJarCalculator();
        }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Task<(bool success, string message, TaxModel tax)> CalculateTax(TaxRequestModel _request)
            => TaxCalculator.CalculateTax(_request);

        public Task<(bool success, string message, RateModel rate)> GetTaxRate(TaxRateRequestModel _request)
            => TaxCalculator.GetTaxRate(_request);

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
