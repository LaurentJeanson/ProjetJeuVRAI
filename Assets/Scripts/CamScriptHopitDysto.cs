//SCRIPT CRÉÉ PAR LAURENT JEANSON
//Ce script est utilisé pour controler, avec le temps, des caméras et textes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScriptHopitDysto : MonoBehaviour {
    //Tout les variables sont des gameobjects qui prend des caméras, textes, pannels et éléments UI du jeu
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

	void Start () {
		
	}
	

	void Update () {
        //Lorsque la scène est chargée, la fonction commence
		StartCoroutine(CineEventHopitalDysto ());
	}
	IEnumerator CineEventHopitalDysto(){
        //Pendant la cinématique, après 5 secondes, un texte et un panel disparait.
        yield return new WaitForSeconds(5);
        textePerso.SetActive(false);
        panelTextPerso.SetActive(false);
        //Après 15 secondes, la cinématique finit et le jeu commence
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
