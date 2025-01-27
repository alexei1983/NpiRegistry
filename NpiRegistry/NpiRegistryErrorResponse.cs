using System.Text.Json.Serialization;
using Llc.GoodConsulting.Interfaces.NpiRegistry.Model;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Represents an error response from the National Provider Identifier (NPI) registry.
    /// </summary>
    internal class NpiRegistryErrorResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("Errors")]
        public List<NpiRegistryError>? Errors { get; set; }
    }
}
