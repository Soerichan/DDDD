using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvileyeMissile : MonoBehaviour
{
    public Vector3 ToPlayerDir;
    private float m_LifeSpan = 5f;
    private float m_fMoveSpeed = 25f;
    private float m_fDamage = 10f;
    private StageManager stageManager;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    // Update is called once per frame

    void Update()
    {
        transform.Translate(ToPlayerDir * m_fMoveSpeed * Time.deltaTime, Space.World);

        m_LifeSpan-=Time.deltaTime;



        if(m_LifeSpan<=0)
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var that = collision.gameObject.tag;

        if(that != null)
        {
            if(that=="Player")
            {
                stageManager.m_player.Damaged(m_fDamage);
            }
        }
    }
}
