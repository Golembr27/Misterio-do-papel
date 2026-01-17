using UnityEngine;

public class StatusInimigo : MonoBehaviour
{
    public static StatusInimigo Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject inimigoPrefab;
    public string nomeInimigo = "";
    public float vidaAtual;
    public float vidaMaxima = 50f;
    public float vidaRegeneracao = 0.25f;
    public float xpInimigo = 2f;


}
