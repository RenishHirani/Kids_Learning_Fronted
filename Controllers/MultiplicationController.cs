using frontend.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class MultiplicationController : Controller
    {
        private readonly Random _random = new Random();

        public IActionResult Index(int skillId)
        {
            TempData["SkillId"] = skillId;
            var model = new DigitModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult GenerateNumber(int skillId, DigitModel model)
        {
            TempData["SkillId"] = skillId;
            // Call the corresponding method based on SkillID
            switch (skillId)
            {
                case 41:
                    return GenerateNumberIndex1(model);
                case 42:
                    return GenerateNumberIndex2(model);
                case 43:
                    return GenerateNumberIndex3(model);
                case 44:
                    return GenerateNumberIndex4(model);
                case 45:
                    return GenerateNumberIndex5(model);
                case 46:
                    return GenerateNumberIndex6(model);
                case 47:
                    return GenerateNumberIndex7(model);
                case 48:
                    return GenerateNumberIndex8(model);
                case 49:
                    return GenerateNumberIndex9(model);
                case 50:
                    return GenerateNumberIndex10(model);
                case 51:
                    return GenerateNumberIndex11(model);
                case 52:
                    return GenerateNumberIndex12(model);
                case 53:
                    return GenerateNumberIndex13(model);
                case 54:
                    return GenerateNumberIndex14(model);
                case 55:
                    return GenerateNumberIndex15(model);
                case 56:
                    return GenerateNumberIndex16(model);
                case 57:
                    return GenerateNumberIndex17(model);
                case 58:
                    return GenerateNumberIndex18(model);
                case 59:
                    return GenerateNumberIndex19(model);
                case 60:
                    return GenerateNumberIndex20(model);
                default:
                    return View("Error");  // Default action if SkillID is invalid
            }
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex1(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10); // 1 to 9
            model.Digit2 = _random.Next(1, 10); // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex2(DigitModel model)
        {
            model.Digit1 = _random.Next(10, 100); // 10 to 99
            model.Digit2 = _random.Next(1, 10);   // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex3(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 10; // 10, 20, ..., 90
            model.Digit2 = _random.Next(1, 10) * 10; // 10, 20, ..., 90
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex4(DigitModel model)
        {
            int digit1, digit2;

            do
            {
                digit1 = _random.Next(10, 100); // Two-digit number (10-99)
                digit2 = _random.Next(10, 100); // Two-digit number (10-99)
            }
            while ((digit1 % 10) * (digit2 % 10) >= 10); // Ensures no carrying in the units place

            model.Digit1 = digit1;
            model.Digit2 = digit2;

            return View("Index", model);
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex5(DigitModel model)
        {
            model.Digit1 = _random.Next(100, 1000); // 100 to 999
            model.Digit2 = _random.Next(1, 10);     // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex6(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 100; // 100, 200, ..., 900
            model.Digit2 = _random.Next(1, 10) * 100; // 100, 200, ..., 900
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex7(DigitModel model)
        {
            model.Digit1 = _random.Next(100, 1000); // 100 to 999
            model.Digit2 = _random.Next(10, 100);   // 10 to 99
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex8(DigitModel model)
        {
            model.Digit1 = _random.Next(100, 1000); // 100 to 999
            model.Digit2 = _random.Next(100, 1000); // 100 to 999
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex9(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 1000; // 1000, 2000, ..., 9000
            model.Digit2 = _random.Next(1, 10) * 1000; // 1000, 2000, ..., 9000
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex10(DigitModel model)
        {
            model.Digit1 = _random.Next(11, 100); // 11 to 99 (ensuring carrying)
            model.Digit2 = _random.Next(11, 100);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex11(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(1, 10);       // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex12(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 10000; // 10000, 20000, ..., 90000
            model.Digit2 = _random.Next(1, 10) * 10000; // 10000, 20000, ..., 90000
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex13(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(10, 100);     // 10 to 99
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex14(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(100, 1000);   // 100 to 999
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex15(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(1000, 10000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex16(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(1, 10);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex17(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(10, 100);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex18(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(100, 1000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex19(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(1000, 10000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex20(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(10000, 100000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer(DigitModel model,int skillId)
        {
            TempData["SkillId"] = skillId;

            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int correctAnswer = model.Digit1.Value * model.Digit2.Value;

                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} * {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                switch (skillId)
                {
                    case 41: GenerateNumberIndex1(model); break;
                    case 42: GenerateNumberIndex2(model); break;
                    case 43: GenerateNumberIndex3(model); break;
                    case 44: GenerateNumberIndex4(model); break;
                    case 45: GenerateNumberIndex5(model); break;
                    case 46: GenerateNumberIndex6(model); break;
                    case 47: GenerateNumberIndex7(model); break;
                    case 48: GenerateNumberIndex8(model); break;
                    case 49: GenerateNumberIndex9(model); break;
                    case 50: GenerateNumberIndex10(model); break;
                    case 51: GenerateNumberIndex11(model); break;
                    case 52: GenerateNumberIndex12(model); break;
                    case 53: GenerateNumberIndex13(model); break;
                    case 54: GenerateNumberIndex14(model); break;
                    case 55: GenerateNumberIndex15(model); break;
                    case 56: GenerateNumberIndex16(model); break;
                    case 57: GenerateNumberIndex17(model); break;
                    case 58: GenerateNumberIndex18(model); break;
                    case 59: GenerateNumberIndex19(model); break;
                    case 60: GenerateNumberIndex20(model); break;
                    default: return View("Error");
                }
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }

       

    }
}
