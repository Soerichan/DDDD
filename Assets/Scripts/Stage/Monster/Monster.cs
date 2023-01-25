using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public float m_fMoveSpeed;
    [SerializeField]
    public float m_fHP;
    [SerializeField]
    public int m_iExp;
    [SerializeField]
    public float m_fAttackDamage;
    [SerializeField]
    public float m_fAttackCoolTime;

    [SerializeField]
    public float m_fAttackRange;

    [SerializeField]
    public float m_fAttackingTime;
    [SerializeField]
    public float m_fAttackingTimeChecker;

    [SerializeField]
    public float m_fLastAttackTime;

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


    protected float m_fNowSpeed;
    protected float m_fNowHP;
    protected Animator m_animator;
 
    protected StageManager m_stageManager;
    protected PoolManager m_poolmanager;
   

    protected Vector3 ToPlayerDir;
    protected Vector3 ToKnockBack;

    protected virtual void Start()
    {
        m_stageManager      = GameObject.Find("StageManager").GetComponent<StageManager>();
        m_poolmanager       = GameObject.Find("PoolManager").GetComponent<PoolManager>();
       
        m_animator          = gameObject.GetComponentInChildren<Animator>();
        m_fNowHP            = m_fHP;
        m_fNowSpeed         = m_fMoveSpeed;
    }

    protected virtual void Update()
    {
        if (m_bIsAttack == false)
        {
            ChasePlayer();

            AttackPlayer();

            
        }
 

        if(m_fNowHP <= 0||m_stageManager.m_bIsGameOver==true)
        {
             Die();
          
        }
    }

    protected void ChasePlayer()
    {
        m_fDistanceToPlayer = Vector3.Distance(transform.position, m_stageManager.PlayerPosition);

   
        if (m_fDistanceToPlayer > m_fAttackRange)
        {

            ToPlayerDir = (m_stageManager.PlayerPosition - transform.position).normalized;
            transform.forward = ToPlayerDir;
            transform.Translate(ToPlayerDir * m_fNowSpeed * Time.deltaTime, Space.World);
            m_animator.SetBool("Move", true);


      
        }
        else
        {
            m_animator.SetBool("Move", false);
         
        }
    }

    protected virtual void AttackPlayer()
    {
     
        if (m_fDistanceToPlayer <= m_fAttackRange)
        {
            m_bIsAttack = true;
            m_animator.SetTrigger("Attack");
            m_stageManager.m_player.Damaged(m_fAttackDamage);
            Coroutine co1= StartCoroutine(AttackCorutine());
        }


    }

    protected void Die()
    {
        m_animator.SetTrigger("Die");
        DropCookie();
        m_poolmanager.Release(this.gameObject);
        m_fNowHP = m_fHP;
        m_fNowSpeed = m_fMoveSpeed;

    }

    protected void DropCookie()
    {

       
        CookieManager.Instance.DropCookie(m_iExp,transform.position);
       
    }

    protected IEnumerator AttackCorutine()
    {
        yield return new WaitForSeconds(m_fAttackingTime);

        m_bIsAttack = false;

    

        m_animator.SetTrigger("EndAttack");
    }

    public void Damaged(float Damage)
    {
        m_fNowHP-=Damage;
    }

    public void Slowed(float SlowPer)
    {
        m_fNowSpeed = m_fNowSpeed * SlowPer;
        Coroutine co2=StartCoroutine(SlowIsEnd());
    }

    private IEnumerator SlowIsEnd()
    {
        yield return new WaitForSeconds(4f);
        m_fNowSpeed = m_fMoveSpeed;
    }

    public void KnockBacked(float knockback,Vector3 pos)
    {
        Coroutine co3 = StartCoroutine(KnockBacking(knockback, pos));
        Coroutine co4 = StartCoroutine(KnockBackEnd());
    }

    private IEnumerator KnockBacking(float knockback, Vector3 pos)
    {
        while(true)
        {
            ToKnockBack = (m_stageManager.PlayerPosition - transform.position).normalized;
            transform.forward = ToKnockBack;
            transform.Translate(-knockback * ToKnockBack * m_fNowSpeed * Time.deltaTime, Space.World);
        }
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator KnockBackEnd()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
