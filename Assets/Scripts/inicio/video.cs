using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class video : MonoBehaviour
{
    //public GameObject titulo;
    //public SpriteRenderer tituloSprite;
    public CanvasGroup grupo;
    public bool subeFade;

    private void Start()
    {
        StartCoroutine(Contador());
        //tituloSprite = titulo.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (subeFade)
        {
            if (grupo.alpha <= 255)
            {
                grupo.alpha += 1 * Time.deltaTime;
            }
        }
    }

    IEnumerator Contador()
    {
        subeFade = false;
        
        yield return new WaitForSeconds(24f);
        subeFade = true;
    }

    public void ComeOn(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CambioCreditos (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
