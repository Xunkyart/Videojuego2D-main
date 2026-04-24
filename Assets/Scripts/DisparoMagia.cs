using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.InputSystem;
public class DisparoMagia : MonoBehaviour
{
    public GameObject fuegoBala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DISPARO MAGIA 
        //Al pulsar click derecho, instancio al objeto hijo (bala de fuego). Lo hago fuera de la propia bala porque no puede instanciarse si no existe todavía

        bool disparoMagia = InputSystem.actions["Magia"].WasPressedThisFrame();
        if (disparoMagia)
        {
            Instantiate(fuegoBala, transform.position, Quaternion.identity);
        }
    }
}
