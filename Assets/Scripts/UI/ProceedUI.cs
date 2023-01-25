using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedUI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_shopUI;

    public void GameProceed()
    {
        //SceneManager.LoadScene("Scenes/GameScene");
        m_shopUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
