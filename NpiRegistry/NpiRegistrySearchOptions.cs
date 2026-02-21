
using System.Collections.Generic;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal Dictionary<string, string> GetQueryParameters()
        {
            var result = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(FirstName))
            {
                var useAlias = UseFirstNameAlias ?? true;
                result.TryAdd(NpiQueryParameters.FirstName, FirstName);
                if (!useAlias)
                    result.TryAdd(NpiQueryParameters.UseFirstNameAlias, NpiConstants.False);
            }

            if (!string.IsNullOrEmpty(LastName))
                result.TryAdd(NpiQueryParameters.LastName, LastName);

            if (!string.IsNullOrEmpty(EnumerationType)) {
                if (!NpiType.IsValid(EnumerationType))
                    throw new Exception($"Invalid enumeration type: {enumerationType}");

                result.TryAdd(NpiQueryParameters.EnumerationType, EnumerationType.ToUpper());
            }

            if (!string.IsNullOrEmpty(TaxonomyDescription))
                result.TryAdd(NpiQueryParameters.TaxonomyDescription, TaxonomyDescription);

            if (!string.IsNullOrEmpty(OrganizationName))
                result.TryAdd(NpiQueryParameters.OrganizationName, OrganizationName);

            if (!string.IsNullOrEmpty(AddressPurpose))
            {
                if (!NpiAddressPurpose.IsValid(AddressPurpose))
                    throw new Exception($"Invalid address purpose: {AddressPurpose}");

                result.TryAdd(NpiQueryParameters.AddressPurpose, AddressPurpose.ToUpper());
            }

            if (!string.IsNullOrEmpty(City))
                result.TryAdd(NpiQueryParameters.City, City);

            if (!string.IsNullOrEmpty(State))
                result.TryAdd(NpiQueryParameters.State, State);

            if (!string.IsNullOrEmpty(PostalCode))
                result.TryAdd(NpiQueryParameters.PostalCode, PostalCode);

            if (!string.IsNullOrEmpty(CountryCode))
                result.TryAdd(NpiQueryParameters.CountryCode, CountryCode);

            if (Skip.HasValue && Skip.Value > 0)
                result.TryAdd(NpiQueryParameters.Skip, Skip.Value.ToString());

            if (Limit.HasValue) {

                if (Limit.Value < NpiConstants.MinLimit || Limit.Value > NpiConstants.MaxLimit)
                    throw new Exception($"Limit must be a value from {NpiConstants.MinLimit} to {NpiConstants.MaxLimit}.");

                result.TryAdd(NpiQueryParameters.Limit, Limit.Value.ToString());
            }
            return result;
        }

        string? addressPurpose, enumerationType;
        int? limit, skip;
    }
}
