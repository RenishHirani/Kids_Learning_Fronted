using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using frontend.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace frontend.Controllers
{
    public class WorksheetController : Controller
    {

        private const int Ten = 10;
        private const int NintyNine = 99;
        private const int Nine = 9;
        private const int Zero = 0;
        private readonly Random _random = new Random();

        private IConfiguration configuration;

        public WorksheetController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        private List<GradeModel> GetGrades()
        {
            List<GradeModel> gradeList = new List<GradeModel>();
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_Worksheet_Grade_DropDown", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gradeList.Add(new GradeModel
                    {
                        GradeID = Convert.ToInt32(reader["GradeID"]),
                        GradeName = reader["Name"].ToString()
                    });
                }
            }
            return gradeList;
        }

        [HttpGet]
        public JsonResult GetChapters(int gradeId)
        {
            List<ChapterModel> chapterList = new List<ChapterModel>();
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_Worksheet_Chapter_DropDown", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GradeID", gradeId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chapterList.Add(new ChapterModel
                    {
                        ChapterID = Convert.ToInt32(reader["ChapterID"]),
                        ChapterName = reader["ChapterName"].ToString()
                    });
                }
            }
            return Json(chapterList);
        }

        [HttpPost]
        public IActionResult StoreSkillId(int skillId)
        {
            TempData["SkillID"] = skillId;  // Store SkillID in TempData
            return Ok();  // Send success response
        }


        [HttpGet]
        public JsonResult GetSkills(int gradeId, int chapterId)
        {
            List<SkillModel> skillList = new List<SkillModel>();
            string connectionString = configuration.GetConnectionString("ConnectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_Worksheet_Skill_DropDown", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GradeID", gradeId);
                command.Parameters.AddWithValue("@ChapterID", chapterId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skillList.Add(new SkillModel
                    {
                        SkillID = Convert.ToInt32(reader["SkillID"]),
                        SkillName = reader["SkillName"].ToString()
                    });
                }
            }
            return Json(skillList);
        }



        public IActionResult CreateWorksheet()
        {
            ViewBag.GradeList = GetGrades();
            return View();
        }


        // Addition -------------------------------------------------------------------------------------------
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

        // Subtraction -------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult GenerateNumberIndex26(DigitModel model)
        {
            int num1 = _random.Next(1, 9); // First number between 1 and 8 (ensures num1 > 0)
            int num2 = _random.Next(0, num1); // Second number between 0 and num1-1 (ensures num2 < num1)

            model.Digit1 = num1;
            model.Digit2 = num2;

            return View("Index", model); // Return the view with generated numbers
        }


        [HttpPost]
        public IActionResult GenerateNumberIndex27(DigitModel model)
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
        public IActionResult GenerateNumberIndex28(DigitModel model)
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
        public IActionResult GenerateNumberIndex29(DigitModel model)
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
        public IActionResult GenerateNumberIndex30(DigitModel model)
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
        public IActionResult GenerateNumberIndex31(DigitModel model)
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
        public IActionResult GenerateNumberIndex32(DigitModel model)
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
        public IActionResult GenerateNumberIndex33(DigitModel model)
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
        public IActionResult GenerateNumberIndex34(DigitModel model)
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
        public IActionResult GenerateNumberIndex35(DigitModel model)
        {
            // Generate the first random number between 1 and 999 (Digit1)
            model.Digit1 = _random.Next(1, 1000);

            // Generate the second random number between 1 and 99 (Digit2)
            model.Digit2 = _random.Next(1, 100);

            return View("Index", model); // Return the view with generated numbers
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex36(DigitModel model)
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
        public IActionResult GenerateNumberIndex37(DigitModel model)
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
        public IActionResult GenerateNumberIndex38(DigitModel model)
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
        public IActionResult GenerateNumberIndex39(DigitModel model)
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
        public IActionResult GenerateNumberIndex40(DigitModel model)
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

        // Multiplication -------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult GenerateNumberIndex41(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10); // 1 to 9
            model.Digit2 = _random.Next(1, 10); // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex42(DigitModel model)
        {
            model.Digit1 = _random.Next(10, 100); // 10 to 99
            model.Digit2 = _random.Next(1, 10);   // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex43(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 10; // 10, 20, ..., 90
            model.Digit2 = _random.Next(1, 10) * 10; // 10, 20, ..., 90
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex44(DigitModel model)
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
        public IActionResult GenerateNumberIndex45(DigitModel model)
        {
            model.Digit1 = _random.Next(100, 1000); // 100 to 999
            model.Digit2 = _random.Next(1, 10);     // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex46(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 100; // 100, 200, ..., 900
            model.Digit2 = _random.Next(1, 10) * 100; // 100, 200, ..., 900
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex47(DigitModel model)
        {
            model.Digit1 = _random.Next(100, 1000); // 100 to 999
            model.Digit2 = _random.Next(10, 100);   // 10 to 99
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex48(DigitModel model)
        {
            model.Digit1 = _random.Next(100, 1000); // 100 to 999
            model.Digit2 = _random.Next(100, 1000); // 100 to 999
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex49(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 1000; // 1000, 2000, ..., 9000
            model.Digit2 = _random.Next(1, 10) * 1000; // 1000, 2000, ..., 9000
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex50(DigitModel model)
        {
            model.Digit1 = _random.Next(11, 100); // 11 to 99 (ensuring carrying)
            model.Digit2 = _random.Next(11, 100);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex51(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(1, 10);       // 1 to 9
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex52(DigitModel model)
        {
            model.Digit1 = _random.Next(1, 10) * 10000; // 10000, 20000, ..., 90000
            model.Digit2 = _random.Next(1, 10) * 10000; // 10000, 20000, ..., 90000
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex53(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(10, 100);     // 10 to 99
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex54(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(100, 1000);   // 100 to 999
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex55(DigitModel model)
        {
            model.Digit1 = _random.Next(1000, 10000); // 1000 to 9999
            model.Digit2 = _random.Next(1000, 10000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex56(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(1, 10);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex57(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(10, 100);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex58(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(100, 1000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex59(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(1000, 10000);
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult GenerateNumberIndex60(DigitModel model)
        {
            model.Digit1 = _random.Next(10000, 100000); // 10000 to 99999
            model.Digit2 = _random.Next(10000, 100000);
            return View("Index", model);
        }

        // Division -------------------------------------------------------------------------------------------
        public IActionResult GenerateNumberIndex61(DigitModel model)
        {
            model.Digit2 = _random.Next(1, 10); // Divisor (1 to 9)

            // Get possible single-digit multiples of Digit2
            List<int> possibleDividends = Enumerable.Range(1, 9).Where(n => n % model.Digit2 == 0).ToList();

            model.Digit1 = possibleDividends[_random.Next(possibleDividends.Count)]; // Pick a valid Dividend

            return View("Index", model);
        }
        public IActionResult GenerateNumberIndex62(DigitModel model)
        {
            model.Digit2 = _random.Next(2, 10); // One-digit divisor (2-9)

            int digit2Value = model.Digit2 ?? 2; // Ensure it's non-null, defaulting to 2

            int minQuotient = (10 + digit2Value - 1) / digit2Value; // Ensures a two-digit result
            int maxQuotient = 99 / digit2Value; // Ensures it doesn't exceed two digits

            int quotient = _random.Next(minQuotient, maxQuotient + 1);
            model.Digit1 = digit2Value * quotient; // Ensures a two-digit first number

            return View("Index", model);
        }


        public IActionResult GenerateNumberIndex63(DigitModel model)
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
        public IActionResult GenerateNumberIndex64(DigitModel model)
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

        public IActionResult GenerateNumberIndex65(DigitModel model)
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
        public IActionResult GenerateNumberIndex66(DigitModel model)
        {
            model.Digit2 = _random.Next(1, 10) * 100; // Ensures a whole hundred (100, 200, ..., 900)

            int quotient = _random.Next(1, 10); // Ensures a single-digit quotient (1-9)

            model.Digit1 = model.Digit2 * quotient; // Result is always a whole hundred

            return View("Index", model);
        }

        public IActionResult GenerateNumberIndex67(DigitModel model)
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
        public IActionResult GenerateNumberIndex68(DigitModel model)
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

        public IActionResult GenerateNumberIndex69(DigitModel model)
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
        public IActionResult GenerateNumberIndex70(DigitModel model)
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
        public IActionResult GenerateNumberIndex71(DigitModel model)
        {
            // Ensure Digit2 is a multiple of 1000 (1000, 2000, ..., 9000)
            model.Digit2 = _random.Next(1, 10) * 1000; // Random multiple of 1000

            // Generate a quotient (1-9) to multiply Digit2 and get Digit1
            int quotient = _random.Next(1, 10); // Single-digit quotient (1-9)

            // Ensure Digit1 is a multiple of 1000 (Digit2 * quotient will be multiple of 1000)
            model.Digit1 = model.Digit2 * quotient; // Result will be multiple of 1000

            return View("Index", model);
        }
        public IActionResult GenerateNumberIndex72(DigitModel model)
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

        public IActionResult GenerateNumberIndex73(DigitModel model)
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
        public IActionResult GenerateNumberIndex74(DigitModel model)
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
        public IActionResult GenerateNumberIndex75(DigitModel model)
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

        public IActionResult GenerateNumberIndex76(DigitModel model)
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

        public IActionResult GenerateNumberIndex77(DigitModel model)
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

        public IActionResult GenerateNumberIndex78(DigitModel model)
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



        public IActionResult GenerateNumberIndex79(DigitModel model)
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

        public IActionResult GenerateNumberIndex80(DigitModel model)
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
        public IActionResult GenerateNumberIndex81(DigitModel model)
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
        public IActionResult GenerateNumberIndex82(DigitModel model)
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



        public IActionResult DownloadPdf(int count, int skillId, string schoolName, int totalMarks, string examDate)
        {
            var model = new PdfViewModel
            {
                SchoolName = schoolName,
                TotalMarks = totalMarks,
                ExamDate = DateTime.TryParse(examDate, out DateTime parsedDate) ? parsedDate : DateTime.Now,
                SkillName = GetSkillName(skillId)
            };

            // Generate Questions
            for (int i = 1; i <= count; i++)
            {
                var digitModel = new DigitModel();
                GenerateNumber(skillId, digitModel);

                string problem = $"{i}) {digitModel.Digit1}";
                if (digitModel.Digit2 != null) problem += $" {GetOperator(skillId)} {digitModel.Digit2}";
                if (digitModel.Digit3 != null) problem += $" {GetOperator(skillId)} {digitModel.Digit3}";
                if (digitModel.Digit4 != null) problem += $" {GetOperator(skillId)} {digitModel.Digit4}";

                model.Problems.Add(problem);
            }

            return View("DownloadPdf", model);
        }



        private void GenerateNumber(int skillId, DigitModel model)
        {
            switch (skillId)
            {
                case 1: GenerateNumberIndex1(model); break;
                case 2: GenerateNumberIndex2(model); break;
                case 3: GenerateNumberIndex3(model); break;
                case 4: GenerateNumberIndex4(model); break;
                case 5: GenerateNumberIndex5(model); break;
                case 6: GenerateNumberIndex6(model); break;
                case 8: GenerateNumberIndex8(model); break;
                case 9: GenerateNumberIndex9(model); break;
                case 10: GenerateNumberIndex10(model); break;
                case 11: GenerateNumberIndex11(model); break;
                case 12: GenerateNumberIndex12(model); break;
                case 13: GenerateNumberIndex13(model); break;
                case 14: GenerateNumberIndex14(model); break;
                case 15: GenerateNumberIndex15(model); break;
                case 16: GenerateNumberIndex16(model); break;
                case 17: GenerateNumberIndex17(model); break;
                case 18: GenerateNumberIndex18(model); break;
                case 19: GenerateNumberIndex19(model); break;
                case 20: GenerateNumberIndex20(model); break;
                case 21: GenerateNumberIndex21(model); break;
                case 22: GenerateNumberIndex22(model); break;
                case 23: GenerateNumberIndex23(model); break;
                case 24: GenerateNumberIndex24(model); break;
                case 25: GenerateNumberIndex25(model); break;
                case 26: GenerateNumberIndex26(model); break;
                case 27: GenerateNumberIndex27(model); break;
                case 28: GenerateNumberIndex28(model); break;
                case 29: GenerateNumberIndex29(model); break;
                case 30: GenerateNumberIndex30(model); break;
                case 31: GenerateNumberIndex31(model); break;
                case 32: GenerateNumberIndex32(model); break;
                case 33: GenerateNumberIndex33(model); break;
                case 34: GenerateNumberIndex34(model); break;
                case 35: GenerateNumberIndex35(model); break;
                case 36: GenerateNumberIndex36(model); break;
                case 37: GenerateNumberIndex37(model); break;
                case 38: GenerateNumberIndex38(model); break;
                case 39: GenerateNumberIndex39(model); break;
                case 40: GenerateNumberIndex40(model); break;
                case 41: GenerateNumberIndex41(model); break;
                case 42: GenerateNumberIndex42(model); break;
                case 43: GenerateNumberIndex43(model); break;
                case 44: GenerateNumberIndex44(model); break;
                case 45: GenerateNumberIndex45(model); break;
                case 46: GenerateNumberIndex46(model); break;
                case 47: GenerateNumberIndex47(model); break;
                case 48: GenerateNumberIndex48(model); break;
                case 49: GenerateNumberIndex49(model); break;
                case 50: GenerateNumberIndex50(model); break;
                case 51: GenerateNumberIndex51(model); break;
                case 52: GenerateNumberIndex52(model); break;
                case 53: GenerateNumberIndex53(model); break;
                case 54: GenerateNumberIndex54(model); break;
                case 55: GenerateNumberIndex55(model); break;
                case 56: GenerateNumberIndex56(model); break;
                case 57: GenerateNumberIndex57(model); break;
                case 58: GenerateNumberIndex58(model); break;
                case 59: GenerateNumberIndex59(model); break;
                case 60: GenerateNumberIndex60(model); break;
                case 61: GenerateNumberIndex61(model); break;
                case 62: GenerateNumberIndex62(model); break;
                case 63: GenerateNumberIndex63(model); break;
                case 64: GenerateNumberIndex64(model); break;
                case 65: GenerateNumberIndex65(model); break;
                case 66: GenerateNumberIndex66(model); break;
                case 67: GenerateNumberIndex67(model); break;
                case 68: GenerateNumberIndex68(model); break;
                case 69: GenerateNumberIndex69(model); break;
                case 70: GenerateNumberIndex70(model); break;
                case 71: GenerateNumberIndex71(model); break;
                case 72: GenerateNumberIndex72(model); break;
                case 73: GenerateNumberIndex73(model); break;
                case 74: GenerateNumberIndex74(model); break;
                case 75: GenerateNumberIndex75(model); break;
                case 76: GenerateNumberIndex76(model); break;
                case 77: GenerateNumberIndex77(model); break;
                case 78: GenerateNumberIndex78(model); break;
                case 79: GenerateNumberIndex79(model); break;
                case 80: GenerateNumberIndex80(model); break;
                case 81: GenerateNumberIndex81(model); break;
                case 82: GenerateNumberIndex82(model); break;
                default:
                    Console.WriteLine("Invalid skill ID received.");
                    break;
            }
        }

        private string GetOperator(int skillId)
        {
            if (skillId >= 1 && skillId <= 25) return "+";
            if (skillId >= 26 && skillId <= 40) return "-";
            if (skillId >= 41 && skillId <= 60) return "×";
            return "÷";
        }


        // ** Helper method to get skill name **
        private string GetSkillName(int skillId)
        {
            var skillNames = new Dictionary<int, string>
{
    { 1, "Single Digit Addition Without Carry" },
    { 2, "Single Digit Addition With Carry" },
    { 3, "Add Two-Digit and One-Digit Without Regrouping" },
    { 4, "Add Two-Digit and One-Digit With Regrouping" },
    { 5, "Add Three Single-Digit Numbers" },
    { 6, "Addition of Whole Tens" },
    { 7, "Addition Word Problems" },
    { 8, "Add Two-Digit Numbers Without Regrouping" },
    { 9, "Add Two-Digit Numbers With Regrouping" },
    { 10, "Add Three Two-Digit Numbers" },
    { 11, "Addition of Whole Hundreds" },
    { 12, "Add Three-Digit Numbers Without Regrouping" },
    { 13, "Add Three-Digit Numbers With Regrouping" },
    { 14, "Add Three Numbers Each Up to Three Digits" },
    { 15, "Add Three Numbers Three Digits" },
    { 16, "Add Four Numbers Three Digits" },
    { 17, "Add Two Four-Digit Numbers" },
    { 18, "Add Three Four-Digit Numbers" },
    { 19, "Add Four Four-Digit Numbers" },
    { 20, "Add Three Numbers Each Up to Four Digits" },
    { 21, "Add Two Five-Digit Numbers" },
    { 22, "Add Three Five-Digit Numbers" },
    { 23, "Add Four Five-Digit Numbers" },
    { 24, "Add Two Six-Digit Numbers" },
    { 25, "Add Three Six-Digit Numbers" },
    { 26, "Single Digit Subtraction" },
    { 27, "Subtract a 1-Digit Number from a 2-Digit Number Without Borrowing" },
    { 28, "Subtract a 2-Digit Number from a 2-Digit Number Without Borrowing" },
    { 29, "Subtraction of Whole Tens" },
    { 30, "Subtract a 1-Digit Number from a 2-Digit Number with Borrowing" },
    { 31, "Subtract a 2-Digit Number from a 2-Digit Number with Borrowing" },
    { 32, "Subtraction for 3-Digit Numbers" },
    { 33, "Subtraction for 3-Digit Numbers with Borrow" },
    { 34, "Borrowing Over Zeros (2-Digit and 3-Digit)" },
    { 35, "Subtract Two Numbers up to 3-Digits Each" },
    { 36, "Subtract a 4-Digit Number" },
    { 37, "Subtraction with Borrowing Over Three Zeros" },
    { 38, "Subtract Two Numbers up to 5-Digits" },
    { 39, "Subtract a 5-Digit Number" },
    { 40, "Subtract Two Numbers up to 6-Digits" },
    { 41, "Multiply a 1-Digit Number by Another 1-Digit Number" },
    { 42, "Multiply a 2-Digit Number by a 1-Digit Number" },
    { 43, "Multiplication of Whole Tens" },
    { 44, "Multiply a 2-Digit Number by Another 2-Digit Number Without Carry" },
    { 45, "Multiply a 3-Digit Number by a 1-Digit Number" },
    { 46, "Multiplication of Whole Hundreds" },
    { 47, "Multiply a 3-Digit Number by a 2-Digit Number" },
    { 48, "Multiply a 3-Digit Number by Another 3-Digit Number" },
    { 49, "Multiplication of Whole Thousands" },
    { 50, "Multiply a 2-Digit Number by Another 2-Digit Number With Carry" },
    { 51, "Multiply a 4-Digit Number by a 1-Digit Number" },
    { 52, "Multiplication of Whole Ten Thousands" },
    { 53, "Multiply a 4-Digit Number by a 2-Digit Number" },
    { 54, "Multiply a 4-Digit Number by a 3-Digit Number" },
    { 55, "Multiply a 4-Digit Number by Another 4-Digit Number" },
    { 56, "Multiply a 5-Digit Number by Another 1-Digit Number" },
    { 57, "Multiply a 5-Digit Number by Another 2-Digit Number" },
    { 58, "Multiply a 5-Digit Number by Another 3-Digit Number" },
    { 59, "Multiply a 5-Digit Number by Another 4-Digit Number" },
    { 60, "Multiply a 5-Digit Number by Another 5-Digit Number" },
    { 61, "Divide a 1-Digit Number by Another 1-Digit Number" },
    { 62, "Divide a 2-Digit Number by a 1-Digit Number" },
    { 63, "Division of Whole Tens" },
    { 64, "Divide a 2-Digit Number by Another 2-Digit Number" },
    { 65, "Divide a 3-Digit Number by a 1-Digit Number" },
    { 66, "Division of Whole Hundreds" },
    { 67, "Divide a 3-Digit Number by a 2-Digit Number" },
    { 68, "Divide a 3-Digit Number by a 3-Digit Number" },
    { 69, "Divide a Number by a 2-Digit Number" },
    { 70, "Divide a Number by a 3-Digit Number" },
    { 71, "Division of Whole Thousands" },
    { 72, "Divide a 4-Digit Number by a 1-Digit Number" },
    { 73, "Divide a 4-Digit Number by a 2-Digit Number" },
    { 74, "Divide a 4-Digit Number by a 3-Digit Number" },
    { 75, "Divide a 4-Digit Number by Another 4-Digit Number" },
    { 76, "Divide a 5-Digit Number by a 1-Digit Number" },
    { 77, "Divide a 5-Digit Number by a 2-Digit Number" },
    { 78, "Divide a 5-Digit Number by a 3-Digit Number" },
    { 79, "Divide a 5-Digit Number by a 4-Digit Number" },
    { 80, "Divide a 5-Digit Number by a 5-Digit Number" },
    { 81, "Divide Two Numbers Up to 5-Digits Each" },
    { 82, "Divide Two Numbers Up to 6-Digits Each" }
};


            return skillNames.ContainsKey(skillId) ? skillNames[skillId] : "Math"; // Default if skillId not found
        }
    }
}
