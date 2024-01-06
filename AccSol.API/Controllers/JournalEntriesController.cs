using Microsoft.AspNetCore.Mvc;
using AccSol.EF.Models;
using AccSol.EF.Repositories;

namespace AccSol.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalEntriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public JournalEntriesController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Journal>> GetAll()
        {
            var list = _repository.JournalEntry.GetAll(trackChanges: false);
           
            return Ok(list);
        }

        // GET: JournalEntries/GetById/5
        [HttpPost("Get")]
        public ActionResult<Journal?> Get([FromBody] int? id)
        {
            try
            {
                Journal? journalEntry = null;
                if (id != null)
                {
                    journalEntry = _repository.JournalEntry.Get(id, trackChanges: false);
                     
                }

                return Ok(journalEntry);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Journal? journalEntry)
        {
            try
            {
                if (journalEntry != null)
                {
                    _repository.JournalEntry.CreateJournalEntry(journalEntry);
                    _repository.Save();

                }

                return Ok(_repository.JournalEntry);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Journal? journalEntry)
        {
            try
            {
                if (journalEntry != null) {
                    _repository.JournalEntry.UpdateJournalEntry(journalEntry);
                    _repository.Save();
                }

                return Ok(journalEntry);
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
                    var journalEntry = _repository.JournalEntry.Get(id, false);
                    if (journalEntry != null) 
                    {
                        _repository.JournalEntry.DeleteJournalEntry(journalEntry);
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
