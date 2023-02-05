using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "canCatch")
        {
            Destroy(collision.gameObject);
            StartCoroutine(EscenaFinal());
        }
    }

    IEnumerator EscenaFinal()
    {
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(3f);
    }
}
