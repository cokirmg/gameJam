using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lianaIA : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        transform.position += new Vector3(3f, 0, 0) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "waypoint1")
        {
            Debug.Log("toca");
            speed = -3f;
        }

        if (collision.gameObject.tag == "waypoint2")
        {
            speed = 3f;
        }
    }
}
