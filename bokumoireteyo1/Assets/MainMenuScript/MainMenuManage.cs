using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManage : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
