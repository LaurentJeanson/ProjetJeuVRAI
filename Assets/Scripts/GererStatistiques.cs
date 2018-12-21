//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-12-20////
//////////////////////////////////////////
/*Script qui gère l'augmentation des statistiques
à la fin de chaque vague*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererStatistiques : MonoBehaviour {

    //Le personnage
    public GameObject perso;

    //Particule de tir
    public GameObject tir;

    //Augmenter la vie du personnage et démarrer la prochaine vague
    public void AugmenterVie()
    {
        perso.GetComponent<GestionPerso>().vieTotale += 0.5f;
        perso.GetComponent<GestionPerso>().vieActuelle = perso.GetComponent<GestionPerso>().vieTotale;
        gameObject.SetActive(false);
        Ennemis.AllerProchaineVague();
    }

    //Augmenter la dimension des balles et démarrer la prochaine vague
    public void DimensionBalles()
    {
        var sysParticules = tir.GetComponent<ParticleSystem>().main;
        var size = sysParticules.startSize.constant + 0.2f;
        sysParticules.startSize = size;
        gameObject.SetActive(false);
        Ennemis.AllerProchaineVague();
    }

    //Augmenter les dégâts du personnage et démarrer la prochaine vague
    public void Dommages()
    {
        perso.GetComponent<GestionPerso>().degats += 0.5f;
        gameObject.SetActive(false);
        Ennemis.AllerProchaineVague();
    }
}
