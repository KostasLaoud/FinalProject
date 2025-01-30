//using System.ComponentModel.DataAnnotations;

//namespace CertStore.Models
//{
//    public struct Item
//    {
//        [Key]
//        public int ItemKey { get; set; }
//        public int ExamId { get; set; }
//        public int Number { get; set; }
//    }

//    public class CertExam
//    {
//        [Key]
//        public int CertExamId { get; set; }
//        public int FullId { get; set; }
//        public int CategoryId { get; set; }
//        public int ExamId { get; set; }
//        public List<Item> ExamQuestions { get; set; }
//        public string TestTitle { get; set; } = string.Empty;
//        public string TestDescription { get; set; } = string.Empty;
//        public decimal Price { get; set; }
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace CertStore.Models
{


    public class CertExam
    {
        [Key]
        public int CertExamId { get; set; }

        public int FullId { get; set; }

        public string TestTitle { get; set; } = string.Empty;
        public string TestDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Navigation Property for related Items
        public List<Item> ExamQuestions { get; set; } = new List<Item>();
    }
}
