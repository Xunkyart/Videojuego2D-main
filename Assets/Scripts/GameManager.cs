using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int vidas = 6;

    public static int dinero = 0;

    GameObject Player;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.vidas);
        if (vidas <= 0)
        {
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
