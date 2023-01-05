using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    protected float m_fMoveSpeed;
    protected float m_fHP;
    protected float m_fExp;

    protected float m_fAttackDamage;
    protected float m_fAttackCoolTime;

    [SerializeField]
    protected float m_fAttackRange;

    [SerializeField]
    protected float m_fAttackingTime;

    [SerializeField]
    protected float m_fLastAttackTime;

    [SerializeField]
    protected float m_fCorpseTime;

    protected float m_fDistanceToPlayer;

    protected bool m_bIsDie;
    protected bool m_bIsAttack;
    protected bool m_bIsMove;
    

    protected Animator m_animator;
    private StageManager stageManager;
   // protected Vector2 m_playerPosition;


    protected virtual void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        m_animator= gameObject.GetComponentInChildren<Animator>();    
    }

    protected virtual void Update()
    {
        ChasePlayer();

        AttackPlayer();

        if(m_fHP<=0)
        {
             Die();
            Debug.Log("局坷克");
        }
    }

    protected void ChasePlayer()
    {
        m_fDistanceToPlayer = Vector3.Distance(transform.position, stageManager.PlayerPosition);

       // Debug.Log(transform.position);
      //  Debug.Log(stageManager.PlayerPosition);
       // Debug.Log(m_fDistanceToPlayer);
        if (m_fDistanceToPlayer > m_fAttackRange)
        {
            Vector3 ToPlayerDir = (stageManager.PlayerPosition - transform.position).normalized;
            transform.forward = ToPlayerDir;
            transform.Translate(ToPlayerDir * m_fMoveSpeed * Time.deltaTime);
            m_animator.SetBool("Move", true);
            Debug.Log(ToPlayerDir);
        }
        else
        {
            m_animator.SetBool("Move", false);
            AttackPlayer();
            Debug.Log("局快旷");
        }
    }

    protected void AttackPlayer()
    {
        var now = Time.time;

        if(m_fAttackCoolTime>m_fLastAttackTime-now)
        {
            return;
        }

        m_animator.SetTrigger("Attack");
        stageManager.m_player.Damaged(m_fAttackDamage);


    }

    protected void Die()
    {
        m_animator.SetTrigger("Die");
    }


}
