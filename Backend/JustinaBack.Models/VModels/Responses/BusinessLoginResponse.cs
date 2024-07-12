
namespace JustinaBack.Models
{ 
    public class BusinessMVCResponse
    {
        public bool Success { get; set; }
        public string ToasterCode
        {
            get
            {
                return Success ? "success" : "error";
            }
        }
        public string Message { get; set; }
    }
}
