using DoadorOnline.Domain;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;
public class UpdatePersonalDataCommand : IRequest<ValidationResult>
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }  
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    public bool IsValid()
    {
        this.ValidationResult = new UpdatePersonalDataCommandValidator().Validate(this);
        return this.ValidationResult.IsValid;
    }
}
