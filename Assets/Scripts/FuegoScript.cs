using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
public class FuegoScript : MonoBehaviour
{
    GameObject Player;

    bool direccionPersonaje;

    public GameObject PadreFuego;

    public float velocidadFuego = 0.5f;

    float nacimiento;

    public float tiempoHastaMorir = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");

        direccionPersonaje = Player.GetComponent<Movimiento>().direccionFuegoDcha;

        nacimiento = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //MOV - BALA FUEGO

        if (direccionPersonaje)
        {
            PadreFuego.transform.Translate(velocidadFuego*Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
             PadreFuego.transform.Translate(-1*velocidadFuego*Time.deltaTime, 0, 0);
             this.GetComponent<SpriteRenderer>().flipX = false;
        }

        // DESTRUCCIÓN TRAS TIEMPO - BALA FUEGO

        if(Time.time >= nacimiento + tiempoHastaMorir)
        {
            Destroy(PadreFuego);
        }
    }
}
