using System.ComponentModel.DataAnnotations;
using dotnetapi.Enums;

namespace dotnetapi.Models;

public class EmployeeRequestViewModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DepartmentEnum Department { get; set; }
    public bool Active { get; set; }
    public TurnEnum Turn { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime UpdatedAt { get; set; } = DateTime.Now.ToLocalTime();
}