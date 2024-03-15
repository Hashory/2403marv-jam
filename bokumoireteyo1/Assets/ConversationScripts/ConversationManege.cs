using System;
using System.Net;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    Scenario currentScenario;
    private int ScenarioIndex = 0;
    private bool IsConversationScenarioEndFlag = false;
    private bool resultFlag = false;
    private bool isCorrect = false;
    private bool isTyping = false;
    private string inputText = "";
    private IEnumerator typeTextFunc;
    private bool Isfirst = true;
    AudioSource audioSource;

    // インスペクタから設定
    public Text NameText;
    public Text dialogText;
    public GameObject ChoiceParent;
    public GameObject Choice0Button;
    public GameObject Choice1Button;
    public GameObject Choice2Button;
    public Text choice0Text;
    public Text choice1Text; 
    public Text choice2Text;
    public GameObject AvaterLeft;
    public GameObject AvaterMiddle;
    public GameObject AvaterRight;
    public Material avaterOverrayMaterial; 
    public Material defaultMaterial;
    public GameObject Bg;
    public GameObject MissionComplete;
    public GameObject MissionFailed;
    public AudioClip click;
    public GameObject BGM1;
    public GameObject BGM2;
    public GameObject BGM3;
    public GameObject BGM4;
    public GameObject BGM5;
    public GameObject BGM6;
    public GameObject BGM7;


    public string playerName;

    // インスペクタから設定 - 配列
    public Sprite[] Bgs;
    public Sprite[] Avaters;
    public string[] Names;

    // 任意の設定
    public float typingSpeed = 0.5f;

    // Start is called before the first frame update
    public void Start()
    {
        // シナリオを読み込む
        currentScenario = new Scenario(StageManager.StageNumber);

        // 背景を表示
        Bg.GetComponent<Image>().sprite = Bgs[currentScenario.BgId];

        // キャラクターを表示
        AvaterLeft.GetComponent<Image>().sprite = Avaters[currentScenario.AvatarId[0] + 1];
        AvaterMiddle.GetComponent<Image>().sprite = Avaters[currentScenario.AvatarId[1] + 1];
        AvaterRight.GetComponent<Image>().sprite = Avaters[currentScenario.AvatarId[2] + 1];

        //音を鳴らすための取得
        audioSource = GetComponent<AudioSource>();

        //bgm
        switch (currentScenario.BgId)
        {
            case 1:
                BGM1.SetActive(true);
                break;
            case 2:
                BGM2.SetActive(true);
                break;
            case 3:
                BGM3.SetActive(true);
                break;
            case 4:
                BGM4.SetActive(true);
                break;
            case 5:
                BGM5.SetActive(true);
                break;
            case 6:
                BGM6.SetActive(true);
                break;
            case 7:
                BGM7.SetActive(true);
                break;
            default:
                break;
        }

        Next();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Next();
        }
    }

    /// <summary>
    /// シナリオを次に進める、選択肢を選ばせる。ユーザーへステップを提供します
    /// </summary>
    private void Next()
    {
        if(isTyping)
        {
            // 会話をスキップ
            dialogText.text = inputText;
            StopCoroutine(typeTextFunc);
            isTyping = false;
            return;
        }

        if (!IsConversationScenarioEndFlag)
        {
            if (ScenarioIndex < currentScenario.Conversation.Count)
            {
                if (!Isfirst)
                {
                    //音を鳴らす
                    audioSource.PlayOneShot(click);
                }else{
                    Isfirst = false;
                }
                // 会話を表示
                NameText.text = Names[currentScenario.Conversation[ScenarioIndex].AvatarId];
                // dialogText.text = currentScenario.Conversation[ScenarioIndex].Text;
                typeTextFunc = TypeText();
                inputText = currentScenario.Conversation[ScenarioIndex].Text;
                StartCoroutine(typeTextFunc);

                // キャラクターをフォーカス
                var avaters = new[] { AvaterLeft, AvaterMiddle, AvaterRight };
                for (var i = 0; i < 3; i++)
                {
                    if (currentScenario.AvatarId[i] == currentScenario.Conversation[ScenarioIndex].AvatarId)
                    {
                        avaters[i].GetComponent<Image>().material = defaultMaterial;
                    }
                    else
                    {
                        avaters[i].GetComponent<Image>().material = avaterOverrayMaterial;
                    }
                }

                // シナリオのインデックスを進める
                ScenarioIndex++;
            }
            else
            {
                // length over
                Debug.Log("View Choice");
                // 選択肢を表示
                ChoiceParent.SetActive(true);
                choice0Text.text = currentScenario.Choices[0].Text;
                choice1Text.text = currentScenario.Choices[1].Text;
                choice2Text.text = currentScenario.Choices[2].Text;

                // ボタンを有効化
                var button0 = Choice0Button.GetComponent<Button>();
                button0.onClick.AddListener(() => OnClickChoice(0));

                var button1 = Choice1Button.GetComponent<Button>();
                button1.onClick.AddListener(() => OnClickChoice(1));

                var button2 = Choice2Button.GetComponent<Button>();
                button2.onClick.AddListener(() => OnClickChoice(2));

                // シナリオの処理の無効か (画面全体クリック)
                IsConversationScenarioEndFlag = true;
            }
        }

        if(resultFlag)
        {
            if (isCorrect)
            {
                MissionComplete.SetActive(true);
            }
            else
            {
                MissionFailed.SetActive(true);
            }
        }
    }

    /// <summary>
    /// 選択肢をクリックしたときの処理
    /// </summary>
    /// <param name="clickIdx">クリックしたボタンのインデックス</param>
    public void OnClickChoice(int clickIdx)
    {
        Debug.Log("Choice: " + clickIdx);

        // 選択肢を非表示
        ChoiceParent.SetActive(false);

        NameText.text = playerName;
        inputText = currentScenario.Choices[clickIdx].Text;
        StartCoroutine(TypeText());

        if (currentScenario.Choices[clickIdx].Correct)
        {
            Debug.Log("Answer: Correct");
            isCorrect = true;
        }
        else
        {
            Debug.Log("Answer: Wrong");
            isCorrect = false;
        }

        resultFlag = true;
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in inputText.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

}
