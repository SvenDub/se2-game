using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Ontwikkelopdracht_Game.Entity;

namespace Ontwikkelopdracht_Game.Database.File
{
    public class MapRepository : IRepository<List<GameObject>, string>
    {
        public string Path { get; set; } = "Levels";

        public MapRepository()
        {
            Directory.CreateDirectory(Path);
        }

        public void Dispose()
        {
        }

        public IEnumerable<string> List()
        {
            return Directory.EnumerateFiles(Path, "*.lvl").Select(System.IO.Path.GetFileNameWithoutExtension);
        }

        public void Delete(string id)
        {
            System.IO.File.Delete(PathForId(id));
        }
        
        public bool Exists(string id)
        {
            return System.IO.File.Exists(PathForId(id));
        }

        public List<GameObject> FindOne(string id)
        {
            try
            {
                // Read from file
                string json = System.IO.File.ReadAllText(PathForId(id));

                // Deserialize from json
                List<GameObject> gameObjects = JsonConvert.DeserializeObject<List<GameObject>>(json, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                });

                return gameObjects;
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
                // Serialize to json
                string json = JsonConvert.SerializeObject(entity, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                });

                // Save to file
                Directory.CreateDirectory(Path);
                System.IO.File.WriteAllText(PathForId(id), json);

                return entity;
            }
            catch (Exception e)
            {
                throw new LevelSaveException(e);
            }
        }

        private string PathForId(string id) => Path + System.IO.Path.DirectorySeparatorChar + id + ".lvl";
    }
}