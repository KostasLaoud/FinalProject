using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CertStore.Models
{
    public class Item
    {
        [Key]
        public int ItemKey { get; set; }

        [ForeignKey("CertExam")]
        public int CertExamId { get; set; } // Foreign Key to CertExam

        public int CategoryId { get; set; }
        public int Number { get; set; }

        [JsonIgnore] // Prevent serialization and validation
        [Newtonsoft.Json.JsonIgnore] // Ensure compatibility with Newtonsoft if used
        public CertExam? CertExam { get; set; }
    }
}
