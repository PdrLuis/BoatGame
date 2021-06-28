using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EscreveTextoDois : MonoBehaviour
{
    private float intervalo = 0.1f, soma = 0.1f;
    private string[] textos;
    private string textoCompleto = "", textoAtual = "";

    [SerializeField] private AudioSource somEscrevendo;

    private void Awake()
    {
        textos = new string[] { "Hum..." , "por que não fazer uma ponte?", "Facilitaria muito o comércio"};
    }

    private void Start()
    {
        StartCoroutine("ApareceTexto");
    }

    public IEnumerator ApareceTexto()
    {

        somEscrevendo.Play();
        for (int j = 0; j < textos.Length; j++)
        {
            textoCompleto = textos[j];
            for (int i = 0; i <= textoCompleto.Length; i++)
            {
                textoAtual = textoCompleto.Substring(0, i);
                this.GetComponent<Text>().text = textoAtual;
                yield return new WaitForSeconds(soma);
                soma -= 0.01f; 
            }
            yield return new WaitForSeconds(1f);
        }
        Invoke("ChamaMenu", 1f);
    }
    void ChamaMenu()
    {
        TelaSelecao.ZeraTeclas();
        TelaSelecao.teclasEscolhidas = new Dictionary<int, string>();
        SceneManager.LoadScene("Menu");
    }
}
