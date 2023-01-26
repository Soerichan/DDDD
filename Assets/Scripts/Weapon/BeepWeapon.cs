using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepWeapon : Weapon
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

        //오버랩스피어 해서 제일 가까운쪽에 쏜다
        //날아간다


        m_target = null;
        LayerMask mask = LayerMask.GetMask("Monster");
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_fRange, mask);

        if (m_fLevel < 3)
        {
            if (colliders.Length > 0)
            {
                m_target = colliders[0].GetComponent<Monster>();
            }

            if (null != m_target)
            {

                WeaponMechanism();

            }
        }
        else if (m_fLevel >= 3 && m_fLevel < 9)
        {

            for (int a = 0; a < colliders.Length && a < 3; a++)
            {

                if (colliders[a] != null)
                {
                    if (colliders.Length > 0)
                    {

                        m_target = colliders[a].GetComponent<Monster>();

                    }

                    if (null != m_target)
                    {
                        WeaponMechanism();
                    }
                }
            }




        }
        else if (m_fLevel >= 6)
        {

            for (int a = 0; a < colliders.Length && a < 12; a++)
            {
                if (colliders[a] != null)
                {

                    if (colliders.Length > 0)
                    {

                        m_target = colliders[a].GetComponent<Monster>();

                    }

                    if (null != m_target)
                    {
                        WeaponMechanism();
                    }
                }
            }



        }



    }

    private void WeaponMechanism()
    {
        Vector3 offsetPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        WeaponProjectile instance = Instantiate(m_projectile, offsetPosition, Quaternion.identity);
        m_targetDirection = (m_target.transform.position - instance.transform.position).normalized;
        m_targetDirection.y = 0;
        instance.m_direction = m_targetDirection;
        instance.m_fLevel = m_fLevel;
        instance.m_fSpeed = m_weaponData.m_fProjectileSpeed;
        instance.m_fHitRange = m_weaponData.m_fProjectileHitRange;
        instance.m_fDamage = m_weaponData.m_fDefaultDamage;


    }
}
