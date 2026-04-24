using UnityEngine;

public class Dead : MonoBehaviour
{

    GameObject player;

    Movimiento movimiento;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player= GameObject.Find("Player");
        movimiento = player.GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //MUERTE
    //Si el Player toca el collider de un objeto con este script, muere y respawnea

    void OnTriggerEnter2D (Collider2D col)
    {
       if(col.name == "Player")
        {
            movimiento.Respawnear();
        }
    }


}
