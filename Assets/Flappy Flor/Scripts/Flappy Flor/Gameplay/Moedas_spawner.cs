using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas_spawner : MonoBehaviour
{
    public GameObject moeda;
    [Range(0.5f, 2f)]
    public float tempoSpawn;    
    public Vector2 local;
    public float variacaoMin;
    public float variacaoMax;
    public bool parar;

    private void Start()
    {
        
        StartCoroutine(spawnarMoeda());
    }
    
    IEnumerator spawnarMoeda()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempoSpawn);
            instanciarMoedas();
            if(parar == true)
            {
                yield break;
            }
        }
        
    }

    private void instanciarMoedas()
    {
        local = new Vector2(local.x, Random.Range(variacaoMin, variacaoMax));
        GameObject moedaClone = Instantiate(moeda, local, Quaternion.identity);
    }

}
