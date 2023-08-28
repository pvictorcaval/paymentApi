namespace paymetAPI.Dto
{
    public class PaymentDto
    {
        public string? description { get; set; }
        public DateTime paymentDate { get; set; }
        public Decimal paymentValue { get; set; }
    }
}
