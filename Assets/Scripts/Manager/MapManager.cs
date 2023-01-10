using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RoomType { None, Room_RampageGuys, Room_Anvil, Room_HumanWave, Room_SturdyHunks, Room_Danger, Room_Cookie, Room_BOSS };

public class MapManager : Singleton<MapManager>
{
    public static RoomType NowRoom = RoomType.None;

    private void Awake()
    {
        var obj = FindObjectsOfType<MapManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

     
    }

   



}
