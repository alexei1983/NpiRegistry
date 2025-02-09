using System.Reflection;
using Llc.GoodConsulting.Web.EnhancedWebRequest;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Encapsulates a web API request to the National Provider Identifier (NPI) registry.
    /// </summary>
    internal class NpiRegistryRequest
    {
        const string ApiUrl = "https://npiregistry.cms.hhs.gov/api";
        protected readonly EnhancedWebRequest request;
        const string UserAgentName = "NpiRegistryClient";

        /// <summary>
        /// Creates a new instance of the <see cref="NpiRegistryRequest"/> class.
        /// </summary>
        public NpiRegistryRequest()
        {
            request = new EnhancedWebRequest(ApiUrl, new EnhancedWebRequestOptions()
            {
                UserAgent = UserAgentName,
                UserAgentVersion = Assembly.GetExecutingAssembly().GetName()?.Version
            });
        }

        /// <summary>
        /// Executes the current <see cref="NpiRegistryRequest"/> instance.
        /// </summary>
        /// <returns></returns>
        protected async virtual Task<TResponse?> Execute<TResponse>(Dictionary<string, string>? parameters = null) where TResponse : class, new()
        {
            var response = await request.Get(parameters ?? []);
            return await response.ExpectSuccess().AsJsonEntityAsync<TResponse>();
        }
    }
}
