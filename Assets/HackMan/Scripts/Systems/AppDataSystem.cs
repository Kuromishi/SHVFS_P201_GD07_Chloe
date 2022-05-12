using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using Newtonsoft.Json;
using System.IO;

public class AppDataSystem
{
    //This system will have generic methods to serialize and deserialize almost any kind of data we want, except...
    //Monobehaviours, GameObjects, prefabs, etc...
    //However, almost everything is ok: built in types, your own POCO

    //This system needs TWO generic methods

    //One method to save object of ANY type
    //Needs to check if a DIRECTORY exists, and if not... create it automatically!
    //Each TYPE of T that you try to save, should be in its own directory...
    //Needs to check if a FILE exists, and if not...create it automatically!
    //Needs to save the file, with the serialized object
    //public static Save<T>...

    //For example using Save will look like this...
    //AppDataSystem.Save(obj, fileName);

    //One method to load objects of any type
    //public static Load<T>
    //Needs to load and return the requested object, if the file exists...
    //Needs to load and return a default object, if the file doesn't exist (perhaps it should call Save if not)
    
    //For example using load will look like this...
    //var level = AppDataSystem.Load<LevelGrid>(fileName);

    //HW
    //Finish Save and Load for AppDataSystem
    //Make 10 different levels 
    //LevelGenerator should pick a random level from the 10
    //BONUS POINTS -> Create a LoadAll method in the AppDataSystem
    //When the game is run, won, or lost, user should see a UI message telling them what happened, and have a button to click to play/play another level
    //Give me 4 features to add to your games (powerup etc...)
    

    public static void Save<T>(T obj, string filename)
    {
        var directoryPath = $"{Application.dataPath}/Hackman/StreamingAssets/" + typeof(T).Name;
        var fullFilePath = directoryPath + "/" + filename + ".json";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (!File.Exists(fullFilePath))
        {
            var filestream = File.Create(fullFilePath);
            filestream.Close();
        }

        var serializedData = JsonConvert.SerializeObject(obj);
        File.WriteAllText(fullFilePath, serializedData);
    }

    public static T Load<T>(string fileName)
    {
        var fullFilePath = $"{Application.dataPath}/StreamingAssets/{typeof(T).Name}/{fileName}.json";

        if (!File.Exists(fullFilePath))
        {
            T defaultObject = default;
            Save(defaultObject, fileName);
        }

        var serializedData = File.ReadAllText(fullFilePath);
        var data = JsonConvert.DeserializeObject<T>(serializedData);
        return data;
    }

    public static List<T> LoadAll<T>()
    {
        var directoryPath = $"{Application.dataPath}/StreamingAssets/" + typeof(T).Name;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            return new List<T>();
        }

        var fullfilePaths = Directory.GetFiles(directoryPath, "*.json");

        var fileDataList = new List<T>();

        foreach (var fullfilePath in fullfilePaths)
        {
            var serializedData = File.ReadAllText(fullfilePath);
            var data = JsonConvert.DeserializeObject<T>(serializedData);

            if (!fileDataList.Contains(data))
            {
                fileDataList.Add(data);
            }
        }

        return fileDataList;
    }

}
