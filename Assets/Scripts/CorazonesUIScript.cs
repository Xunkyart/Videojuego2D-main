using UnityEngine;

public class CorazonesUIScript : MonoBehaviour
{
    int vidas = 6;

    Animator corazonAnimator;

    public int vidaMax;

    public int vidaMedia;

    public int vidaNula;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corazonAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vidas = GameManager.vidas;

        if(vidas >= vidaMax)
        {
            corazonAnimator.SetBool("VidaCompleta", true);
            corazonAnimator.SetBool("VidaMedia", false);
            corazonAnimator.SetBool("VidaDestruida", false);
        }
        else if (vidas == vidaMedia)
        {
            corazonAnimator.SetBool("VidaCompleta", false);
            corazonAnimator.SetBool("VidaMedia", true);
            corazonAnimator.SetBool("VidaDestruida", false);
        }
        else if (vidas <= vidaNula)
        {
            corazonAnimator.SetBool("VidaCompleta", false);
            corazonAnimator.SetBool("VidaMedia", false);
            corazonAnimator.SetBool("VidaDestruida", true);
        }
    }
}
