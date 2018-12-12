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
    
    private Text txtCompteur; // Montrer combien d'ennemis il reste
    private Text txtVague; // Montrer combien d'ennemis il reste
    public GameObject GenerateurEnnemis; // Permet d'accéder au script lui étant relié pouvant ainsi utilisre les variable déclarées dans ce script

    void Start () {

        // Définir le compteur
        txtCompteur = GameObject.Find("CompteurEnnemis").GetComponent<Text>();
        txtVague = GameObject.Find("NoVague").GetComponent<Text>();


    }

  
    void Update () {

        // Affiche le décompte des ennemis restants dans l'écran de jeu
        print(GenerationEnnemis.iNoVague);
        txtVague.text = "Vague :" + GenerationEnnemis.iNoVague;

        if (GenerationEnnemis.iNoVague == 1)
        {
            txtCompteur.text = "Ennemis restants: " + (GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisMax - GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts);

        } else
            txtCompteur.text = "Ennemis restants: " + ((10 + GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisMax) - GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts);



    }
}
