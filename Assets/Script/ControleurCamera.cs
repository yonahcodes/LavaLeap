using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurCamera : MonoBehaviour
{
    // Publiques
    public Transform personnage; // Cible
    // Limites de deplacement de camera
    public Transform pointHG;
    public Transform pointBD;

    // Privees
    Transform transfo;
    // Taille camera
    float cameraDemiLargeur;
    float cameraDemiHauteur;

    void Start()
    {
        transfo = gameObject.transform;
        Camera cam = gameObject.GetComponent<Camera>();

        cameraDemiHauteur = cam.orthographicSize; // Demi-hauteur
        cameraDemiLargeur= cam.aspect * cameraDemiHauteur; // Demi-largeur
    }

    void Update()
    {
        // Limite de deplacement camera
        float posHoriz, posVert;

        // Deplacement horizontal
        posHoriz = Mathf.Clamp(
            personnage.position.x,
            pointHG.position.x + cameraDemiLargeur,
            pointBD.position.x - cameraDemiLargeur
            );

        // Deplacement vertical
        posVert = Mathf.Clamp(
            personnage.position.y,
            pointBD.position.y + cameraDemiHauteur,
            pointHG.position.y - cameraDemiHauteur
            );

        // La camera suit le personnage
        transfo.position = new Vector3(
            posHoriz,
            posVert, 
            transfo.position.z
            );
    }
}
