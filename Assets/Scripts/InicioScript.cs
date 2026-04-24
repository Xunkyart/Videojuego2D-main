using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelSettings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //BOTÓN INICIO JUEGO

     public void Inicio()
    {
        SceneManager.LoadScene("Level_Prototype");
    }

    //BOTÓN SETTINGS

    public void showSettings()
    {
        panelSettings.SetActive(true);
        panelInicio.SetActive(false);
    }

    //BOTÓN EXIT SETTINGS

    public void exit()
    {
        panelSettings.SetActive(false);
        panelInicio.SetActive(true);
    }

    //BOTÓN EXIT GAME

    public void exitGame()
    {
        Application.Quit();
    }
}
