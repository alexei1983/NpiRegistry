using System.Reflection;
using Llc.GoodConsulting.Web.EnhancedWebRequest;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryRequest
    {
        const string ApiUrl = "https://npiregistry.cms.hhs.gov/api";
        protected readonly EnhancedWebRequest request;

        /// <summary>
        /// 
        /// </summary>
        public NpiRegistryRequest()
        {
            request = new EnhancedWebRequest(ApiUrl, new EnhancedWebRequestOptions()
            {
                UserAgent = "NpiRegistryClient",
                UserAgentVersion = Assembly.GetExecutingAssembly().GetName()?.Version
            });
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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
