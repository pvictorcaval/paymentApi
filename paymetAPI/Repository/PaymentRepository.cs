using paymetAPI.Data;
using paymetAPI.Models;
using paymetAPI.Repository.Interfaces;

namespace paymetAPI.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext dbContext;
        public PaymentRepository(DataContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public List<Payment> findAll() 
        {
            return dbContext.payments.ToList();
        }
        public Payment findById(int id) 
        {
            return dbContext.payments.FirstOrDefault(x => x.id == id);
        }

        public Payment create(Payment payment) 
        {
            dbContext.payments.Add(payment);
            dbContext.SaveChanges();

            return payment;
        }

        public Payment update(Payment payment, int id) 
        {
            Payment paymentById = findById(id);

            if (paymentById == null) 
            {
                throw new Exception("Payment not found!");
            }

            paymentById.description = payment.description;
            paymentById.paymentDate = payment.paymentDate;
            paymentById.paymentValue = payment.paymentValue;

            dbContext.Update(paymentById);
            dbContext.SaveChanges();

            return paymentById;
        }

        public string delete(int id) 
        {
            Payment paymentById = findById(id);

            if (paymentById == null)
            {
                throw new Exception("Payment not found!");
            }

            dbContext.payments.Remove(paymentById);
            dbContext.SaveChanges();
            return "successfully deleted payment!";
        }
    }
}
