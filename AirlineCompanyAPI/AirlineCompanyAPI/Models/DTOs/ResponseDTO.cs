namespace AirlineCompWebApi.DTOs
{
    public class ResponseDTO
    {
        public string Status { get; set; } // E.g., "Success" or "Error"
        public string Message { get; set; } // Additional information about the result
        public object Data { get; set; } // Optional: Include any data you want to return
    }
}
