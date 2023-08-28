namespace paymetAPI.Models
{
    public class Payment
    {
        public int id {get; set;}
        public string? description { get; set;}
        public DateTime paymentDate { get; set;} 
        public Decimal paymentValue { get; set; }
    }

}
