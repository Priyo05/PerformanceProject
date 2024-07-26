using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Additionalindicator
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? IndikatorTotalValue { get; set; }

    public int? Period { get; set; }

    public virtual ICollection<Anuallycompetence> Anuallycompetences { get; set; } = new List<Anuallycompetence>();

    public virtual ICollection<Indicator> Indicators { get; set; } = new List<Indicator>();
}
