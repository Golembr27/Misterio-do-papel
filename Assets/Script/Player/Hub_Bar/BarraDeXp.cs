using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeXp : MonoBehaviour
{
    public static BarraDeXp Instance;

    void Awake()
    {
        Instance = this;
    }

    public float xpAtual;
    public float xpMaxima;
    public float nivelAtual;
    public float nivelMaximo;

    public GameObject player;

    public Slider slider;

    public TextMeshProUGUI tmXpAtul;
    public TextMeshProUGUI tmNivelAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpAtual = Status.Instance.vidaAtual;
        xpMaxima = Status.Instance.vidaMaxima;
        nivelAtual = Status.Instance.nivelAtual;
        nivelMaximo = Status.Instance.nivelMaximo;
        xpAtual = 0;
        nivelAtual = 1;
        slider.maxValue = xpMaxima;
        slider.value = xpAtual;
        MudaTexto();
    }

    public void MudaTexto()
    {//Mathf.RoundToInt(xpAtual).ToString() É para mostra só números inteiros
        tmXpAtul.text = ($"{Mathf.RoundToInt(xpAtual).ToString()}/{xpMaxima}");
        tmNivelAtual.text = ($"{nivelAtual}");
        slider.maxValue = xpMaxima;
        slider.value = xpAtual;
    }

    public void MudarDeNivel()
    {
        if(xpAtual >= xpMaxima)
        {
            nivelAtual++;
            xpAtual = 0;
            xpMaxima += 10f;
            slider.value = 0;
            //slider.maxValue = xpMaxima;
            MudaTexto();
        }
    }

    public void XpRecebido()
    {

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            xpAtual += 5f;
            slider.value = xpAtual;
            MudaTexto();
            MudarDeNivel();
        }
    }
}
