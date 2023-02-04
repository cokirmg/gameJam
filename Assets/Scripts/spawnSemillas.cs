using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSemillas : MonoBehaviour
{
    public bool canSpawn;
    public GameObject semilla;
    public Transform semillaZona;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        while (canSpawn) 
        {
            spawnSemilla();
        }
    }

    public void spawnSemilla()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        canSpawn = false;
        Instantiate(semilla, new Vector3(4.1f, -1.77f, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }
}
