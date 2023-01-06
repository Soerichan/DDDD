using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{

   public enum RoomType { None,Room_RampageGuys, Room_Anvil, Room_HumanWave, Room_SturdyHunks, Room_Danger, Room_Cookie, Room_BOSS };
    public PlayerController m_player;
    public float m_playerNowHP;
    public Vector3 PlayerPosition;

    public bool m_bIsGameOver;

    private void Awake()
    {
        RoomType room=RoomType.None;
        m_player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }


}
