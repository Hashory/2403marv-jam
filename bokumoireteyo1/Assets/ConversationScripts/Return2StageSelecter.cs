using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Return2StageSelecter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // TODO: ステージセレクターに戻る。
        // UnityEngine.SceneManagement.SceneManager.LoadScene("StageSelecter");
    }
}
