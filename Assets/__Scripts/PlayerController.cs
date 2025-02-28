using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //public float maxX = 8.4f;
    public float speed;
    public float jumpPower;
    private bool canJump = false;
    private bool canRWallJump = false;
    private bool canLWallJump = false;
    private bool canWallJump = false;
    private string tempWallCheck;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
		// Movement Left and Right
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 lrMovement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
        rb.AddForce (lrMovement * speed, ForceMode.Impulse);
        //rb.MovePosition(rb.position + lrMovement * speed * Time.deltaTime);

        //Jumping (if statements to check if player is on ground)
        float jump = Input.GetAxis("Jump");
        Vector3 jumpMovement = new Vector3 (0.0f, jump, 0.0f);
        Vector3 jumpRMovement = new Vector3 (jump, jump, 0.0f);
        Vector3 jumpLMovement = new Vector3 (-jump, jump, 0.0f);

        /*
        if ((canJump && canWallJump) == true) {
            canWallJump = false;
            if (canRWallJump == true) {
                canRWallJump = false;
                tempWallCheck = "right";
            }
            if (canLWallJump == true) {
                canLWallJump = false;
                tempWallCheck = "left";
            }
        }
        */

        if (canJump == true) {
            //rb.AddForce (jumpMovement * jumpPower); 
            rb.AddForce (jumpMovement * jumpPower, ForceMode.Impulse);
            //rb.MovePosition(rb.position-1 * speed * Time.deltaTime);
        }
        if (canRWallJump == true && canWallJump == true) {
            //rb.AddForce (jumpRMovement * jumpPower);
            rb.AddForce (jumpRMovement * jumpPower, ForceMode.Impulse);
        }
        if (canLWallJump == true && canWallJump == true) {
            //rb.AddForce (jumpLMovement * jumpPower);
            rb.AddForce (jumpLMovement * jumpPower, ForceMode.Impulse);
        }
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag("Ground")) {
            canJump = true;
            canWallJump = true;
        }
        if (col.gameObject.CompareTag("RWall")) {
            canRWallJump = true;
        }
        if (col.gameObject.CompareTag("LWall")) {
            canLWallJump = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground")) {
            canJump = false;
            
            /*
            if ((col.gameObject.CompareTag("LWall") || col.gameObject.CompareTag("RWall")) == false) {
                canWallJump = true;
                if (tempWallCheck == "right") {
                    canRWallJump = true;
                } else if (tempWallCheck == "left") {
                    canLWallJump = true;
                }
            }*/
        }
        if (col.gameObject.CompareTag("RWall")) {
            canRWallJump = false;
            canWallJump = false;
        }
        if (col.gameObject.CompareTag("LWall")) {
            canLWallJump = false;
            canWallJump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
