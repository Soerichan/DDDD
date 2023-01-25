using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopProceed : MonoBehaviour
{
    [SerializeField]
    private GameObject m_mapUI;

    [SerializeField]
    private GameObject m_shopUI;

    public void GameProceed()
    {
        
        m_mapUI.SetActive(true);
        m_shopUI.SetActive(false);
    }
}
