using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaPlayer : MonoBehaviour
{
    [SerializeField] private GameObject botaoTrue, obj_teclaEscolhida;
    [SerializeField] private Text txt_feedback;
    public int id;
    public Text txt_teclaEscolhida;
    public bool ativado = false;
    public bool escolhendoTecla = false;
    public static bool podeSelecionar = true;

    public static List<string> portaTeclas = new List<string>();
    void Start()
    {
        txt_teclaEscolhida = obj_teclaEscolhida.transform.GetChild(0).GetComponent<Text>();
        if (id == 0)
        {
            ativado = true;
            escolhendoTecla = true;
            podeSelecionar = false;
        }
    }

    void Update()
    {
        txt_feedback.text = (!podeSelecionar? "Escolha uma tecla": "");
        if (escolhendoTecla)
        {
            if (Input.inputString != "")
            {
                if (verificadorDeTeclas(Input.inputString.Substring(0,1)))
                {
                    portaTeclas.Add(Input.inputString.Substring(0,1));
                    txt_teclaEscolhida.text = Input.inputString.Substring(0,1).ToUpper();
                    escolhendoTecla = false;
                    podeSelecionar = true;
                }
            }
        }
        else if (txt_teclaEscolhida.text == "\0")
        {
            txt_teclaEscolhida.text = "...";
        }

        obj_teclaEscolhida.SetActive(ativado);
        if (!ativado && txt_teclaEscolhida.text != "...")
        {
            portaTeclas.Remove(txt_teclaEscolhida.text.ToLower());
            txt_teclaEscolhida.text = "...";
        }
        botaoTrue.GetComponent<Image>().color = (ativado ? Color.green : Color.red);
    }
    bool verificadorDeTeclas(string tecla)
    {
        foreach (var i in portaTeclas)
        {
            if (i == tecla)
            {
                return false;
            }
        }
        return true;
    }
    public void EscolhendoTecla()
    {
        if (podeSelecionar)
        {
            portaTeclas.Remove(txt_teclaEscolhida.text.ToLower());
            txt_teclaEscolhida.text = "...";
            escolhendoTecla = true;
            podeSelecionar = false;
        }
    }

    public void Ativar()
    {
        if (podeSelecionar)
        {
            if (!ativado)
            {
                ativado = true;
                escolhendoTecla = true;
                podeSelecionar = false;
            }
            else if (ativado)
            {

                ativado = false;
                podeSelecionar = true;
            }
        }
        else if(ativado)
        {
            ativado = false;
            podeSelecionar = true;
        }
    }
}
