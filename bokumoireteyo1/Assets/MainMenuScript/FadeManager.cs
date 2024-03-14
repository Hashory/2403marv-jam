using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static bool isFadeinstance = false;

    public bool isFadeOut = false;
    public bool isFadeIn = false;

    public float alpha = 0.0f;
    public float fadeSpeed = 0.2f;

    void Start()
    {
        if (!isFadeinstance)
        {
            DontDestroyOnLoad(this);
            isFadeinstance = true;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (isFadeIn)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            if (alpha <= 0.0f)
            {
                isFadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (isFadeOut)
        {
            alpha += Time.deltaTime / fadeSpeed;
            if (alpha >= 1.0f)
            {
                isFadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    public void fadeIn()
    {
        isFadeIn = true;
        isFadeOut = false;
    }

    public void fadeOut()
    {
        isFadeOut = true;
        isFadeIn = false;
    }
}