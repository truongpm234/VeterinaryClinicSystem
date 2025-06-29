using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }
    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? AvatarUrl { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual Role? Role { get; set; }
}
