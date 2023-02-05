using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaa : MonoBehaviour
{
    public Transform moverArriba;
    public followCamara f;
    public int speed = 2;

    public Transform cameraA;
    public bool ya = true;

    public void Awake()
    {
        

        
    }

    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        f = GetComponent<followCamara>();
        f.enabled = false;
        cameraA.position = moverArriba.transform.position * speed * Time.deltaTime;
        f.enabled = true;
    }
}
