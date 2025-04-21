using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Chapter
{
    public int IdChapter { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
