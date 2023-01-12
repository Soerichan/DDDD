using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    public string m_name;

    [SerializeField]
    public string m_described;

    [SerializeField]
    public float m_fDefaultDamage;

    [SerializeField]
    public float m_fDefaultCoolTime;

    [SerializeField]
    public float m_fDefaultRange;

    [SerializeField]
    public float m_fDefaultHitBoxRange;

    [SerializeField]
    public float m_fLevel;

    [SerializeField]
    public float m_fProjectileSpeed;


}
