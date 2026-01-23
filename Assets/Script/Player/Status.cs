using UnityEngine;

public class Status : MonoBehaviour
{
    public static Status Instance;

    void Awake()
    {

        Instance = this;
    }

    //ESTADO PLAYER
    public bool invocado = false;
    public bool rencarnado = false;
    public bool mortoVivo = false;
    public bool morto = false;
    public bool invenenado = false;
    public bool doente = false;
    public bool amaldicoado = false;
    public bool vivo = true;
    //STATUS PLAYER
    //TALENTO NATURAL (TAL RAÇA)
    public float talento;
    //NÍVEL DO PLAYER
    public int nivelMaximo = 25;
    public int nivelAtual = 1;
    //EXPERIENCIA NATURAL(EXP RAÇA)
    public float xpMaximo;
    public float xpAtual;
    //VELOCIDADE NATURAL(VEL RAÇA)
    public float velocidadeMaxima = 25f;
    public float velocidadeAtual;
    //VIDA NATURAL(VIDA RAÇA)
    public float vidaRegeneracao = 0.1f;
    public float vidaMaxima = 100f;
    public float vidaAtual;
    //MANA NATURAL(MANA RAÇA)
    public float manaRegeneracao = 0.5f;
    public float manaExtra;
    public float manaMaxima = 100f;
    public float manaAtual;
    public float manaGasto = 5f;
    //RESPIRAÇÃO(ESTAMINA)
    public float staminaRegeneracao = 0.5f;
    public float staminaExtra;
    public float staminaMaxima = 100f;
    public float staminaAtual;
    public float staminaGasto = 2f;
    //FOCOS NATURAL(MANA DE GUERREIRO)
    public float focosRegeneracao = 0.5f;
    public float focosExtra;
    public float focosMaxima = 120f;
    public float focosAtual;
    public float focosGasto = 5f;
    //DEFESA NATURAL(DEF DA RAÇA)
    public float defesaPele;
    //FORÇA NATURAL(FOR DA RAÇA)
    public float forcaMaxima;
    public float forcaAtual = 10f;
    //******************************

    //VIDA DO CORPO COMO PARTE SEPARADA
    //CABEÇA
    public float vidaCabecaMaxima;
    public float vidaCabecaAtual;
    //TRONCO
    public float vidaTroncoMaximo;
    public float vidaTroncoAtual;
    //BRAÇO ESQUERDO
    public float vidaBracoEsquerdoMaximo;
    public float vidaBracoEsquerdoAtual;
    //BRAÇO DIREITO
    public float vidaBracoDireitoMaximo;
    public float vidaBracoDireitoAtual;
    //PERNA ESUQERDA
    public float vidaPernaEsquerdaMaximo;
    public float vidaPernaEsquerdaAtual;
    //PERNA DIREITA
    public float vidaPernaDireitoMaximo;
    public float vidaPernaDireitoAtual;
    //******************************

    private void Start()
    {
        velocidadeAtual = velocidadeMaxima;
    }

    public void AtualizarStatusVelocidade()
    {
        velocidadeAtual = BarraDeStamina.Instance.velocidadeAtual;
        Movmentacao.Instance.velocidadeAtual = velocidadeAtual;
    }

    public void AtualizarXpDoPlayer()
    {
        BarraDeXp.Instance.xpAtual = xpAtual;
        BarraDeXp.Instance.MudaTexto();
    }
}
