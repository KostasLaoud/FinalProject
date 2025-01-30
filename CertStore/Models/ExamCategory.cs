using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CertStore.Models
{
    public class ExamCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey("FullCategory")]
        public int FullId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        //public  decimal Price { get; set; }
    }
}
