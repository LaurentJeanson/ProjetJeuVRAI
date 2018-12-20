using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEcranCredit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("RetourMenu");
	}
	
	// Update is called once per frame
	void update() {
		
	}

    IEnumerator RetourMenu()
    {
        yield return new WaitForSeconds(26);
        SceneManager.LoadScene("menuPrincipal");
    }
}
