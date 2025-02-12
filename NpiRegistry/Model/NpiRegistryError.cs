﻿using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// Represents an error in the National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistryError
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("field")]
        public string? Field { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }
}
