using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movment : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;
    GameObject[] trees;
    treeplant treeplant;
    public Text text;
    public int jumpForce = 20;
    public int jumpCount = 30;
    public int speed = 10;
    float verticalInput = 0f;
    int jumpCounter = 0;
    int wood = 0;
    int count = 0;
    int treeType = 0;
    bool isFallingTree = false;
    public int chopingTime = 60;
    int fallTime = 128;
    bool jump = false; 
    bool chop = false;
    public Vector3 distance;
    Vector3 scale;
    Vector3 pos;
    Vector3 staticPos;
    // Start is called before the first frame update
    void Start()
    {
        treeplant = GameObject.Find("Spawner").GetComponent<treeplant>();
    }

    // Update is called once per framef
    void Update()
    {   
        scale = transform.localScale;
        verticalInput = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
        animator.SetFloat("xSpeed",Mathf.Abs(verticalInput));
        animator.SetFloat("ySpeed",rigidBody.velocity.y);

        if (verticalInput > 0) {
            scale.x = 5;
        }
        if ( verticalInput < 0) {
            scale.x = -5;
        }
        if (Input.GetMouseButtonDown(0)){
            animator.SetBool("chop",true);
            chop = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            animator.SetBool("chop",false);
            chop = false;
        }
        if (chop) {
            pos = transform.localPosition;
            foreach (GameObject treesObj in trees)
            {   
                distance = (treesObj.transform.localPosition-pos)*scale.x/5;
                Debug.Log(distance);
                if(distance.x < 3 && distance.x > 0 && !isFallingTree ) {
                    Debug.Log(distance.x);
                    treeType = count;
                    isFallingTree = true;
                    staticPos = trees[treeType].transform.localPosition;
                }
                count++;
            }
            
            count = 0;
        }
        rigidBody.velocity = new Vector2(verticalInput*speed, rigidBody.velocity.y);
        transform.localScale = scale;
        if(jump){
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpForce);
            jumpCounter = jumpCount;
        }
        if(jumpCounter > 0){
            jumpCounter--;
            animator.SetInteger("jumpCounter", jumpCounter);
        }

        if(Input.GetMouseButtonDown(1)){
            pos = transform.localPosition;
            treeplant.PlantTree(pos);
            trees = GameObject.FindGameObjectsWithTag("tree");
        } 
    
    }
    public void SendWood(){
        wood++;
        text.text = "wood:" + wood;
    }
        void FixedUpdate()
    {
       if (isFallingTree) {
            Debug.Log("timber");
                if (fallTime % 16 == 0){
                Debug.Log(pos);
                pos = new Vector3(staticPos.x + Mathf.Cos(Mathf.PI*fallTime/256)*3,staticPos.y - 3 + Mathf.Sin(Mathf.PI*fallTime/256)*3,0);
                trees[treeType].transform.rotation = Quaternion.Euler(0,0,fallTime*90/128-90);
                trees[treeType].transform.position = pos;
                fallTime = fallTime - (128-fallTime)/8; 
                    if(fallTime < 0){
                        timber();
                        
                    }
                }
        fallTime--;
        }
    }
        void timber() {
        isFallingTree = false;
        chopingTime = 60;
        fallTime = 128;
        Debug.Log("bruh");
        trees = GameObject.FindGameObjectsWithTag("tree");
        Destroy(trees[treeType]);
        SendWood();
    }
}

