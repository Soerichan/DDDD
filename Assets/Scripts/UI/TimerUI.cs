using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private float m_fDefaultTime;

    private float m_fTime;

    private TextMeshProUGUI m_TextMeshPro;
    private bool m_bRunning;
    // Start is called before the first frame update
    void Start()
    {
        m_fTime = m_fDefaultTime;
        
     
       
        m_bRunning = false;
       // StageStart();
    }

 

    public void StageStart()
    {
        m_TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (m_TextMeshPro != null)
        {
            Debug.Log("NULL이 아니다");
        }
        m_fTime = m_fDefaultTime;
        StartCoroutine(TimerCoroutine());
        m_bRunning=true;
        m_TextMeshPro.text = "90";
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            m_fTime--;
          
            m_TextMeshPro.text=m_fTime.ToString();
        }
    }

    public void StageEnd()
    {
        StopCoroutine(TimerCoroutine());
        m_fTime = m_fDefaultTime;
        m_TextMeshPro.text = m_fTime.ToString();
        m_bRunning = false;
    }

}
