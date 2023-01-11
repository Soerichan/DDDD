using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : Monster
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
       
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

    protected override void AttackPlayer()
    {
        if (m_fDistanceToPlayer <= m_fAttackRange)
        {
            m_bIsAttack = true;
            m_animator.SetTrigger("PreAttack");
            //m_stageManager.m_player.Damaged(m_fAttackDamage);
            
            StartCoroutine(ChargeCorutine());
        }
    }

    
    

    private IEnumerator ChargeCorutine()
    {
        yield return new WaitForSeconds(1);
        
        StartCoroutine(ChargeEndCorutine());
        m_animator.SetTrigger("Attack");
        while (true)
        {
            transform.Translate(ToPlayerDir * m_fMoveSpeed * 3f * Time.deltaTime, Space.World);
        }

    }

    private IEnumerator ChargeEndCorutine()
    {
       
        yield return new WaitForSeconds(1);

        m_animator.SetTrigger("EndAttack");
        StopCoroutine(ChargeCorutine());
        m_bIsAttack=false;

    }


    private void OnTriggerEnter(Collider other)
    {
        var that = other.gameObject.tag;

        if (that != null)
        {

            if (that == "Player")
            {
                m_stageManager.m_player.Damaged(m_fAttackDamage);

            }
        }
    }
}

