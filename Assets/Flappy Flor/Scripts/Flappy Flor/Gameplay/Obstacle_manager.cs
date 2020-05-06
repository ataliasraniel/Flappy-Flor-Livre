using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_manager : MonoBehaviour
{
    [Header("Spawner de Inimigos")]
    public GameObject dragao;
    public GameObject aguia;
    public GameObject arvore;

    public Vector3 posSpawn;
    public float tempoSpawn;
    public int chance;
    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnArvore());
    }
    public IEnumerator Spawn()
    {
        while (true)
        {
            posSpawn = new Vector3(posSpawn.x, Random.Range(0.5f, 5.3f), -1);
            tempoSpawn = Random.Range(3.5f, 4.9f);
            yield return new WaitForSeconds(tempoSpawn);
            chance = Random.Range(0, 3);
            SpawnarAguia();
            SpawnarDragao();
        }
        
    }
    private IEnumerator SpawnArvore(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.2f, 4.5f));
            Vector3 posArvore = new Vector3(8, -1.697567f, -1);
            Instantiate(arvore, posArvore, Quaternion.identity);
        }
    }
    void SpawnarDragao()
    {
        if(chance >= 2)
            {
                Instantiate(dragao, posSpawn, Quaternion.identity);
            }
        
    }
    void SpawnarAguia()
    {
        if(chance <= 1)
        {
            Instantiate(aguia, posSpawn, Quaternion.identity);
        }
        
    }
}
