using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class CreateSaleCommand : IRequest<ValidationResult>
{
    public string Description { get; set; }
    public int Points { get;set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
}
