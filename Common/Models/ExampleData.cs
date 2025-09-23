using Common.Interfaces;

namespace Common.Models;

public class ExampleData : IIdentifyable
{
    public string Name { get; set; }
    public int Value { get; set; }
    public string Id { get; set; }
}