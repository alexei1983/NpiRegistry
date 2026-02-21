
using Llc.GoodConsulting.Interfaces.NpiRegistry.Model;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// API client for interacting with the National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistryClient
    {
        readonly HttpClient client;
        const string ApiUrl = "https://npiregistry.cms.hhs.gov/api";
        const string UserAgentName = "NpiRegistryClient";

        /// <summary>
        /// Creates a new instance of the <see cref="NpiRegistryClient"/> class.
        /// </summary>
        public NpiRegistryClient(HttpClient httpClient)
        {
            client = httpClient;
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(UserAgentName, Assembly.GetExecutingAssembly().GetName()?.Version?.ToString(3)));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by first and last name, optionally including 
        /// aliases of the first name.
        /// </summary>
        /// <param name="lastName">Individual last name.</param>
        /// <param name="firstName">Individual first name.</param>
        /// <param name="searchOnFirstNameAlias">Whether or not to search using aliases of the first name.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByNameAsync(string lastName, string firstName, bool searchOnFirstNameAlias = true)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Last name is required.", nameof(lastName));

            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First name is required.", nameof(firstName));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                LastName = lastName,
                FirstName = firstName,
                UseFirstNameAlias = searchOnFirstNameAlias
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by first and last name, optionally including 
        /// aliases of the first name.
        /// </summary>
        /// <param name="lastName">Individual last name.</param>
        /// <param name="firstName">Individual first name.</param>
        /// <param name="searchOnFirstNameAlias">Whether or not to search using aliases of the first name.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByName(string lastName, string firstName, bool searchOnFirstNameAlias = true)
        {
            return SearchByNameAsync(lastName, firstName, searchOnFirstNameAlias).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by organization name.
        /// </summary>
        /// <param name="organizationName">Organization name.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByOrganizationNameAsync(string organizationName)
        {
            if (string.IsNullOrEmpty(organizationName))
                throw new ArgumentException("Organization name is required.", nameof(organizationName));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                OrganizationName = organizationName,
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by organization name.
        /// </summary>
        /// <param name="organizationName">Organization name.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByOrganizationName(string organizationName)
        {
            return SearchByOrganizationNameAsync(organizationName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by NPI number.
        /// </summary>
        /// <param name="number">NPI number.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByNumberAsync(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentException("NPI number is required.", nameof(number));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                Number = number,
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by NPI number.
        /// </summary>
        /// <param name="number">NPI number.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByNumberAsync(int number)
        {
            if (number < 1)
                throw new ArgumentException($"Invalid NPI number: {number}", nameof(number));

            return await SearchByNumberAsync(number.ToString());
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by NPI number.
        /// </summary>
        /// <param name="number">NPI number.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByNumber(string number)
        {
            return SearchByNumberAsync(number).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by NPI number.
        /// </summary>
        /// <param name="number">NPI number.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByNumber(int number)
        {
            return SearchByNumberAsync(number).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by city and state.
        /// </summary>
        /// <param name="city">City name.</param>
        /// <param name="state">Two-letter U.S. state.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByCityStateAsync(string city, string state, int limit = 0, int skip = 0)
        {
            if (string.IsNullOrEmpty(city))
                throw new ArgumentException("City name is required.", nameof(city));

            if (string.IsNullOrEmpty(state))
                throw new ArgumentException("State is required.", nameof(state));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                City = city,
                State = state,
                Limit = limit > 0 ? limit : null,
                Skip = skip > 0 ? skip : null
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by city and state.
        /// </summary>
        /// <param name="city">City name.</param>
        /// <param name="state">Two-letter U.S. state.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByCityState(string city, string state, int limit = 0, int skip = 0)
        {
            return SearchByCityStateAsync(city, state, limit, skip).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by postal code.
        /// </summary>
        /// <param name="postalCode">Postal code.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByPostalCodeAsync(string postalCode, int limit = 0, int skip = 0)
        {
            if (string.IsNullOrEmpty(postalCode))
                throw new ArgumentException("Postal code is required.", nameof(postalCode));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                PostalCode = postalCode,
                Limit = limit > 0 ? limit : null,
                Skip = skip > 0 ? skip : null
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by postal code.
        /// </summary>
        /// <param name="postalCode">Postal code.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByPostalCode(string postalCode, int limit = 0, int skip = 0)
        {
            return SearchByPostalCodeAsync(postalCode, limit, skip).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by taxonomy and state.
        /// </summary>
        /// <param name="taxonomy">Taxonomy description.</param>
        /// <param name="state">Two-letter U.S. state.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByTaxonomyStateAsync(string taxonomy, string state, int limit = 0, int skip = 0)
        {
            if (string.IsNullOrEmpty(taxonomy))
                throw new ArgumentException("Taxonomy is required.", nameof(taxonomy));

            if (string.IsNullOrEmpty(state))
                throw new ArgumentException("State is required.", nameof(state));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                State = state,
                TaxonomyDescription = taxonomy,
                Limit = limit > 0 ? limit : null,
                Skip = skip > 0 ? skip : null
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by taxonomy and state.
        /// </summary>
        /// <param name="taxonomy">Taxonomy description.</param>
        /// <param name="state">Two-letter U.S. state.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByTaxonomyState(string taxonomy, string state, int limit = 0, int skip = 0)
        {
            return SearchByTaxonomyStateAsync(taxonomy, state, limit, skip).Result;
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry using the specified search options.
        /// </summary>
        /// <param name="searchOptions"><see cref="NpiRegistrySearchOptions"/> instance of options to use when searching.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        public async Task<List<NpiRegistryRecord>> SearchAsync(NpiRegistrySearchOptions searchOptions)
        {
            var searchResult = await Execute<NpiRegistryListResponse>(searchOptions);
            return searchResult?.Results ?? new List<NpiRegistryRecord>();
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry using the specified search options.
        /// </summary>
        /// <param name="searchOptions"><see cref="NpiRegistrySearchOptions"/> instance of options to use when searching.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> Search(NpiRegistrySearchOptions searchOptions)
        {
            return SearchAsync(searchOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async virtual Task<TResponse?> Execute<TResponse>(NpiRegistrySearchOptions opts = default) where TResponse : class, new()
        {
            var uri = string.Empty;
            var parameters = opts.GetQueryParameters();
            parameters.TryAdd(NpiQueryParameters.Version, NpiConstants.ApiVersion21);

            if (parameters.Count > 0)
            {
                uri += '?';
                foreach (var kvp in parameters)
                    uri += $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}&";
            }

            var req = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}{uri}");

            using (var resp = await client.SendAsync(req).ConfigureAwait(false)) {

                var content = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);

                var error = JsonSerializer.Deserialize<NpiRegistryErrorResponse>(content);
                if (error != null && error.Errors?.Count > 0)
                {
                    var message = string.Empty;
                    foreach (var err in error.Errors)
                    {
                        if (!string.IsNullOrEmpty(message))
                            message += Environment.NewLine;
                        message += $"{err.Field}: {err.Description}";
                    }
                    throw new Exception(message);
                }

                if (resp.IsSuccessStatusCode)
                   return JsonSerializer.Deserialize<TResponse>(content);
                else
                    throw new Exception($"{(int)resp.StatusCode} - {resp.ReasonPhrase}{Environment.NewLine}{content}");
            }
            return default;
        }
    }
}
