using System.ComponentModel.DataAnnotations;

namespace MvcRope.Models
{
    public class Rope
    {
        public int Id { get; set; }
        [Required]
        public string Ropename { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int AmountMade { get; set; }
    }
}
