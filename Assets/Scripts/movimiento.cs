using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public float jumpforce = 10f;
    public bool canJump;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            transform.position -= new Vector3(speed, 0f, 0f) * Time.deltaTime;

        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.down);

        if (Physics.Raycast(ray, out hit))
        {if (hit.distance < 1f) {
                canJump = true;
            }
            else
            {
                canJump = false;
                transform.position -= new Vector3(speed, 0f, 0f) * Time.deltaTime;
            }
        }

    }
        
}
