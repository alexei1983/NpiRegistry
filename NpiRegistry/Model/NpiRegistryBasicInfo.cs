using System.Text.Json.Serialization;

namespace Llc.GoodConsulting.Interfaces.NpiRegistry.Model
{
    /// <summary>
    /// Represents basic information about an individual or organization in the 
    /// National Provider Identifier (NPI) registry.
    /// </summary>
    public class NpiRegistryBasicInfo
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("authorized_official_last_name")]
        public string? AuthorizedOfficialLastName { get; set; }

        [JsonPropertyName("authorized_official_first_name")]
        public string? AuthorizedOfficialFirstName { get; set; }

        [JsonPropertyName("authorized_official_middle_name")]
        public string? AuthorizedOfficialMiddleName { get; set; }

        [JsonPropertyName("authorized_official_name_prefix")]
        public string? AuthorizedOfficialNamePrefix { get; set; }

        [JsonPropertyName("authorized_official_name_suffix")]
        public string? AuthorizedOfficialNameSuffix { get; set; }

        [JsonPropertyName("authorized_official_title_or_position")]
        public string? AuthorizedOfficialTitleOrPosition { get; set; }

        [JsonPropertyName("authorized_official_telephone_number")]
        public string? AuthorizedOfficialTelephoneNumber { get; set; }

        [JsonPropertyName("authorized_official_credential")]
        public string? AuthorizedOfficialCredential { get; set; }

        [JsonPropertyName("replacement_npi")]
        public string? ReplacementNpi { get; set; }

        [JsonPropertyName("ein")]
        public string? Ein { get; set; }

        [JsonPropertyName("organization_name")]
        public string? OrganizationName { get; set; }

        [JsonPropertyName("organizational_subpart")]
        public string? OrganizationalSubpart { get; set; }

        [JsonPropertyName("parent_organization_legal_business_name")]
        public string? ParentOrganizationLegalBusinessName { get; set; }

        [JsonPropertyName("parent_organization_ein")]
        public string? ParentOrganizationEin { get; set; }

        [JsonPropertyName("credential")]
        public string? Credential { get; set; }

        [JsonPropertyName("sole_proprietor")]
        public string? SoleProprietor { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("enumeration_date")]
        public DateTime? EnumerationDate { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime? LastUpdated { get; set; }

        [JsonPropertyName("certification_date")]
        public DateTime? CertificationDate { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("deactivation_reason_code")]
        public string? DeactivationReasonCode { get; set; }

        [JsonPropertyName("deactivation_date")]
        public DateTime? DeactivationDate { get; set; }

        [JsonPropertyName("reactivation_date")]
        public DateTime? ReactivationDate { get; set; }

        [JsonPropertyName("name_prefix")]
        public string? NamePrefix { get; set; }

        [JsonPropertyName("name_suffix")]
        public string? NameSuffix { get; set; }
    }
}
