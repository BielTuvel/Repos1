using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    private float x;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        x = transform.position.x;
        x += speed * Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (x >= 8)
        {
            Destroy(transform.gameObject);
        } 

    }
}
