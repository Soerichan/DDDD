using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_RabbitRed :Monster
{
    [SerializeField]
    private float m_fRabbitMoveSpeed;

    [SerializeField]
    private float m_fRabbitHP;

    [SerializeField]
    private float m_fRabbitExp;

    [SerializeField]
    private float m_fRabbitAttackDamage;

    [SerializeField]
    private float m_fRabbitAttackCoolTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_fMoveSpeed = m_fRabbitMoveSpeed;
        Debug.Log(m_fHP);
        m_fHP = m_fRabbitHP;
        Debug.Log(m_fHP);
        m_fExp = m_fRabbitExp;
        m_fAttackDamage = m_fRabbitAttackDamage;
        m_fAttackCoolTime = m_fRabbitAttackCoolTime;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Debug.Log("Áö±Ý Åä³¢"+transform.position);
    }
}
