using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using Newtonsoft.Json;
using System.IO;

public class LevelGeneratorSystem : Singleton<LevelGeneratorSystem>
{

    //0=pill,1=wall,2=player,3=ghost
    public BaseGridObject[] BaseGridObjectPrefabs;
    private GameObject levelObj;

    //public static int[,] Grid = new int[,] 
    //{
    //    {1,1,1,1,1,1,1,1,1,1 }, //y=0
    //    {1,0,1,0,0,0,1,3,0,1 }, //y=-1
    //    {1,0,2,0,1,0,0,0,1,1 }, //y=-2
    //    {1,0,1,0,0,0,0,0,0,1 },
    //    {1,0,1,0,1,0,1,1,0,1 },
    //    {1,0,0,0,0,0,0,3,0,1 },
    //    {1,1,1,1,1,1,1,1,1,1 }
    //};

    public static LevelPack CurrentLevel => currentLevel;
    private static LevelPack currentLevel;
    private List<LevelPack> levelList;


    //Instantiate/Generate our level

    private void Awake()
    {
        //var level = AppDataSystem.Load<T>(fileName);
        //var fullFilePath = $"{Application.dataPath}/Hackman/StreamingAssets/Level_1.json";
        //var obj = File.ReadAllText(fullFilePath);
        //var grid = JsonConvert.DeserializeObject<int[,]>(obj);

        levelList = AppDataSystem.LoadAll<LevelPack>();

        AnotherLevel();
    }

    //[ContextMenu("Log Grid")]
    //public void LogGrid()
    //{
    //    var obj = JsonConvert.SerializeObject(Grid); //give an object, return a string
    //    Debug.Log(obj);
    //}

    //[ContextMenu("Save Level")]
    //public void SaveLevel()
    //{
    //    var obj = JsonConvert.SerializeObject(Grid);

    public void AnotherLevel()
    {
        LevelEnd();

        while(true)
        {
            var currentLevelindex = Random.Range(0, levelList.Count);

            if (currentLevel != null && currentLevel == levelList[currentLevelindex]) continue;
            currentLevel = levelList[currentLevelindex];
            break;
        }

        LogLevel(currentLevel);
    }

    //===========//
    public void LevelEnd()
    {
        if (!levelObj)
        {
            levelObj = new GameObject("[GRID]");
        }

        if (levelObj.transform.childCount == 0) return;

        for (var i = 0; i < levelObj.transform.childCount; i++)
        {
            Destroy(levelObj.transform.GetChild(i).gameObject);
        }
    }

    public void LogLevel(LevelPack levelsToGenerate)
    {

        var gridSizeY = levelsToGenerate.Grid.GetLength(0); //行
        var gridSizeX = levelsToGenerate.Grid.GetLength(1); //列
        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                //This seems counter-intuitive
                //Normally with "math," x comes first, then y...
                var objectType = levelsToGenerate.Grid[y, x]; //从第一行开始，所以y
                var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.transform.parent = levelObj.transform;
                gridObjectClone.GridPosition = new IntVector2(x, -y); //如果y不为负，方向就会颠倒
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y);

            }
        }
    }


        

    //    if (!File.Exists(fullFilePath))
    //    {
    //        var filestream = File.Create(fullFilePath);
    //        filestream.Close();
    //    }

    //    File.WriteAllText(fullFilePath, obj);

    //    Debug.Log(obj);
    //}

    //[ContextMenu("Log Enemies")]
    //public void LogEnemies()
    //{
    //    //var enemies = new List<ExampleEnemy>()
    //    //{
    //    //    new ExampleEnemy(){HP=20};
    //    //    new ExampleEnemy() { HP = 10 };
    //    //};

    //    //var obj = JsonConvert.SerializeObject(Grid); //give an object, return a string
    //    //Debug.Log(obj);
    //}
}
