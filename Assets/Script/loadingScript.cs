using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = .5f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Narrativa");
        }
    }
}
