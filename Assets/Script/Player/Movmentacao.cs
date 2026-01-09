using UnityEngine;

public class Movmentacao : MonoBehaviour
{
    public static Movmentacao Instance;

    void Awake()
    {

        Instance = this;
    }
    public float velocidadeAtual;
    public float velocidadeMaxima;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadeAtual = Status.Instance.velocidadeAtual;
        velocidadeMaxima = Status.Instance.velocidadeMaxima;
        velocidadeAtual = velocidadeMaxima;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");


        rb.linearVelocity = new Vector3(movX * velocidadeAtual, movZ * velocidadeAtual); 
    }
}
