using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semillaIATOL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-3f, 0, 0) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

