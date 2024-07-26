using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Responsibilityareaindicator
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? NilaiUntukKerjaTotal { get; set; }

    public int? Period { get; set; }

    public virtual ICollection<Anuallycompetence> Anuallycompetences { get; set; } = new List<Anuallycompetence>();

    public virtual ICollection<Aspek> Aspeks { get; set; } = new List<Aspek>();
}
