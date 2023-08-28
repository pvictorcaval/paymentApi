using paymetAPI.Models;

namespace paymetAPI.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        List<Payment> findAll();
        
        Payment findById(int id);
        
        Payment create(Payment payment);

        Payment update(Payment payment, int id);

        string delete(int id); 

    }
}
