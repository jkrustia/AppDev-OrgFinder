using System;

namespace OrgFinder.Models;

public class Organization
{
    public string? Name { get; set; }
    public string? Website { get; set; }
    public string? Department { get; set; }
    public List<string> Programs { get; set; } = new List<string>();
    public List<string> Interests { get; set; } = new List<string>();
}
