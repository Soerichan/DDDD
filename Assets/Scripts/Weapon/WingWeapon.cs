using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingWeapon :Weapon
{
    public float m_fDamage;


    public float m_fCoolTime;


    public float m_fRange;


    public float m_fHitBoxRange;

    public float m_fSpeed;



    public float m_fDamageIncreasePerLevel;

    public Monster m_target;

    public Vector3 m_targetDirection;

    private PlayerController m_playerController;

    [SerializeField]
    public GameObject m_GFX;


    //public WeaponProjectile m_projetcile;

    private void Start()
    {

        m_playerController = GetComponentInParent<PlayerController>();


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
            m_playerController.m_fGlideSpeed = m_playerController.m_fGlideDefaultSpeed * (1f + m_fLevel);
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
       if(m_playerController.m_bGliding==true)
        {
            WeaponMechanism();
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
