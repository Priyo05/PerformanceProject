﻿using System.ComponentModel.DataAnnotations;

namespace Performance.Web.Blazor.ViewModels;
public class RegisterEmployeeViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Firstname is required")]
    public string Firstname { get; set; }

    [Required(ErrorMessage = "Lastname is required")]
    public string Lastname { get; set; }

    [MaxLength(16, ErrorMessage = "NIK cannot exceed 16 characters")]
    [Required(ErrorMessage = "NIK is required")]
    public string NIK { get; set; }

    [Required(ErrorMessage = "Department is required")]
    public string Department { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Birthdate is required")]
    public DateTime Birthdate { get; set; }
}

