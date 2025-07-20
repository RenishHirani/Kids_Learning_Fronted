namespace frontend.Models
{
    public class PdfViewModel
    {
        public string SchoolName { get; set; }
        public int TotalMarks { get; set; }
        public DateTime ExamDate { get; set; }
        public string SkillName { get; set; }
        public List<string> Problems { get; set; } = new List<string>();
    }
}
