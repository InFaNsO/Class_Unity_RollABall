using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Text coinText;

    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private float JumpHeight = 3.0f;

    Vector3 myDirection = new Vector3();
    int score = 0;
    private Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myDirection = Vector3.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, (transform.position + myDirection) * 5.0f);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        float mouseDeltaX = Input.GetAxis("Mouse X");

        myRigidbody.AddForce(new Vector3(horizontal, jump, vertical) * moveSpeed);

        transform.

        transform.Rotate(Vector3.up, mouseDeltaX);
        myDirection = transform.forward;
        myDirection.y = 0.0f;
        //Vector3 movement = myDirection * vertical + Vector3.Cross(transform.up, myDirection) * horizontal;
        //movement.y += jump;
        Vector3 dir = new Vector3(horizontal, jump, vertical);

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
    }
}
