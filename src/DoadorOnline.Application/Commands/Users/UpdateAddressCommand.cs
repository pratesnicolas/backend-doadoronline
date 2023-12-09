using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class UpdateAddressCommand : IRequest<ValidationResult>
{

    public string UserId { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string AddressLine2 { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
}
