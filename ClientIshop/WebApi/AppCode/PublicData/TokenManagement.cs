using Newtonsoft.Json;

namespace WebApi.AppCode.PublicData
{ 

    public class TokenManagement
    {
        [JsonProperty("cloudHost")]
        public string CloudHost { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }

        [JsonProperty("refreshExpiration")]
        public int RefreshExpiration { get; set; }
    }
}
