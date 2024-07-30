using System;
using System.Collections.Generic;

namespace Performance.DataAccess.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public int? ProfileId { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual Role? RoleNavigation { get; set; }
}
