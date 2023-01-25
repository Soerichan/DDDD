using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSale : MonoBehaviour
{
    [SerializeField]
    private ShopManager m_shopManager;
    [SerializeField]
    private Button m_button;
    [SerializeField]
    private Image m_icon;
    private WeaponData m_weaponData;
    [SerializeField]
    private TextMeshProUGUI[] m_text;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void SaleRerole()
    {
        m_button.interactable=true;
    }

    public void SetSale(WeaponData weaponData)
    {
        m_weaponData= weaponData;
    }

    public void SaleRefresh()
    {
       
        m_button.interactable = m_button.interactable ? true : true;
        m_icon.sprite = m_weaponData.m_image;
        m_text[0].text = m_weaponData.m_described;
        m_text[1].text = m_weaponData.m_iDefaultCost.ToString();
    }

    public void ClickToBuy()
    {
        if (CookieManager.Instance.GetHowManyCookie() < m_weaponData.m_iCost)
        {
            Debug.Log("돈모자람");
            return;
        }

        Debug.Log("클릭투바이");
        m_shopManager.Buy(m_weaponData);
        m_button.interactable = false;
    }
}
