namespace Bookiby.Domain.Apartments;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    private Currency(string code) => Code = code;
    public string Code { get; set; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException($"Code {code} is invalid");
    }
    
    public static readonly IReadOnlyCollection<Currency> All = [Usd, Eur];
}