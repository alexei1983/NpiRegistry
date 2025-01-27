
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Options for searching the National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistrySearchOptions
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Whether or not to include aliases of the first name in the search.
        /// </summary>
        public bool? UseFirstNameAlias { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Taxonomy description.
        /// </summary>
        public string? TaxonomyDescription { get; set; }

        /// <summary>
        /// Two-letter U.S. state.
        /// </summary>
        public string? State {  get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Organization name.
        /// </summary>
        public string? OrganizationName { get; set; }

        /// <summary>
        /// NPI type.
        /// </summary>
        public string? EnumerationType
        {
            get
            {
                return enumerationType;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && !NpiType.IsValid(value))
                    throw new ArgumentException($"Invalid enumeration type: {value}", nameof(value));
                enumerationType = value;
            }
        }

        /// <summary>
        /// NPI number.
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// Address purpose.
        /// </summary>
        public string? AddressPurpose
        {
            get
            {
                return addressPurpose;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && !NpiAddressPurpose.IsValid(value))
                    throw new ArgumentException($"Invalid address purpose: {value}", nameof(value));
                addressPurpose = value;
            }
        }

        /// <summary>
        /// Number of records to return when searching.
        /// </summary>
        public int? Limit
        {
            get
            {
                return limit;
            }

            set
            {
                if (value.HasValue)
                {
                    if (value.Value < NpiConstants.MinLimit || value.Value > NpiConstants.MaxLimit)
                        throw new ArgumentException($"Limit must be a value from {NpiConstants.MinLimit} to {NpiConstants.MaxLimit}.", nameof(value));
                }
                limit = value;
            }
        }

        /// <summary>
        /// Number of records to skip when searching (i.e., the offset).
        /// </summary>
        public int? Skip
        {
            get
            {
                return skip;
            }

            set
            {
                if (value.HasValue && value.Value < 0)
                    value = 0;
                skip = value;
            }
        }

        string? addressPurpose, enumerationType;
        int? limit, skip;
    }
}
