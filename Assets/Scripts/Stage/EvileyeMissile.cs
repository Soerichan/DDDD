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
        StartCoroutine(LifeSpanCorutine());
    }

    // Update is called once per frame

    void Update()
    {
        transform.Translate(ToPlayerDir * m_fMoveSpeed * Time.deltaTime, Space.World);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        var that = other.gameObject.tag;

        if(that != null)
        {
           
            if (that=="Player")
            {
                stageManager.m_player.Damaged(m_fDamage);
               
            }
        }
    }

    private IEnumerator LifeSpanCorutine()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);    
    }
}
