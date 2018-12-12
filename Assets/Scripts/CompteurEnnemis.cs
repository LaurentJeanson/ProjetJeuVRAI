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

        // Définir le compteur d'ennemis
        txtCompteur = GameObject.Find("CompteurEnnemis").GetComponent<Text>();
        // Définir le compteur de vague pour que le joueur se repère plus facilement dans son avancement
        txtVague = GameObject.Find("NoVague").GetComponent<Text>();


    }

  
    void Update () {

        // Affiche la vague à laquelle le joueur est rendu
        txtVague.text = "Vague :" + GenerationEnnemis.iNoVague;

        // Affiche le nombre d'ennemis restant dans les différentes vagues
        if (GenerationEnnemis.iNoVague == 1)
        {
            // Nombre d'ennemis total par défaut
            // Nombre d'ennemis maximum devant être produit - Nombre d'ennemis tuer par le joueur
            txtCompteur.text = "Ennemis restants: " + (GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisMax - GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts);

        } else
            // Nombre d'ennemis total après que la première vague soit terminée
            // Nombre d'ennemis maximum devant être produit - Nombre d'ennemis tuer par le joueur
            txtCompteur.text = "Ennemis restants: " + ((10 + GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisMax) - GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts);



    }
}
