using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager: MonoBehaviour
{
    public static int StageArea;
    public static int StageNumber;

    [SerializeField] private Button[] _stageButton;

    public void SelectStage(int stage)
    {
        StageNumber = stage;
        Debug.Log(stage);
        SceneManager.LoadScene("conversation");
    }
}
