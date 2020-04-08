namespace Core.Model
{
    public class ApiResponseModel
    {
        public string Message { get; set; }
        public ResponseType Type { get; set; } 
        public object Data { get; set; }
    }
}
