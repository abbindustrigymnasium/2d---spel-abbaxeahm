using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<Camera>().orthographicSize + Input.mouseScrollDelta.y > 0)
            GetComponent<Camera>().orthographicSize += Input.mouseScrollDelta.y; // zooming with mouse wheel
    }
}
