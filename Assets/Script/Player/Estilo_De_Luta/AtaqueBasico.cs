using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtaqueBasico : MonoBehaviour
{
    public static AtaqueBasico Instance;

    private void Awake()
    {
        Instance = this;
    }

    GameObject ataqueArea = default;

    public float danoBase;
    [SerializeField] bool ataque = false;

    public int quantidadeDeInimigo = 0;
    [SerializeField] string nomeDoInmigo;
    [SerializeField] GameObject[] listaInimigo;

    float tempoParaAtacar = 0.25f;
    [SerializeField] float vidaInimigo;
    [SerializeField] float tempo = 1;

    public List<string> listaDeInimigo = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        danoBase = Status.Instance.forcaAtual;
        ataqueArea = transform.GetChild(0).gameObject;
    }

    public void Atacar()
    {
        ataqueArea.SetActive(true);
        ataque = false;
        
    }

    public void ListaAdicionarInimigo()
    {
        quantidadeDeInimigo++;
        listaDeInimigo.Add(nomeDoInmigo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null & collision.CompareTag("inimigo"))
        {
            nomeDoInmigo = collision.name;
            BarraDeVidaInimigo barraDeVidaInimigo = collision.gameObject.GetComponent<BarraDeVidaInimigo>();
            barraDeVidaInimigo.DanoRecebido();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && ataque == true)
        {
            Atacar();
        }

        if (ataque == false)
        {
            tempo += Time.deltaTime;

            if(tempo >= tempoParaAtacar)
            {
                tempo = 0;
                ataque = true;
                ataqueArea.SetActive(false);
            }
        }
    }
}
