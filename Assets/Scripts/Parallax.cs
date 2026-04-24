using System.Numerics;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject Player;
    public float velocidadParallax = 0.5f;

    public GameObject Camara;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camara = GameObject.Find("Main Camera");

        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        // PARALLAX
        //Script que sirve para todas las capas, se personalizan individualmente con el float público

       float posicionX = Camara.transform.position.x ;

       float posicionY = Camara.transform.position.y ;

        transform.position = new UnityEngine.Vector3(posicionX*velocidadParallax, transform.position.y , 0.5f);
    }
}
