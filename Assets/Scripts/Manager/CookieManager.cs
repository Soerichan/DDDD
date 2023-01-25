using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieManager : Singleton<CookieManager>
{
    [SerializeField]
    private GameObject[] cookiePrefabs;

    private int m_iCookieWallet;

    private PoolManager m_poolManager;
    public CookieUI m_cookieUI;

    private Vector3[] m_ArrayCookiePosOffset=new Vector3[31];

    private void Awake()
    {
        m_iCookieWallet = 0;
        m_poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
       // m_cookieUI = GameObject.Find("CookieUI").GetComponent<CookieUI>();

        for (int a = 1; a < 31; a += 6)
        {
            m_ArrayCookiePosOffset[a] = new Vector3(0, 1, 1 * a);
            m_ArrayCookiePosOffset[a + 1] = new Vector3(-0.87f * a, 1, -0.5f * a);
            m_ArrayCookiePosOffset[a + 2] = new Vector3(-0.87f * a, 1, -0.5f * a);

            m_ArrayCookiePosOffset[a + 3] = new Vector3(0, 1, -1 * a);
            m_ArrayCookiePosOffset[a + 4] = new Vector3(0.5f * a, 1, -0.87f * a);
            m_ArrayCookiePosOffset[a + 5] = new Vector3(0.5f * a, 1, 0.87f * a);


        }
    }

    private void Start()
    {
       
    }

    public void WakeUp()
    {
        int hello = 0;
        hello += 1;
    }

    public void DropCookie(int exp,Vector3 pos)
    {
        int cookie_625=0;
        int cookie_125=0;
        int cookie_25=0;
        int cookie_5=0;
        int cookie_1=0;

        Vector3[] dropPos = new Vector3[30];
        

        int cookieCount = 1;

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

       
           for (int i = 0; i < cookie_625; i++)
           {
            GameObject instanceCookie = m_poolManager.Get("Cookie_625");

            dropPos[cookieCount] = pos + m_ArrayCookiePosOffset[cookieCount];
            instanceCookie.transform.position = dropPos[cookieCount];
            instanceCookie.transform.rotation = Quaternion.identity;
            cookieCount++;
           }

           for (int i = 0; i < cookie_125; i++)
           {
            GameObject instanceCookie = m_poolManager.Get("Cookie_125");

            dropPos[cookieCount] = pos + m_ArrayCookiePosOffset[cookieCount];
            instanceCookie.transform.position = dropPos[cookieCount];
            instanceCookie.transform.rotation = Quaternion.identity;
            cookieCount++;
           }

           for (int i = 0; i < cookie_25; i++)
           {
            GameObject instanceCookie = m_poolManager.Get("Cookie_25");

            dropPos[cookieCount] = pos + m_ArrayCookiePosOffset[cookieCount];
            instanceCookie.transform.position = dropPos[cookieCount];
            instanceCookie.transform.rotation = Quaternion.identity;
            cookieCount++;
           }

           for (int i = 0; i < cookie_5; i++)
           {
            GameObject instanceCookie = m_poolManager.Get("Cookie_5");

            dropPos[cookieCount] = pos + m_ArrayCookiePosOffset[cookieCount];
            instanceCookie.transform.position = dropPos[cookieCount];
            instanceCookie.transform.rotation = Quaternion.identity;
            cookieCount++;
           }

           for (int i = 0; i < cookie_1; i++)
           {
            GameObject instanceCookie = m_poolManager.Get("Cookie_1");

            dropPos[cookieCount] = pos + m_ArrayCookiePosOffset[cookieCount];
            instanceCookie.transform.position = dropPos[cookieCount];
            instanceCookie.transform.rotation = Quaternion.identity;
            cookieCount++;
           }
        

       
    }

    public void EatCookie(GameObject cookie, int exp)
    {
        PlusCookie(exp);
        m_poolManager.Release(cookie);
    }


    public void PlusCookie(int cookie)
    {
        m_iCookieWallet += cookie;
        m_cookieUI.SetCookie(m_iCookieWallet);
    }

    public void MinusCookie(int cookie)
    {
        m_iCookieWallet -= cookie;
        m_cookieUI.SetCookie(m_iCookieWallet);
    }

    public void ClearCookie(GameObject cookie)
    {
        m_poolManager.Release(cookie);
    }

    public int GetHowManyCookie()
    {
        return m_iCookieWallet;
    }
}
