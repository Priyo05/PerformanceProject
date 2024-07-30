using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Workmainindicator
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AnuallycompetencesId { get; set; }

    public string? StrategicObjective { get; set; }

    public string? Kpi { get; set; }

    public string? UnitOfMeasurement { get; set; }

    public int? Bobot { get; set; }

    public string? Polarisasi { get; set; }

    public int? Target { get; set; }

    public int? Aktual { get; set; }

    public int? TingkatUnjukKerja { get; set; }

    public int? NilaiUnjukKerja { get; set; }

    public int? Period { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Anuallycompetence? Anuallycompetences { get; set; }

    public virtual Profile? User { get; set; }
}
