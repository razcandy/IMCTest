using System;
using System.Threading.Tasks;
using IMCTest.Calculators;
using IMCTest.Data;
using IMCTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMCTest.UnitTests
{
	[TestClass]
	public class TaxJarCalculator_UnitTests
	{
		public static TaxRateRequestModel MakeInvalidRateRequest()
		{
			return new TaxRateRequestModel
			{
				State = "NC",
			};
		}

		public static TaxRateRequestModel MakeValildRateRequest()
		{
			return new TaxRateRequestModel("27609");
		}

		public static TaxRequestModel MakeInvalidTaxRequest()
		{
			return new TaxRequestModel
			{
				ToZip = "27609",
			};
		}

		public static TaxRequestModel MakeValidTaxRequest()
		{
			return new TaxRequestModel
			{
				Amount = 3.14,
				FromCountry = "US",
				FromState = "NC",
				FromZip = "28804",
				Shipping = 5.99,
				ToCountry = "US",
				ToState = "NC",
				ToZip = "27609",
			};
		}

		[TestMethod]
		public async Task CalculateTax_WhenSuccessful_ReturnsTax()
		{
			var taxJar = new TaxJarCalculator();
			var res = await taxJar.CalculateTax(MakeValidTaxRequest());

			Assert.IsTrue(res.success);
			Assert.IsTrue(string.IsNullOrEmpty(res.message));
			Assert.IsNotNull(res.tax);
			Assert.IsTrue(res.tax.AmountToCollect > 0);
		}

		[TestMethod]
		public async Task CalculateTax_WhenUnsuccessful_ReturnsError()
		{
			var taxJar = new TaxJarCalculator();
			var res = await taxJar.CalculateTax(MakeInvalidTaxRequest());

			Assert.IsFalse(res.success);
			Assert.IsNotNull(res.message);
			Assert.IsNull(res.tax);
		}

		[TestMethod]
		public async Task GetTaxRate_WhenSuccessful_ReturnsRate()
		{
			var taxJar = new TaxJarCalculator();
			var res = await taxJar.GetTaxRate(MakeValildRateRequest());

			Assert.IsTrue(res.success);
			Assert.IsTrue(string.IsNullOrEmpty(res.message));
			Assert.IsNotNull(res.rate);
			Assert.IsTrue(res.rate.CombinedRate > 0);
		}

		[TestMethod]
		public async Task GetTaxRate_WhenUnsuccessful_ReturnsError()
		{
			var taxJar = new TaxJarCalculator();
			var res = await taxJar.GetTaxRate(MakeInvalidRateRequest());

			Assert.IsFalse(res.success);
			Assert.IsNotNull(res.message);
			Assert.IsNull(res.rate);
		}
	}

	[TestClass]
	public class TaxService_UnitTests
	{
		[TestMethod]
		public void GeneratesDefaultITaxCalculator()
		{
			var taxService = new TaxService();

			Assert.IsNotNull(taxService.TaxCalculator);
		}

		[TestMethod]
		public async Task CalculateTax_WhenSuccessful_ReturnsTax()
		{
			var taxService = new TaxService();
			var res = await taxService.CalculateTax(TaxJarCalculator_UnitTests.MakeValidTaxRequest());

			Assert.IsTrue(res.success);
			Assert.IsTrue(string.IsNullOrEmpty(res.message));
			Assert.IsNotNull(res.tax);
			Assert.IsTrue(res.tax.AmountToCollect > 0);
		}

		[TestMethod]
		public async Task CalculateTax_WhenUnsuccessful_ReturnsError()
		{
			var taxService = new TaxService();
			var res = await taxService.CalculateTax(TaxJarCalculator_UnitTests.MakeInvalidTaxRequest());

			Assert.IsFalse(res.success);
			Assert.IsNotNull(res.message);
			Assert.IsNull(res.tax);
		}

		[TestMethod]
		public async Task GetTaxRate_WhenSuccessful_ReturnsRate()
		{
			var taxService = new TaxService();
			var res = await taxService.GetTaxRate(TaxJarCalculator_UnitTests.MakeValildRateRequest());

			Assert.IsTrue(res.success);
			Assert.IsTrue(string.IsNullOrEmpty(res.message));
			Assert.IsNotNull(res.rate);
			Assert.IsTrue(res.rate.CombinedRate > 0);
		}

		[TestMethod]
		public async Task GetTaxRate_WhenUnsuccessful_ReturnsError()
		{
			var taxService = new TaxService();
			var res = await taxService.GetTaxRate(TaxJarCalculator_UnitTests.MakeInvalidRateRequest());

			Assert.IsFalse(res.success);
			Assert.IsNotNull(res.message);
			Assert.IsNull(res.rate);
		}
	}
}
