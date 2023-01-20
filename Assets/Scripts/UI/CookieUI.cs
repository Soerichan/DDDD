using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookieUI : MonoBehaviour
{

    private TextMeshProUGUI m_TextMeshPro;
    // Start is called before the first frame update
    private void Start()
    {
        m_TextMeshPro = GetComponentInChildren<TextMeshProUGUI> ();
        m_TextMeshPro.text = "0";
    }

    private void OnEnable()
    {
        CookieManager.Instance.m_cookieUI = this;
    }

    public void SetCookie(int cookie)
    {
        m_TextMeshPro.text = cookie.ToString();
    }
}
