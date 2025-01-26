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
            var urlParameters = GetQueryString(parameters) ?? string.Empty;
            var entity = await request.MakeRequest<TResponse>(urlParameters, "GET");
            if (entity == null || !entity.IsSuccess)
                throw new Exception("NPI registry returned a non-successful response.");
            return entity?.Entity;
        }

        /// <summary>
        /// Builds a url-encoded query string for the specified parameter(s).
        /// </summary>
        /// <param name="parameters">Parameters to url-encode into a query string.</param>
        /// <returns><see cref="string"/></returns>
        protected virtual string? GetQueryString(Dictionary<string, string>? parameters)
        {
            if (parameters?.Count > 0)
            {
                var queryString = "?";
                foreach (var parameter in parameters)
                    queryString += $"{parameter.Key}={Uri.EscapeDataString(parameter.Value)}&";

                return queryString.TrimEnd('&');
            }
            return null;
        }
    }
}
