public class Donor
{
    public int DonorID { get; set; }
    public string Name { get; set; }
    public string Organization { get; set; }
    public string ContactInformation { get; set; }
    public string Notes { get; set; }
    public string UserId { get; set; }

    public ApplicationUser User { get; set; }
    public ICollection<Donation> Donations { get; set; }
}

public class Donation
{
    public int DonationID { get; set; }
    public int DonorID { get; set; }
    public DateTime DonationDate { get; set; }
    public string DonationType { get; set; }
    public decimal? DonationAmount { get; set; }
    public string DonationPurpose { get; set; }
    public string ItemDescription { get; set; }
    public int? Quantity { get; set; }
    public decimal? EstimatedValue { get; set; }
    public string PaymentMethod { get; set; }
    public bool TaxReceiptIssued { get; set; }

    public Donor Donor { get; set; }
}

public class Request
{
    public int RequestID { get; set; }
    public DateTime RequestDate { get; set; }
    public string RequestStatus { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public string Notes { get; set; }

    public ICollection<AffectedIndividual> AffectedIndividuals { get; set; }
    public ICollection<RequestItem> RequestItems { get; set; }
    public ICollection<RequestEvaluation> RequestEvaluations { get; set; }
}

public class RequestEvaluation
{
    public int EvaluationID { get; set; }
    public int RequestID { get; set; }
    public string EvaluatorID { get; set; }
    public DateTime EvaluationDate { get; set; }
    public int UrgencyScore { get; set; }
    public int NeedScore { get; set; }
    public int ImpactScore { get; set; }
    public int ResourceAvailabilityScore { get; set; }
    public string Comments { get; set; }

    public Request Request { get; set; }
    public ApplicationUser Evaluator { get; set; }
}

public class AffectedIndividual
{
    public int AffectedIndividualID { get; set; }
    public int RequestID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Relationship { get; set; }
    public string Status { get; set; }
    public string AdditionalInformation { get; set; }

    public Request Request { get; set; }
}

public class RequestItem
{
    public int RequestItemID { get; set; }
    public int RequestID { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; }
    public string Description { get; set; }

    public Request Request { get; set; }
}

public class InventoryItem
{
    public int ItemID { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}

public class FinancialTransaction
{
    public int TransactionID { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int? DonorID { get; set; }

    public Donor Donor { get; set; }
}
