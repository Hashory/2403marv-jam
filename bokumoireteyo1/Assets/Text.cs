using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using 
public class Text : MonoBehaviour
{
    [SerializeField]
    Text ScenarioMessage;

    public Text guiText;

    public GameObject a;
    private Text b;

    Scenario currentScenario;
    int index = 0;
    public List<string> Texts;

    // Start is called before the first frame update
    public void Start()
    {

        Scenario scenario = new Scenario(StageManager.StageNumber);
        
        DisplayText(scenario);
    }

    private void DisplayText(Scenario sc)
    {
        foreach (var index in sc.Conversation)
        {
            Debug.Log(index);
            //guiText.GetComponent<Text>().text = index;
            b = a.GetComponent<Text>();
            b.Texts = index.text;

            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGUI()
    {
        float CenterX = Screen.width / 2;
        float CenterY = Screen.height / 2;
    }

}
