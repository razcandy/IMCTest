using Newtonsoft.Json;

namespace IMCTest.Data
{
	public class TaxModel
	{
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Constructors ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public TaxModel() { }

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Total amount of the order.
        /// </summary>
        [JsonProperty("order_total_amount")]
        public double OrderTotalAmount { get; set; }

        /// <summary>
        /// Total amount of shipping for the order.
        /// </summary>
        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        /// <summary>
        /// Amount of the order to be taxed.
        /// </summary>
        [JsonProperty("taxable_amount")]
        public double TaxableAmount { get; set; }

        /// <summary>
        /// Amount of sales tax to collect.
        /// </summary>
        [JsonProperty("amount_to_collect")]
        public double AmountToCollect { get; set; }

        /// <summary>
        /// Overall sales tax rate of the order (amount_to_collect ÷ taxable_amount).
        /// </summary>
        [JsonProperty("rate")]
        public double Rate { get; set; }

        /// <summary>
        /// Whether or not you have nexus for the order based on an address on file, nexus_addresses
        /// parameter, or from_ parameters.
        /// </summary>
        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }

        /// <summary>
        /// Freight taxability for the order.
        /// </summary>
        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }

        /// <summary>
        /// Origin-based or destination-based sales tax collection.
        /// </summary>
        [JsonProperty("tax_source")]
        public string TaxSource { get; set; }

        /// <summary>
        /// Type of exemption for the order: wholesale, government, marketplace, other, or non_exempt.
        /// If no customer_id or exemption_type is provided, no exemption_type is returned in the response.
        /// </summary>
        [JsonProperty("exemption_type")]
        public string ExemptionType { get; set; }

        /// <summary>
        /// Jurisdiction names for the order.
        /// </summary>
        [JsonProperty("jurisdictions")]
        public object Jurisdictions { get; set; }

        /// <summary>
        /// Breakdown of rates by jurisdiction for the order, shipping, and individual line items. If
        /// has_nexus is false or no line items are provided, no breakdown is returned in the response.
        /// </summary>
        [JsonProperty("breakdown")]
        public object Breakdown { get; set; }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
