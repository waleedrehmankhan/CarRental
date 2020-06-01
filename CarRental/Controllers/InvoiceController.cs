using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Models;
using CarRental.Persistence;
using CarRental.Persistence.Repositories.Invoice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        // GET: /<controller>/
        public InvoiceController(ILogger<InvoiceController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost("getInvoiceDetails")]
        public async Task<ContentResult> GetInvoice(GetInvoiceInput input)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var invoices = await Task.Run(() => _unitOfWork.Invoices.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true, includeProperties: "Customer,Booking"));
                var invoicesToReturn = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
                return this.Content(rm.returnMessage(new PagedResultDto<InvoiceDto>
                    (invoicesToReturn.AsQueryable(), input.pagenumber, input.pagesize)),
                    "application/json");
            }
            catch (Exception ex)
            {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = -3,
                    msg = ex.Message
                }), "application/json");
            }
        }
        [HttpPost("getInvoiceItemDetails")]
        public async Task<ContentResult> GetInvoiceItem(GetInvoiceInput input)
        {
            try
            {
                List<ExtraDto> extralist = new List<ExtraDto>();
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var invoices = await Task.Run(() => _unitOfWork.Invoices.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true, includeProperties: "Customer,Booking"));
                var invoicesToReturn = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
                //  var extra = _unitOfWork.BookingExtras.Find(x => x.BookingId == invoices.First().Booking.Id);
                var extra = await Task.Run(() => _unitOfWork.BookingExtras.GetAsync(filter: w => w.BookingId == invoices.First().BookingId, includeProperties: "Extra"));
                var cars = await Task.Run(() => _unitOfWork.Cars.GetAsync(filter: w => w.Id == invoices.First().Booking.CarId, includeProperties: "CarClassification"));
                var car = _mapper.Map<IEnumerable<CarDto>>(cars).First();
                var payment = _unitOfWork.Payments.Find(x => x.InvoiceId == input.Id).SingleOrDefault();
                PaymentDto paymentDto = _mapper.Map<PaymentDto>(payment);
                if(paymentDto!=null)
                    paymentDto.PaymentType = ((Utility.PaymentType)Convert.ToInt32( paymentDto.PaymentType)).ToString();
                foreach (var item in extra)
                {
                    var extraDto = _mapper.Map<ExtraDto>(item.Extra);
                    extraDto.Count = item.Count ?? 0;
                    extralist.Add(extraDto);
                }
                InvoiceDetailDto invoiceDetail = new InvoiceDetailDto()
                {
                    Invoice = invoicesToReturn.First(),
                    InvoiceId = invoicesToReturn.First().Id,
                    Booking = invoicesToReturn.First().Booking,
                    BookingExtraList = extralist,
                    Car = car,
                    Payment= paymentDto
                };
                
                List<InvoiceDetailDto> invoicedetailList = new List<InvoiceDetailDto>();
                invoicedetailList.Add(invoiceDetail);

                return this.Content(rm.returnMessage(new PagedResultDto<InvoiceDetailDto>
                   (invoicedetailList.AsQueryable(), input.pagenumber, input.pagesize)),
                   "application/json");
            }
            catch (Exception ex)
            {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = -3,
                    msg = ex.Message
                }), "application/json");
            }
        }



        [HttpPost("PayInvoice")]
        [ValidateFilter]
        public ContentResult MakePayment(PaymentDto payDto)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Payment Made ");
            try
            {
                var invoice = _unitOfWork.Invoices.Find(x => x.Id == payDto.InvoiceId).SingleOrDefault();

                invoice.status = true;
                var paymenttotadd = _mapper.Map<Payment>(payDto);
                paymenttotadd.ReceiptNumber = "REC-" + payDto.InvoiceId.ToString();
                _unitOfWork.Payments.Add(paymenttotadd);
                _unitOfWork.Invoices.Update(invoice);
                var status = _unitOfWork.Complete();
                _logger.LogInformation("Log:Add Payment for ID: {Id}", paymenttotadd.Id);
                return this.Content(returnmessage.returnMessage(null),
                         "application/json");
            }
            catch (Exception ex)
            {
                returnmessage.msg = ex.Message.ToString();
                returnmessage.msgCode = -3;
                return this.Content(returnmessage.returnMessage(null));
            }

        }

    }
}
