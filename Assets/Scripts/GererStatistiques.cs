using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererStatistiques : MonoBehaviour {

    public GameObject perso;

    public GameObject tir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AugmenterVie()
    {
        perso.GetComponent<GestionPerso>().vieTotale += 0.5f;
        gameObject.SetActive(false);
        Ennemis.AllerProchaineVague();
    }

    public void DimensionBalles()
    {
        var sysParticules = tir.GetComponent<ParticleSystem>().main;
        var size = sysParticules.startSize.constant + 0.2f;
        sysParticules.startSize = size;
        gameObject.SetActive(false);
        Ennemis.AllerProchaineVague();
    }

    public void Dommages()
    {
        perso.GetComponent<GestionPerso>().degats += 0.5f;
        gameObject.SetActive(false);
        Ennemis.AllerProchaineVague();
    }
}
