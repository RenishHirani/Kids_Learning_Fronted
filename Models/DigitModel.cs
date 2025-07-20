namespace frontend.Models
{
    public class DigitModel
    {
        public int? Digit1 { get; set; }
        public int? Digit2 { get; set; }

        public int? Digit3 { get; set; }
        public int? Digit4 { get; set; }

        public string Answer { get; set; }
        public string ResultMessage { get; set; }
        public string ResultType { get; set; } // ✅ This property determines color

    }
}
