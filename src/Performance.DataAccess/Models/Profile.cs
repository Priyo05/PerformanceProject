using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class Profile
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Nik { get; set; }

    public string? Department { get; set; }

    public string? Title { get; set; }

    public DateTime? Birthdate { get; set; }

    public virtual ICollection<Additionalindicator> Additionalindicators { get; set; } = new List<Additionalindicator>();

    public virtual ICollection<Anuallycompetence> Anuallycompetences { get; set; } = new List<Anuallycompetence>();

    public virtual ICollection<Basiccompetence> Basiccompetences { get; set; } = new List<Basiccompetence>();

    public virtual ICollection<Responsibilityareaindicator> Responsibilityareaindicators { get; set; } = new List<Responsibilityareaindicator>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Workmainindicator> Workmainindicators { get; set; } = new List<Workmainindicator>();
}
