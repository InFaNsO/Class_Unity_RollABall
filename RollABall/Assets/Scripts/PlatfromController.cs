using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromController : MonoBehaviour
{
    [SerializeField] float mTime = 1.0f;
    [SerializeField] float mSpeed = 1.0f;
    [SerializeField] bool isLeftRight = true;
    [SerializeField] bool isUpDown = false;

    float mTimer = 0.0f;
    bool switchDir = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(isLeftRight)
            pos.x += switchDir ? mTime * mSpeed * Time.deltaTime: -(mTime * mSpeed) * Time.deltaTime;
        else
            pos.z += switchDir ? mTime * mSpeed * Time.deltaTime : -(mTime * mSpeed) * Time.deltaTime;
        if(isUpDown)
            pos.y += switchDir ? mTime * mSpeed * Time.deltaTime : -(mTime * mSpeed) * Time.deltaTime;

        transform.position = pos;

        mTimer += Time.deltaTime;
        if (mTimer > mTime)
        {
            switchDir = !switchDir;
            mTimer = 0.0f;
        }
    }
}
