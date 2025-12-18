using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using static GrimeRandomizer.ItemPool;
using Newtonsoft.Json;

namespace GrimeRandomizer
{
    internal class SaveRandomState
    {
        private static string dataDirPath = Application.persistentDataPath;

        private static string dataFileName = "RandomStateSave.json";

        public SaveRandomState(string dataDirPath, string dataFileName)
        {
            SaveRandomState.dataDirPath = dataDirPath;
            SaveRandomState.dataFileName = dataFileName;
        }

        public static void Save(Dictionary<ItemCoord, ItemDefinition> data, string ID)
        {
            string json = JsonConvert.SerializeObject(data);
            string savePath = Path.Combine(dataDirPath, ID, dataFileName);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    writer.WriteLine(json);
                }
            }
            catch (Exception e)
            {
                GrimeRandomizer.Log.LogInfo("Error occured when trying to save data to file: " + savePath + "\n" + e);
            }
        }

        public static Dictionary<ItemCoord, ItemDefinition> Load(string ID)
        {
            Dictionary<ItemCoord, ItemDefinition> data = null;
            string savePath = Path.Combine(dataDirPath, ID, dataFileName);
            if (File.Exists(savePath))
            {
                try
                {
                    string json = string.Empty;

                    using (StreamReader reader = new StreamReader(savePath))
                    {
                        json = reader.ReadToEnd();
                    }

                    GrimeRandomizer.Patches.itemsRandomized = true;
                    GrimeRandomizer.Log.LogInfo("Loaded Randomizer State");
                    data = JsonConvert.DeserializeObject<Dictionary<ItemCoord, ItemDefinition>>(json);
                    return data;
                }
                catch (Exception e)
                {
                    GrimeRandomizer.Log.LogInfo("Error occured when trying to load data from file: " + savePath + "\n" + e);
                    return null;
                }
            }

            else
            {
                GrimeRandomizer.Log.LogInfo("No save files found");
                GrimeRandomizer.Patches.itemsRandomized = false;
                Dictionary<ItemCoord, ItemDefinition> initDictionary = new Dictionary<ItemCoord, ItemDefinition>();
                return initDictionary;
            }
        }

        public static void Delete(string ID)
        {
            string savePath = Path.Combine(dataDirPath, ID, dataFileName);
            try
            {
                File.Delete(savePath);
            }
            catch (Exception e)
            {
                GrimeRandomizer.Log.LogInfo("Error occured when trying to delete file: " + savePath + "\n" + e);
            }
        }
    }
}
