using Newtonsoft.Json;

namespace IMCTest.Data
{
	public class TaxModelParse
	{
		[JsonProperty("tax")]
		public TaxModel Tax { get; set; }
	}
}
