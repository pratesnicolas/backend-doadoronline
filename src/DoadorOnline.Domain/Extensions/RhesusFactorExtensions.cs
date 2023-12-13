namespace DoadorOnline.Domain;

public static class RhesusFactorExtensions
{
    public static string ToDescriptionString(this RHFactorType rhFactor)
    => rhFactor switch
    {
        RHFactorType.Positive => "+",
        _ => "-",
    };

}
