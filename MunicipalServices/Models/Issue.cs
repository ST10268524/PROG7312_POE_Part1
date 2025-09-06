using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalServices.Models
{
    public enum IssueStatus { Received, InQueue, InProgress, Resolved }

    public class Issue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        public string? AttachmentFileName { get; set; }

        public IssueStatus Status { get; set; } = IssueStatus.Received;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string ReferenceNumber { get; set; } = string.Empty;

        public bool NotifyBySms { get; set; }
        public bool NotifyByEmail { get; set; }
    }
}
