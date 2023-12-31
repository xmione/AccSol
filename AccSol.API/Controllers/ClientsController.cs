﻿using Microsoft.AspNetCore.Mvc;
using AccSol.EF.Models;
using AccSol.EF.Repositories;

namespace AccSol.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public ClientsController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            var list = _repository.Client.GetAll(trackChanges: false);
           
            return Ok(list);
        }

        // GET: Clients/GetById/5
        [HttpPost("Get")]
        public ActionResult<Client?> Get([FromBody] int? id)
        {
            try
            {
                Client? client = null;
                if (id != null)
                {
                    client = _repository.Client.Get(id, trackChanges: false);
                     
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Client? client)
        {
            try
            {
                if (client != null)
                {
                    _repository.Client.CreateClient(client);
                    _repository.Save();

                }

                return Ok(_repository.Client);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Client? client)
        {
            try
            {
                if (client != null) {
                    _repository.Client.UpdateClient(client);
                    _repository.Save();
                }

                return Ok(client);
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
                    var client = _repository.Client.Get(id, false);
                    if (client != null) 
                    {
                        _repository.Client.DeleteClient(client);
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
