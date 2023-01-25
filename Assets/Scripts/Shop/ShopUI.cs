using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private ShopManager m_shopManager;

    private void OnEnable()
    {
        m_shopManager.Rerole();
        CookieManager.Instance.PlusCookie(10);
    }
}
