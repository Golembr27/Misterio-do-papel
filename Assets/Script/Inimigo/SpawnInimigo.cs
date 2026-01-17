using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public static SpawnInimigo Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject prefabInimigos;
    public string spawnInimigo = "";
    [SerializeField] GameObject spawnTransform;
    public int spawnQuantidade = Random.Range(2,3);

    public string nomoDoBioma = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < spawnQuantidade; i++) 
            {
                GameObject spawnar = Instantiate(prefabInimigos, spawnTransform.transform.position, Quaternion.identity);
            }
        }
    }
}
