using System.Collections.Generic;

namespace DesktopApp.Dtos.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public bool Success { get; set; }

        public List<string> Errors { get; set; }
    }
}
