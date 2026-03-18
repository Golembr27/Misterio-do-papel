using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public static Inventario Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject spawnParent;
    [SerializeField] bool podeAtivarOParent = false;
    public GameObject inventario;
    [SerializeField] bool podeAtivarOMenu = false;

    [SerializeField] private GameObject slotAtual;
    [SerializeField] private int slotNum = 0;
    [SerializeField] private int listNum = 0;
    public string nomeDoItem = "";
    private Transform buscaSlot;
    private GameObject spawnItem;
    [SerializeField] GameObject[] listaPrefab;
    [SerializeField] Transform[] listaTransformSlot;

    [SerializeField] private Transform invetarioTransform;

    [SerializeField] private List<string> listaDeItems = new List<string>();

    [SerializeField] private Canvas canvas;

    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        inventario.SetActive(false);
    }

    public void SlotSelecao()
    {
        if(slotNum <= 14 && listaTransformSlot.Length > slotNum)
        {
            buscaSlot = listaTransformSlot[slotNum];
            slotNum++;
            AdicionarItem();
        }
    }

    public void ListaAdicionarItem()
    {
        if(listaDeItems.Count <= 14)
        {
            listNum++;
            listaDeItems.Add(nomeDoItem);
        }
    }

    public void AdicionarItem()
    {
        // Itera pela lista para encontrar o prefab com nome igual a nomeDoItem
        for (int i = 0; i < listaPrefab.Length; i++)
        {
            if (listaPrefab[i] != null && listaPrefab[i].name == nomeDoItem)
            {
                spawnItem = Instantiate(listaPrefab[i], buscaSlot.position, Quaternion.identity);
                spawnItem.transform.SetParent(spawnParent.transform);
                spawnItem.transform.localScale = new Vector3(2f, 2f, 2f);
                return;  
            }
        }
        Debug.LogError("Nenhum prefab com nome '" + nomeDoItem + "' encontrado na lista!");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("item"))
        {
            nomeDoItem = collision.gameObject.name;
            if (listaDeItems.Count <= 14)
            {
                ListaAdicionarItem();
                SlotSelecao();
                Destroy(collision.gameObject);
                return;
            }
        }
    }

    public void MenuAtivo()
    {
        podeAtivarOMenu = !podeAtivarOMenu;
        inventario.SetActive(podeAtivarOMenu);
        spawnParent.SetActive(podeAtivarOMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MenuAtivo();
        }
    }
}
