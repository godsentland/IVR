using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

//не использованный скрипт

[System.Serializable]
public static class SaveLoadManager 
{
   public static void SavePlayer(FirstPersonController FPC)
    {
        BinaryFormatter BF = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        PlayerData data = new PlayerData(FPC);

        BF.Serialize(stream, data);
        stream.Close();
    }

    public static void SavePlayerAR(FirstPersonController FPC)
    {
        BinaryFormatter BF = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        PlayerData data = new PlayerData(FPC);
        //data.position[0] = Convert.ToSingle(-0.21);
        //data.position[1] = Convert.ToSingle(1.66);
        data.position[2] += Convert.ToSingle(3);

        BF.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadPlayer()
    {
        string filePath = Application.persistentDataPath + "/player.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            PlayerData data = BF.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + filePath);
            return null;
        }
    }
}
