using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject inventario;
    [SerializeField] bool podeAtivarOMenu = false;
    public bool autoSafe = false;

    [SerializeField] private GameObject slotAtual;
    public int slotNum = 0;
    public int slotMaximo = 15;
    public Image buscaSlot;
    public string guardarCaminho;
    public string caminhoImagem = "imagem/item_inventario/";
    public string nomeDoItem = "";
    public string caminhoCompleto;

    public List<string> listaDeItens = new List<string>();

    private void Start()
    {
        
    }

    public void SlotSelecao()
    {
        if(autoSafe == true)
        {
            
            ListaVerificar();
        }
        if (slotNum == 0 || slotNum <= 14 && autoSafe == false)
        {
            slotNum++;
            buscaSlot = GameObject.Find($"slot_{slotNum}").GetComponent<Image>();
            Debug.Log($"{buscaSlot}");
            ImagemMuda();
        }
    }

    public void ListaAdicionarItem()
    {
        if(listaDeItens.Count <= 14)
        {
            listaDeItens.Add(nomeDoItem);
        }
        return;
    }

    public void ImagemMuda()
    {
        caminhoCompleto = $"{caminhoImagem}{nomeDoItem}";
        Sprite sprite = Resources.Load<Sprite>(caminhoCompleto);
        buscaSlot.sprite = sprite;
        ListaAdicionarItem();
        autoSafe = false;
    }

    public void MenuAtivo()
    {
        podeAtivarOMenu = !podeAtivarOMenu;
        inventario.SetActive(podeAtivarOMenu);
    }

    public void ListaVerificar()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("item"))
        {
            nomeDoItem = collision.gameObject.name;
            if(podeAtivarOMenu == true)
            {
                SlotSelecao();
            }else if (podeAtivarOMenu == false)
            {
                autoSafe = true;
                ListaAdicionarItem();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MenuAtivo();
        }
    }
}
