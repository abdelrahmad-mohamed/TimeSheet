using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class EmployeeTaskDTO
{
    public int Id { get; set; }
    //---------------------------------------------------------------------------------------------------
    [DisplayName("Project Name")]
    [Required(ErrorMessage ="Please Select Project Name")]
    public int ProjectId { get; set; }
    //---------------------------------------------------------------------------------------------------
    [Required, StringLength(50, ErrorMessage = "Task Name must be in range (10 to 50) characters.", MinimumLength = 10)]
    public string? TaskName { get; set; } = null!;
    //---------------------------------------------------------------------------------------------------
    [StringLength(500, ErrorMessage = "Task Description must be between 15 and 500 characters.", MinimumLength = 15)]
    public string? Description { get; set; } = null!;
    //---------------------------------------------------------------------------------------------------
    public string ProjectName { get; set; } = null!;
    //---------------------------------------------------------------------------------------------------
    [Required(ErrorMessage ="Please Select Start Date of task")]
    public DateTime StartDate { get; set; } =
    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                 DateTime.Now.Hour, DateTime.Now.Minute, 0);
    //---------------------------------------------------------------------------------------------------
    [Required(ErrorMessage = "Please Select End Date of task")]
    public DateTime EndDate { get; set; } =
    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                 DateTime.Now.Hour, DateTime.Now.Minute, 0);
    //---------------------------------------------------------------------------------------------------
    [Required(ErrorMessage ="Please Select Status")]
    public string Status { get; set; } = "Pending";

    public int EmployeeId { get; set; }

}