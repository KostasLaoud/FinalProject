using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace CertStore.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateKey { get; set; } 
        public string userId { get; set; } 
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public string SuccessRate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TotalScore { get; set; }
        public int CandidateNumber { get; set; } 
        public int TestCode { get; set; } = 0;
        public string StartTime { get; set; }
        public string ReportDate { get; set; }
        public string FinishTitle { get; set; }
        public bool Passed { get; set; }
        public bool Marked { get; set; }
        public bool Reject { get; set; }
        public string TestDescription { get; set; }

    }
}
