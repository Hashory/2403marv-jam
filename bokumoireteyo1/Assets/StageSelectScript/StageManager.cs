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
        SceneManager.LoadScene("conversation");
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
