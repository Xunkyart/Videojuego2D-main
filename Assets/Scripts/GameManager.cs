using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int vidas = 6;

    static public int dinero = 0;

    GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.vidas);
        if (vidas <= 0){
           Player.GetComponent<Movimiento>().Respawnear();
            vidas = 6;
        }

        if (vidas > 6)
        {
            Player.GetComponent<Movimiento>().Respawnear();
       
            vidas = 6;
        } 
    }

}
