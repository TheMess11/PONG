using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    // Start is called before the first frame update
public int scoreJoueurGauche = 0;
public int scoreJoueurDroit = 0;

[Range(1f,100f)] public float vitesseMax = 5f;

public string nomJoueurGauche = "Jacquie";
public string nomJoueurDroit = "Michel";

public bool enPause = false;

public Rigidbody body;

public TextMesh scoreJ1, scoreJ2;
public AudioClip sonBut;
public TrailRenderer maQueue;

    void Start()    // Lancement nouvelle partie
    {
        NouvellePartie();
    }

    void NouvellePartie()
    {
        scoreJoueurDroit = 0;
        scoreJoueurGauche = 0;
        NouvelleBalle();
    }
    

    void Update()
    {
        DetecterBut(); // j'appelle la fonction DetecterBut
    }

    void DetecterBut()
    {
        if(transform.position.x > 36f)//si la balle sort à droite
        {
            ButJ1();
        }
        
        if(transform.position.x < -36f)//si la balle sort à gauche
        {
            ButJ2();
        }
    }

    void ButJ1()
    {
        scoreJoueurGauche += 1;
        AudioSource.PlayClipAtPoint(sonBut , Vector3.right*10f);
        NouvelleBalle();
    }

    void ButJ2()
    {
        scoreJoueurDroit += 1;
        AudioSource.PlayClipAtPoint(sonBut , Vector3.left*10f);
        NouvelleBalle();
    }

    void NouvelleBalle()
    {
        CancelInvoke();
        if (scoreJoueurDroit>9 || scoreJoueurGauche>9) Invoke("GameOver",2f);//      fin de la partie quand un joueur à 10

        scoreJ1.text = nomJoueurGauche + " : " + scoreJoueurGauche;
        scoreJ2.text = nomJoueurDroit + " : " + scoreJoueurDroit;
        body.velocity = Vector3.zero; //                                                on arrête la balle
        transform.position = Vector3.zero; //                                           on remet la balle
        maQueue.Clear();//                                          on enlève le trail de la balle
        Invoke("LancerBalle", 2f); //                                                   on attend 2 secondes avant de lancer la balle
    }

    void LancerBalle()
    {
        

        Vector3 direction = Vector3.one;
        
        if (Random.value > 0.5f) direction.x = -1f;//pile ou face pour changer l'angle de la balle en x
        if (Random.value > 0.5f) direction.y = -1f;//pile ou face pour changer l'angle de la balle en y

        body.AddForce(direction.normalized*vitesseMax, ForceMode.VelocityChange); //  on lance la balle      
    }
    void GameOver()
    {
        NouvellePartie();
    }


}   // fin du script
