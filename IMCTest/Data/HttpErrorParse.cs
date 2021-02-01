using Newtonsoft.Json;

namespace IMCTest.Data
{
	public class HttpErrorParse
	{
		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("detail")]
		public string Detail { get; set; }
	}
}
