﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC_One.Models;

public class UpdateProjectViewModel
{

    public IEnumerable<SelectListItem> Clients { get; set; } = [];
    public IEnumerable<SelectListItem> Users { get; set; } = [];
    public IEnumerable<SelectListItem> Statuses { get; set; } = [];
    
    [Required]
    [Display(Name = "Project Name", Prompt = "Enter project name")]
    public string Id { get; set; } = null!;

    [Required]
    [Display(Name = "Project Name", Prompt = "Enter project name")]
    public string ProjectName { get; set; } = null!;

    [Required]
    [Display(Name = "Client Name", Prompt = "Select client name")]
    public string ClientId { get; set; } = null!;

    [Display(Name = "Description", Prompt = "Enter description")]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Start Date", Prompt = "Enter start date")]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "End Date", Prompt = "Enter end date")]
    public DateTime EndDate { get; set; } = DateTime.Now;

    [Display(Name = "Budget", Prompt = "Enter budget")]
    public decimal? Budget { get; set; }

    [Required]
    [Display(Name = "User", Prompt = "Select user")]
    public string UserId { get; set; } = null!;

    [Required]
    [Display(Name = "Status", Prompt = "Select status")]
    public int StatusId { get; set; }
}
