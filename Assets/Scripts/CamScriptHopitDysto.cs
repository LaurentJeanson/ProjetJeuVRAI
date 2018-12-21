using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script créé par Laurent Jeanson. Ce script gère la cinématique lorsque le joueur entre dans l'hopital

public class CamScriptHopitDysto : MonoBehaviour {
	public GameObject CameraEvent;
	public GameObject CameraPerso;
    public GameObject texte;
    public GameObject panel;
    public GameObject textePerso;
    public GameObject panelTextPerso;
    public GameObject imageCerveauVide;
    public GameObject imageCerveauPlein;
    public GameObject contourMiniMap;
    public GameObject miniMap;
    public GameObject maskMiniMap;
    public GameObject Perso;
    public GameObject EventHopitalDysto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Lorsque la scène est chargé, la fonction CineEventHopitalDysto commence.
		StartCoroutine(CineEventHopitalDysto ());
	}

	//Fonction qui contrôle le texte, panel et caméra selon un temps donné

	IEnumerator CineEventHopitalDysto(){
		//Après les premières 5 secondes, le texte 1 disparait
        yield return new WaitForSeconds(5);
        textePerso.SetActive(false);
        panelTextPerso.SetActive(false);
		//Les 15 secondes suivantes, la caméra de la cinématique se désactive et les UI du jeu apparaissent.
        yield return new WaitForSeconds (15);
		print (Time.time);
		CameraEvent.SetActive (false);
		//FauxPerso.SetActive (false);
		//Perso.SetActive (true);
		CameraPerso.SetActive (true);
        texte.SetActive(true);
        panel.SetActive(true);
        maskMiniMap.SetActive(true);
        miniMap.SetActive(true);
        contourMiniMap.SetActive(true);
        imageCerveauPlein.SetActive(true);
        imageCerveauVide.SetActive(true);
        Perso.SetActive(false);
        Destroy (EventHopitalDysto);
	}
}
