using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    private bool leftFoot;
    private bool rightFoot;
    private float speedX;
    public float jumpSpeed;
    public bool isInGround;
    public int waitTime;
    public int deadFrameCount;
    Animator animator;
    Rigidbody2D player;
    public bool isComplete;
    public GameObject cempleteLevelUI;
    

    // Start is called before the first frame update
    void Start()
    {
        leftFoot = false;
        rightFoot = false;
        speedX = 2;
        jumpSpeed = 6f;
        isInGround = false;
        deadFrameCount = 60;
        isComplete = false;
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isComplete) {
            return;
        }
        // waittime
        if(waitTime > 0) {
            waitTime++;
            if(animator.GetBool("isJump") == true) {
                if(waitTime == 30) {
                    waitTime = 0;
                    animator.SetBool("isJump", false);
                }
                Debug.Log("Lompat");
            }
            if(animator.GetBool("isJatuh") == true) {                    
                if(waitTime == 300) {
                    waitTime = 0;
                    animator.SetBool("isJatuh", false);
                }
            }
            return;
        }

        // loncat
        if(Input.GetKey(KeyCode.Space) && isInGround) {
            resetState();
            animator.SetBool("isJump", true);
            waitTime = 1;
            player.velocity = new Vector2(2, jumpSpeed) * speedX;
            isInGround = false;
            return;
        }

        // lari
        if(Input.GetKey(KeyCode.RightArrow) && isInGround) {
            animator.SetBool("isRun", true);
            Vector2 v = Vector2.zero;
            v.x = 2;
            float speed = speedX * Time.deltaTime;
            transform.Translate(v * speed);
        } else {
            animator.SetBool("isRun", false);
            return;
        }
    }

    public void completeLevel() {
        cempleteLevelUI.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isInGround = true;
        if(collision.gameObject.name.Contains("obstacle")) {
            Destroy(collision.gameObject);
            waitTime = 1;
            animator.SetBool("isJatuh", true);
            return;
        } else if(collision.gameObject.name.Contains("finish")) {
            animator.SetBool("isRun", false);
            completeLevel();
            return;
        }
    }

    void resetState() {
        this.leftFoot = false;
        this.rightFoot = false;
        speedX = 2;
    }

    void changeRunningFeet(string whichFeet) {
        if(whichFeet == "kiri") {
            leftFoot = true;
            rightFoot = false;
        } else if(whichFeet == "kanan") {
            leftFoot = false;
            rightFoot = true;
        }
        speedX++;
    }

    void jatuh() {
        resetState();
        animator.SetBool("isJatuh", false);
        waitTime = 1;
        Debug.Log("jatuh");
    }
}
