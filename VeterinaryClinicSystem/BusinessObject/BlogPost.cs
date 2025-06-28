using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class BlogPost
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string? Slug { get; set; }

    public string Content { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public int? AuthorId { get; set; }

    public string? Category { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsPublished { get; set; }

    public virtual User? Author { get; set; }
}
