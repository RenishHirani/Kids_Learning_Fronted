using frontend.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;    

namespace frontend.Controllers
{
    public class AdditionController : Controller
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
                case 1:
                    return GenerateNumberIndex1(model);
                case 2:
                    return GenerateNumberIndex2(model);
                case 3:
                    return GenerateNumberIndex3(model);
                case 4:
                    return GenerateNumberIndex4(model);
                case 5:
                    return GenerateNumberIndex5(model);
                case 6:
                    return GenerateNumberIndex6(model);
                //case 7:
                //    return GenerateNumberIndex7(model);
                case 8:
                    return GenerateNumberIndex8(model);
                case 9:
                    return GenerateNumberIndex9(model);
                case 10:
                    return GenerateNumberIndex10(model);
                case 11:
                    return GenerateNumberIndex11(model);
                case 12:
                    return GenerateNumberIndex12(model);
                case 13:
                    return GenerateNumberIndex13(model);
                case 14:
                    return GenerateNumberIndex14(model);
                case 15:
                    return GenerateNumberIndex15(model);
                case 16:
                    return GenerateNumberIndex16(model);
                case 17:
                    return GenerateNumberIndex17(model);
                case 18:
                    return GenerateNumberIndex18(model);
                case 19:
                    return GenerateNumberIndex19(model);
                case 20:
                    return GenerateNumberIndex20(model);
                case 21:
                    return GenerateNumberIndex21(model);
                case 22:
                    return GenerateNumberIndex22(model);
                case 23:
                    return GenerateNumberIndex23(model);
                case 24:
                    return GenerateNumberIndex24(model);
                case 25:
                    return GenerateNumberIndex25(model);
                default:
                    return View("Error");  // Default action if SkillID is invalid


            }
        }
        [HttpPost]
        public IActionResult SubmitAnswer(int skillId, DigitModel model)
        {
            TempData["SkillId"] = skillId;
            // Call the corresponding SubmitAnswer method based on SkillID
            switch (skillId)
            {
                case 1:
                    return SubmitAnswer1(model);
                case 2:
                    return SubmitAnswer2(model);
                case 3:
                    return SubmitAnswer3(model);
                case 4:
                    return SubmitAnswer4(model);
                case 5:
                    return SubmitAnswer5(model);
                case 6:
                    return SubmitAnswer6(model);
                //case 7:
                //    return SubmitAnswer7(model);
                case 8:
                    return SubmitAnswer8(model);
                case 9:
                    return SubmitAnswer9(model);
                case 10:
                    return SubmitAnswer10(model);
                case 11:
                    return SubmitAnswer11(model);
                case 12:
                    return SubmitAnswer12(model);
                case 13:
                    return SubmitAnswer13(model);
                case 14:
                    return SubmitAnswer14(model);
                case 15:
                    return SubmitAnswer15(model);
                case 16:
                    return SubmitAnswer16(model);
                case 17:
                    return SubmitAnswer17(model);
                case 18:
                    return SubmitAnswer18(model);
                case 19:
                    return SubmitAnswer19(model);
                case 20:
                    return SubmitAnswer20(model);
                case 21:
                    return SubmitAnswer21(model);
                case 22:
                    return SubmitAnswer22(model);
                case 23:
                    return SubmitAnswer23(model);
                case 24:
                    return SubmitAnswer24(model);
                case 25:
                    return SubmitAnswer25(model);
                default:
                    return View("Error");  // Default action if SkillID is invalid
            }
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex1(DigitModel model)
        {
            int num1 = _random.Next(0, 9); // Random number between 0 and 8
            model.Digit1 = num1;

            int temp = 9 - num1;
            int num2 = _random.Next(0, temp); // Random number between 0 and (9 - num1)
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex2(DigitModel model)
        {
            int num1 = _random.Next(0, 10);
            model.Digit1 = num1;
            int temp = Math.Max(10 - num1, 0);

            int num2 = _random.Next(temp, 10);
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex3(DigitModel model)
        {

            // Generate the first random two-digit number (Digit1)
            model.Digit1 = _random.Next(10, 100); // Random number between 10 and 99

            // Extract the tens and ones places of Digit1
            int tens1 = model.Digit1.Value / 10; // Tens place
            int ones1 = model.Digit1.Value % 10; // Ones place

            // Generate the second random single-digit number (Digit2)
            // Ensure no carry in the ones place when adding Digit1 and Digit2
            model.Digit2 = _random.Next(0, 10 - ones1);

            return View("Index", model); // Return the view with generated numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex4(DigitModel model)
        {
            int num1, num2;
            do
            {
                // Generate a two-digit number
                num1 = _random.Next(10, 100);

                // Generate a one-digit number
                num2 = _random.Next(1, 10);
            }
            while ((num1 % 10) + num2 < 10); // Ensure grouping condition

            // Update the model with the generated numbers
            model.Digit1 = num1;
            model.Digit2 = num2;

            return View("Index", model); // Assuming an Index view exists to display results
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex5(DigitModel model)
        {

            // Generate the first random number
            int num1 = _random.Next(0, 9); // Random number between 0 and 8
            model.Digit1 = num1;

            // Generate the second random number with a range adjusted based on num1
            int temp1 = 9 - num1;
            int num2 = _random.Next(0, temp1); // Random number between 0 and (9 - num1)
            model.Digit2 = num2;

            // Generate the third random number with a range adjusted based on num1 and num2
            int temp2 = 9 - (num1 + num2);
            int num3 = _random.Next(0, temp2 > 0 ? temp2 : 1); // Random number between 0 and (9 - num1 - num2), ensuring temp2 > 0
            model.Digit3 = num3;

            return View("Index", model); // Return the view with generated numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex6(DigitModel model)
        {
            // Generate Num1 such that it is a multiple of 10 (10, 20, ..., 90)
            int num1 = _random.Next(1, 10) * 10;  // Num1 is 10, 20, ..., 90

            // Generate Num2 such that Num2 is also a multiple of 10, and Num1 > Num2
            int num2 = _random.Next(1, num1 / 10) * 10;  // Num2 is  10, ..., 80, and Num2 < Num1

            // Assign the values to the model
            model.Digit1 = num1;
            model.Digit2 = num2;

            // Display these values in the view
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex8(DigitModel model)
        {
            // Generate the first random number between 10 and 99 (Digit1)
            model.Digit1 = _random.Next(10, 100);

            // Extract the tens and ones places of Digit1
            int tens1 = model.Digit1.Value / 10;
            int ones1 = model.Digit1.Value % 10;

            // Generate the second number ensuring no carry in the ones place
            int ones2 = _random.Next(0, 10 - ones1);

            // Generate the second number ensuring no carry in the tens place
            int tens2 = _random.Next(0, 10 - tens1);

            // Combine tens and ones to form Digit2, which must be a valid two-digit number (10-99)
            model.Digit2 = (tens2 * 10) + ones2;

            // Ensure that Digit2 is always greater than or equal to 10
            if (model.Digit2 < 10)
            {
                model.Digit2 = 10; // Set a valid two-digit number if it is less than 10
            }

            return View("Index", model); // Return the view with generated numbers and validation result
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex9(DigitModel model)
        {
            // Generate Num1 between 10 and 99
            int num1 = _random.Next(Ten, NintyNine);

            // Calculate Temp and Temp1 based on Num1
            int temp = Nine - (num1 % Ten);
            int temp1 = Nine - ((num1 / 10) % Ten);

            // Determine the Lower value
            int lower = (temp == Nine) ? Nine : _random.Next(temp + 1, Nine);

            // Generate the Upper value
            int upper = _random.Next(Zero, temp1);

            // Calculate Num2
            int num2;
            if (upper == Zero)
            {
                num2 = lower;
            }
            else
            {
                num2 = (upper * Ten) + lower;
            }

            model.Digit1 = num1;
            string formattedNum1 = num2 < Ten ? num1.ToString("D2") : num2.ToString();
            model.Digit2 = int.Parse(formattedNum1);

            return View("Index", model); // Assuming you have an Index view that displays these values
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex10(DigitModel model)
        {

            // Generate the first random number between 10 and 99 (Digit1)
            model.Digit1 = _random.Next(10, 100);

            // Extract the tens and ones places of Digit1
            int tens1 = model.Digit1.Value / 10;
            int ones1 = model.Digit1.Value % 10;

            // Generate the second number ensuring no carry in the ones place
            int ones2 = _random.Next(0, 10 - ones1);

            // Generate the second number ensuring no carry in the tens place
            int tens2 = _random.Next(0, 10 - tens1);

            // Combine tens and ones to form Digit2
            model.Digit2 = (tens2 * 10) + ones2;

            // Ensure that Digit2 is always greater than or equal to 10
            if (model.Digit2 < 10)
            {
                model.Digit2 = 10; // Set a valid two-digit number if it is less than 10
            }

            // Generate the third number ensuring no carry with respect to Digit1 and Digit2
            int ones3 = _random.Next(0, Math.Min(10 - ones1, 10 - ones2));
            int tens3 = _random.Next(0, Math.Min(10 - tens1, 10 - tens2));

            // Combine tens and ones to form Digit3
            model.Digit3 = (tens3 * 10) + ones3;

            // Ensure that Digit3 is always greater than or equal to 10
            if (model.Digit3 < 10)
            {
                model.Digit3 = 10; // Set a valid two-digit number if it is less than 10
            }

            return View("Index", model); // Return the view with generated numbers
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex11(DigitModel model)
        {
            // Generate Num1 such that it is a multiple of 100 (100, 200, ..., 900)
            int num1 = _random.Next(1, 10) * 100;  // Num1 is 100, 200, ..., 900

            // Generate Num2 such that Num2 is also a multiple of 100, and Num1 > Num2
            int num2 = _random.Next(1, num1 / 100) * 100;  // Num2 is 100, ..., 800, and Num2 < Num1

            // Assign the values to the model
            model.Digit1 = num1;
            model.Digit2 = num2;

            // Display these values in the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex12(DigitModel model)
        {
            while (true) // Loop until valid numbers are generated
            {
                // Generate random digits for Digit1
                int hundreds1 = _random.Next(1, 10); // Hundreds place for Digit1 (1-9)
                int tens1 = _random.Next(0, 10);     // Tens place for Digit1 (0-9)
                int ones1 = _random.Next(0, 10);     // Ones place for Digit1 (0-9)

                // Generate random digits for Digit2
                int hundreds2 = _random.Next(1, 10); // Hundreds place for Digit2 (1-9)
                int tens2 = _random.Next(0, 10);     // Tens place for Digit2 (0-9)
                int ones2 = _random.Next(0, 10);     // Ones place for Digit2 (0-9)

                // Check for no regrouping condition
                if ((ones1 + ones2 < 10) && (tens1 + tens2 < 10) && (hundreds1 + hundreds2 < 10))
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
            // Generate random digits for each place (hundreds, tens, and ones) allowing for regrouping (carry)

            // First number (Digit1)
            int hundreds1 = _random.Next(1, 10); // Hundreds place for Digit1 (1-9 to ensure a valid 3-digit number)
            int tens1 = _random.Next(0, 10);     // Tens place for Digit1 (0-9)
            int ones1 = _random.Next(0, 10);     // Ones place for Digit1 (0-9)

            // Second number (Digit2)
            int hundreds2 = _random.Next(0, 10); // Hundreds place for Digit2 (0-9, no carry yet)
            int tens2 = _random.Next(0, 10);     // Tens place for Digit2 (0-9)
            int ones2 = _random.Next(0, 10);     // Ones place for Digit2 (0-9)

            // Ensure the second number (Digit2) can cause a carry-over in the addition if necessary.
            // The sum for each place (hundreds, tens, ones) may be more than 9, which will cause a carry in the addition.
            int sumOnes = ones1 + ones2;
            int carryOnes = sumOnes / 10; // If the sum exceeds 9, there will be a carry (either 0 or 1)
            ones1 = sumOnes % 10; // Ensure the ones place stays within bounds

            int sumTens = tens1 + tens2 + carryOnes; // Include carry from ones place
            int carryTens = sumTens / 10;
            tens1 = sumTens % 10;

            int sumHundreds = hundreds1 + hundreds2 + carryTens; // Include carry from tens place
            int carryHundreds = sumHundreds / 10;
            hundreds1 = sumHundreds % 10;

            // Combine digits to form two valid three-digit numbers
            model.Digit1 = (hundreds1 * 100) + (tens1 * 10) + ones1;
            model.Digit2 = (hundreds2 * 100) + (tens2 * 10) + ones2;

            // You can generate a third and fourth number similarly if needed.
            // For simplicity, we're only generating two numbers here.

            return View("Index", model); // Pass the model back to the view
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex14(DigitModel model)
        {
            // Generate a random number for Digit1 (up to 1, 2, or 3 digits)
            model.Digit1 = _random.Next(1, 999); // Generates a number between 1 and 999

            // Generate a random number for Digit2 (up to 1, 2, or 3 digits)
            model.Digit2 = _random.Next(1, 99); // Generates a number between 1 and 999

            // Generate a random number for Digit3 (up to 1, 2, or 3 digits)
            model.Digit3 = _random.Next(1, 999); // Generates a number between 1 and 999

            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex15(DigitModel model)
        {
            // Generate random digits for the first number (Digit1)
            int hundreds1 = _random.Next(1, 10);  // Hundreds place for Digit1 (1-9 to ensure a valid 3-digit number)
            int tens1 = _random.Next(0, 10);      // Tens place for Digit1 (0-9)
            int ones1 = _random.Next(0, 10);      // Ones place for Digit1 (0-9)

            // Generate random digits for the second number (Digit2) ensuring no carry
            int hundreds2 = _random.Next(1, 10 - hundreds1);  // Hundreds place for Digit2 (0-9)
            int tens2 = _random.Next(0, 10);      // Tens place for Digit2 (0-9)
            int ones2 = _random.Next(0, 10);      // Ones place for Digit2 (0-9)

            // Generate random digits for the third number (Digit3) ensuring no carry
            int hundreds3 = _random.Next(1, 10 - hundreds2);  // Hundreds place for Digit3 (0-9)
            int tens3 = _random.Next(0, 10);      // Tens place for Digit3 (0-9)
            int ones3 = _random.Next(0, 10);      // Ones place for Digit3 (0-9)

            // Combine digits to form the three three-digit numbers
            model.Digit1 = (hundreds1 * 100) + (tens1 * 10) + ones1;
            model.Digit2 = (hundreds2 * 100) + (tens2 * 10) + ones2;
            model.Digit3 = (hundreds3 * 100) + (tens3 * 10) + ones3;

            return View("Index", model); // Pass the model back to the view
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex16(DigitModel model)
        {
            // Generate random digits for each place (hundreds, tens, and ones) ensuring no carry
            int hundreds1 = _random.Next(1, 10); // Hundreds place (1-9 to ensure a valid 3-digit number)
            int tens1 = _random.Next(0, 10);     // Tens place (0-9)
            int ones1 = _random.Next(0, 10);     // Ones place (0-9)

            int hundreds2 = _random.Next(1, 10 - hundreds1); // Hundreds place for Digit2 (no carry)
            int tens2 = _random.Next(0, 10 - tens1);         // Tens place for Digit2 (no carry)
            int ones2 = _random.Next(0, 10 - ones1);         // Ones place for Digit2 (no carry)

            int hundreds3 = _random.Next(1, 10 - hundreds2); // Hundreds place for Digit3 (no carry)
            int tens3 = _random.Next(0, 10 - tens2);         // Tens place for Digit3 (no carry)
            int ones3 = _random.Next(0, 10 - ones2);         // Ones place for Digit3 (no carry)

            int hundreds4 = _random.Next(1, 10 - hundreds3); // Hundreds place for Digit4 (no carry)
            int tens4 = _random.Next(0, 10 - tens3);         // Tens place for Digit4 (no carry)
            int ones4 = _random.Next(0, 10 - ones3);         // Ones place for Digit4 (no carry)

            // Combine digits to form four valid three-digit numbers
            model.Digit1 = (hundreds1 * 100) + (tens1 * 10) + ones1;
            model.Digit2 = (hundreds2 * 100) + (tens2 * 10) + ones2;
            model.Digit3 = (hundreds3 * 100) + (tens3 * 10) + ones3;
            model.Digit4 = (hundreds4 * 100) + (tens4 * 10) + ones4;


            return View("Index", model); // Pass the model back to the view
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex17(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 9999);

            model.Digit2 = _random.Next(1000, 9999);


            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex18(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 9999);

            model.Digit2 = _random.Next(1000, 9999);

            model.Digit3 = _random.Next(1000, 9999);


            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex19(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 9999);

            model.Digit2 = _random.Next(1000, 9999);

            model.Digit3 = _random.Next(1000, 9999);

            model.Digit4 = _random.Next(1000, 9999);



            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex20(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 9999);

            model.Digit2 = _random.Next(1, 999);

            model.Digit3 = _random.Next(1, 9999);




            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex21(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 99999);

            model.Digit2 = _random.Next(10000, 99999);



            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex22(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 99999);

            model.Digit2 = _random.Next(10000, 99999);

            model.Digit3 = _random.Next(10000, 99999);


            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex23(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 99999);

            model.Digit2 = _random.Next(10000, 99999);

            model.Digit3 = _random.Next(10000, 99999);

            model.Digit4 = _random.Next(10000, 99999);



            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex24(DigitModel model)
        {
            model.Digit1 = _random.Next(100000, 999999);

            model.Digit2 = _random.Next(100000, 999999);


            // Return the updated model to the view
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult GenerateNumberIndex25(DigitModel model)
        {
            model.Digit1 = _random.Next(100000, 999999);

            model.Digit2 = _random.Next(100000, 999999);

            model.Digit3 = _random.Next(100000, 999999);


            // Return the updated model to the view
            return View("Index", model);
        }


        [HttpPost]
        public IActionResult SubmitAnswer1(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int temp = model.Digit1.Value + model.Digit2.Value;
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {temp}";
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
                int temp = model.Digit1.Value + model.Digit2.Value;
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer"; model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {temp}";
                    model.ResultType = "danger";

                }
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
                // Calculate the sum of the two numbers
                int correctSum = model.Digit1.Value + model.Digit2.Value;

                // Check if the user's answer matches the correct sum
                if (model.Answer.Equals(correctSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {correctSum}";
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

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer4(DigitModel model)
        {
            // Check if the necessary fields are filled and valid
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrWhiteSpace(model.Answer))
            {
                // Calculate the correct sum of the digits
                int correctAnswer = model.Digit1.Value + model.Digit2.Value;

                // Compare the user's answer with the correct answer
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer! Well done.";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer: {model.Digit1} + {model.Digit2} = {correctAnswer}";
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
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue &&
                !string.IsNullOrEmpty(model.Answer))
            {
                int temp = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;

                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {temp}";
                    model.ResultType = "danger";

                }

                // Regenerate numbers for the next question
                GenerateNumberIndex5(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid."; model.ResultType = "warning";

            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer6(DigitModel model)
        {
            // Check if the necessary fields are filled and valid
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrWhiteSpace(model.Answer))
            {
                // Parse the user's answer
                if (int.TryParse(model.Answer, out int userAnswer))
                {
                    // Calculate the correct answer (sum of the two digits)
                    int correctAnswer = model.Digit1.Value + model.Digit2.Value;

                    // Check if the user's answer matches the correct answer
                    if (userAnswer == correctAnswer)
                    {
                        model.ResultMessage = "Correct Answer! Well done.";
                        model.ResultType = "success";
                    }
                    else
                    {
                        model.ResultMessage = $"Invalid Answer. Correct Answer: {model.Digit1} + {model.Digit2} = {correctAnswer}";
                        model.ResultType = "danger";

                    }
                }
                else
                {
                    model.ResultMessage = "Invalid input. Please enter a numeric answer.";
                    model.ResultType = "warning";

                }

                // Generate new numbers for the next question
                GenerateNumberIndex6(model);
            }
            else
            {
                // Handle missing or invalid inputs
                model.ResultMessage = "Please ensure all inputs are valid.";
            }

            // Return the updated model to the view
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer8(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int temp = model.Digit1.Value + model.Digit2.Value;
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {temp}";
                    model.ResultType = "danger";

                }
                GenerateNumberIndex8(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer9(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                int temp = model.Digit1.Value + model.Digit2.Value;
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {temp}";
                    model.ResultType = "danger";

                }
                GenerateNumberIndex9(model);
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SubmitAnswer10(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the three digits
                int temp = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;

                // Compare user's answer with the correct sum
                if (model.Answer.Equals(temp.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {temp}";
                    model.ResultType = "danger";

                }

                // Regenerate numbers for the next attempt
                GenerateNumberIndex10(model);
            }
            else
            {
                // Error message for invalid inputs
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the updated model to the view
        }

        [HttpPost]
        public IActionResult SubmitAnswer11(DigitModel model)
        {
            // Check if the necessary fields are filled and valid
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrWhiteSpace(model.Answer))
            {
                // Parse the user's answer
                if (int.TryParse(model.Answer, out int userAnswer))
                {
                    // Calculate the correct answer (sum of the two digits)
                    int correctAnswer = model.Digit1.Value + model.Digit2.Value;

                    // Check if the user's answer matches the correct answer
                    if (userAnswer == correctAnswer)
                    {
                        model.ResultMessage = "Correct Answer! Well done.";
                        model.ResultType = "success";

                    }

                    else
                    {
                        model.ResultMessage = $"Invalid Answer. Correct Answer: {model.Digit1} + {model.Digit2} = {correctAnswer}";
                        model.ResultType = "danger";

                    }
                }
                else
                {
                    model.ResultMessage = "Invalid input. Please enter a numeric answer.";
                    model.ResultType = "warning";

                }

                // Generate new numbers for the next question
                GenerateNumberIndex11(model);
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
        public IActionResult SubmitAnswer12(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;

                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex12(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message
        }

        [HttpPost]
        public IActionResult SubmitAnswer13(DigitModel model)
        {
            // Ensure the required values are present
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the correct sum of the two three-digit numbers
                int correctAnswer = model.Digit1.Value + model.Digit2.Value;

                // Check if the user's answer matches the correct answer
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer!";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Invalid Answer. The correct answer is {model.Digit1} + {model.Digit2} = {correctAnswer}.";
                    model.ResultType = "danger";

                }
            }
            else
            {
                // If the input is missing or invalid
                model.ResultMessage = "Please ensure all inputs are valid and try again."; model.ResultType = "warning";

            }

            // Re-generate the numbers to allow for another attempt if needed
            GenerateNumberIndex13(model);

            return View("Index", model); // Return the view with updated model and result message
        }
        [HttpPost]
        public IActionResult SubmitAnswer14(DigitModel model)
        {

            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex14(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }

        }

        [HttpPost]
        public IActionResult SubmitAnswer15(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;

                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex15(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message
        }
        [HttpPost]
        public IActionResult SubmitAnswer16(DigitModel model)
        {
            // Ensure that the numbers are generated and the user provided an answer
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && model.Digit4.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the four three-digit numbers
                int correctAnswer = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value + model.Digit4.Value;

                // Compare the user's answer with the correct sum
                if (model.Answer.Equals(correctAnswer.ToString()))
                {
                    model.ResultMessage = "Correct Answer!";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {correctAnswer}";
                    model.ResultType = "danger";

                }

                // Re-generate new numbers for the user
                GenerateNumberIndex16(model);  // Reuse the earlier method to generate new numbers
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result and updated model
        }
        [HttpPost]
        public IActionResult SubmitAnswer17(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex17(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer18(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex18(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer19(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && model.Digit4.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value + model.Digit4.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} + {model.Digit4} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex19(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer20(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex20(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer21(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex21(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer22(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex22(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer23(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && model.Digit4.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value + model.Digit4.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";
                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} + {model.Digit4} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex23(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer24(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex24(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }
        [HttpPost]
        public IActionResult SubmitAnswer25(DigitModel model)
        {
            if (model.Digit1.HasValue && model.Digit2.HasValue && model.Digit3.HasValue && !string.IsNullOrEmpty(model.Answer))
            {
                // Calculate the sum of the generated numbers
                int expectedSum = model.Digit1.Value + model.Digit2.Value + model.Digit3.Value;
                // Check if the user's answer is correct
                if (model.Answer.Equals(expectedSum.ToString()))
                {
                    model.ResultMessage = "Correct Answer";
                    model.ResultType = "success";

                }
                else
                {
                    model.ResultMessage = $"Incorrect Answer. Correct Answer = {model.Digit1} + {model.Digit2} + {model.Digit3} = {expectedSum}";
                    model.ResultType = "danger";

                }

                // Regenerate the numbers after submitting the answer
                GenerateNumberIndex25(model); // Ensure numbers are regenerated after answer submission
            }
            else
            {
                model.ResultMessage = "Please ensure all inputs are valid.";
                model.ResultType = "warning";

            }

            return View("Index", model); // Return the view with the result message        }
        }

        
    }
}
