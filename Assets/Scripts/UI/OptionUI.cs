using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class OptionUI : MonoBehaviour
{
    private bool m_bfolded;
    private bool m_bfolding;
    private Animator m_animator;
    public GameObject m_shopButton;
    public GameObject m_musicButton;
    private float m_fFoldTime;

    private void Start()
    {
        m_fFoldTime = 0.25f;
        m_bfolded = true;
        m_bfolding = false;
        m_animator = GetComponent<Animator>();
       // m_shopButton = GetComponent<GameObject>();
       // m_musicButton = GetComponent<GameObject>();
        m_musicButton.SetActive(false);
        m_shopButton.SetActive(false);
    }

    private void Update()
    {
        if(true==m_bfolding)
        {
            m_fFoldTime-=Time.deltaTime;

            if(m_fFoldTime < 0)
            {
                m_bfolded = true;
                m_bfolding =false;
                m_musicButton.SetActive(false);
                m_shopButton.SetActive(false);
                m_fFoldTime = 0.25f;
            }
        }
    }


    public void OptionButtonClick()
    {
        if(true==m_bfolded)
        {
            Unfold();
        }
        else
        {
            Fold();
        }
    }


    public void Unfold()
    {
        m_animator.SetTrigger("unfold");
        m_musicButton.SetActive(true);
        m_shopButton.SetActive(true);
        m_bfolded=false;
        Debug.Log("click");
    }

   public void Fold()
    {
        m_animator.SetTrigger("fold");
        m_bfolding = true;
        Debug.Log("click2");
    }

    
   
}
