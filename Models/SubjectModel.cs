namespace frontend.Models
{
    public class SubjectModel
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public List<GradeModel> Grades { get; set; }
    }
}
