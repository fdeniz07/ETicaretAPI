using System.Text.Json.Serialization;

namespace ETicaretAPI.Application.Dtos.Facebook
{
    public class FacebookUserAccessTokenValidationDto
    {
        [JsonPropertyName("data")]
        public FacebookUserAccessTokenValidationDataDto Data { get; set; }
    }

    public class FacebookUserAccessTokenValidationDataDto
    {
        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
