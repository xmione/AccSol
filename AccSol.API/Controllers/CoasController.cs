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
        [HttpGet("Get")]
        public ActionResult<Coa?> Get([FromBody] int? id)
        {
            try
            {
                Coa? coa = null;
                if (id != null)
                {
                    coa = _repository.Coa.Get(id, trackChanges: false);
                     
                }

                return Ok(coa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Coa? coa)
        {
            try
            {
                if (coa != null)
                {
                    _repository.Coa.Create(coa);
                    _repository.Save();

                }

                return Ok(_repository.Coa);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Coa? coa)
        {
            try
            {
                if (coa != null) {
                    _repository.Coa.Update(coa);
                    _repository.Save();
                }

                return Ok(coa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] int? id)
        {
            try
            {
                if (id != null)
                {
                    var coa = _repository.Coa.Get(id, false);
                    if (coa != null) 
                    {
                        _repository.Coa.Delete(coa);
                        _repository.Save();
                    }
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
