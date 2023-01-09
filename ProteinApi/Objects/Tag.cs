
namespace ProteinApi.Models;

public class Tag
{
    public string TagType { get; set; } = null!; //Quality standard OR Production value

    public string Name { get; set; } = null!; 

    public double? Value { get; set; }

}
