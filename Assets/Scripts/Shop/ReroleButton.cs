using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReroleButton : MonoBehaviour
{
    
    private Button m_button;
    [SerializeField]
    private ShopSale[] m_shopSales;
    [SerializeField]
    private ShopManager m_shopManager;
    private TextMeshProUGUI m_cost;

    // Start is called before the first frame update
    void Start()
    {
        m_button=GetComponentInChildren<Button>();
        m_cost= GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
  
    public void ClickReroleButton()
    {
        if(CookieManager.Instance.GetHowManyCookie()<m_shopManager.m_iReroleCost)
        {
            return;
        }

        m_shopManager.Rerole();
    }
}
