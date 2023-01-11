using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Slider m_slider;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();
    }
    public void SetMaxHPBar(float MaxHP)
    {
        m_slider.maxValue = MaxHP;
        m_slider.value = MaxHP;
    }

    public void SetHPBar(float HP)
    {
        m_slider.value = HP;
    }
}
