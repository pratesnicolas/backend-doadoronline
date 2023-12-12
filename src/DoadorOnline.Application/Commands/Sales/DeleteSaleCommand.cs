using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class DeleteSaleCommand : IRequest<ValidationResult>
{
    public string SaleId { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
}
