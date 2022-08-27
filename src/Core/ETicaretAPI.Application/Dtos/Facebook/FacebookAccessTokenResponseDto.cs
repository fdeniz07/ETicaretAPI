using System.Text.Json.Serialization;

namespace ETicaretAPI.Application.Dtos.Facebook
{
    public class FacebookAccessTokenResponseDto
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
