using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgChanger : MonoBehaviour
{
    private Image m_Image;
    public Sprite[] m_Sprite;
    int bgid;
    int Avater;
    // Start is called before the first frame update
    void Start()
    {
        Scenario scenario = new Scenario(StageManager.StageNumber);
        m_Image = gameObject.GetComponent<Image>();
        DisplayBackGround(scenario);
    }

    private void DisplayBackGround(Scenario sc)
    {
        bgid = sc.BgId;
        bgid = bgid - 1;
        m_Image.sprite = m_Sprite[bgid];
        Debug.Log("bg" + bgid);
    }
}
