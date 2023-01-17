using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponData m_weaponData;

    [SerializeField]
    protected WeaponProjectile m_projectile;

   
    public float m_fLevel=0;

    public virtual void  StartStage()
    {

    }

}
