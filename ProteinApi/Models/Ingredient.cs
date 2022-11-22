
namespace ProteinApi.Models;

public class Tag
{
    public string TagType { get; set; } = null!; //Quality standard OR Production value

    public string Name { get; set; } = null!; //Red-Tractor, Organic OR 'Busisness CO2 (Kg/y)', 'Fertilizer (Kg/Acre)'

    public double? Value { get; set; }

}
