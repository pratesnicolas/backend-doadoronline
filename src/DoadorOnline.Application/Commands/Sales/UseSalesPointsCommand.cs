using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace DoadorOnline.Application;

public class UseSalesPointsCommand : IRequest<ValidationResult>
{

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
    public string UserId { get; set; }
    public string SaleId { get; set; }

}
