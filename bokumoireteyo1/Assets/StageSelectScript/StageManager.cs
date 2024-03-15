using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager: MonoBehaviour
{
    public static int StageNumber;
   

    public void SelectStage(int stage)
    {
        StageNumber = stage;
        Debug.Log(StageNumber);
        FadeManager.Instance.LoadScene("Conversation", 0.5f);
    }

    public void BackTitle()
    {
        FadeManager.Instance.LoadScene("mainMenu", 0.5f);
    }
}
