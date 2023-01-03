using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    
    
    public PlayerController m_playerController;

    [SerializeField]
    private float m_fGlideDefaultCoolTime;

    public float m_fGlideCoolTime;

    private float m_fGlideCoolTimeChecker;
    private float m_fLastGlideTime;

    private bool m_bCoolDown;

   public Button m_Button;

    private void Start()
    {
       // m_Button = GetComponent<Button>();
        m_fGlideCoolTime = m_fGlideDefaultCoolTime;
        m_fLastGlideTime = 0f;
        
    }

    private void Update()
    {
        CoolDownCheck();
       
       // GlidingCheck();
    }

    public void ClickAttackButton()
    {
        //var now= Time.time;
        
        //if(m_fGlideCoolTime>now-m_fLastGlideTime)
        //{
        //    Debug.Log("CoolTime");
        //    return;
        //}

        if(false==m_bCoolDown)
        {
            Debug.Log("CoolTime");
            return;
        }

        m_playerController.m_bGliding = true;
        m_bCoolDown = false;
        m_Button.interactable = false;
        
        Debug.Log("Click3");

       // m_fLastGlideTime = now;
    }

    
    private void CoolDownCheck()
    {

        if(false==m_bCoolDown)
        {
            m_fGlideCoolTimeChecker -= Time.deltaTime;

            if (m_fGlideCoolTimeChecker <= 0)
            {

                m_bCoolDown = true;
                m_fGlideCoolTimeChecker = m_fGlideCoolTime;
                m_Button.interactable = true;
            }
        }

    }



    private void GlidingCheck()
    {

        if (true == m_playerController.m_bGliding)
        {
            m_fGlideCoolTimeChecker -= Time.deltaTime;

            if (m_fGlideCoolTimeChecker <= 0)
            {
                m_playerController.m_bGliding = false;

                m_fGlideCoolTimeChecker = m_fGlideCoolTime;
            }
        }
    }
}
