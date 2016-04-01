using System;
using System.Collections.Generic;
using Ontwikkelopdracht_Game;
using Ontwikkelopdracht_Game.Database;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Database.Memory
{
    public class MapRepository : IRepository<List<GameObject>, string>
    {
        private readonly IDictionary<string, List<GameObject>> _levelsList = new Dictionary<string, List<GameObject>>();

        public MapRepository()
        {
            Reset();
        }

        public void Reset()
        {
            _levelsList.Clear();

            _levelsList.Add("One", LevelPreset.One);
            _levelsList.Add("Test", LevelPreset.Test);
        }

        public void Dispose()
        {
        }

        public IEnumerable<string> List()
        {
            return _levelsList.Keys;
        }

        public void Delete(string id)
        {
            _levelsList.Remove(id);
        }
        
        public bool Exists(string id)
        {
            return _levelsList.ContainsKey(id);
        }

        public List<GameObject> FindOne(string id)
        {
            try
            {
                return _levelsList[id];
            }
            catch (Exception e)
            {
                throw new LevelLoadException(e);
            }
        }

        public S Save<S>(S entity, string id) where S : List<GameObject>
        {
            try
            {
                _levelsList[id] = entity;

                return entity;
            }
            catch (Exception e)
            {
                throw new LevelSaveException(e);
            }
        }
    }
}