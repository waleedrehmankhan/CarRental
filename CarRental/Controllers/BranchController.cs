using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Dtos;
using CarRental.Helpers;
using CarRental.Models;
using CarRental.Persistence;
using CarRental.Persistence.Repositories.Branch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchController(ILogger<BranchController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContentResult> GetBranch(GetBranchInput input)
        {
            // TODO: Your code here
            try
            {
                ReturnMessage rm = new ReturnMessage(1,"Success");
                var branchs = await Task.Run(() => _unitOfWork.Branchs.GetAsync());
                var branchsToReturn = _mapper.Map<IEnumerable<BranchDto>>(branchs);
                return this.Content(rm.returnMessage(new PagedResultDto<BranchDto>
                    (branchsToReturn.AsQueryable(), input.pagenumber, input.pagesize)),
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