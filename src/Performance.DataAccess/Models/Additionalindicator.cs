using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Additionalindicator
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AnuallycompetencesId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? IndikatorTotalValue { get; set; }

    public int? Period { get; set; }

    public virtual Anuallycompetence? Anuallycompetences { get; set; }

    public virtual ICollection<Indicator> Indicators { get; set; } = new List<Indicator>();

    public virtual Profile? User { get; set; }
}
