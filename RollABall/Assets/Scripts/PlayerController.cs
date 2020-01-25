using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Text coinText;

    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private float JumpHeight = 20.0f;

    [SerializeField]bool mIsJumping = false;
    [SerializeField]bool jump = false;

    Vector3 myDirection = new Vector3();
    int score = 0;
    private Rigidbody myRigidbody;
    private BoxCollider myJumpCheck;

    void Start()
    {
        myJumpCheck = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();
        myDirection = Vector3.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, (transform.position + myDirection) * 5.0f);
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 0.55f ))
        {
            mIsJumping = false;
        }

        if(Input.GetAxis("Jump") > 0.0f)
        {
            jump = true;
        }

        //if(myJumpCheck)
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseDeltaX = Input.GetAxis("Mouse X");

        if(jump && !mIsJumping)
        {
            mIsJumping = true;
            jump = false;
            myRigidbody.AddForce(Vector3.up * JumpHeight);
        }

        myRigidbody.AddForce(new Vector3(horizontal, 0.0f, vertical) * moveSpeed);

        transform.Rotate(Vector3.up, mouseDeltaX);
        myDirection = transform.forward;
        myDirection.y = 0.0f;
        //Vector3 movement = myDirection * vertical + Vector3.Cross(transform.up, myDirection) * horizontal;
        //movement.y += jump;
        Vector3 dir = new Vector3(horizontal, 0.0f, vertical);

        dir.Scale(myDirection.normalized);

        myDirection = dir;
        myRigidbody.AddForce(dir*moveSpeed);

        coinText.text = score.ToString();
    }
    public Vector3 Direction() { return myDirection; }
    public float MoveSpeed() { return moveSpeed; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            other.GetComponent<Coin>().Collect();
            other.enabled = false;
            score++;
        }
        //if(other.CompareTag("Ground"))
        //{
        //    mIsJumping = false;
        //}
    }
}
