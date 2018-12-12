using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripte créé par Laurent Jeanson

public class GestionArmeEvent : MonoBehaviour {
    public GameObject Texte;
    public GameObject Panel;
    public GameObject Texte2;
    public GameObject Panel2;
    public bool peutTirer = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	// Lorsque le joueur appuie sur ENTER, les textes du tutoriel se désactive
	// et d'autre textes apparaient pour montrer un autre tutoriel sur la gestion de vie
	void Update () {
        if (peutTirer == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {       
                Texte.SetActive(false);
                Panel.SetActive(false);
                Texte2.SetActive(true);
                Panel2.SetActive(true);
                StartCoroutine(Cerveautexte());
            }
        }
    }

	//Le nombre de temps que le tutoriel de la vie va durée est de 10 secondes 

    IEnumerator Cerveautexte()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
        Destroy(Texte2);
        Destroy(Panel2);
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.tag == "Arme")
        {
           
            peutTirer = true;       
        }
    }
}
