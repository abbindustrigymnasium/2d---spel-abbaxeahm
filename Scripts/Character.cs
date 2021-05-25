using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;
    public LayerMask WhatIsGround; // which layer is conssidered ground
    public Transform GroundCheck; // the point to count as bottom of character 
    public GameObject TreePlant;
    GameObject[] trees; // all trees i the scene
    treeplant treeplant;
    public static bool MarketClosed = true; // market ui is closed
    public int jumpSpeed = 20;
    public int speed = 10;
    float verticalInput = 0f;
    float direction = 1f;
    float GroundedRadius = .4f;
    int count = 0;
    int treeType;
    int chopTimer = 0;
    bool isChopingTree = false;
    bool isFallingTree = false;
    public static int chopingTime = 100; // how long time it takes to chop a tree
    int fallTime = 128;
    int staticFallTime = 128;
    bool chop = false;
    bool Grounded = true;
    bool doPlant = true;
    Vector3 distance;
    Vector3 scale;
    Vector3 pos;
    Vector3 staticPos;
    void Start()
    {
        treeplant = GameObject.Find("Spawner").GetComponent<treeplant>();
    }
    void Update()
    {

        if (MarketClosed) // if market is closed then you can controll the character
        {
            Grounded = isGrounded();
            scale = transform.localScale;
            verticalInput = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("xSpeed", Mathf.Abs(verticalInput));
            animator.SetFloat("ySpeed", rigidBody.velocity.y);
            rigidBody.velocity = new Vector2(verticalInput * speed, rigidBody.velocity.y); // set the x-velocity of the character

            if (verticalInput > 0) scale.x = 5; // change which way character sprite is facing 
            if (verticalInput < 0) scale.x = -5;

            if (Input.GetMouseButtonDown(0)) // start choping
            {
                animator.SetBool("chop", true); // start chop animation
                chop = true;
            }
            if (Input.GetMouseButtonUp(0)) // stop choping
            {
                animator.SetBool("chop", false);
                chop = false;
            }
            if (chop && !isFallingTree) ChopingPlantingTree(0); // is not called when tree is falling

            if (Grounded)
            {
                animator.SetBool("air", false);
            }
            else
            {
                animator.SetBool("air", true);
            }
            if (Input.GetButtonDown("Jump") && Grounded)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed); // set y-velocity to jumpSpeed when jump
            }
            if (Input.GetMouseButtonDown(1) && !isFallingTree && Grounded && market.plant > 0)
            {
                ChopingPlantingTree(1); // check if character can plant
                if (doPlant)
                {
                    pos = transform.localPosition + new Vector3(0, 1.9f, 0); // 1.9 units under character 
                    Instantiate(TreePlant, pos, Quaternion.identity); // spawn tree
                    market.plant--;
                    GameObject.Find("Market").GetComponent<market>().UpdateInventory(); // update inventory
                }
                else
                {
                    doPlant = true;
                }
            }
            transform.localScale = scale; // update scale
        }

    }
    void ChopingPlantingTree(int Planting) // check if character can chop / plant tree
    {
        trees = GameObject.FindGameObjectsWithTag("tree"); // update trees
        if (trees.Length + Planting > 1) // only chop if more then 2 trees exist and plant if more then 1 trees exist
        {
            count = 0; // keep track of which tree is being checked
            pos = transform.localPosition;
            foreach (GameObject treesObj in trees)
            {
                distance = (treesObj.transform.localPosition - pos) * scale.x / 5; // units away from tree (negativ if tree is behind character)
                if (Mathf.Abs(distance.x) < 3 && Planting == 1) // if tree is less than 3 units away, don't plant. 
                {
                    doPlant = false;
                }
                else if (distance.x < 3 && distance.x > 0 && Planting == 0) // if character is close to tree then start choping
                {
                    treeType = count; // save which tree to chop
                    isChopingTree = true;
                    staticPos = trees[treeType].transform.localPosition; // position of tree
                }
                count++;
            }
        }
        else
        {
            doPlant = true;
        }
    }
    void FixedUpdate()
    {
        if (isChopingTree) // if character curently is choping
        {
            chopTimer++;
            if (chopTimer == chopingTime) // after chopingTime of frames a tree will fall (axe: 100, saw: 50)
            {
                isFallingTree = true;
                chopTimer = 0;
                direction = scale.x / 5; // sets which direction the tree will fall in
            }
            isChopingTree = false;
        }
        if (isFallingTree) // the tree falling animation
        {
            if (fallTime % 16 == 0) // every 16th show 1 frame
            {
                trees[treeType].transform.position = new Vector3(staticPos.x + direction * Mathf.Cos(Mathf.PI * fallTime / staticFallTime / 2) * 3, staticPos.y - 3 + Mathf.Sin(Mathf.PI * fallTime / staticFallTime / 2) * 3, 0);
                trees[treeType].transform.rotation = Quaternion.Euler(0, 0, direction * (fallTime * 90 / staticFallTime - 90)); // rotate 1/8 of 90 every "frame"
                fallTime = fallTime - (staticFallTime - fallTime) / 8; // accelateration of motion
                if (fallTime <= 0) timber(trees[treeType].name);
            }
            fallTime--;
        }
    }
    void timber(string treeName)
    {
        chopingTime = 60;
        fallTime = staticFallTime;
        if (treeName == "Tree(Clone)")
        {   // green tree
            market.wood++;
        }
        else
        {   // yellow tree
            market.wood += 2;
        }
        isFallingTree = false;
        Destroy(trees[treeType]);
        GameObject.Find("Market").GetComponent<market>().UpdateInventory(); // update inventory

    }
    bool isGrounded() // check if GroundedRadius around GroundCheck is in terrain layer
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}