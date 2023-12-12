using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class CreatePartnerCommand : IRequest<ValidationResult>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public IFormFile Image { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
}

