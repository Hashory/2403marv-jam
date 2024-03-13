using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGo : MonoBehaviour
{
    // Start is called before the first frame update
    public void plus()
    {
        Transform camera = GameObject.Find("MainCamera").transform;

        Vector3 pos = camera.position;
        pos.x = pos.x + 20f;

        camera.position = pos;   
    }
    public void minus()
    {
        Transform camera = GameObject.Find("MainCamera").transform;

        Vector3 pos = camera.position;
        pos.x = pos.x - 20f;

        camera.position = pos;

    }
}
