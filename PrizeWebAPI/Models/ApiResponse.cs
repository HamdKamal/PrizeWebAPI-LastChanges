﻿namespace PrizeWebAPI.Models
{
   
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public string? Error { get; set; } // Optional: for dev/internal use
    }
  
}
