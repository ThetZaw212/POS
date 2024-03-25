namespace POS.Model
{
    public class ApiResponseModel
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; } = true;

        public required dynamic Data { get; set; }
        public required dynamic Meassage { get; set; }
    }
}
