using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Text text;
    bool begin = true;
    void Update()
    {
        if (begin && Input.GetMouseButtonDown(0)) // makes titel disappear 
        {
            text.enabled = false;
            begin = false;
        }
    }
}
