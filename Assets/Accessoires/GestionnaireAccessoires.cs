using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireAccessoires : MonoBehaviour
{
    // Bombes
    public GameObject bombe;
    public int nbBombes;

    // Vies
    public GameObject vie;
    public int nbVies;
    public float intervalleVies;
    
    // Limites de la scene
    public Transform pointHG;
    public Transform pointBD;

    void Start()
    {
        // Bombes
        for (int i = 0; i < nbBombes; i++)
        {
            // Position aleatoire
            float x = Random.Range(pointHG.position.x, pointBD.position.x);
            float y = Random.Range(pointBD.position.y, pointHG.position.y);

            // Creation d'objets
            Instantiate(bombe, new Vector2(x, y), Quaternion.identity, gameObject.transform.parent);
        }

        InvokeRepeating("CreationVies", intervalleVies, intervalleVies);
    }

    void CreationVies()
    {
        // Vies
        for (int i = 0; i < nbVies; i++)
        {
            // Position
            float x = Random.Range(pointHG.position.x, pointBD.position.x);
            float y = pointHG.position.y;

            // Creation d'objets
            Instantiate(vie, new Vector2(x, y), Quaternion.identity, gameObject.transform.parent);
        }
    }
}
