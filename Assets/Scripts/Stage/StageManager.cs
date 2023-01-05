using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public PlayerController m_player;
    public float m_playerNowHP;
    public Vector3 PlayerPosition;

    public bool m_bIsGameOver;
    // Update is called once per frame
    void Update()
    {
       
    }


}
