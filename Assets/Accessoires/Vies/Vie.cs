using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Vie : MonoBehaviour
{
    public float dureeVie = 5f;
    public PlayableAsset timeline2;

    void Start()
    {
        // Duree de vie
        Destroy(gameObject, dureeVie);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RobotBoy"))
        {
            // Arreter la descente
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            // Demarrer animation 2
            gameObject.GetComponent<PlayableDirector>().Play(timeline2, DirectorWrapMode.Hold);
            // Destruction de l'objet
            Destroy(gameObject, 2f);
        } 
    }
}
