using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscreveTexto : MonoBehaviour
{
    private float intervalo = 0.1f;
    private string[] textos;
    private string textoCompleto = "", textoAtual = "";

    [SerializeField] private AudioSource somEscrevendo;

    private void Awake()
    {
        textos = new string[] {"Oceano Atlântico 1637...", "Destino: Brasil...", "Frota de Nassau"};
    }

    private void Start()
    {
        StartCoroutine("ApareceTexto");
    }
	
    private void Update()
    {
	if(Input.anyKeyDown)
	{
          SceneManager.LoadScene("GameTest");
	}	
    }

    public IEnumerator ApareceTexto()
    {
        for (int j = 0; j < textos.Length; j++)
        {
            textoCompleto = textos[j];
            somEscrevendo.Play();
            for (int i = 0; i <= textoCompleto.Length; i++)
            {
                textoAtual = textoCompleto.Substring(0, i);
                this.GetComponent<Text>().text = textoAtual;
                yield return new WaitForSeconds(intervalo);
            }
            somEscrevendo.Stop();
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene("GameTest");
    }
}
