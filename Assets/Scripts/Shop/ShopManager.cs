using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    [SerializeField]
    private ShopUI m_shopUI;
    [SerializeField]
    private ShopSale[] m_shopsales;
    [SerializeField]
    private ShopInventory m_inventory;
    [SerializeField]
    private WeaponData[] m_weaponDatas;
    [SerializeField]
    public int m_iReroleCost=10;

 

    public void Buy(WeaponData weaponData)
    {
        Debug.Log("πŸ¿Ã");
        m_inventory.Add(weaponData);
        CookieManager.Instance.MinusCookie(weaponData.m_iDefaultCost);
    }

    public void Rerole()
    {
        int Count = m_weaponDatas.Length;
        int Random01 = Random.Range(0, Count);
        int Random02 = Random.Range(0, Count);
        int Random03 = Random.Range(0, Count);

        m_shopsales[0].SetSale(m_weaponDatas[Random01]);
        m_shopsales[1].SetSale(m_weaponDatas[Random02]);
        m_shopsales[2].SetSale(m_weaponDatas[Random03]);

        m_shopsales[0].SaleRefresh();
        m_shopsales[1].SaleRefresh();
        m_shopsales[2].SaleRefresh();

        CookieManager.Instance.MinusCookie(m_iReroleCost);
    }
    
}
