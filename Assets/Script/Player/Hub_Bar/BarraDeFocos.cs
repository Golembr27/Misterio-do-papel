using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeFocos : MonoBehaviour
{
    public static BarraDeFocos Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool tempoAtivar = false;
    public float tempoTotal = 1f;
    public float tempoRestante;
    public bool regemAtivo = true;

    public float focosRegem;
    public float focosMaxima;
    public float focosAtual;
    public float focosGasto;

    public Slider slider;

    public TextMeshProUGUI tmManaAtul;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        focosGasto = Status.Instance.focosGasto;
        focosAtual = Status.Instance.focosAtual;
        focosMaxima = Status.Instance.focosMaxima;
        focosRegem = Status.Instance.focosRegeneracao;
        focosAtual = focosMaxima;
        tempoRestante = tempoTotal;
        slider.maxValue = focosMaxima;
        slider.value = focosMaxima;
        FocosTextoMuda();
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
            FocosRegenacao();
        }
    }

    private void FocosRegenacao()
    {
        //ESSE VOID FAZ COM QUE CADA 1 SEGUNDO O JOGADOR REGENERE A QUANTIDADE DE MANA QUE ESTÀ NA VARIAVEL "manaRegem"
        //QUE ESTÁ NO SCRIPT STATUS.
        if (focosAtual >= focosMaxima)
        {
            tempoAtivar = false;
        }

        if (regemAtivo == true && focosAtual <= focosMaxima && tempoRestante < 0)
        {
            tempoRestante = 1f;
            focosAtual += focosRegem;
            slider.value = focosAtual;
            FocosTextoMuda();
        }
        if (focosAtual > focosMaxima)
        {
            focosAtual = focosMaxima;
        }
    }

    public void FocosGasta()
    {
        focosAtual -= 5f;
        FocosTextoMuda();
        tempoAtivar = true;
        FocosRegenacao();
        FocosTextoMuda();
        slider.value = focosAtual;
    }

    public void FocosTextoMuda()
    {
        tmManaAtul.text = ($"{Mathf.RoundToInt(focosAtual).ToString()}/{focosMaxima}");
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            focosAtual -= focosGasto;
            FocosTextoMuda();
            tempoAtivar = true;
            FocosRegenacao();
            FocosTextoMuda();
            slider.value = focosAtual;
        }
    }
}
