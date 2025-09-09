namespace BlazorWebAppMovies.Models.MyFlood;

public class QuoteResponseMessage
{
    public NewQuoteRequest? Request { get; set; }
    public QuoteResponse? Response { get; set; }
    public Messages? Messages { get; set; }
}

public class QuoteResponse
{
    public string? RedactedCompanyId { get; set; }
    public string? QuoteRequestDate { get; set; }
    public string? QuoteExpiryDate { get; set; }
    public ResidentialQuote? Residential { get; set; }
}

public class ResidentialQuote
{
    public double? BuildingPremium { get; set; }
    public double? ContentsPremium { get; set; }
    public double? TotalPremium { get; set; }
    public List<ResidentialDeductible>? Deductibles { get; set; }
}

public class ResidentialDeductible
{
    public int Deductible { get; set; }
    public double BuildingPremium { get; set; }
    public double ContentsPremium { get; set; }
    public double TotalPremium { get; set; }
}

public class Messages
{
    public List<string>? Validation { get; set; }
    public List<string>? UnderwriterDecisions { get; set; }
}

public class ProblemDetails
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int? Status { get; set; }
    public string? Detail { get; set; }
    public string? Instance { get; set; }
}