///////////////////////////////////////////////
////// Carolanne Legault //////////////////////
///////////////////////////////////////////////
////// Dernière modification: 2018-11-09 //////
///////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompteurEnnemis : MonoBehaviour {

    public int nbEnnemis = 0; // Le nombre d'ennemis au départ
    private Text txtCompteur; // Montrer combien d'ennemis il reste
    public GameObject GenerateurEnnemis; // Permet d'accéder au script lui étant relié pouvant ainsi utilisre les variable déclarées dans ce script
    
    void Start () {

        // Définir le compteur
        txtCompteur = GameObject.Find("CompteurEnnemis").GetComponent<Text>();

	}

  
    void Update () {
		
        // Affiche le décompte des ennemis restants dans l'écran de jeu
        txtCompteur.text = "Ennemis restants: " + (GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisMax - GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts);




	}
}
