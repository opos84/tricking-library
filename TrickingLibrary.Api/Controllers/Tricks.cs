using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/tricks")]
    public class Tricks : ControllerBase
    {
        private TrickyStore _trickyStore;
        
        public Tricks(TrickyStore trickyStore)
        {
            _trickyStore = trickyStore;
        }

        [HttpGet]
        public IActionResult All() => Ok(_trickyStore.All);

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_trickyStore.All.FirstOrDefault(x => x.Id == id));

        [HttpPost]
        public IActionResult Create([FromBody] Trick trick)
        {
            _trickyStore.Add(trick);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Trick trick)
        {
           throw  new NotImplementedException();
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw  new NotImplementedException();
        }
    }
}