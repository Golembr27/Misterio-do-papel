using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public string biomaAtual = "";
    [SerializeField]public  string[] listaInimigo;
    [SerializeField] GameObject[] prefabInimigos;

    public void VerificarListaInimigo()
    {
        for (int i = 0; i < listaInimigo.Length; i++) 
        {
            if (listaInimigo[i] == StatusInimigo.Instance.nomeInimigo)
            {
                StatusInimigo.Instance.inimigoPrefab = prefabInimigos[i];
            }
        }
        
    }
}
