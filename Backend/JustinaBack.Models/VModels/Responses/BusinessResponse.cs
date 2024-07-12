
using System.Collections;
using System.Net;


namespace JustinaBack.Models
{
    public class BusinessResponse
    {
        public bool Success
        {
            get
            {
                return StatusCode.Equals(HttpStatusCode.OK);
            }
        }
        public string? PublicKey { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable? GenericList { get; set; }
        public object? GenericObject { get; set; }
    }
}
