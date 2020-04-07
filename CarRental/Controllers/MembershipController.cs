using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Persistence;
using CarRental.Persistence.Repositories.MemberShipType;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("getMemberShip")]
        public async Task<ContentResult> GetMembership(GetMemberShipTypeInput input)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage(1, "Success");
                var membershiptypes = await Task.Run(() => _unitOfWork.MembershipTypes.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true));
                var membershiptypetoreturn = _mapper.Map<IEnumerable<MembershipTypeDto>>(membershiptypes);
                return this.Content(rm.returnMessage(new PagedResultDto<MembershipTypeDto>
                    (membershiptypetoreturn.AsQueryable(), input.pagenumber, input.pagesize)),
                    "application/json");
            }
            catch (Exception ex)
            {
                return this.Content(JsonConvert.SerializeObject(new
                {
                    msgCode = 0,
                    msg = ex.Message
                }), "application/json");
            }
        }
    }
}