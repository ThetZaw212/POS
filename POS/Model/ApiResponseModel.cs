namespace POS.Model
{
    public class ApiResponseModel
    {
        public required int StatusCode { get; set; }
        public required bool Success { get; set; } = false;

        public dynamic? Data { get; set; }
        public dynamic? Meassage { get; set; }

        public bool? exists {  get; set; }
    }
}
