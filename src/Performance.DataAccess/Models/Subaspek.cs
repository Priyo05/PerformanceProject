using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Subaspek
{
    public int Id { get; set; }

    public string? SubaspekName { get; set; }

    public int? SubaspekTarget { get; set; }

    public int? SubaspekAktual { get; set; }

    public int? AspekId { get; set; }

    public virtual Aspek? Aspek { get; set; }
}
