using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    private bool m_bfolded;
    private Animator m_animator;
    private GameObject m_shopButton;
    private GameObject m_musicButton;

    private void Start()
    {
        m_bfolded = true;
        m_animator = GetComponent<Animator>();
        m_shopButton = GetComponent<GameObject>();
        m_musicButton = GetComponent<GameObject>();
    }

    
    public void OptionButtonClick()
    {
        if(m_bfolded)
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
        m_animator.SetBool("bFolded", false);
        m_musicButton.SetActive(true);
        m_shopButton.SetActive(true);
    }

   public void Fold()
    {
        m_animator.SetBool("bFolded", true);
        m_musicButton.SetActive(false);
        m_shopButton.SetActive(false);
    }

}
