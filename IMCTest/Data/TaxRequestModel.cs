using Newtonsoft.Json;

namespace IMCTest.Data
{
    public class TaxRequestModel
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TaxRequestModel() { }

        public TaxRequestModel(string _toCountry, double _shipping)
        {
            ToCountry = _toCountry;
            Shipping = _shipping;
        }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// [optional]
        /// Two-letter ISO country code of the country where the order shipped from.
        /// </summary>
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }

        /// <summary>
        /// [optional]
        /// Postal code where the order shipped from (5-Digit ZIP or ZIP+4).
        /// </summary>
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }

        /// <summary>
        /// [optional]
        /// Two-letter ISO state code where the order shipped from.
        /// </summary>
        [JsonProperty("from_state")]
        public string FromState { get; set; }

        /// <summary>
        /// City where the order shipped from.
        /// </summary>
        [JsonProperty("from_city")]
        public string FromCity { get; set; }

        /// <summary>
        /// [required]
        /// Two-letter ISO country code of the country where the order shipped to.
        /// </summary>
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }

        /// <summary>
        /// [conditional]
        /// Postal code where the order shipped to (5-Digit ZIP or ZIP+4).
        /// If `to_country` is 'US', `to_zip` is required.
        /// </summary>
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }

        /// <summary>
        /// [conditional]
        /// Two-letter ISO state code where the order shipped to.
        /// If `to_country` is 'US', `to_state` is required.
        /// </summary>
        [JsonProperty("to_state")]
        public string ToState { get; set; }

        /// <summary>
        /// City where the order shipped to.
        /// </summary>
        [JsonProperty("to_city")]
        public string ToCity { get; set; }

        /// <summary>
        /// [optional]
        /// Total amount of the order, excluding shipping.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// [required]
        /// Total amount of shipping for the order.
        /// </summary>
        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
