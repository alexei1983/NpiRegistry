
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Searches the National Plan &amp; Provider Enumeration System NPI Registry.
    /// </summary>
    public class NpiRegistrySearchRequest : NpiRegistryRequest
    {
        readonly Dictionary<string, string> Parameters = [];

        /// <summary>
        /// 
        /// </summary>
        public NpiRegistrySearchRequest()
        {
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
                SetParameter(NpiQueryParameters.UseFirstNameAlias, "False");
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
            if (limit < 1 || limit > 200)
                throw new ArgumentException("Limit must be a value from 1 to 200.", nameof(limit));

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
        public NpiRegistryListResponse? Execute()
        {
            SetParameter(NpiQueryParameters.Version, "2.1");
            return base.Execute<NpiRegistryListResponse>(Parameters);
        }
    }
}
