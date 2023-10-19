using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class ChangePasswordCommand : IRequest<ValidationResult>
{
    public string Token { get; set; }   
    public string Password { get; set; }
    public string ConfirmPassword { get;set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public bool IsValid()
    {
        return true;
    }
 
}
