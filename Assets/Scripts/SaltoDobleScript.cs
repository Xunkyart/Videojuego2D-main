using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SaltoDobleScript : MonoBehaviour
{
    GameObject Player;

    public bool permiteSaltoDoble;

    Animator SaltoDobleAnimator;

    private bool recargando = false;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");

        permiteSaltoDoble = Player.GetComponent<Movimiento>().saltoDoble;

        SaltoDobleAnimator = this.GetComponent<Animator>();

        recargando = false;

        //collider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(permiteSaltoDoble);
        if (InputSystem.actions["Jump"].ReadValue<float>() == 1.0f && permiteSaltoDoble == true)
        {
            Debug.Log("Hola");
            SaltoDobleAnimator.SetBool("Gastado",true);
            recargando = true;  
            StartCoroutine(IniciarTemporizador());
        }
    }

    IEnumerator IniciarTemporizador(){
        yield return new WaitForSeconds(3.0f);
        recargando = false;
        SaltoDobleAnimator.SetBool("Gastado",false);
        //collider.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player" && recargando == false)
        {
            permiteSaltoDoble = true;
        }
    }
  
    void OnTriggerExit2D(){
        permiteSaltoDoble = false;
    }
}
