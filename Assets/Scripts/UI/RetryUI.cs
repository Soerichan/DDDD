using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryUI : MonoBehaviour
{
    public void GameRetry()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }
}
