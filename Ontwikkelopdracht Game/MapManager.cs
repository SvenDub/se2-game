using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Ontwikkelopdracht_Game.Entity;

namespace Ontwikkelopdracht_Game
{
    public class MapManager
    {
        public static void Export(List<GameObject> gameObjects, string filename)
        {
            try
            {
                // Serialize to json
                string json = JsonConvert.SerializeObject(gameObjects, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto
                });

                // Save to file
                //Directory.CreateDirectory(filename.Substring(0, filename.LastIndexOf('\\')));
                File.WriteAllText(filename, json);
            }
            catch (Exception e)
            {
                throw new LevelSaveException(e);
            }
        }

        public static List<GameObject> Import(string filename)
        {
            try
            {
                // Read from file
                string json = File.ReadAllText(filename);

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
    }
}