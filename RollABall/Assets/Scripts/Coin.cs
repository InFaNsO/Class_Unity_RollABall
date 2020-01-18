using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float angleRotate = 10.0f;

    float bounce = 0.0f;
    float startHeight = 0.0f;
    bool collected {get;set;}


    // Start is called before the first frame update
    private void Awake()
    {
        collected = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, angleRotate);

 
        if(collected)
        {
            bounce += Time.deltaTime * 0.1f ;
            Vector3 pos = transform.position;
            pos.y += Mathf.Sin(bounce) * 1.0f;
            transform.position = pos;
            if(bounce > Mathf.PI)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Collect()
    {
        angleRotate *= 10.0f;
        collected = true;
    }
}
