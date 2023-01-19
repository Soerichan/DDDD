using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieManager : Singleton<CookieManager>
{
    [SerializeField]
    private GameObject[] cookiePrefabs;

    private int m_iCookieWallet;

    private PoolManager m_poolManager;

    Vector3 m_pos01 = new Vector3(-1, 1, 0);
    Vector3 m_pos02 = new Vector3(-0, 1, 0);
    Vector3 m_pos03 = new Vector3(+1, 1, 0);
    Vector3 m_pos04 = new Vector3(0, 1, -1);
    Vector3 m_pos05 = new Vector3(0, 1, 0);
    Vector3 m_pos06 = new Vector3(0, 1, 1);
    Vector3 m_pos07 = new Vector3(-1, 1, 0);
    Vector3 m_pos08 = new Vector3(-1, 1, 0);
    Vector3 m_pos09 = new Vector3(-1, 1, 0);
    Vector3 m_pos010 = new Vector3(-1, 1, 0);
    Vector3 m_pos011 = new Vector3(-1, 1, 0);
    Vector3 m_pos012 = new Vector3(-1, 1, 0);
    private void Start()
    {
        m_iCookieWallet = 0;
        m_poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
    }

    public void DropCookie(int exp,Vector3 pos)
    {
        int cookie_625=0;
        int cookie_125=0;
        int cookie_25=0;
        int cookie_5=0;
        int cookie_1=0;

        while(exp>=625)
        {
            cookie_625++;
            exp -= 625;
        }
        while (exp >= 125)
        {
            cookie_125++;
            exp -= 125;
        }
        while (exp >= 25)
        {
            cookie_25++;
            exp -= 25;
        }
        while (exp >=5)
        {
            cookie_5++;
            exp -= 5;
        }
        while (exp >= 1)
        {
            cookie_1++;
            exp -= 1;
        }


        for(int i= cookie_625; i!=0 ;i--)
        {
           
        }
        for (int i = cookie_125; i != 0; i--)
        {

        }
        for (int i = cookie_25; i != 0; i--)
        {

        }
        for (int i = cookie_5; i != 0; i--)
        {

        }
        for (int i = cookie_1; i != 0; i--)
        {

        }
        GameObject instance = m_poolManager.Get(cookiePrefabs[0]);
     
        instance.transform.position = pos;
        instance.transform.rotation = Quaternion.identity;
    }

    public void EatCookie(GameObject cookie, int exp)
    {
        PlusCookie(exp);
        m_poolManager.Release(cookie);
    }


    public void PlusCookie(int cookie)
    {
        m_iCookieWallet += cookie;
    }

    public void MinusCookie(int cookie)
    {
        m_iCookieWallet -= cookie;
    }

   

}
