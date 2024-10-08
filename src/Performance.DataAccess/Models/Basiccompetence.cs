﻿using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Basiccompetence
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AnuallycompetencesId { get; set; }

    public string? CustomerFocus { get; set; }

    public string? Integrity { get; set; }

    public string? Teamwork { get; set; }

    public string? CountinousImprovement { get; set; }

    public string? WorkExcellent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? TotalValue { get; set; }

    public int? Period { get; set; }

    public virtual Anuallycompetence? Anuallycompetences { get; set; }

    public virtual Profile? User { get; set; }
}
