using I2.Loc.SimpleJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

namespace GrimeRandomizer
{
    internal class SaveDataItem
    {
        private static string dataDirPath = Application.persistentDataPath;

        private static string dataFileName = "DataItemSave.json";

        public SaveDataItem(string dataDirPath, string dataFileName)
        {
            SaveDataItem.dataDirPath = dataDirPath;
            SaveDataItem.dataFileName = dataFileName;
        }

        public static void Save(Data_Item data, string ID)
        {
            string json = JsonUtility.ToJson(data);
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

        public static Data_Item Load(string ID)
        {
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

                    Data_Item data = Data_Item.CreateInstance<Data_Item>();
                    JsonUtility.FromJsonOverwrite(json, data);
                    data.SetDirty();
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
                return null;
            }
        }

        public static void Delete(Data_Item data, string ID)
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
