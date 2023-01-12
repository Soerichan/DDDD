using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeapon : MonoBehaviour
{
    [SerializeField]
    private WeaponData m_weaponData;

    [SerializeField]
    private WeaponProjectile m_projectile;


    public float m_fDamage;

    
    public float m_fCoolTime;

  
    public float m_fRange;

  
    public float m_fHitBoxRange;

   
    public float m_fLevel;

    public float m_fDamageIncreasePerLevel;



    private void Start()
    {
        m_fDamage = m_weaponData.m_fDefaultDamage;
        m_fCoolTime = m_weaponData.m_fDefaultCoolTime;
        m_fRange = m_weaponData.m_fDefaultRange;
        m_fHitBoxRange = m_weaponData.m_fDefaultHitBoxRange;
        m_projectile.m_fProjectileSpeed = m_weaponData.m_fProjectileSpeed;

    }
    public void StartStage()
    {
        StartCoroutine(WeaponCoroutine());
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator WeaponCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_fCoolTime);
            WeaponInvoke();
        }
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this);
    }

    private void WeaponInvoke()
    {
        //오버랩스피어 해서 제일 가까운쪽에 쏜다
        //날아간다
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
