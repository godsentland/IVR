using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public bool key1;

    public PlayerData(FirstPersonController FPC)
    {
        position = new float[3];
        position[0] = FPC.transform.position.x;
        position[1] = FPC.transform.position.y;
        position[2] = FPC.transform.position.z;
        key1 = FPC.key1;
    }
}

