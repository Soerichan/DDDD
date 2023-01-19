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
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¥Í¿Ω");
        LayerMask mask = LayerMask.GetMask("Monster");

       
           
            m_target = null;
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_fHitRange, mask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Debug.Log("∆˜πÆø°±Ó¡¯ µÈæÓ∞¨¿Ω");
                m_target = colliders[i].GetComponent<Monster>();

                if (null != m_target)
                {
                    Debug.Log("≈∏∞Ÿ¿Ã ≥Œ¿Ã æ∆¥‘");
                    m_target.Damaged(m_fDamage * m_fLevel);
                    m_target.Slowed(m_fSlowPer * m_fLevel);
                }
            }
            Destroy(gameObject);
        
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_fHitRange);
    }

}
