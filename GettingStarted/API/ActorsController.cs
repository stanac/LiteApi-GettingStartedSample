using LiteApi;
using LiteApi.Attributes;
using System;
using System.Collections.Generic;
using GettingStarted.Models;

namespace GettingStarted.API
{
    // RestfulLinks will tell LiteApi to ignore action names when maching parameters, 
    // ControllerRoute will tell LiteApi to use specified path to target the controller
    [RestfulLinks, ControllerRoute("/api/v2/actors")] 
    public class ActorsController : LiteController, IActorsService
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        [HttpPost] // will respond to POST /api/v2/actors
        public ActorModel Add(ActorModel model) => _service.Add(model);

        [HttpDelete, ActionRoute("/{id}")] // will respond to DELETE /api/v2/actors/{id}
        public bool Delete(Guid id) => _service.Delete(id);

        [HttpGet, ActionRoute("/{id}")] // HttpGet is optional, will respond to GET /api/v2/actors/{id}
        public ActorModel Get(Guid id) => _service.Get(id);

        [HttpGet] // HttpGet is optional, will respond to GET /api/v2/actors
        public IEnumerable<ActorModel> GetAll() => _service.GetAll();

        [HttpPut, ActionRoute("/{id}")] // will respond to PUT /api/v2/actors/{id}
        public ActorModel Update(Guid id, ActorModel model) => _service.Update(id, model);
    }
}
