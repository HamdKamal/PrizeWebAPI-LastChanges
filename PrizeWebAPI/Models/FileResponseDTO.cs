using System.ComponentModel.DataAnnotations;

namespace PrizeWebAPI.Models
{
    public class FileResponseDTO
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileBytes { get; set; }
    }

}
