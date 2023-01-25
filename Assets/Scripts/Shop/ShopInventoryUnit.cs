using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class ShopInventoryUnit : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image[] m_icon;
    public WeaponData m_weaponData;
    private TextMeshProUGUI m_textMeshPro;
    private float m_fLevel=0;
    
    // Start is called before the first frame update
    void Start()
    {
        m_icon=GetComponentsInChildren<UnityEngine.UI.Image>();
        m_textMeshPro=GetComponentInChildren<TextMeshProUGUI>();
        m_textMeshPro.text = "";
    }

    public void Add(WeaponData weaponData)
    {

       
        m_weaponData = weaponData;
            m_icon[1].sprite=weaponData.m_image;      
            m_textMeshPro.text=m_fLevel.ToString();
            m_fLevel++;
            m_textMeshPro.text = m_fLevel.ToString();
        
    }


}
