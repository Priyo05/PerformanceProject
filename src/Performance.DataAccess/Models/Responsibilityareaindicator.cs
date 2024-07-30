using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Responsibilityareaindicator
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AnuallycompetencesId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? NilaiUntukKerjaTotal { get; set; }

    public int? Period { get; set; }

    public virtual Anuallycompetence? Anuallycompetences { get; set; }

    public virtual ICollection<Aspek> Aspeks { get; set; } = new List<Aspek>();

    public virtual Profile? User { get; set; }
}
