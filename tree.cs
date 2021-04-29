using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    movment movment;
    Vector3 distance;
    Vector3 pos;
    Vector3 staticPos;
    //Vector3 Rotation;
    bool isFallingTree = false;
    public int chopingTime = 60;
    int fallTime = 128;

    // Start is called before the first frame update
    void Start()
    {
        movment = GameObject.FindGameObjectWithTag("Player").GetComponent<movment>();
        staticPos = transform.localPosition;
        
    }
    public Vector3 GetVector3(){
        pos = transform.localPosition;
        return pos;
    } 
    public void SendPos(){
        distance = movment.distance;
        Debug.Log(distance);
        if(distance.x > 0 && distance.x < 2 && !isFallingTree){
            chopingTime--;
            Debug.Log(chopingTime);
            if(chopingTime == 0){
                isFallingTree = true;
                Debug.Log("chopchop");
            }
        }
    }

    void timber() {
        isFallingTree = false;
        chopingTime = 60;
        fallTime = 128;
        Debug.Log("bruh");
        movment.SendWood();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (isFallingTree) {
            Debug.Log("timber");
                if (fallTime % 16 == 0){
                Debug.Log(pos);
                pos = new Vector3(staticPos.x + Mathf.Cos(Mathf.PI*fallTime/256)*3,staticPos.y - 3 + Mathf.Sin(Mathf.PI*fallTime/256)*3,0);
                transform.rotation = Quaternion.Euler(0,0,fallTime*90/128-90);
                transform.position = pos;
                fallTime = fallTime - (128-fallTime)/8; 
                    if(fallTime < 0){
                        timber();
                    }
                }
        fallTime--;
        }
    }
}
