using frontend.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Controllers
{
    public class SubtractionController : Controller
    {
        private const int Ten = 10;
        private const int NintyNine = 99;
        private const int Nine = 9;
        private const int Zero = 0;
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
                case 26:
                    return GenerateNumberIndex1(model);
                case 27:
                    return GenerateNumberIndex2(model);
                case 28:
                    return GenerateNumberIndex3(model);
                case 29:
                    return GenerateNumberIndex4(model);
                case 30:
                    return GenerateNumberIndex5(model);
                case 31:
                    return GenerateNumberIndex6(model);
                case 32:
                    return GenerateNumberIndex7(model);
                case 33:
                    return GenerateNumberIndex8(model);
                case 34:
                    return GenerateNumberIndex9(model);
                case 35:
                    return GenerateNumberIndex10(model);
                case 36:
                    return GenerateNumberIndex11(model);
                case 37:
                    return GenerateNumberIndex12(model);
                case 38:
                    return GenerateNumberIndex13(model);
                case 39:
                    return GenerateNumberIndex14(model);
                case 40:
                    return GenerateNumberIndex15(model);
                default:
                    return View("Error");  // Default action if SkillID is invalid
            }
        }
        public IActionResult SubmitAnswer(int skillId, DigitModel model)
        {
            TempData["SkillId"] = skillId;
            // Call the corresponding SubmitAnswer method based on SkillID
            switch (skillId)
            {
                case 26:
                    return SubmitAnswer1(model);
                case 27:
                    return SubmitAnswer2(model);
                case 28:
                    return SubmitAnswer3(model);
                case 29:
                    return SubmitAnswer4(model);
                case 30:
                    return SubmitAnswer5(model);
                case 31:
                    return SubmitAnswer6(model);
                case 32:
                    return SubmitAnswer7(model);
                case 33:
                    return SubmitAnswer8(model);
                case 34:
                    return SubmitAnswer9(model);
                case 35:
                    return SubmitAnswer10(model);
                case 36:
                    return SubmitAnswer11(model);
                case 37:
                    return SubmitAnswer12(model);
                case 38:
                    return SubmitAnswer13(model);
                case 39:
                    return SubmitAnswer14(model);
                case 40:
                    return SubmitAnswer15(model);
                default:
                    return View("Error");  // Default action if SkillID is invalid
            }
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex1(DigitModel model)
        {
            int num1 = _random.Next(1, 9); // First number between 1 and 8 (ensures num1 > 0)
            int num2 = _random.Next(0, num1); // Second number between 0 and num1-1 (ensures num2 < num1)

            model.Digit1 = num1;
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex2(DigitModel model)
        {
            int num1_tens = _random.Next(1, 10); // Tens place (1 to 9)
            int num1_units = _random.Next(0, 10); // Units place (0 to 9)
            int num1 = (num1_tens * 10) + num1_units; // Construct two-digit number

            int num2 = _random.Next(0, num1_units + 1); // One-digit number, ensuring no borrowing

            model.Digit1 = num1;
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex3(DigitModel model)
        {
            // Generate the tens place (1 to 9) to ensure a two-digit number
            int tens1 = _random.Next(1, 10);
            int ones1 = _random.Next(0, 10);

            model.Digit1 = (tens1 * 10) + ones1; // Construct first two-digit number

            // Ensure the second number's tens place is less than or equal to the first number's tens place
            int tens2 = _random.Next(0, tens1 + 1);

            // Ensure the ones place of second number is <= ones place of first number to avoid borrowing
            int ones2 = _random.Next(0, ones1 + 1);

            model.Digit2 = (tens2 * 10) + ones2; // Construct second two-digit number

            return View("Index", model); // Return the view with generated numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex4(DigitModel model)
        {
            // Generate the first number: a multiple of 10 between 10 and 90
            int num1 = _random.Next(1, 10) * 10; // Ensures numbers like 10, 20, ..., 90

            // Generate the second number: a multiple of 10 that is smaller than num1
            int num2 = _random.Next(1, (num1 / 10) + 1) * 10; // Ensures num2 < num1

            // Assign values to model
            model.Digit1 = num1;
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex5(DigitModel model)
        {
            int num1, num2, ones1;

            do
            {
                // Generate a two-digit number (10 to 99)
                num1 = _random.Next(10, 100);

                // Extract the ones place of num1
                ones1 = num1 % 10;

                // Generate a one-digit number greater than ones1 to force borrowing
                num2 = _random.Next(ones1 + 1, 10);
            }
            while (num2 <= ones1); // Ensures borrowing occurs

            // Assign values to the model
            model.Digit1 = num1;
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex6(DigitModel model)
        {
            // Generate Num1 as a two-digit number
            int num1 = _random.Next(10, 100); // Num1 is a two-digit number (e.g., 10, 20,..., 99)

            // Generate Num2 such that Num2 < Num1 and allows for borrowing
            int num2 = _random.Next(10, num1); // Num2 is a two-digit number less than Num1

            // Ensure borrowing will occur (e.g., Num1's ones digit is smaller than Num2's ones digit)
            while ((num1 % 10) < (num2 % 10))
            {
                num2 = _random.Next(10, num1); // Retry if borrowing is not possible
            }

            // Assign the values to the model
            model.Digit1 = num1;
            model.Digit2 = num2;

            // Display these values in the view
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex7(DigitModel model)
        {
            // Generate Num1 as a three-digit number
            int num1 = _random.Next(100, 1000); // Num1 is a three-digit number (e.g., 100, 200,..., 999)

            // Generate Num2 such that Num2 < Num1 and no borrowing occurs
            int num2 = _random.Next(100, num1); // Num2 is a three-digit number less than Num1

            // Ensure no borrowing will occur (e.g., Num1's ones digit >= Num2's ones digit)
            while ((num1 % 10) < (num2 % 10) || (num1 / 10 % 10) < (num2 / 10 % 10) || (num1 / 100) < (num2 / 100))
            {
                num2 = _random.Next(100, num1); // Retry if borrowing would occur
            }

            // Assign the values to the model
            model.Digit1 = num1;
            model.Digit2 = num2;

            // Display these values in the view
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex8(DigitModel model)
        {
            // Generate the first random number between 100 and 999 (Digit1)
            model.Digit1 = _random.Next(100, 1000);

            // Extract the hundreds, tens, and ones places of Digit1
            int hundreds1 = model.Digit1.Value / 100;
            int tens1 = (model.Digit1.Value / 10) % 10;
            int ones1 = model.Digit1.Value % 10;

            // Generate the second number ensuring borrowing in the ones place
            int ones2 = _random.Next(0, ones1);  // Ensures borrowing in ones place

            // Generate the second number ensuring borrowing in the tens place
            int tens2 = _random.Next(0, tens1);  // Ensures borrowing in tens place

            // Generate a valid hundreds place for Digit2 (keeping it less than hundreds1)
            int hundreds2 = _random.Next(0, hundreds1);  // Ensures borrowing in hundreds place

            // Combine hundreds, tens, and ones to form Digit2
            model.Digit2 = (hundreds2 * 100) + (tens2 * 10) + ones2;

            // Ensure both numbers are three-digit numbers and Digit1 > Digit2
            while (model.Digit2 >= model.Digit1 || model.Digit2 < 100 || model.Digit1 < 100)
            {
                // Regenerate both numbers if conditions are not met
                model.Digit1 = _random.Next(100, 1000);
                hundreds1 = model.Digit1.Value / 100;
                tens1 = (model.Digit1.Value / 10) % 10;
                ones1 = model.Digit1.Value % 10;

                ones2 = _random.Next(0, ones1);  // Ensures borrowing in ones place
                tens2 = _random.Next(0, tens1);  // Ensures borrowing in tens place
                hundreds2 = _random.Next(0, hundreds1);  // Ensures borrowing in hundreds place
                model.Digit2 = (hundreds2 * 100) + (tens2 * 10) + ones2;
            }

            return View("Index", model); // Return the view with generated numbers and validation result
        }




        [HttpPost]
        public IActionResult GenerateNumberIndex9(DigitModel model)
        {
            // Generate Num1 as a three-digit number between 100 and 999
            int num1 = _random.Next(100, 1000);

            // Extract the hundreds, tens, and ones places of Num1
            int hundreds1 = num1 / 100;
            int tens1 = (num1 / 10) % 10;
            int ones1 = num1 % 10;

            // Generate Num2 as a two-digit number where borrowing occurs (ensuring it’s less than Num1)
            int ones2 = _random.Next(0, ones1 + 1);  // Ones digit of Num2 must be less than or equal to Num1's ones digit
            int tens2 = _random.Next(0, tens1 + 1);  // Tens digit of Num2 must be less than or equal to Num1's tens digit
            int hundreds2 = _random.Next(0, hundreds1 + 1);  // Hundreds digit of Num2 must be less than or equal to Num1's hundreds digit

            // Create Num2 using the hundreds, tens, and ones places
            int num2 = (hundreds2 * 100) + (tens2 * 10) + ones2;

            // Ensure Num2 is a valid two-digit number (between 10 and 99)
            while (num2 < 10 || num2 > 99 || num2 >= num1)
            {
                // Regenerate Num2 if it does not meet the conditions
                ones2 = _random.Next(0, ones1 + 1);
                tens2 = _random.Next(0, tens1 + 1);
                hundreds2 = _random.Next(0, hundreds1 + 1);
                num2 = (hundreds2 * 100) + (tens2 * 10) + ones2;
            }

            // Assign the values to the model
            model.Digit1 = num1;
            model.Digit2 = num2;

            // Return the view with the generated numbers
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex10(DigitModel model)
        {
            // Generate the first random number between 1 and 999 (Digit1)
            model.Digit1 = _random.Next(1, 1000);

            // Generate the second random number between 1 and 99 (Digit2)
            model.Digit2 = _random.Next(1, 100);

            return View("Index", model); // Return the view with generated numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex11(DigitModel model)
        {
            // Generate Num1 as a four-digit number between 1000 and 9999 (Digit1)
            model.Digit1 = _random.Next(1000, 10000);

            // Extract the thousands, hundreds, tens, and ones places of Digit1
            int thousands1 = model.Digit1.Value / 1000;
            int hundreds1 = (model.Digit1.Value / 100) % 10;
            int tens1 = (model.Digit1.Value / 10) % 10;
            int ones1 = model.Digit1.Value % 10;

            // Generate Num2 such that there is no borrowing, meaning each digit of Num2 must be less than or equal to the corresponding digit of Num1
            int thousands2 = _random.Next(0, thousands1 + 1);
            int hundreds2 = _random.Next(0, hundreds1 + 1);
            int tens2 = _random.Next(0, tens1 + 1);
            int ones2 = _random.Next(0, ones1 + 1);

            // Combine the digits to form Num2
            model.Digit2 = (thousands2 * 1000) + (hundreds2 * 100) + (tens2 * 10) + ones2;

            // Ensure that Num2 is a valid four-digit number
            if (model.Digit2 < 1000)
            {
                model.Digit2 = 1000; // Set a valid four-digit number if it is less than 1000
            }

            return View("Index", model); // Return the view with generated numbers
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex12(DigitModel model)
        {
            while (true) // Loop until valid numbers are generated
            {
                // Generate random digits for Digit1 (Num1)
                int hundreds1 = _random.Next(1, 10); // Hundreds place for Digit1 (1-9)
                int tens1 = _random.Next(0, 10);     // Tens place for Digit1 (0-9)
                int ones1 = _random.Next(0, 10);     // Ones place for Digit1 (0-9)

                // Generate random digits for Digit2 (Num2), ensuring Num2 is greater than Num1 in each place
                int hundreds2 = _random.Next(hundreds1 + 1, 10); // Hundreds place for Digit2 (greater than Digit1's hundreds)
                int tens2 = _random.Next(tens1 + 1, 10);         // Tens place for Digit2 (greater than Digit1's tens)
                int ones2 = _random.Next(ones1 + 1, 10);         // Ones place for Digit2 (greater than Digit1's ones)

                // Check for the condition that subtraction will allow borrowing over all digits
                if ((ones2 > ones1) && (tens2 > tens1) && (hundreds2 > hundreds1))
                {
                    // Combine digits into full three-digit numbers
                    model.Digit1 = (hundreds1 * 100) + (tens1 * 10) + ones1;
                    model.Digit2 = (hundreds2 * 100) + (tens2 * 10) + ones2;

                    // Exit loop if valid numbers are found
                    break;
                }
            }

            return View("Index", model); // Return the updated model with two valid three-digit numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex13(DigitModel model)
        {
            while (true) // Loop until valid numbers are generated
            {
                // Generate random digits for the first number (Digit1)
                int thousands1 = _random.Next(1, 10); // Thousands place for Digit1 (1-9)
                int hundreds1 = _random.Next(0, 10);  // Hundreds place for Digit1 (0-9)
                int tens1 = _random.Next(0, 10);      // Tens place for Digit1 (0-9)
                int ones1 = _random.Next(0, 10);      // Ones place for Digit1 (0-9)

                // Generate random digits for the second number (Digit2)
                int thousands2 = _random.Next(0, thousands1); // Thousands place for Digit2 (must be less than or equal to thousands1)
                int hundreds2 = _random.Next(0, hundreds1);   // Hundreds place for Digit2 (must be less than or equal to hundreds1)
                int tens2 = _random.Next(0, tens1);            // Tens place for Digit2 (must be less than or equal to tens1)
                int ones2 = _random.Next(0, ones1);            // Ones place for Digit2 (must be less than or equal to ones1)

                // Ensure the second number is smaller than the first number for valid subtraction
                if ((thousands2 < thousands1) ||
                    (thousands2 == thousands1 && hundreds2 < hundreds1) ||
                    (thousands2 == thousands1 && hundreds2 == hundreds1 && tens2 < tens1) ||
                    (thousands2 == thousands1 && hundreds2 == hundreds1 && tens2 == tens1 && ones2 < ones1))
                {
                    // Combine digits into full 5-digit numbers
                    model.Digit1 = (thousands1 * 10000) + (hundreds1 * 1000) + (tens1 * 100) + (ones1 * 10);
                    model.Digit2 = (thousands2 * 10000) + (hundreds2 * 1000) + (tens2 * 100) + (ones2 * 10);

                    break; // Exit the loop once valid numbers are found
                }
            }

            return View("Index", model); // Return the updated model with two valid numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex14(DigitModel model)
        {
            while (true) // Loop until valid numbers are generated
            {
                // Generate random digits for the first number (Digit1)
                int tenThousands1 = _random.Next(1, 10); // Ten-thousands place for Digit1 (1-9)
                int thousands1 = _random.Next(0, 10);    // Thousands place for Digit1 (0-9)
                int hundreds1 = _random.Next(0, 10);     // Hundreds place for Digit1 (0-9)
                int tens1 = _random.Next(0, 10);         // Tens place for Digit1 (0-9)
                int ones1 = _random.Next(0, 10);         // Ones place for Digit1 (0-9)

                // Generate random digits for the second number (Digit2)
                int tenThousands2 = _random.Next(0, tenThousands1); // Ten-thousands place for Digit2 (must be smaller than Digit1)
                int thousands2 = _random.Next(0, thousands1);       // Thousands place for Digit2 (must be smaller than Digit1)
                int hundreds2 = _random.Next(0, hundreds1);         // Hundreds place for Digit2 (must be smaller than Digit1)
                int tens2 = _random.Next(0, tens1);                  // Tens place for Digit2 (must be smaller than Digit1)
                int ones2 = _random.Next(0, ones1);                  // Ones place for Digit2 (must be smaller than Digit1)

                // Ensure borrowing will occur at each place value (ones, tens, hundreds, etc.)
                if ((ones2 < ones1) && (tens2 < tens1) && (hundreds2 < hundreds1) && (thousands2 < thousands1) && (tenThousands2 < tenThousands1))
                {
                    // Combine digits to form two valid 5-digit numbers
                    model.Digit1 = (tenThousands1 * 10000) + (thousands1 * 1000) + (hundreds1 * 100) + (tens1 * 10) + ones1;
                    model.Digit2 = (tenThousands2 * 10000) + (thousands2 * 1000) + (hundreds2 * 100) + (tens2 * 10) + ones2;

                    break; // Exit the loop once valid numbers are found
                }
            }

            return View("Index", model); // Return the updated model with two valid 5-digit numbers
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex15(DigitModel model)
        {
            while (true) // Loop until valid numbers are generated
            {
                // Generate random digits for the first number (Digit1)
                int hundredThousands1 = _random.Next(1, 10); // Hundred-thousands place for Digit1 (1-9 to ensure a valid 6-digit number)
                int tenThousands1 = _random.Next(0, 10);     // Ten-thousands place for Digit1 (0-9)
                int thousands1 = _random.Next(0, 10);        // Thousands place for Digit1 (0-9)
                int hundreds1 = _random.Next(0, 10);         // Hundreds place for Digit1 (0-9)
                int tens1 = _random.Next(0, 10);             // Tens place for Digit1 (0-9)
                int ones1 = _random.Next(0, 10);             // Ones place for Digit1 (0-9)

                // Generate random digits for the second number (Digit2) ensuring borrowing
                int hundredThousands2 = _random.Next(0, hundredThousands1); // Hundred-thousands place for Digit2 (must be smaller than Digit1)
                int tenThousands2 = _random.Next(0, tenThousands1);         // Ten-thousands place for Digit2 (must be smaller than Digit1)
                int thousands2 = _random.Next(0, thousands1);               // Thousands place for Digit2 (must be smaller than Digit1)
                int hundreds2 = _random.Next(0, hundreds1);                 // Hundreds place for Digit2 (must be smaller than Digit1)
                int tens2 = _random.Next(0, tens1);                         // Tens place for Digit2 (must be smaller than Digit1)
                int ones2 = _random.Next(0, ones1);                         // Ones place for Digit2 (must be smaller than Digit1)

                // Ensure borrowing will occur at each place value (ones, tens, hundreds, etc.)
                if ((ones2 < ones1) && (tens2 < tens1) && (hundreds2 < hundreds1) && (thousands2 < thousands1) && (tenThousands2 < tenThousands1) && (hundredThousands2 < hundredThousands1))
                {
                    // Combine digits to form two valid 6-digit numbers
                    model.Digit1 = (hundredThousands1 * 100000) + (tenThousands1 * 10000) + (thousands1 * 1000) + (hundreds1 * 100) + (tens1 * 10) + ones1;
                    model.Digit2 = (hundredThousands2 * 100000) + (tenThousands2 * 10000) + (thousands2 * 1000) + (hundreds2 * 100) + (tens2 * 10) + ones2;

                    break; // Exit the loop once valid numbers are found
                }
            }

            return View("Index", model); // Return the updated model with two valid 6-digit numbers
        }

        [HttpPost]
        public IActionResult SubmitAnswer1(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int temp = model.Digit1.Value - model.Digit2.Value;
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {temp}";
                    model.ResultType = "danger";
                }
                GenerateNumberIndex1(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";
            }
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer2(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Perform the subtraction
                int temp = model.Digit1.Value - model.Digit2.Value;

                // Check if the answer is correct
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {temp}";
                    model.ResultType = "danger";
                }

                // Generate new random numbers for the next subtraction problem
                GenerateNumberIndex2(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer3(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction of the two numbers
                int correctDifference = model.Digit1.Value - model.Digit2.Value;

                // Check if the user's answer matches the correct difference
                if (model.Answer.Equals(correctDifference.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctDifference}";
                    model.ResultType = "danger";
                }

                // Generate new numbers after checking the answer
                GenerateNumberIndex3(model);
            }
            else
            {
                // Handle invalid inputs
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";
            }

            return View("Index", model); // Return the view with the result
        }


        [HttpPost]
        public IActionResult SubmitAnswer4(DigitModel model)
        {
            // Check if the necessary fields are filled and valid
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrWhiteSpace(model.Answer))
            {
                // Calculate the correct difference of the digits
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct answer
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer! Well done.";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer: {model.Digit1} - {model.Digit2} = {correctAnswer}";
                    model.ResultType = "danger";
                }

                // Generate new numbers for the next question
                GenerateNumberIndex4(model);
            }
            else
            {
                // Handle missing or invalid inputs
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";
            }

            // Return the updated model to the view
            return View("Index", model);
        }


        [HttpPost]
        public IActionResult SubmitAnswer5(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}";
                    model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex5(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";
            }

            return View("Index", model);
        }


        [HttpPost]
        public IActionResult SubmitAnswer6(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}";
                    model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex6(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer7(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex7(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer8(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex8(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer9(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex9(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer10(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex10(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer11(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultType = "danger";
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex11(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer12(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex12(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer13(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex13(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer14(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex14(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult SubmitAnswer15(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                // Perform subtraction (Digit1 - Digit2 - Digit3)
                int correctAnswer = model.Digit1.Value - model.Digit2.Value;

                // Compare the user's answer with the correct subtraction result
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} - {model.Digit2} = {correctAnswer}"; model.ResultType = "danger";
                }

                // Regenerate numbers for the next question
                GenerateNumberIndex15(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";
            }

            return View("Index", model);
        }

       

    }
}