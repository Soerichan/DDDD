using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingWeaponProjectile :WeaponProjectile
{
    public Monster m_target;

    


    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

 

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

        LayerMask mask = LayerMask.GetMask("Monster");



        m_target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_fHitRange, mask);

        for (int i = 0; i < colliders.Length; i++)
        {

            m_target = colliders[i].GetComponent<Monster>();

            if (null != m_target)
            {

                m_target.Damaged(m_fDamage * m_fLevel);
                
            }
        }
        Destroy(gameObject);

    }

}
