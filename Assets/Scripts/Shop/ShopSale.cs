using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSale : MonoBehaviour
{
    [SerializeField]
    private ShopManager m_shopManager;
    private Button m_button;
    [SerializeField]
    private UnityEngine.UI.Image[] m_icon;
    private WeaponData m_weaponData;
    private TextMeshProUGUI[] m_text;
    // Start is called before the first frame update
    void Start()
    {
        m_text= GetComponentsInChildren<TextMeshProUGUI>();
        m_icon=GetComponentsInChildren<UnityEngine.UI.Image>();
        m_button=GetComponentInChildren<Button>();
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
        //m_button.interactable = true;
        //m_icon[2].sprite = m_weaponData.m_image;
        m_text[0].text = m_weaponData.m_described;
        m_text[1].text = m_weaponData.m_iDefaultCost.ToString();
    }

    public void ClickToBuy(WeaponData m_weponData)
    {
        if (CookieManager.Instance.GetHowManyCookie() < m_weaponData.m_iCost)
        {
            return;
        }

        m_shopManager.Buy(m_weponData);
        m_button.interactable = false;
    }
}
