using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroducaoScript : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(temp());
	}

    	private void Update()
	{
		if(Input.anyKeyDown)
		{
			if(Input.anyKeyDown)
				{
        			 SceneManager.LoadScene("Menu");
				}				
			}
	}

	IEnumerator temp()
	{
		yield return new WaitForSeconds(30f);
        	SceneManager.LoadScene("Menu");
	}
}
