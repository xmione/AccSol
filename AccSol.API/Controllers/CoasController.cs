using Microsoft.AspNetCore.Mvc;
using AccSol.EF.Models;
using AccSol.EF.Repositories;

namespace AccSol.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoasController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public CoasController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Coa>> GetAll()
        {
            var list = _repository.Coa.GetAll(trackChanges: false);
           
            return Ok(list);
        }

        // GET: Coas/GetById/5
        [HttpGet("GetCoa")]
        public ActionResult<Coa> GetCoa([FromBody] Coa? coa)
        {
            try
            {

                if (coa != null)
                {
                    coa = _repository.Coa.Get(coa, trackChanges: false);
                     
                }

                return Ok(coa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
