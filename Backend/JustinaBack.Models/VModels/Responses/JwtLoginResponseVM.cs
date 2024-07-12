

namespace JustinaBack.Models
{ 
    public class JwtLoginResponseVM
    {
        public bool Success { get; set; }
        public UserToken Token { get; set; }
    }
}
