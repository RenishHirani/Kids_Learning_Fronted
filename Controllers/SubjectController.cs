using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using frontend.Models;

public class SubjectController : Controller
{
    private readonly IConfiguration configuration;

    public SubjectController(IConfiguration config)
    {
        configuration = config;
    }

    // ✅ 1. Display all subjects as links
    public IActionResult SubjectList()
    {
        DataTable dataTable = new DataTable();
        string connectionString = configuration.GetConnectionString("ConnectionString");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_SelectAll_Subject", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error fetching subject list.";
                Console.WriteLine(ex.ToString());
            }
        }
        return View(dataTable);
    }


    // ✅ 2. Fetch grades for a selected subject
    public IActionResult GradeList(int subjectId)
    {
        DataTable dataTable = new DataTable();
        string connectionString = configuration.GetConnectionString("ConnectionString");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_GetGradesBySubject", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SubjectID", subjectId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error fetching grade list.";
                Console.WriteLine(ex.ToString());
            }
        }

        ViewBag.SubjectID = subjectId; // Passing SubjectID to the View for navigation
        return View(dataTable);
    }


    // ✅ 3. Fetch chapters for a selected grade & subject
    public IActionResult ChapterList(int subjectId, int gradeId)
    {
        DataTable dataTable = new DataTable();
        string connectionString = configuration.GetConnectionString("ConnectionString");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_GetChaptersBySubjectAndGrade", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SubjectID", subjectId);
                    command.Parameters.AddWithValue("@GradeID", gradeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error fetching chapter list.";
                Console.WriteLine(ex.ToString());
            }
        }

        ViewBag.SubjectID = subjectId; // Passing SubjectID to View
        ViewBag.GradeID = gradeId;     // Passing GradeID to View
        return View(dataTable);
    }


    // ✅ 4. Fetch chapters for a selected chapter & grade & subject
    public IActionResult SkillList(int subjectId, int gradeId, int chapterId)
    {
        DataTable dataTable = new DataTable();
        string connectionString = configuration.GetConnectionString("ConnectionString");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PR_GetSkillsByChapterGradeSubject", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SubjectID", subjectId);
                    command.Parameters.AddWithValue("@GradeID", gradeId);
                    command.Parameters.AddWithValue("@ChapterID", chapterId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error fetching skill list.";
                Console.WriteLine(ex.ToString());
            }
        }

        ViewBag.SubjectID = subjectId;
        ViewBag.GradeID = gradeId;
        ViewBag.ChapterID = chapterId;
        return View(dataTable);
    }



    [HttpGet]
    public IActionResult GetSkillRoute(int skillId)
    {
        string connectionString = configuration.GetConnectionString("ConnectionString");
        DataTable dataTable = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT ControllerName, ActionName FROM SkillRoutes WHERE SkillID = @SkillID", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@SkillID", skillId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching skill route: " + ex.Message);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        if (dataTable.Rows.Count > 0)
        {
            var row = dataTable.Rows[0];
            return Json(new { controller = row["ControllerName"].ToString(), action = row["ActionName"].ToString() });
        }

        return Json(new { controller = "", action = "" });
    }





}
