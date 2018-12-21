//////////////////////////////////////////
////Philippe Thibeault////////////////////
//////////////////////////////////////////
////Dernière modification : 2018-12-20////
//////////////////////////////////////////
/*Script qui gère le déplacement et les
interactions des ennemis à distance*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemiRange : MonoBehaviour
{

    //Cible à suivre
    public GameObject laCible;

    //Objet qui génère les ennemis
    public static GameObject GenerateurEnnemis;

    //Particule de tir de L'ennemi
    public GameObject ParticuleEnnemi;

    //Variables pour stocker la vie de L'ennemi
    public static int vieEnnemi;
    public int vie;

    //GameObject pour le UI de l'amélioration des statistiques
    public GameObject UIStatistique;

    //Booléenne déterminant si l'ennemi peut tirer
    private bool peutTirer = true;

    //NavMesh et Animator de l'ennemi
    NavMeshAgent navAgent;
    Animator ennemiAnim;

    //Valeurs publiques pour déterminer si l'ennemi touche le personnage, ses dégâts et sa vitesse d'attaque
    public static bool touchePerso = false;
    public static float degatEnnemi = 0.1f;
    public static float vitesseAttaque = 2;

    void Start()
    {
        GenerateurEnnemis = GameObject.Find("Generateur_Ennemis");

        navAgent = GetComponent<NavMeshAgent>();
        ennemiAnim = GetComponent<Animator>();
        vie = InitializeVie();
    }

    void Update()
    {
        //On dit à l'ennemi de se diriger vers le personnage à une certaine vitesse
        navAgent.SetDestination(laCible.transform.position);

        //À une certaine distance, l'ennemi arrête et tire sur le personnage
        if (navAgent.remainingDistance <= 30 && navAgent.remainingDistance > 0 && peutTirer == true)
        {
            peutTirer = false;
            StartCoroutine("TirEnnemi");
        }
    }

    //Si l'ennemi est touché par une balle de fusil, on le diminue sa vie
    public void Touche()
    {
        vie--;

        //Si la vie est 0, on le détruit et on recalcule le nombre d'ennemis morts
        if (vie <= 0)
        {
            Destroy(gameObject);
            GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts++;
        }

        //Si tous les ennemis sont morts, on passe à la prochaine vague
        if (GenerateurEnnemis.GetComponent<GenerationEnnemis>().iNbEnnemisMorts >= GenerateurEnnemis.GetComponent<GenerationEnnemis>().nbEnnemisTotal)
        {
            GenerationEnnemis.iNoVague++;

            UIStatistique.SetActive(true);
        }
    }

    //L'ennemi tire une nouvelle particule qui se dirige vers le personnage
    IEnumerator TirEnnemi()
    {
        var clone = Instantiate(ParticuleEnnemi);
        clone.transform.position = ParticuleEnnemi.transform.position + (ParticuleEnnemi.transform.forward * 2);
        clone.transform.localEulerAngles = transform.localEulerAngles;
        clone.SetActive(true);
        clone.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(2);
        peutTirer = true;
    }

    //Passer à la prochaine vague et déterminer le nombre d'ennemis de chaque sorte, leur vie et leurs dégâts
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
