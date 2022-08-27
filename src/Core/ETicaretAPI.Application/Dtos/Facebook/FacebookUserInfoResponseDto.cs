using System.Text.Json.Serialization;

namespace ETicaretAPI.Application.Dtos.Facebook
{
    public class FacebookUserInfoResponseDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
