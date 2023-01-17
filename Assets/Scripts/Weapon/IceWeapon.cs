using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeapon : Weapon
{
    


    public float m_fDamage;

    
    public float m_fCoolTime;

  
    public float m_fRange;

  
    public float m_fHitBoxRange;

    public float m_fSpeed;
   
    

    public float m_fDamageIncreasePerLevel;

    public Monster m_target;

    public Vector3 m_targetDirection;



    //public WeaponProjectile m_projetcile;

    private void Start()
    {
        m_fDamage        = m_weaponData.m_fDefaultDamage;   
        m_fCoolTime      = m_weaponData.m_fDefaultCoolTime;
        m_fRange         = m_weaponData.m_fDefaultRange;
       
        //m_fHitBoxRange   = m_weaponData.m_fDefaultSearchRange;
    

    }
    public override void StartStage()
    {
        m_fLevel = 1f;
        StartCoroutine(WeaponCoroutine());
        Debug.Log("스테이지스타트");

    }

    public void EndStage()
    {
        StopCoroutine(WeaponCoroutine());
        Debug.Log("엔드");
    }

    private IEnumerator WeaponCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_fCoolTime);
            WeaponInvoke();
            Debug.Log("코루틴");
        }
    }

   

    private void WeaponInvoke()
    {

        //오버랩스피어 해서 제일 가까운쪽에 쏜다
        //날아간다
        Debug.Log("인보크");
        m_target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_fRange);
       

        if (m_fLevel < 3)
        {
              m_target = colliders[0].GetComponent<Monster>();
            if (null != m_target)
            {
                WeaponMechanism();

            }
        }
        else if(m_fLevel >= 3&&m_fLevel<9)
        {
          
               for(int a=0;a<3;a++)
                {
                        m_target = colliders[a].GetComponent<Monster>();
                    if (null != m_target)
                    {
                        WeaponMechanism();
                    }
                }

            
          

        }
        else if(m_fLevel >=6)
        {
           
                for (int a = 0; a < 12; a++)
                {
                        m_target = colliders[a].GetComponent<Monster>();
                    if (null != m_target)
                    {
                        WeaponMechanism();
                    }
                }

            

        }



    }

    private void WeaponMechanism()
    {
        WeaponProjectile instance   = Instantiate(m_projectile, transform.position, Quaternion.identity);
        m_targetDirection           = (m_target.transform.position - instance.transform.position).normalized;
        instance.m_direction        = m_targetDirection;
        instance.m_fLevel           = m_fLevel;
        instance.m_fSpeed           = m_weaponData.m_fProjectileSpeed;
        instance.m_fHitRange        = m_weaponData.m_fProjectileHitRange;
        instance.m_fDamage          = m_weaponData.m_fDefaultDamage;
        Debug.Log("웨펀메커니즘");

    }
  


   
}
