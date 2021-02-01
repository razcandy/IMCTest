using Newtonsoft.Json;

namespace IMCTest.Data
{
	public class RateModelParse
	{
		[JsonProperty("rate")]
		public RateModel Rate { get; set; }
	}
}
