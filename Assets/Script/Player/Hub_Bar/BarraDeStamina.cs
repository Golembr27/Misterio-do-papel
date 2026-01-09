using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeStamina : MonoBehaviour
{
    public static BarraDeStamina Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool podeCorrer = true;
    public float velocidadeAnterior;
    public float velocidadeAtual;

    public bool tempoAtivar = false;
    public float tempoTotal = 1f;
    public float tempoRestante;
    public bool regemAtivo = true;

    public float staminaRegem;
    public float staminaMaxima;
    public float staminaAtual;
    public float staminaGasto;

    public Slider slider;

    public TextMeshProUGUI tmManaAtul;
    
    void Start()
    {
        staminaGasto = Status.Instance.staminaGasto;
        velocidadeAtual = Status.Instance.velocidadeAtual;
        staminaAtual = Status.Instance.staminaAtual;
        staminaMaxima = Status.Instance.staminaMaxima;
        staminaRegem = Status.Instance.staminaRegeneracao;
        staminaAtual = staminaMaxima;
        tempoRestante = tempoTotal;
        slider.maxValue = staminaMaxima;
        slider.value = staminaMaxima;
        StaminaTextoMuda();
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
            StaminaRegeneracao();
        }
    }

    private void StaminaRegeneracao()
    {
        //ESSE VOID FAZ COM QUE CADA 1 SEGUNDO O JOGADOR REGENERE A QUANTIDADE DE MANA QUE ESTÀ NA VARIAVEL "manaRegem"
        //QUE ESTÁ NO SCRIPT STATUS.
        if (staminaAtual >= staminaMaxima)
        {
            tempoAtivar = false;
        }

        if (regemAtivo == true && staminaAtual <= staminaMaxima && tempoRestante < 0)
        {
            tempoRestante = 0.5f;
            staminaAtual += staminaRegem;
            slider.value = staminaAtual;
            StaminaTextoMuda();
        }
        if(staminaAtual > staminaMaxima)
        {
            staminaAtual = staminaMaxima;
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaAtual >= 0 && tempoRestante > 0)
        {
            if (podeCorrer == true)
            {
                velocidadeAnterior = Status.Instance.velocidadeMaxima;
                podeCorrer = false;
                velocidadeAtual = 8f;
                Status.Instance.AtualizarStatusVelocidade();
                staminaAtual -= 2f;
                StaminaTextoMuda();
                tempoAtivar = true;
                StaminaRegeneracao();
                StaminaTextoMuda();
                slider.value = staminaAtual;
                StaminaAcabou();
            }
        }
        else if ( velocidadeAtual == 8f || staminaAtual < 0)
        {
            if(staminaAtual < 0)
            {
                StaminaAcabou();
            }
            podeCorrer = true;
            velocidadeAtual = velocidadeAnterior;
            Status.Instance.AtualizarStatusVelocidade();
        }
    }

    public void StaminaAcabou()
    {
        if (staminaAtual <= 0) 
        {
            podeCorrer = false;
            velocidadeAtual = 2.5f;
            Status.Instance.AtualizarStatusVelocidade();
        }
    }

    public void StaminaTextoMuda()
    {
        tmManaAtul.text = ($"{Mathf.RoundToInt(staminaAtual).ToString()}/{staminaMaxima}");
    }
}
