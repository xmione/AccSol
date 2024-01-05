using Microsoft.AspNetCore.Mvc;
using AccSol.EF.Models;
using AccSol.EF.Repositories;

namespace AccSol.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PettyCashesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public PettyCashesController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<PettyCash>> GetAll()
        {
            var list = _repository.PettyCash.GetAll(trackChanges: false);
           
            return Ok(list);
        }

        // GET: PettyCashes/GetById/5
        [HttpPost("Get")]
        public ActionResult<PettyCash?> Get([FromBody] int? id)
        {
            try
            {
                PettyCash? pettyCash = null;
                if (id != null)
                {
                    pettyCash = _repository.PettyCash.Get(id, trackChanges: false);
                     
                }

                return Ok(pettyCash);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public ActionResult<PettyCash?> Create([FromBody] PettyCash? pettyCash)
        {
            try
            {
                if (pettyCash != null)
                {
                    _repository.PettyCash.CreatePettyCash(pettyCash);
                    _repository.Save();

                }

                return Ok(pettyCash);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] PettyCash? pettyCash)
        {
            try
            {
                if (pettyCash != null) {
                    _repository.PettyCash.UpdatePettyCash(pettyCash);
                    _repository.Save();
                }

                return Ok(pettyCash);
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
                    var pettyCash = _repository.PettyCash.Get(id, false);
                    if (pettyCash != null) 
                    {
                        _repository.PettyCash.DeletePettyCash(pettyCash);
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
