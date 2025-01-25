using System.Net;
using System.Text.Json;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryRequest
    {
        const string ApiUrl = "https://npiregistry.cms.hhs.gov/api/";

        /// <summary>
        /// 
        /// </summary>
        public NpiRegistryRequest()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string? ExecuteString(Dictionary<string, string>? parameters = null)
        {
            var request = GetRequest(parameters);
            return ReadResponseString(GetResponse(request));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual TResponse? Execute<TResponse>(Dictionary<string, string>? parameters = null)
        {
            var jsonString = ExecuteString(parameters);
            if (!string.IsNullOrEmpty(jsonString))
                return JsonSerializer.Deserialize<TResponse>(jsonString);
            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual HttpWebResponse GetResponse(HttpWebRequest request)
        {
            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual string? ReadResponseString(HttpWebResponse response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response), "Response cannot be null.");

            using var responseStream = response.GetResponseStream() ?? throw new NullReferenceException("Error reading response stream");
            using var reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected virtual HttpWebRequest GetRequest(Dictionary<string, string>? parameters = null)
        {
            parameters ??= [];

            var request = (HttpWebRequest)WebRequest.Create($"{ApiUrl}{GetQueryString(parameters)}");
            request.Method = "GET";

            // enable TLS 1.2 protocol
            request.ServicePoint.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            return request;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected virtual string? GetQueryString(Dictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                var queryString = "?";
                foreach (var parameter in parameters)
                {
                    queryString += $"{parameter.Key}={Uri.EscapeDataString(parameter.Value)}&";
                }

                return queryString.TrimEnd('&');
            }

            return string.Empty;
        }
    }
}
