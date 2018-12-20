using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionFailles : MonoBehaviour {

    public GameObject textFaille;
    public GameObject panelFaille;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textFaille.SetActive(true);
            panelFaille.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<GestionPerso>().vieActuelle += 1;
                textFaille.SetActive(false);
                panelFaille.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textFaille.SetActive(false);
            panelFaille.SetActive(false);
        }
    }
}
