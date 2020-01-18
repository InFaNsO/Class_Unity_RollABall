using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Vector3 offset = new Vector3();

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
        //transform.RotateAround(ppos, Vector3.up, mouseDeltaX);
    }

}
