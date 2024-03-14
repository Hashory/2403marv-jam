using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManage : MonoBehaviour
{
    public void GameStart()
    {
        FadeManager.Instance.LoadScene("Stageselect", 0.7f);
    }
}
