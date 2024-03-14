using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    // [SerializeField]
    private Text guiText;

    Scenario currentScenario;

    // Start is called before the first frame update
    public void Start()
    {

        Scenario scenario = new Scenario(StageManager.StageNumber);
        
        guiText = GameObject.Find("guiText").GetComponent<Text>();
        DisplayText(scenario);
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
        
    }
    public void OnGUI()
    {
        float CenterX = Screen.width / 2;
        float CenterY = Screen.height / 2;
    }

}
