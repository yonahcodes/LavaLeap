using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Bombe : MonoBehaviour
{
    // Collision avec le personnage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RobotBoy"))
        {
            // Animation de la cle
            gameObject.GetComponent<PlayableDirector>().Play();
            // Destruction de la cle
            Destroy(gameObject, 1f);
        }
    }
}
