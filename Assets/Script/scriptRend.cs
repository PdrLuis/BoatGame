using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRend : MonoBehaviour
{
    [SerializeField]private AudioSource[] power;
    public enum Obs { 
        rendFora, rendDentro,
        velUp, velDown
    }

    public Obs obsType;

    private void Update()
    {
        if((int) obsType == 0)
        {
            this.gameObject.transform.Rotate(0f, 0f, this.gameObject.transform.rotation.z + 10, Space.World);        
        }
        else if ((int) obsType == 1)
        {
            this.gameObject.transform.Rotate(0f, 0f, this.gameObject.transform.rotation.z - 10, Space.World);
        }
        else if((int) obsType == 2)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if ((int)obsType == 3)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f,0f,90f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && (int) obsType == 2)
        {
            power[0].Play();
            collision.gameObject.GetComponent<ShipBehaviour>().typeVel = 1;
            StartCoroutine(AjusteVelocidade(1));
        }
        else if(collision.gameObject.tag == "Player" && (int) obsType == 3)
        {
            power[1].Play();
            collision.gameObject.GetComponent<ShipBehaviour>().typeVel = 2;
            StartCoroutine(AjusteVelocidade(0));
        }

        IEnumerator AjusteVelocidade(int caso)
        {

            switch (caso)
            {
                case 0:
                    yield return new WaitForSeconds(1.5f);
                    collision.gameObject.GetComponent<ShipBehaviour>().typeVel = 0;
                    break;

                case 1:
                    yield return new WaitForSeconds(.5f);
                    collision.gameObject.GetComponent<ShipBehaviour>().typeVel = 0;
                    break;
            }
        }
    }
}
