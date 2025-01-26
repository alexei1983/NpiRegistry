
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Searches the National Provider Identifier (NPI) Registry.
    /// </summary>
    internal class NpiRegistrySearchRequest : NpiRegistryRequest
    {
        readonly Dictionary<string, string> Parameters = [];

        /// <summary>
        /// Creates a new instance of the <see cref="NpiRegistrySearchRequest"/> class.
        /// </summary>
        public NpiRegistrySearchRequest() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="NpiRegistrySearchRequest"/> class.
        /// </summary>
        /// <param name="options"><see cref="NpiRegistrySearchOptions"/> instance to apply to the current request.</param>
        public NpiRegistrySearchRequest(NpiRegistrySearchOptions options) : base()
        {
            SetOptions(options);
        }

        /// <summary>
        /// Sets the search parameters specified in the <see cref="NpiRegistrySearchOptions"/> instance.
        /// </summary>
        /// <param name="options"><see cref="NpiRegistrySearchOptions"/> instance to apply to the current request.</param>
        public void SetOptions(NpiRegistrySearchOptions options)
        {
            if (!string.IsNullOrEmpty(options.FirstName))
            {
                var useAlias = options.UseFirstNameAlias ?? true;
                SetFirstName(options.FirstName, useAlias);
            }

            if (!string.IsNullOrEmpty(options.LastName))
                SetLastName(options.LastName);

            if (!string.IsNullOrEmpty(options.OrganizationName))
                SetOrganizationName(options.OrganizationName);

            if (!string.IsNullOrEmpty(options.EnumerationType))
                SetEnumerationType(options.EnumerationType);

            if (!string.IsNullOrEmpty(options.Number))
                SetNumber(options.Number);

            if (!string.IsNullOrEmpty(options.TaxonomyDescription))
                SetTaxonomyDescription(options.TaxonomyDescription);

            if (!string.IsNullOrEmpty(options.AddressPurpose))
                SetAddressPurpose(options.AddressPurpose);

            if (!string.IsNullOrEmpty(options.City))
                SetCity(options.City);

            if (!string.IsNullOrEmpty(options.State))
                SetState(options.State);

            if (!string.IsNullOrEmpty(options.PostalCode))
                SetPostalCode(options.PostalCode);

            if (!string.IsNullOrEmpty(options.CountryCode))
                SetCountryCode(options.CountryCode);

            if (options.Limit.HasValue)
                SetLimit(options.Limit.Value);

            if (options.Skip.HasValue)
                SetSkip(options.Skip.Value);
        }

        /// <summary>
        /// Clears search parameter queries and options.
        /// </summary>
        public void ClearOptions()
        {
            Parameters.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="searchAliasFirstName"></param>
        public void SetFirstName(string firstName, bool searchAliasFirstName)
        {
            SetParameter(NpiQueryParameters.FirstName, firstName);
            if (!searchAliasFirstName)
                SetParameter(NpiQueryParameters.UseFirstNameAlias, NpiConstants.False);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        public void SetFirstName(string firstName)
        {
            SetFirstName(firstName, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        public void SetLastName(string lastName)
        {
            SetParameter(NpiQueryParameters.LastName, lastName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerationType"></param>
        public void SetEnumerationType(string enumerationType)
        {
            if (!NpiType.IsValid(enumerationType))
                throw new ArgumentException($"Invalid enumeration type: {enumerationType}", nameof(enumerationType));

            SetParameter(NpiQueryParameters.EnumerationType, enumerationType.ToUpper());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(string number)
        {
            SetParameter(NpiQueryParameters.Number, number);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException($"Invalid NPI number: {number}", nameof(number));

            SetNumber(number.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public void SetTaxonomyDescription(string description)
        {
            SetParameter(NpiQueryParameters.TaxonomyDescription, description);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgName"></param>
        public void SetOrganizationName(string orgName)
        {
            SetParameter(NpiQueryParameters.OrganizationName, orgName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressPurpose"></param>
        public void SetAddressPurpose(string addressPurpose)
        {
            if (!NpiAddressPurpose.IsValid(addressPurpose))
                throw new ArgumentException($"Invalid address purpose: {addressPurpose}", nameof(addressPurpose));

            SetParameter(NpiQueryParameters.AddressPurpose, addressPurpose.ToUpper());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        public void SetCity(string city)
        {
            SetParameter(NpiQueryParameters.City, city);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void SetState(string state)
        {
            SetParameter(NpiQueryParameters.State, state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postalCode"></param>
        public void SetPostalCode(string postalCode)
        {
            SetParameter(NpiQueryParameters.PostalCode, postalCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryCode"></param>
        public void SetCountryCode(string countryCode)
        {
            SetParameter(NpiQueryParameters.CountryCode, countryCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit"></param>
        public void SetLimit(int limit)
        {
            if (limit < NpiConstants.MinLimit || limit > NpiConstants.MaxLimit)
                throw new ArgumentException($"Limit must be a value from {NpiConstants.MinLimit} to {NpiConstants.MaxLimit}.", nameof(limit));

            SetParameter(NpiQueryParameters.Limit, limit.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        public void SetSkip(int skip)
        {
            if (skip < 0)
                skip = 0;

            SetParameter(NpiQueryParameters.Skip, skip.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetParameter(string key, string? value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                if (!Parameters.TryAdd(key, value))
                    Parameters[key] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<NpiRegistryListResponse?> Execute()
        {
            SetParameter(NpiQueryParameters.Version, NpiConstants.ApiVersion21);
            return await base.Execute<NpiRegistryListResponse>(Parameters);
        }
    }
}
