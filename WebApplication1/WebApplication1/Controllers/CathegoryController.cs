using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Mappers;
using BusinessLogicLayer.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BusinessLogicLayer.DtoModels;

namespace WebApplication1.Controllers
{
    [Route("api/cathegories")]
    [ApiController]
    public class CathegoryController : ControllerBase
    {
        private readonly ICathegoryService cathegoryService;
        private readonly IWebPortalService webPortalService;
        private readonly CathegoryMapper _mapper = new();
        private readonly WebPortalMapper _mapperWeb = new();

        public CathegoryController(ICathegoryService service, IWebPortalService webPortalService)
        {
            this.webPortalService = webPortalService;
            cathegoryService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCathegories()
        {
            try
            {
                IEnumerable<CathegoryViewModel> cathegoriesVM = _mapper.mapListToVM(await cathegoryService.GetCathegories());
                return Ok(cathegoriesVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CathegoryController>
        [HttpPost]
        public async Task<IActionResult> CreateCathegory([FromBody]CathegoryViewModel cathegoryVM)
        {
            try
            {
                Guid id = await cathegoryService.CreateCathegory(_mapper.mapToDto(cathegoryVM));
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CathegoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCathegory(Guid id, [FromBody]CathegoryViewModel cathegoryVM)
        {
            try
            {
                CathegoryDtoModel cathegoryDto = await cathegoryService.GetCathegoryById(id);
                if (cathegoryDto == null)
                    return NotFound();

                cathegoryDto = _mapper.mapToDto(cathegoryVM);

                Guid checkId = cathegoryService.UpdateCathegory(cathegoryDto);

                return Ok(checkId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
