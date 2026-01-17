using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaInimigo : MonoBehaviour
{
    public static BarraDeVidaInimigo Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool tempoAtivar = false;
    public float tempoTotal = 1f;
    public float tempoRestante;
    public bool regemAtivo = true;

    public float vidaRegem;
    public float vidaAtual;
    public float vidaMaxima;

    public GameObject inimigo;

    public Slider slider;

    public float xpInimigo;

    public TextMeshProUGUI tmVidaAtul;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpInimigo = StatusInimigo.Instance.xpInimigo;
        slider = inimigo.GetComponentInChildren<Slider>();
        vidaRegem = StatusInimigo.Instance.vidaRegeneracao;
        vidaAtual = StatusInimigo.Instance.vidaAtual;
        vidaMaxima = StatusInimigo.Instance.vidaMaxima;
        tempoRestante = tempoTotal;
        vidaAtual = vidaMaxima;
        slider.maxValue = vidaMaxima;
        slider.value = vidaMaxima;
        VidaMudaTexto();
    }

    private void FixedUpdate()
    {
        //REGENERAÇÃO DE VIDA TIMER.
        if (tempoRestante > 0 && tempoAtivar == true)
        {
            tempoRestante -= Time.deltaTime;
        }
        else if (tempoRestante < 0)
        {
            VidaRegeneracao();
        }
    }

    private void VidaRegeneracao()
    {
        //ESSE VOID FAZ COM QUE CADA 1 SEGUNDO O JOGADOR REGENERE A QUANTIDADE DE VIDA QUE ESTÀ NA VARIAVEL "vidaRegem"
        //QUE ESTÁ NO SCRIPT STATUS.
        if (vidaAtual >= vidaMaxima)
        {
            tempoAtivar = false;
        }

        if (regemAtivo == true && vidaAtual <= vidaMaxima && tempoRestante < 0)
        {
            tempoRestante = 1f;
            vidaAtual += vidaRegem;
            slider.value = vidaAtual;
            VidaMudaTexto();
        }
        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }
    }

    private void MortePlayer()
    {
        if (vidaAtual <= 0)
        {
            Status.Instance.xpAtual += xpInimigo;
            BarraDeXp.Instance.MudaTexto();
            inimigo.SetActive(false);
        }
    }

    public void DanoRecebido()
    {
        VidaMudaTexto();
        vidaAtual -= Status.Instance.forcaAtual;
        VidaMudaTexto();
        tempoAtivar = true;
        VidaRegeneracao();
        VidaMudaTexto();
        slider.value = vidaAtual;
        MortePlayer();
    }

    public void VidaMudaTexto()
    {
        tmVidaAtul.text = ($"{Mathf.RoundToInt(vidaAtual).ToString()}/{vidaMaxima}");
    }

    private void Update()
    {
        
    }
}
