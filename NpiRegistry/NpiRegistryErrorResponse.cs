using System.Text.Json.Serialization;
using Llc.GoodConsulting.Interfaces.NpiRegistry.Model;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public class NpiRegistryErrorResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Errors")]
        public List<NpiRegistryError>? Errors { get; set; }
    }
}
