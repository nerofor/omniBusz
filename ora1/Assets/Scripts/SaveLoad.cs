using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad{

    public static Game savedGame = Game.current;

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.ekegame");
        Debug.Log(Application.persistentDataPath);
        bf.Serialize(file, savedGame);
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.ekegame"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.ekegame", FileMode.Open);
            savedGame = (Game)bf.Deserialize(file);
            file.Close();
        }
    }

}
