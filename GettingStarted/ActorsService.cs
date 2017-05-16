using GettingStarted.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GettingStarted
{
    public interface IActorsService
    {
        IEnumerable<ActorModel> GetAll();
        ActorModel Get(Guid id);
        ActorModel Add(ActorModel model);
        ActorModel Update(Guid id, ActorModel model);
        bool Delete(Guid id);
    }

    public class ActorsService : IActorsService
    {
        private static readonly IDictionary<Guid, ActorModel> _data = new ConcurrentDictionary<Guid, ActorModel>();

        public ActorModel Add(ActorModel model)
        {
            if (model.Id == Guid.Empty) model.Id = Guid.NewGuid();
            _data[model.Id] = model;
            return model;
        }

        public bool Delete(Guid id)
        {
            if (_data.ContainsKey(id))
            {
                _data.Remove(id);
                return true;
            }
            return false;
        }

        public ActorModel Get(Guid id)
        {
            if (_data.ContainsKey(id)) return _data[id];
            return null;
        }

        public IEnumerable<ActorModel> GetAll() => _data.Select(x => x.Value);

        public ActorModel Update(Guid id, ActorModel model)
        {
            model.Id = id;
            _data[id] = model;
            return model;
        }
    }
}
