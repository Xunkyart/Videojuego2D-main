    using System;
    using NUnit.Framework;
    using Unity.VisualScripting;
    using UnityEngine;

public class Fantasma : MonoBehaviour
{   string estado = "patrulla";

    public float distanciaPatrulla = 3.0f;

    public float velocidadPatrulla = 5.0f;

    public float velocidadAtaque = 1.0f;

    public float distanciaEvitar =3.0f;

    public float distanciaAtaque = 3.0f;

    bool dirPatruDrcha = true;

    GameObject Personaje;

    Vector3 posicionInicial;

    Vector3 posicionLimitIzq, posicionLimitDrcha;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Personaje = GameObject.Find("Player");

        posicionInicial = transform.position;

        posicionLimitIzq = new Vector3(posicionInicial.x - distanciaPatrulla, posicionInicial.y, posicionInicial.z);

        posicionLimitDrcha = new Vector3(posicionInicial.x + distanciaPatrulla, posicionInicial.y, posicionInicial.z);

        estado = "patrulla";
    }

    // Update is called once per frame
    void Update()
    {
        //PATRULLA
        if(estado == "patrulla")
        {
            if(transform.position.x >= posicionLimitDrcha.x)
            {
                dirPatruDrcha = false;
            }
            else if (transform.position.x <= posicionLimitIzq.x)
            {
               dirPatruDrcha = true;
            }

            if (dirPatruDrcha == true)
            {
                transform.Translate(velocidadPatrulla*Time.deltaTime, 0, 0);
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                transform.Translate(velocidadPatrulla*-1*Time.deltaTime,0,0);
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        //REGRESO
        //Si nos alejamos lo suficiente, el enemigo deja de perseguirnos y vuelve a su patrulla

        float distanciaConPlayer = Vector3.Distance(transform.position, Personaje.transform.position);
        if(distanciaConPlayer <= distanciaAtaque)
        {
            estado = "ataque";
        }
        if(distanciaConPlayer > distanciaEvitar&&estado=="ataque")
        {
            estado ="regreso";
        } 

         if (estado == "regreso")
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadPatrulla*Time.deltaTime);
            if (transform.position == posicionInicial)
            {
                estado="patrulla";
            }
        }   
        //ATAQUE

        if (estado == "ataque")
        {
            transform.position = Vector3.MoveTowards(transform.position, Personaje.transform.position, velocidadAtaque * Time.deltaTime);
        }
   }

    // EL FANTASMA MATA POR CONTACTO

   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            Personaje.GetComponent<Movimiento>().Respawnear();
        }
        else if (col.name == "Fuego")
        {
            Destroy(col.gameObject, 0.0f);
            Destroy(this.gameObject, 0.0f);
        }
        

        //EL FANTASMA MUERE POR FUEGO

        
    }
   

}
