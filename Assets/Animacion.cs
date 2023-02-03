using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Animacion : MonoBehaviour
{
    public float speedForce;
    public Animator anim;
    public int salto;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speedForce, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            anim.SetBool("andar", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speedForce, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            anim.SetBool("andar", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, speedForce) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            anim.SetBool("andar", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, 0f, -speedForce) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            anim.SetBool("andar", true);
        }
        else
        {
            anim.SetBool("andar", false);
            //anim.SetBool("Saltar", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0f, salto, 0f) * Time.deltaTime;
            anim.SetBool("saltar", true);
        }
        else
        {
            anim.SetBool("saltar", false);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.position += new Vector3(-speedForce, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            anim.SetBool("huir", true);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            transform.position += new Vector3(speedForce, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            anim.SetBool("huir", true);
        }
        else if (Input.GetKey(KeyCode.I))
        {
            transform.position += new Vector3(0f, 0f, speedForce) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            anim.SetBool("huir", true);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            transform.position += new Vector3(0f, 0f, -speedForce) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            anim.SetBool("huir", true);
        }
        else
        {
            anim.SetBool("huir", false);
            //anim.SetBool("Saltar", false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            
            anim.SetBool("hablar", true);
        }
        else
        {
            anim.SetBool("hablar", false);
        }

        if (Input.GetKey(KeyCode.R))
        {

            anim.SetBool("celebracion", true);
        }
        else
        {
            anim.SetBool("celebracion", false);
        }


    }
}
