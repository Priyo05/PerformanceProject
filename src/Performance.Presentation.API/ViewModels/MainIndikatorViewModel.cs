using System.ComponentModel.DataAnnotations;

namespace Performance.Presentation.API;
public class MainIndikatorViewModel
{
    public int Id { get; set; }
    public string? StrategicObjective { get; set; }
    [Required(ErrorMessage = "KPI is required")]
    public string? KPI { get; set; }
    [Required(ErrorMessage = "UoM is required")]
    public string? UnitOfMeasurement { get; set; }
    [Required(ErrorMessage = "Bobot is required")]
    public int? Bobot { get; set; }
    [Required(ErrorMessage = "Polarisasi is required")]
    public string? Polarisasi { get; set; }
    [Required(ErrorMessage = "Target is required")]
    public int? Target { get; set; }
    [Required(ErrorMessage = "Aktual is required")]
    public int? Aktual { get; set; }
    public int? TingkatUnjukKerja { get; set; }
    public int? NilaiUnjukKerja { get; set; }
    public int? Periode { get; set; }
}

