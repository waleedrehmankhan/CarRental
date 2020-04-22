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

        [HttpPost("getBranchDetails")]
        public async Task<ContentResult> GetBranch(GetBranchInput input)
        {
            try
            {
                ReturnMessage rm = new ReturnMessage(1,"Success");
                var branchs = await Task.Run(() => _unitOfWork.Branchs.GetAsync(filter: w => input.Id != 0 ? (w.Id == input.Id) : true));
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
        
        [HttpPost("createOrUpdateBranch")]
        [ValidateFilter]
        public async Task<ContentResult> CreateOrUpdateBranch(BranchDto branchDto)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Branch Saved Succesfully");
            try
            {
                var branch = await Task.Run(() => _unitOfWork.Branchs.GetAsync(filter: w => w.Id == branchDto.Id));
                var branchToAdd = _mapper.Map<Branch>(branchDto);
                if (branch.Count() == 0)
                {
                    _unitOfWork.Branchs.Add(branchToAdd);

                }
                else
                {
                    _unitOfWork.Branchs.Update(branchToAdd);
                }
                var status = _unitOfWork.Complete();
                _logger.LogInformation("Log:Add Branch for ID: {Id}", branchToAdd.Id);
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

        [HttpPost("deleteBranch")]
        public async Task<ContentResult> DeleteBranch(GetBranchInput input)
        {

            ReturnMessage returnmessage = new ReturnMessage(1, "Branch Deleted Succesfully");
            try
            {

                var branch = await Task.Run(() => _unitOfWork.Branchs.GetAsync(filter: w => w.Id == input.Id));

                if (branch.Count() == 0)
                {
                    returnmessage.msgCode = -2;
                    returnmessage.msg = "Branch Not Found";
                }
                else
                    _unitOfWork.Branchs.Remove(branch.First());
                _unitOfWork.Complete();
                _logger.LogInformation("Log:Delete Branch for ID: {Id}", input.Id);

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