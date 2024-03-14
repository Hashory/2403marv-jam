using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvaterMiddle: MonoBehaviour
{
    int Avater1;
    private Image m_Image;
    public Sprite[] Avat_Sprite1;

    // Start is called before the first frame update
    void Start()
    {
        Scenario scenario = new Scenario(StageManager.StageNumber);
        m_Image = gameObject.AddComponent<Image>();
        DisplayAvater(scenario);
    }

    private void DisplayAvater(Scenario sc)
    {
        Avater1 = sc.AvatarId[1];
        m_Image.sprite = Avat_Sprite1[Avater1];
    }
}