using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallaxOceano : MonoBehaviour
{
    [SerializeField]float parallaxValor, parallaxAdicao;
    SpriteRenderer sr;
    public GameObject[] gOTemp;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        parallaxValor += parallaxAdicao;
        sr.material.SetTextureOffset("_MainTex", new Vector2(-parallaxValor, 0f));

        //Transição Bug
        if (UI.per)
        {
            StartCoroutine(ExcGameObjects());   
        }
    }
    IEnumerator ExcGameObjects()
    {
        yield return new WaitForSeconds(1.6f);
        gOTemp[0].SetActive(false);
        gOTemp[1].SetActive(false);
        UI.per = false;
    }


}
