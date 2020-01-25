using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Vector3 offset = new Vector3();

    [SerializeField] float mCircleRadius = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //connecting Vector = end - start
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 ppos = player.transform.position;
        Vector3 pDir = player.Direction();
        float mouseDeltaX = Input.GetAxis("Mouse X");


        transform.LookAt(player.transform, Vector3.up);

        transform.position = ppos + (((pDir.normalized * offset.z) + (pDir.normalized * offset.y)).normalized + offset);

        //if player is at the edge of the circle let it move on x and y 

        //transform.RotateAround(ppos, Vector3.up, mouseDeltaX);
    }

    private void OnDrawGizmos()
    {
        //make the circle
        float currentAngle = 0.0f;
        float deltaAngle = 360.0f / 16;

        Vector3 prvPos = player.transform.position;

        for (int j = 0; j <= 16; ++j)
        {
            //Set x,y,z for all the points in one row
            Vector3 pos;


            pos.z = Mathf.Sin(currentAngle) * mCircleRadius + player.transform.position.z;   //sin theta
            pos.x = (Mathf.Cos(currentAngle) * mCircleRadius) + player.transform.position.x;    //cos theta
            pos.y = player.transform.position.y;                           //Affected by row

            currentAngle += deltaAngle;

            Gizmos.DrawLine(prvPos, pos);
            prvPos = pos;
        }

    }

}
