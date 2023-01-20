using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
   public int m_value;

    StageManager m_stageManager;

    private void Awake()
    {
        m_stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    private void Update()
    {
       if(m_stageManager.m_bIsGameOver == true)
        {
            CookieManager.Instance.ClearCookie(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CookieManager.Instance.EatCookie(gameObject, m_value);
    }
}
