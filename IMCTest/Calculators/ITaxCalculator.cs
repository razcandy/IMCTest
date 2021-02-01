using IMCTest.Data;
using System.Threading.Tasks;

namespace IMCTest.Calculators
{
	public interface ITaxCalculator
	{
		Task<(bool success, string message, TaxModel tax)> CalculateTax(TaxRequestModel _request);
		Task<(bool success, string message, RateModel rate)> GetTaxRate(TaxRateRequestModel _request);
	}
}
