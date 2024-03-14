using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    // [SerializeField]
    private Text guiText;
    private Text buttonText;

    Scenario currentScenario;
    private int ScenarioIndex = 0;

    // Start is called before the first frame update
    public void Start()
    {

        currentScenario = new Scenario(StageManager.StageNumber);
        
        guiText = GameObject.Find("guiText").GetComponent<Text>();
       
    }

    private void DisplayText(Scenario sc)
    {
        foreach (var index in sc.Conversation)
        {
            guiText.text = index.Text;
            
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if(ScenarioIndex < currentScenario.Conversation.Count)
            {
                guiText.text = currentScenario.Conversation[ScenarioIndex].Text;
                ScenarioIndex++;
            } 
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    return;
                }
                // length over

                Transform Tr = transform.Find("CanvasChoice");
                GameObject.Find("CanvasChoice").SetActive(true);
              
                Text[] ChoiceButton = Tr.GetComponentsInChildren<Text>();
                for (int i=0; i < ChoiceButton.Length; i++) 
                {
                    ChoiceButton[i].text = currentScenario.Choices[i].Text;
                    
                }
            }
            
        }


    }

}
