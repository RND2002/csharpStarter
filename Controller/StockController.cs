using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starterProject.Data;
using starterProject.Dtos.Stock;
using starterProject.Interfaces;
using starterProject.Mappers;

namespace starterProject.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController :ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDbContext context,IStockRepository stockRepository)
        {
            _stockRepo=stockRepository;
            _context=context;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stocks=await _stockRepo.getAllAsync();
            var stockDtos=stocks.Select(s=>s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stock=await _stockRepo.getByIdAsync(id);
            if(stock==null){
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] CreateStockRequest createStockRequest){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel=createStockRequest.ToStockFromCreateDto();

            await _stockRepo.createAsync(stockModel);
            return CreatedAtAction(nameof(GetById),new {id=stockModel.Id},stockModel.ToStockDto());
            
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateStockRequestDto){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stockModel=await _stockRepo.updateAsync(id,updateStockRequestDto);
            if(stockModel==null){
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel=await _stockRepo.deleteAsync(id);
            if(stockModel==null){
                return NotFound();
            }

        
            return NoContent();
        }
    }
}