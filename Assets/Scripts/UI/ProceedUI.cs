using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedUI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_mapUI;

    public void GameProceed()
    {
        //SceneManager.LoadScene("Scenes/GameScene");
        m_mapUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
