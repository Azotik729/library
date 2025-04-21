using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; }

    public string? Adres { get; set; }

    public string? Phone { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Fio { get; set; }

    public virtual Authorization? LoginNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
