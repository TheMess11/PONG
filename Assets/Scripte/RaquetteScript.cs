using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteScript : MonoBehaviour
{
    public float vitesse = 15f;
    public string axe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 raquettepos = transform.position;
        raquettepos.y += Input.GetAxisRaw(axe) * vitesse * Time.deltaTime;
        raquettepos.y = Mathf.Clamp(raquettepos.y, -18f, 18f);//pour bloquer la raquette
        transform.position = raquettepos;//on applique une nouvelle position
    }
}
