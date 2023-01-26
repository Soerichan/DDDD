using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWeapon : Weapon
{
    public float m_fDamage;


    public float m_fCoolTime;


    public float m_fRange;


    public float m_fHitBoxRange;

    public float m_fSpeed;



    public float m_fDamageIncreasePerLevel;

    public Monster m_target;

    public Vector3 m_targetDirection;



    [SerializeField]
    public GameObject m_GFX;


    //public WeaponProjectile m_projetcile;

    private void Start()
    {

      


        m_fDamage = m_weaponData.m_fDefaultDamage;
        m_fCoolTime = m_weaponData.m_fDefaultCoolTime;
        m_fRange = m_weaponData.m_fDefaultRange;

        //m_fHitBoxRange   = m_weaponData.m_fDefaultSearchRange;


    }
    public override void StartStage()
    {

        if (m_fLevel > 0)
        {
            m_GFX.SetActive(true);
            StartCoroutine(WeaponCoroutine());
           
        }



    }


    public override void EndStage()
    {
        StopAllCoroutines();

    }

    private IEnumerator WeaponCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_fCoolTime);
            WeaponInvoke();

        }
    }



    private void WeaponInvoke()
    {
        
            WeaponMechanism();
        
    }

    private void WeaponMechanism()
    {
        LayerMask mask = LayerMask.GetMask("Monster");



        m_target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, mask);

        for (int i = 0; i < colliders.Length; i++)
        {

            m_target = colliders[i].GetComponent<Monster>();

            if (null != m_target)
            {

                m_target.Damaged(m_fDamage * m_fLevel);

            }
        }


    }
}
