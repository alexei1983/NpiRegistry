
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistrySearchOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? UseFirstNameAlias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? TaxonomyDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? State {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? OrganizationName { get; set; }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// 
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
        /// 
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
        /// 
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
