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
            Debug.Log("»Ð");
            StartCoroutine(AttackCorutine());
        }

    }

    private void CreateMissile()
    {
        Vector3 MissileStartPosition = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        EvileyeMissile instance = Instantiate(m_missile, MissileStartPosition, Quaternion.identity);
        instance.ToPlayerDir = ToPlayerDir;
        Debug.Log("½¹");
       
       


    }
}

