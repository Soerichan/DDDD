using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
   public int m_value;

   
    
    private void OnTriggerEnter(Collider other)
    {
        CookieManager.Instance.EatCookie(gameObject, m_value);
    }
}
