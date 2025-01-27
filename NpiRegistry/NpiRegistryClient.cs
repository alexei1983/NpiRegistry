
using Llc.GoodConsulting.Interfaces.NpiRegistry.Model;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// API client for interacting with the National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistryClient
    {
        /// <summary>
        /// Underlying search request.
        /// </summary>
        readonly NpiRegistrySearchRequest searchRequest;

        /// <summary>
        /// Creates a new instance of the <see cref="NpiRegistryClient"/> class.
        /// </summary>
        public NpiRegistryClient()
        {
            searchRequest = new NpiRegistrySearchRequest();
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
            return SearchByNameAsync(lastName, firstName, searchOnFirstNameAlias).Result;
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
            return SearchByOrganizationNameAsync(organizationName).Result;
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
            return SearchByNumberAsync(number).Result;
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by NPI number.
        /// </summary>
        /// <param name="number">NPI number.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByNumber(int number)
        {
            return SearchByNumberAsync(number).Result;
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
            return SearchByCityStateAsync(city, state, limit, skip).Result;
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by state.
        /// </summary>
        /// <param name="state">Two-letter U.S. state.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="Task{List{NpiRegistryRecord}}"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByStateAsync(string state, int limit = 0, int skip = 0)
        {
            if (string.IsNullOrEmpty(state))
                throw new ArgumentException("State is required.", nameof(state));

            return await SearchAsync(new NpiRegistrySearchOptions()
            {
                State = state,
                Limit = limit > 0 ? limit : null,
                Skip = skip > 0 ? skip : null
            });
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry by state.
        /// </summary>
        /// <param name="state">Two-letter U.S. state.</param>
        /// <param name="limit">Number of records to return when searching (1-200).</param>
        /// <param name="skip">Number of records to skip when searching.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> SearchByState(string state, int limit = 0, int skip = 0)
        {
            return SearchByStateAsync(state, limit, skip).Result;
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
            searchRequest.ClearOptions();

            searchRequest.SetOptions(searchOptions);

            var searchResult = await searchRequest.Execute();

            return searchResult?.Results ?? [];
        }

        /// <summary>
        /// Searches the National Provider Identifier (NPI) registry using the specified search options.
        /// </summary>
        /// <param name="searchOptions"><see cref="NpiRegistrySearchOptions"/> instance of options to use when searching.</param>
        /// <returns><see cref="List{NpiRegistryRecord}"/></returns>
        public List<NpiRegistryRecord> Search(NpiRegistrySearchOptions searchOptions)
        {
            return SearchAsync(searchOptions).Result;
        }
    }
}
