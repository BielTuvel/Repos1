using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBomba : MonoBehaviour {
    public float speed;
    private float x;
    private float y;

    void Start () {
		
	}
	
	
	void Update () {
        y = transform.position.y;
        x = transform.position.x;
        x += speed * Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (x <= -9.3f)
        {
            Destroy(transform.gameObject);
        }

        if (transform.position.x <= 12.4f)
        {
            transform.position = new Vector3(x, y = -0.85f, transform.position.z);
        }

    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == "Player")
        {
            Destroy(transform.gameObject);
        }
    }
}
