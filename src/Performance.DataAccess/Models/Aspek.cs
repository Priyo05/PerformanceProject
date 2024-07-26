using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Aspek
{
    public int Id { get; set; }

    public string? AspekName { get; set; }

    public string? AspekDescription { get; set; }

    public int? Bobot { get; set; }

    public int? TingkatUntukKerja { get; set; }

    public int? NilaiUntukKerja { get; set; }

    public int? ResponsibilityareaindicatorId { get; set; }

    public virtual Responsibilityareaindicator? Responsibilityareaindicator { get; set; }

    public virtual ICollection<Subaspek> Subaspeks { get; set; } = new List<Subaspek>();
}
