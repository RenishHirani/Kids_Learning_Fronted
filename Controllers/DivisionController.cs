using frontend.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace frontend.Controllers
{
    public class DivisionController : Controller
    {
        private readonly Random _random = new Random();

        public IActionResult Index(int skillId)
        {
            TempData["SkillId"] = skillId;
            var model = new DigitModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult GenerateDivision(int skillId, DigitModel model)
        {
            TempData["SkillId"] = skillId;
            // Call the corresponding method based on SkillID
            switch (skillId)
            {
                case 61:
                    return GenerateDivision1(model);
                case 62:
                    return GenerateDivision2(model);
                case 63:
                    return GenerateDivision3(model);
                case 64:
                    return GenerateDivision4(model);
                case 65:
                    return GenerateDivision5(model);
                case 66:
                    return GenerateDivision6(model);
                case 67:
                    return GenerateDivision7(model);
                case 68:
                    return GenerateDivision8(model);
                case 69:
                    return GenerateDivision9(model);
                case 70:
                    return GenerateDivision10(model);
                case 71:
                    return GenerateDivision11(model);
                case 72:
                    return GenerateDivision12(model);
                case 73:
                    return GenerateDivision13(model);
                case 74:
                    return GenerateDivision14(model);
                case 75:
                    return GenerateDivision15(model);
                case 76:
                    return GenerateDivision16(model);
                case 77:
                    return GenerateDivision17(model);
                case 78:
                    return GenerateDivision18(model);
                case 79:
                    return GenerateDivision19(model);
                case 80:
                    return GenerateDivision20(model);
                case 81:
                    return GenerateDivision21(model);
                case 82:
                    return GenerateDivision22(model);
                default:
                    return View("Error");  // Default action if SkillID is invalid
            }
        }

        public IActionResult GenerateDivision1(DigitModel model)
        {
            model.Digit2 = _random.Next(1, 10); // Divisor (1 to 9)

            // Get possible single-digit multiples of Digit2
            List<int> possibleDividends = Enumerable.Range(1, 9).Where(n => n % model.Digit2 == 0).ToList();

            model.Digit1 = possibleDividends[_random.Next(possibleDividends.Count)]; // Pick a valid Dividend

            return View("Index", model);
        }
        public IActionResult GenerateDivision2(DigitModel model)
        {
            model.Digit2 = _random.Next(2, 10); // One-digit divisor (2-9)

            int digit2Value = model.Digit2 ?? 2; // Ensure it's non-null, defaulting to 2

            int minQuotient = (10 + digit2Value - 1) / digit2Value; // Ensures a two-digit result
            int maxQuotient = 99 / digit2Value; // Ensures it doesn't exceed two digits

            int quotient = _random.Next(minQuotient, maxQuotient + 1);
            model.Digit1 = digit2Value * quotient; // Ensures a two-digit first number

            return View("Index", model);
        }


        public IActionResult GenerateDivision3(DigitModel model)
        {
            model.Digit2 = _random.Next(1, 10) * 10; // Ensures two-digit whole ten (10, 20, ..., 90)

            int minQuotient = 2; // Ensures Digit1 > Digit2
            int maxQuotient = 9; // Ensures result stays two-digit
            int quotient = _random.Next(minQuotient, maxQuotient + 1);

            model.Digit1 = model.Digit2 * quotient;

            // Ensure Digit1 remains a two-digit number
            while (model.Digit1 >= 100)
            {
                quotient = _random.Next(minQuotient, maxQuotient + 1);
                model.Digit1 = model.Digit2 * quotient;
            }

            return View("Index", model);
        }
        public IActionResult GenerateDivision4(DigitModel model)
        {
            int digit2Value;
            int digit1Value;

            do
            {
                // Ensure Digit2 is a two-digit number (10 to 99)
                digit2Value = _random.Next(10, 100);

                // Generate a quotient such that Digit1 = Digit2 * quotient is also a two-digit number
                int maxQuotient = 99 / digit2Value; // Ensure Digit1 does not exceed 99
                int quotient = _random.Next(1, maxQuotient + 1); // +1 because Next's upper bound is exclusive

                digit1Value = digit2Value * quotient;

            } while (digit1Value == digit2Value); // Ensure Digit1 and Digit2 are different

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);
        }

        public IActionResult GenerateDivision5(DigitModel model)
        {
            int digit2Value; // 1-digit number
            int digit1Value; // 3-digit number

            do
            {
                // Ensure Digit2 is a 1-digit number (1 to 9)
                digit2Value = _random.Next(1, 10);

                // Generate a quotient such that Digit1 = Digit2 * quotient is a 3-digit number
                int minQuotient = 100 / digit2Value; // Ensure Digit1 is at least 100
                int maxQuotient = 999 / digit2Value; // Ensure Digit1 does not exceed 999

                // Generate a random quotient within the valid range
                int quotient = _random.Next(minQuotient, maxQuotient + 1); // +1 because Next's upper bound is exclusive

                // Calculate Digit1
                digit1Value = digit2Value * quotient;

            } while (digit1Value == digit2Value); // Ensure Digit1 and Digit2 are different (though unlikely in this case)

            // Assign values to the model
            model.Digit1 = digit1Value; // 3-digit number
            model.Digit2 = digit2Value; // 1-digit number

            return View("Index", model);
        }
        public IActionResult GenerateDivision6(DigitModel model)
        {
            model.Digit2 = _random.Next(1, 10) * 100; // Ensures a whole hundred (100, 200, ..., 900)

            int quotient = _random.Next(1, 10); // Ensures a single-digit quotient (1-9)

            model.Digit1 = model.Digit2 * quotient; // Result is always a whole hundred

            return View("Index", model);
        }

        public IActionResult GenerateDivision7(DigitModel model)
        {

            int digit2Value; // 2-digit number
            int digit1Value; // 3-digit number

            do
            {
                // Ensure Digit2 is a 2-digit number (10 to 99)
                digit2Value = _random.Next(10, 100);

                // Generate a quotient such that Digit1 = Digit2 * quotient is a 3-digit number
                int minQuotient = 100 / digit2Value; // Ensure Digit1 is at least 100
                int maxQuotient = 999 / digit2Value; // Ensure Digit1 does not exceed 999

                // Generate a random quotient within the valid range
                int quotient = _random.Next(minQuotient, maxQuotient + 1); // +1 because Next's upper bound is exclusive

                // Calculate Digit1
                digit1Value = digit2Value * quotient;

            } while (digit1Value == digit2Value); // Ensure Digit1 and Digit2 are different

            // Assign values to the model
            model.Digit1 = digit1Value; // 3-digit number
            model.Digit2 = digit2Value; // 2-digit number

            return View("Index", model);

        }
        public IActionResult GenerateDivision8(DigitModel model)
        {
            int digit2Value; // 3-digit number
            int digit1Value; // 3-digit number

            do
            {
                // Ensure Digit2 is a 3-digit number (100 to 999)
                digit2Value = _random.Next(100, 1000);

                // Generate a quotient such that Digit1 = Digit2 * quotient is a 3-digit number
                int minQuotient = 100 / digit2Value; // Ensure Digit1 is at least 100
                int maxQuotient = 999 / digit2Value; // Ensure Digit1 does not exceed 999

                // Generate a random quotient within the valid range
                if (maxQuotient >= minQuotient && maxQuotient > 0)
                {
                    int quotient = _random.Next(minQuotient, maxQuotient + 1); // +1 because Next's upper bound is exclusive

                    // Calculate Digit1
                    digit1Value = digit2Value * quotient;
                }
                else
                {
                    digit1Value = 0; // Force loop retry if invalid range
                }

            } while (digit1Value < 100 || digit1Value > 999 || digit1Value == digit2Value); // Ensure both are different 3-digit numbers

            // Assign values to the model
            model.Digit1 = digit1Value; // 3-digit number
            model.Digit2 = digit2Value; // 3-digit number

            return View("Index", model);
        }

        public IActionResult GenerateDivision9(DigitModel model)
        {
            int digit2Value; // 2-digit number
            int digit1Value; // Random 2, 3, or 4-digit number

            // Ensure Digit2 is a 2-digit number (10 to 99)
            digit2Value = _random.Next(10, 100);

            // Generate a random Digit1 (2, 3, or 4 digits), ensuring it's divisible by Digit2
            int digitLength = _random.Next(2, 5); // Randomly choose a length: 2, 3, or 4 digits
            int minValue = (int)Math.Pow(10, digitLength - 1); // Minimum value based on digit length
            int maxValue = (int)Math.Pow(10, digitLength) - 1; // Maximum value based on digit length

            List<int> divisibleNumbers = new List<int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                if (i % digit2Value == 0)
                {
                    divisibleNumbers.Add(i);
                }
            }

            // Select a random divisible number from the list
            digit1Value = divisibleNumbers[_random.Next(divisibleNumbers.Count)];

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);
        }

        public IActionResult GenerateDivision10(DigitModel model)
        {
            int digit2Value; // 3-digit number
            int digit1Value; // Random 3 or 4-digit number

            // Ensure Digit2 is a 3-digit number (100 to 999)
            digit2Value = _random.Next(100, 1000);

            // Generate a random Digit1 (3 or 4 digits), ensuring it's divisible by Digit2
            int digitLength = _random.Next(3, 5); // Randomly choose a length: 3 or 4 digits
            int minValue = (int)Math.Pow(10, digitLength - 1); // Minimum value based on digit length
            int maxValue = (int)Math.Pow(10, digitLength) - 1; // Maximum value based on digit length

            List<int> divisibleNumbers = new List<int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                if (i % digit2Value == 0)
                {
                    divisibleNumbers.Add(i);
                }
            }

            // Select a random divisible number from the list
            if (divisibleNumbers.Count > 0)
            {
                digit1Value = divisibleNumbers[_random.Next(divisibleNumbers.Count)];
            }
            else
            {
                // Fallback in case no divisible numbers are found
                digit1Value = digit2Value * _random.Next(minValue / digit2Value, (maxValue / digit2Value) + 1);
            }

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }
        public IActionResult GenerateDivision11(DigitModel model)
        {
            // Ensure Digit2 is a multiple of 1000 (1000, 2000, ..., 9000)
            model.Digit2 = _random.Next(1, 10) * 1000; // Random multiple of 1000

            // Generate a quotient (1-9) to multiply Digit2 and get Digit1
            int quotient = _random.Next(1, 10); // Single-digit quotient (1-9)

            // Ensure Digit1 is a multiple of 1000 (Digit2 * quotient will be multiple of 1000)
            model.Digit1 = model.Digit2 * quotient; // Result will be multiple of 1000

            return View("Index", model);
        }
        public IActionResult GenerateDivision12(DigitModel model)
        {
            int digit2Value; // 1-digit number
            int digit1Value; // Fixed 4-digit number

            // Ensure Digit2 is a 1-digit number (1 to 9)
            digit2Value = _random.Next(1, 10);

            // Generate a 4-digit Digit1 (1000 to 9999), ensuring it's divisible by Digit2
            int minValue = 1000; // Minimum 4-digit number
            int maxValue = 9999; // Maximum 4-digit number

            List<int> divisibleNumbers = new List<int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                if (i % digit2Value == 0)
                {
                    divisibleNumbers.Add(i);
                }
            }

            // Select a random divisible number from the list
            if (divisibleNumbers.Count > 0)
            {
                digit1Value = divisibleNumbers[_random.Next(divisibleNumbers.Count)];
            }
            else
            {
                // Fallback in case no divisible numbers are found (this should never happen)
                digit1Value = digit2Value * _random.Next(minValue / digit2Value, (maxValue / digit2Value) + 1);
            }

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }

        public IActionResult GenerateDivision13(DigitModel model)
        {
            int digit2Value; // 2-digit number (10 to 99)
            int digit1Value; // Fixed 4-digit number

            // Ensure Digit2 is a 2-digit number (10 to 99)
            digit2Value = _random.Next(10, 100);

            int minValue = 1000; // Minimum 4-digit number
            int maxValue = 9999; // Maximum 4-digit number

            List<int> divisibleNumbers = new List<int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                if (i % digit2Value == 0)
                {
                    divisibleNumbers.Add(i);
                }
            }

            // Select a random divisible number from the list
            if (divisibleNumbers.Count > 0)
            {
                digit1Value = divisibleNumbers[_random.Next(divisibleNumbers.Count)];
            }
            else
            {
                // Fallback in case no divisible numbers are found (should not happen)
                digit1Value = digit2Value * _random.Next(minValue / digit2Value, (maxValue / digit2Value) + 1);
            }

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }
        public IActionResult GenerateDivision14(DigitModel model)
        {
            int digit2Value; // 3-digit number (100 to 999)
            int digit1Value; // Fixed 4-digit number

            // Ensure Digit2 is a 3-digit number (100 to 999)
            digit2Value = _random.Next(100, 1000);

            int minValue = 1000; // Minimum 4-digit number
            int maxValue = 9999; // Maximum 4-digit number

            List<int> divisibleNumbers = new List<int>();

            // Find all 4-digit numbers divisible by digit2Value
            for (int i = minValue; i <= maxValue; i++)
            {
                if (i % digit2Value == 0)
                {
                    divisibleNumbers.Add(i);
                }
            }

            // Select a random divisible number from the list
            if (divisibleNumbers.Count > 0)
            {
                digit1Value = divisibleNumbers[_random.Next(divisibleNumbers.Count)];
            }
            else
            {
                // Fallback in case no divisible numbers are found (should not happen)
                digit1Value = digit2Value * _random.Next(minValue / digit2Value, (maxValue / digit2Value) + 1);

                // Ensure digit1Value remains within the 4-digit range
                if (digit1Value < minValue || digit1Value > maxValue)
                {
                    digit1Value = minValue + (digit2Value - (minValue % digit2Value));
                }
            }

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }
        public IActionResult GenerateDivision15(DigitModel model)
        {
            int digit2Value; // 4-digit number (1000 to 9999)
            int digit1Value; // 4-digit number, must be divisible by digit2Value

            // Ensure Digit2 is a 4-digit number (1000 to 9999)
            digit2Value = _random.Next(1000, 10000);

            int minValue = 1000; // Minimum 4-digit number
            int maxValue = 9999; // Maximum 4-digit number;

            // Compute the smallest multiple of digit2Value within the 4-digit range
            int minMultiplier = (minValue + digit2Value - 1) / digit2Value;  // Ensures a 4-digit result
            int maxMultiplier = maxValue / digit2Value;  // Ensures a 4-digit result

            // Ensure there is at least one valid multiple
            if (minMultiplier > maxMultiplier)
            {
                // If digit2Value is too large, just assign it to digit1Value (fallback case)
                digit1Value = digit2Value;
            }
            else
            {
                // Select a random multiple within the valid range
                int randomMultiplier = _random.Next(minMultiplier, maxMultiplier + 1);
                digit1Value = digit2Value * randomMultiplier;
            }

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);



        }

        public IActionResult GenerateDivision16(DigitModel model)
        {
            int digit2Value; // 1-digit number
            int digit1Value; // 5-digit number

            // Ensure Digit2 is a 1-digit number (1 to 9)
            digit2Value = _random.Next(1, 10);

            // Generate Digit1 as a 5-digit number that is divisible by Digit2
            do
            {
                digit1Value = _random.Next(10000, 100000);
            } while (digit1Value % digit2Value != 0);

            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }

        public IActionResult GenerateDivision17(DigitModel model)
        {
            int digit2Value; // 2-digit number
            int digit1Value; // 5-digit number

            // Ensure Digit2 is a 2-digit number (10 to 99)
            digit2Value = _random.Next(10, 100);

            // Generate Digit1 as a 5-digit number that is divisible by Digit2
            do
            {
                digit1Value = _random.Next(10000, 100000);
            } while (digit1Value % digit2Value != 0);

            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }

        public IActionResult GenerateDivision18(DigitModel model)
        {
            int digit2Value; // 3-digit number
            int digit1Value; // 5-digit number

            // Ensure Digit2 is a 3-digit number (100 to 999)
            digit2Value = _random.Next(100, 1000);

            // Generate Digit1 as a 5-digit number that is divisible by Digit2
            do
            {
                digit1Value = _random.Next(10000, 100000);
            } while (digit1Value % digit2Value != 0);

            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }



        public IActionResult GenerateDivision19(DigitModel model)
        {
            int digit2Value; // 4-digit number
            int digit1Value; // 5-digit number

            // Ensure Digit2 is a 4-digit number (1000 to 9999)
            digit2Value = _random.Next(1000, 10000);

            // Generate Digit1 as a 5-digit number divisible by Digit2
            do
            {
                digit1Value = _random.Next(10000, 100000);
            } while (digit1Value % digit2Value != 0);

            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }

        public IActionResult GenerateDivision20(DigitModel model)
        {
            int digit2Value; // 5-digit number
            int digit1Value; // 5-digit number

            // Ensure Digit2 is a 5-digit number (10000 to 99999)
            digit2Value = _random.Next(10000, 100000);

            // Generate Digit1 as a 5-digit number divisible by Digit2
            do
            {
                digit1Value = _random.Next(10000, 100000);
            } while (digit1Value % digit2Value != 0);

            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);


        }
        public IActionResult GenerateDivision21(DigitModel model)
        {
            int digit2Value; // Up to 5-digit number
            int digit1Value; // Up to 5-digit number
            int quotient;    // The quotient value for multiplication

            // Ensure Digit2 has a random number of digits between 1 and 5
            int digit2Length = _random.Next(1, 6);
            digit2Value = _random.Next((int)Math.Pow(10, digit2Length - 1), (int)Math.Pow(10, digit2Length));

            // Ensure Digit1 is greater than Digit2 and divisible without remainder
            do
            {
                quotient = _random.Next(1, 10); // Random quotient (1 to 9)

                // Generate Digit1 as a product of the quotient and a random number with a consistent number of digits
                int digit1Length = _random.Next(1, 6);
                int digit1Base = _random.Next((int)Math.Pow(10, digit1Length - 1), (int)Math.Pow(10, digit1Length));

                digit1Value = digit1Base * quotient;

            } while (digit1Value <= digit2Value || digit1Value % digit2Value != 0); // Ensure divisibility and greater than Digit2

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);
        }

        public IActionResult GenerateDivision22(DigitModel model)
        {
            int digit2Value; // Up to 6-digit number
            int digit1Value; // Up to 6-digit number
            int quotient;

            // Ensure Digit2 has a random number of digits between 1 and 6
            int digit2Length = _random.Next(1, 7); // Random number of digits (1 to 6)
            digit2Value = _random.Next((int)Math.Pow(10, digit2Length - 1), (int)Math.Pow(10, digit2Length));

            // Ensure Digit1 is greater than Digit2 and divisible without remainder
            do
            {
                quotient = _random.Next(1, 10); // Random quotient (1 to 9)

                // Generate Digit1 as a product of the quotient and a random number with 1 to 6 digits
                int digit1Length = _random.Next(1, 7);
                int digit1Base = _random.Next((int)Math.Pow(10, digit1Length - 1), (int)Math.Pow(10, digit1Length));

                digit1Value = digit1Base * quotient;

            } while (digit1Value <= digit2Value || digit1Value % digit2Value != 0);

            // Assign values to the model
            model.Digit1 = digit1Value;
            model.Digit2 = digit2Value;

            return View("Index", model);
        }

        private IActionResult ValidateDivisionAnswer(DigitModel model, string methodName)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int expectedQuotient = model.Digit1.Value / model.Digit2.Value;
                if (model.Answer.Equals(expectedQuotient.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} ÷ {model.Digit2} = {expectedQuotient}";
                    model.ResultType = "danger";
                }

                // Regenerate numbers for next question
                typeof(DivisionController).GetMethod(methodName)?.Invoke(this, new object[] { model });
            }
            else
            {
                model.ResultMessage = "Please enter a valid answer.";
                model.ResultType = "warning";
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer(DigitModel model, int skillId)
        {
            TempData["SkillId"] = skillId;

            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int expectedQuotient = model.Digit1.Value / model.Digit2.Value;
                if (model.Answer.Equals(expectedQuotient.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} ÷ {model.Digit2} = {expectedQuotient}";
                    model.ResultType = "danger";
                }

                switch (skillId)
                {
                    case 61: GenerateDivision1(model); break;
                    case 62: GenerateDivision2(model); break;
                    case 63: GenerateDivision3(model); break;
                    case 64: GenerateDivision4(model); break;
                    case 65: GenerateDivision5(model); break;
                    case 66: GenerateDivision6(model); break;
                    case 67: GenerateDivision7(model); break;
                    case 68: GenerateDivision8(model); break;
                    case 69: GenerateDivision9(model); break;
                    case 70: GenerateDivision10(model); break;
                    case 71: GenerateDivision11(model); break;
                    case 72: GenerateDivision12(model); break;
                    case 73: GenerateDivision13(model); break;
                    case 74: GenerateDivision14(model); break;
                    case 75: GenerateDivision15(model); break;
                    case 76: GenerateDivision16(model); break;
                    case 77: GenerateDivision17(model); break;
                    case 78: GenerateDivision18(model); break;
                    case 79: GenerateDivision19(model); break;
                    case 80: GenerateDivision20(model); break;
                    case 81: GenerateDivision21(model); break;
                    case 82: GenerateDivision22(model); break;
                    default: return View("Error");
                }
            }
            else
            {
                model.ResultMessage = "Please enter a valid answer.";
                model.ResultType = "warning";
            }

            return View("Index", model);
        }

    

    }
}