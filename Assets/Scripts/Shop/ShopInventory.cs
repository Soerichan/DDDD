using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    [SerializeField]
    private ShopInventoryUnit[] m_inventoryUnits;
    [SerializeField]
    private ShopManager m_shopManager;
  
    [SerializeField]
    private PlayerController m_playerController;


    public void Add(WeaponData weaponData)
    {
        
        for (int i=0;i<m_inventoryUnits.Length;i++)
        {
           
            if (m_inventoryUnits[i].m_weaponData==weaponData)
            {
                m_inventoryUnits[i].Add(weaponData);
                AddSub(weaponData);
                return;
                
            }
           
        }
        for (int i = 0; i < m_inventoryUnits.Length; i++)
        {
            
            if (m_inventoryUnits[i].m_weaponData == null)
            {
               
                m_inventoryUnits[i].Add(weaponData);
                AddSub(weaponData);
                return;
            }
        }
        
    }

    private void AddSub(WeaponData weaponData)
    {
        for (int j = 0; j < m_playerController.m_AllWeapon.Count; j++)
        {
            if (m_playerController.m_AllWeapon[j].m_weaponData == weaponData)
            {
                
                m_playerController.m_AllWeapon[j].m_fLevel++;
            }
        }
    }

 
}
