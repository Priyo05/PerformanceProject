﻿using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Anuallycompetence
{
    public int Id { get; set; }

    public int Period { get; set; }

    public int UserId { get; set; }

    public int? NilaiUntukKerjaTotalWorkmainindicator { get; set; }

    public int? TotalNilaiAkhirTahun { get; set; }

    public DateTime? EmployeeApprovalDate { get; set; }

    public DateTime? AppraisalApprovalDate { get; set; }

    public DateTime? SupervisorApprovalDate { get; set; }

    public string? EmployeeComment { get; set; }

    public DateTime? EmployeeCommentDate { get; set; }

    public string? AppraisalComment { get; set; }

    public DateTime? AppraisalCommentDate { get; set; }

    public virtual ICollection<Additionalindicator> Additionalindicators { get; set; } = new List<Additionalindicator>();

    public virtual ICollection<Basiccompetence> Basiccompetences { get; set; } = new List<Basiccompetence>();

    public virtual ICollection<Responsibilityareaindicator> Responsibilityareaindicators { get; set; } = new List<Responsibilityareaindicator>();

    public virtual Profile User { get; set; } = null!;

    public virtual ICollection<Workmainindicator> Workmainindicators { get; set; } = new List<Workmainindicator>();
}
