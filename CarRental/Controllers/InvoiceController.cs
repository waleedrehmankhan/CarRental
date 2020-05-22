using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
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
        public InvoiceController (ILogger<InvoiceController> logger, IUnitOfWork unitOfWork, IMapper mapper)
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
                var invoices = await Task.Run(() => _unitOfWork.Invoices.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true,includeProperties:"Customer"));
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


    }
}
