using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class ContactUsCommand : IRequest<ValidationResult>
{
    public string Name { get; set; }

    public string Email { get; set; }   
    public string Message { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }  

}
