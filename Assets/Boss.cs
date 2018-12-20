//////////////////////////////////////////
////Carolanne Legault/////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-11-14////
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    //Cible à suivre
    public GameObject laCible;

    public static GameObject GenerateurEnnemis;

    public float vie;

    //NavMesh et Animator de l'ennemi
    NavMeshAgent navAgent;
    Animator ennemiAnim;

    //Valeurs publiques pour déterminer si l'ennemi touche le personnage, ses dégâts et sa vitesse d'attaque
    public static bool touchePerso = false;
    public static float degatEnnemi = 3f;
    public static float vitesseAttaque = 2;


    void Start()
    {
        GenerateurEnnemis = GameObject.Find("Generateur_Ennemis");
        //Initialization
        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (touchePerso == true)
        {
            ennemiAnim.SetTrigger("Attaque");
        }
        //On dit à l'ennemi de se diriger vers le personnage à une certaine vitesse
        navAgent.SetDestination(laCible.transform.position);
    }

    //Si l'ennemi est touché par une balle de fusil, on le détruit
    public void Touche()
    {
        vie -= laCible.GetComponent<GestionPerso>().degats;

        if (vie <= 0)
        {
            GenerateurEnnemis.GetComponent<GenerationEnnemis>().bossMort = true;
            Destroy(gameObject);
        }
    }
}
