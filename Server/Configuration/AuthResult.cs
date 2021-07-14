using System.Collections.Generic;

namespace G_senger.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }

        public bool Success { get; set; }

        public List<string> Errors { get; set; }
    }
}
