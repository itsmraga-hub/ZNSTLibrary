namespace ZNSTLibrary.Data.Models
{
    public class CustomResponse
    {
        public string Id { get; set; } = "";
        public string Message { get; set; } = "";
        public int StatusCode { get; set; }
        public CustomResponse(
            string id, string message, int statusCode
            ) {
            this.Id = id;
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public CustomResponse() { }
        public CustomResponse(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public CustomResponse(string message, int statusCode)
        {
            this.Message = message;
            this.StatusCode = statusCode;
        }
    }
}
