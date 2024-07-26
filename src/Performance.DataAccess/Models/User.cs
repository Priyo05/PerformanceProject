using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual Role? RoleNavigation { get; set; }
}
