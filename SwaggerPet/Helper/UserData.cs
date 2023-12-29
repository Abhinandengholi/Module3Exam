using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPet.Helper
{
    public class UserData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string? username { get; set; }

        [JsonProperty("firstname")]
        public string? Firstname { get; set; }

        [JsonProperty("lastname")]
        public string? Lastname { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("userStatus")]
        public int? UserStatus { get; set; }

    }
    public class UserDataResponse
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
