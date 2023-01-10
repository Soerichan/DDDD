using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Evileye : Monster
{
    [SerializeField]
    private EvileyeMissile m_missile;
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
            m_animator.SetTrigger("Attack");
            CreateMissile();
        }
    }

    private void CreateMissile()
    {
       // EvileyeMissile instance = Instantiate(transform.position, Quaternion.identity);
      //  m_missile.ToPlayerDir = ToPlayerDir;
       
       


    }
}

