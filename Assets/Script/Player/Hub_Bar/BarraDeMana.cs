using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeMana : MonoBehaviour
{
    public static BarraDeMana Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool tempoAtivar = false;
    public float tempoTotal = 1f;
    public float tempoRestante;
    public bool regemAtivo = true;

    public float manaRegem;
    public float manaMaxima;
    public float manaAtual;
    public float manaGasto;

    public Slider slider;

    public TextMeshProUGUI tmManaAtul;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manaGasto = Status.Instance.manaGasto;
        manaAtual = Status.Instance.manaAtual;
        manaMaxima = Status.Instance.manaMaxima;
        manaRegem = Status.Instance.manaRegeneracao;
        manaAtual = manaMaxima;
        tempoRestante = tempoTotal;
        slider.maxValue = manaMaxima;
        slider.value = manaMaxima;
        ManaTextoMuda();
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
            ManaRegenera();
        }
    }

    private void ManaRegenera()
    {
        //ESSE VOID FAZ COM QUE CADA 1 SEGUNDO O JOGADOR REGENERE A QUANTIDADE DE MANA QUE ESTÀ NA VARIAVEL "manaRegem"
        //QUE ESTÁ NO SCRIPT STATUS.
        if (manaAtual >= manaMaxima)
        {
            tempoAtivar = false;
        }

        if (regemAtivo == true && manaAtual <= manaMaxima && tempoRestante < 0)
        {
            tempoRestante = 1f;
            manaAtual += manaRegem;
            slider.value = manaAtual;
            ManaTextoMuda();
        }
        if (manaAtual > manaMaxima)
        {
            manaAtual = manaMaxima;
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            manaAtual -= 5f;
            ManaTextoMuda();
            tempoAtivar = true;
            ManaRegenera();
            ManaTextoMuda();
            slider.value = manaAtual;
        }
    }

    public void ManaGasta()
    {
        ManaRegenera();
        Status.Instance.vidaAtual -= 5;
        ManaTextoMuda();
        slider.value = manaAtual;
    }

    public void ManaTextoMuda()
    {
        tmManaAtul.text = ($"{Mathf.RoundToInt(manaAtual).ToString()}/{manaMaxima}");
    }
}
