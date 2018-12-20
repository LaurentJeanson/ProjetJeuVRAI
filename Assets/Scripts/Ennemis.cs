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

public class Ennemis : MonoBehaviour
{

    //Cible à suivre
    public GameObject laCible;

    public static GameObject GenerateurEnnemis;

    public static int vieEnnemi;
    public float vie;

    public GameObject UIStatistique;

    //NavMesh et Animator de l'ennemi
    NavMeshAgent navAgent;
    Animator ennemiAnim;

    //Valeurs publiques pour déterminer si l'ennemi touche le personnage, ses dégâts et sa vitesse d'attaque
    public static bool touchePerso = false;
    public static float degatEnnemi = 0.1f;
    public static float vitesseAttaque = 2;


	void Start ()
    {
        GenerateurEnnemis = GameObject.Find("Generateur_Ennemis");
        //Initialization
        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
        vie = InitializeVie();
	}

	void Update ()
    {
        if (touchePerso == true)
        {
            ennemiAnim.SetTrigger("Attaque");
        }
        //On dit à l'ennemi de se diriger vers le personnage à une certaine vitesse
        navAgent.SetDestination(laCible.transform.position);

        //Animation de l'ennemi s'il touche le personnage
        /***NON FONCTIONNEL***/
        //ennemiAnim.SetBool("touchePerso", touchePerso);
	}

    //Si l'ennemi est touché par une balle de fusil, on le détruit
    /***À TRAVAILLER SI ON VEUT QUE L'ENEMI AILLE DE LA VIE***/
    public void Touche()
    {
        vie -= laCible.GetComponent<GestionPerso>().degats;

        if (vie <= 0)
        {
            Destroy(gameObject);
            GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts++;
        }

        if (GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts >= GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisMax && GenerationEnnemis.iNoVague < 10)
        {
            GenerationEnnemis.iNoVague++;

            UIStatistique.SetActive(true);
        }
    }

    public static void AllerProchaineVague()
    {
        switch (GenerationEnnemis.iNoVague)
        {
            case 2:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(15, 3, 2, 0.1f, 0.3f);
                break;
            case 3:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(20, 3, 2, 0.2f, 0.4f);
                break;
            case 4:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(20, 4, 2, 0.3f, 0.6f);
                break;
            case 5:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(25, 4, 2, 0.4f, 0.8f);
                break;
            case 6:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(25, 5, 3, 0.5f, 1);
                break;
            case 7:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(30, 6, 2, 0.6f, 1.5f);
                break;
            case 8:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(30, 6, 4, 0.7f, 1.7f);
                break;
            case 9:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().ProchaineVague(35, 7, 2, 0.8f, 2);
                break;
            case 10:
                print("Vague No : " + GenerationEnnemis.iNoVague);
                GenerateurEnnemis.GetComponent<GenerationEnnemis>().GererBoss();
                break;
        }
    }

    public static int InitializeVie()
    {
        int vie = vieEnnemi;
        return vie;
    }
}
