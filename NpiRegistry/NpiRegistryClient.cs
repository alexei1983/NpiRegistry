
using Llc.GoodConsulting.Interfaces.NpiRegistry.Model;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryClient
    {
        readonly NpiRegistrySearchRequest searchRequest;

        /// <summary>
        /// 
        /// </summary>
        public NpiRegistryClient()
        {
            searchRequest = new NpiRegistrySearchRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="searchOnFirstNameAlias"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="searchOnFirstNameAlias"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByName(string lastName, string firstName, bool searchOnFirstNameAlias = true)
        {
            return SearchByNameAsync(lastName, firstName, searchOnFirstNameAlias).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByOrganizationName(string organizationName)
        {
            return SearchByOrganizationNameAsync(organizationName).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<NpiRegistryRecord>> SearchByNumberAsync(int number)
        {
            if (number < 1)
                throw new ArgumentException($"Invalid NPI number: {number}", nameof(number));

            return await SearchByNumberAsync(number.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByNumber(string number)
        {
            return SearchByNumberAsync(number).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByNumber(int number)
        {
            return SearchByNumberAsync(number).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByCityState(string city, string state, int limit = 0, int skip = 0)
        {
            return SearchByCityStateAsync(city, state, limit, skip).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByState(string state, int limit = 0, int skip = 0)
        {
            return SearchByStateAsync(state, limit, skip).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxonomy"></param>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="taxonomy"></param>
        /// <param name="state"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> SearchByTaxonomyState(string taxonomy, string state, int limit = 0, int skip = 0)
        {
            return SearchByTaxonomyStateAsync(taxonomy, state, limit, skip).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <returns></returns>
        public async Task<List<NpiRegistryRecord>> SearchAsync(NpiRegistrySearchOptions searchOptions)
        {
            searchRequest.ClearOptions();

            searchRequest.SetOptions(searchOptions);

            var searchResult = await searchRequest.Execute();

            return searchResult?.Results ?? [];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <returns></returns>
        public List<NpiRegistryRecord> Search(NpiRegistrySearchOptions searchOptions)
        {
            return SearchAsync(searchOptions).Result;
        }
    }
}
