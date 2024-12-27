using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleurRobotBoy : MonoBehaviour
{
    // Publiques
    public float vitesse; // Vitesse deplacement
    public float impulsion; // Saut
    public GameObject imageVies; // Affichage des vies
    public AudioClip musiqueMort; // Marche mortuaire
    public int viesMax; // Limite de vies 

    // Privees
    int nbVies = 3; // Nombre de vies
    float deplacement; // Input
    bool saute; // Etat de saut
    bool roulade; // Etat de roulade
    bool accroupi; // Etat d'accroupissement
    int nbSauts; // Gestion double sauts
    float vitesseAccroupi;
    float vitesseInitiale;

    // Alias
    Rigidbody2D rb; // Physique
    SpriteRenderer sr; // Apparence
    Animator anim; // Animateur

    // Initialisation
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();

        deplacement = 0;
        saute = false;
        nbSauts = 0;
        accroupi = false;
        roulade = false;
        vitesseInitiale = vitesse;
    }

    // Controle + logique
    void Update()
    {
        deplacement = Input.GetAxis("Horizontal"); // Input clavier -1, 1
        anim.SetFloat("Etat", Mathf.Abs(deplacement));

        // Orientation du personnage
        if (deplacement < 0)
        {
            sr.flipX = true;
        }
        if (deplacement > 0)
        {
            sr.flipX = false;
        }

        // Gestion de saut
        if (Input.GetKeyDown("w") && nbSauts < 2)
        {
            anim.SetTrigger("Saut");
            saute = true;
            nbSauts++;
        }
        
        // Gestion de roulade
        if (Input.GetKeyDown("x") && !roulade)
        {
            anim.SetTrigger("Roulade");
            roulade = true;
            Invoke("ResetRoulade", 1f);
        }
        
        // Gestion d'accroupissement
        if (Input.GetKey("s"))
        {
            if (!accroupi)
            {
                anim.SetBool("Accroupissement", true);
                accroupi = true;
                vitesse = vitesseInitiale / 2;
            }
        }
        else if (Input.GetKeyUp("s") && accroupi)
        {
            anim.SetBool("Accroupissement", false);
            accroupi = false;
            vitesse = vitesseInitiale;
        }
    }

    // Physique
    void FixedUpdate()
    {
        // Deplacement horizontal
        rb.AddRelativeForce(Vector2.right * vitesse * deplacement);
        
        // Saut
        if (saute)
        {
            rb.AddRelativeForce(Vector2.up * impulsion, ForceMode2D.Impulse);
            saute = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        nbSauts = 0;
        GestionCollisions(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GestionCollisions(collision.gameObject);
    }

    // Objets Bonus, Malus ou Mortem ?
    void GestionCollisions(GameObject objet)
    {
        if (objet.CompareTag("Bonus") && nbVies <= viesMax)
        {
            nbVies++;
            AffichageVies();
        }
        if (objet.CompareTag("Malus"))
        {
            nbVies--;
            AffichageVies();
        }
        if (objet.CompareTag("Mortem") || nbVies == 0)
        {
            nbVies = 0;
            AffichageVies();

            impulsion = 0;
            vitesse = 0;
            rb.simulated = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            anim.SetTrigger("Mort");

            // Audio
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().PlayOneShot(musiqueMort);

            // Redemarrer le jeu
            Invoke("Recommencer", 7f);

        }
    }
    // Redemarrer le jeu
    void Recommencer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Affichage des vies
    void AffichageVies()
    {
        imageVies.GetComponent<RectTransform>().localScale = new Vector3(nbVies, 1f, 1f);
        imageVies.GetComponent<RawImage>().uvRect = new Rect(0, 0, nbVies, 1f);
    }

}
