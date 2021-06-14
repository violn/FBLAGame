using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static Dictionary<string, int> scoreKeeper = new Dictionary<string, int>();
    public static Dictionary<int, int> recordsKeeper = new Dictionary<int, int>();

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");
        ScoreData data = new ScoreData
        {
            savedScores = scoreKeeper,
            highScores = recordsKeeper
        };

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat");
            ScoreData data = (ScoreData)bf.Deserialize(file);
            file.Close();

            scoreKeeper = data.savedScores;
            recordsKeeper = data.highScores;
        }
    }
}

[Serializable]
internal class ScoreData
{
    public Dictionary<string, int> savedScores;
    public Dictionary<int, int> highScores;
}
