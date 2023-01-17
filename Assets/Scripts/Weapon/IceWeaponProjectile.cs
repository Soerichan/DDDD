using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeaponProjectile : WeaponProjectile
{
  
   public Monster m_target;

   private float m_fSlowPer=0.1f;


    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private void Update()
    {
        transform.Translate(m_direction * m_fSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(m_fLifeSpan);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        m_target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_fHitRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            m_target = colliders[i].GetComponent<Monster>();
            m_target.Damaged(m_fDamage * m_fLevel);
            m_target.Slowed(m_fSlowPer * m_fLevel);
        }
    }
}
