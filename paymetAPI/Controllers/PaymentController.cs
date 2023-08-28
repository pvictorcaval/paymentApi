using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paymetAPI.Dto;
using paymetAPI.Models;
using paymetAPI.Repository;
using System.Collections;

namespace paymetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentRepository _paymentRepository;
        public PaymentController(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet("findAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Payment>> findAll()
        {
            var payments = _paymentRepository.findAll();

            if (payments == null)
            {
                return NoContent();
            }

            return Ok(payments);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Payment> findByid(int id)
        {
            var payment = _paymentRepository.findById(id);

            if (payment == null)
            {
                return NotFound("Payment not found!");
            }

            return Ok(payment);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Payment> create([FromBody] PaymentDto paymentDto)
        {
            Payment payment = buildPaymentFromDto(paymentDto);
            return Ok(_paymentRepository.create(payment));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Payment> update([FromBody] PaymentDto paymentDto, int id)
        {
            Payment payment = buildPaymentFromDto(paymentDto);
            return Ok(_paymentRepository.update(payment, id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> delete(int id) 
        {
            return Ok(_paymentRepository.delete(id));
        }

        private Payment buildPaymentFromDto(PaymentDto paymentDto)
        {
            Payment payment = new Payment();
            payment.description = paymentDto.description;
            payment.paymentDate = paymentDto.paymentDate;
            payment.paymentValue = paymentDto.paymentValue;
            return payment;
        }
    }
}
