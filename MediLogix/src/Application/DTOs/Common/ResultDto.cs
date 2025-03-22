using System.Collections.Generic;

namespace MediLogix.Application.DTOs.Common;

public class ResultDto
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
} 