using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    [SerializeField]
    private ShopInventoryUnit[] m_inventoryUnits;
    [SerializeField]
    private ShopManager m_shopManager;



    public void Add(WeaponData weaponData)
    {
        for(int i=0;i<m_inventoryUnits.Length;i++)
        {
            if (m_inventoryUnits[i]!=null)
            {
                m_inventoryUnits[i].Add(weaponData);
            }
        }
    }
}
