using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Weapon/Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    public string m_name;
    [SerializeField]
    public Sprite m_image;
    [SerializeField]
    public string m_described;
    [SerializeField]
    public int m_iDefaultCost;
    public int m_iCost;

    [SerializeField]
    public float m_fDefaultDamage;

    [SerializeField]
    public float m_fDefaultCoolTime;

    [SerializeField]
    public float m_fDefaultRange;

    [SerializeField]
    public float m_fDefaultSearchRange;

 

    [SerializeField]
    public float m_fProjectileSpeed;
    [SerializeField]
    public float m_fProjectileHitRange;


}
