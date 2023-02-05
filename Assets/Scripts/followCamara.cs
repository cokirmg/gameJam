using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamara : MonoBehaviour
{
    public GameObject personaje;
    private Vector3 posicionRelativa;

    public Transform moverArriba;
    public followCamara f;
    public int speed = -3;

    public bool moverCamara;
    public bool abajo;
    // Start is called before the first frame update
    void Start()
    {
        posicionRelativa = transform.position - personaje.transform.position;
        this.transform.position = personaje.transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        if (moverCamara)
        {
            transform.position = personaje.transform.position + posicionRelativa;
        }
        else
        {
            if (transform.position.y > -10f && !abajo)
            {
                transform.position += new Vector3(0, -3f,-10f) * Time.deltaTime;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,personaje.transform.position, Time.deltaTime * speed);
                abajo = true;
                if (transform.position == personaje.transform.position)
                {
                    moverCamara = true;
                }
            }


        }
    }
        
}
