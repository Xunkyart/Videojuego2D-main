using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Animator coinAnimator;

    public int valor = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.clipMonedas);
            GameManager.dinero += valor;
            coinAnimator.SetBool("CoinPicked", true);
            Destroy(this.gameObject, 0.5f);
            Debug.Log(GameManager.dinero);
        }
    }
}
