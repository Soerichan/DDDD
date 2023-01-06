using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    protected float m_fMoveSpeed;
    [SerializeField]
    protected float m_fHP;
    [SerializeField]
    protected float m_fExp;
    [SerializeField]
    protected float m_fAttackDamage;
    [SerializeField]
    protected float m_fAttackCoolTime;

    [SerializeField]
    protected float m_fAttackRange;

    [SerializeField]
    protected float m_fAttackingTime;
    [SerializeField]
    protected float m_fAttackingTimeChecker;

    [SerializeField]
    protected float m_fLastAttackTime;

    [SerializeField]
    protected float m_fCorpseTime=1f;
    [SerializeField]
    protected float m_fDistanceToPlayer;
    [SerializeField]
    protected bool m_bIsDie;
    [SerializeField]
    protected bool m_bIsAttack;
    [SerializeField]
    protected bool m_bIsMove;
    

    protected Animator m_animator;
    //[SerializeField]
    private StageManager stageManager;
    // protected Vector2 m_playerPosition;

    protected Vector3 ToPlayerDir;

    protected virtual void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        //Debug.Log("GET");
        m_animator= gameObject.GetComponentInChildren<Animator>();    
    }

    protected virtual void Update()
    {
        if (m_bIsAttack == false)
        {
            ChasePlayer();

            AttackPlayer();

        }
        else
        {
            m_fAttackingTimeChecker -= Time.deltaTime;

            if(m_fAttackingTimeChecker <= 0)
            {
                m_bIsAttack = false;

                m_fAttackingTimeChecker = m_fAttackingTime;

                m_animator.SetTrigger("EndAttack");
            }
        }

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

            ToPlayerDir = (stageManager.PlayerPosition - transform.position).normalized;
            transform.forward = ToPlayerDir;
            transform.Translate(ToPlayerDir * m_fMoveSpeed * Time.deltaTime, Space.World);
            m_animator.SetBool("Move", true);


            //Debug.Log(ToPlayerDir);
            
        }
        else
        {
            m_animator.SetBool("Move", false);
            AttackPlayer();
            Debug.Log("局快旷");
        }
    }

    protected virtual void AttackPlayer()
    {
        //  var now = Time.time;

        //  if(m_fAttackCoolTime>m_fLastAttackTime-now)
        // {
        //      return;
        //  }
        if (m_fDistanceToPlayer <= m_fAttackRange)
        {
            m_bIsAttack = true;
            m_animator.SetTrigger("Attack");
            stageManager.m_player.Damaged(m_fAttackDamage);
        }


    }

    protected void Die()
    {
        m_animator.SetTrigger("Die");
    }


}
