using System;

namespace OrgFinder.Models;

public class StudentProfile
{
    public string? Department { get; set; }
    public string? Program { get; set; }
    public List<string> Interests { get; set; } = new List<string>();
}
