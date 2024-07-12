

namespace JustinaBack.Models
{
    public class ErrorVM
    {
        public ErrorVM(string message)
        {
            this.Message = message;
        }

        public ErrorVM(List<string> errors, string message)
        {
            this.Message = message;
            errors.RemoveAll(e => String.IsNullOrEmpty(e));
            this.Errors = errors;
        }

        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
