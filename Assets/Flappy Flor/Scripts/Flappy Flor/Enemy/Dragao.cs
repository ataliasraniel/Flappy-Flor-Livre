using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragao : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade;
    public int vida;
    private Inimigo inimigo;
    public float frequencia;
    public float magnitude;

    [Header("IA")]
    public float TempoAtq;
    public GameObject fogo;
    public GameObject fumaca;
    public Transform localAtaq;
    void Start()
    {
        inimigo = GetComponent<Inimigo>();
        vida = inimigo.HP;
        Destroy(gameObject, 12);
        StartCoroutine(Ataque1());

    }
    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        MoverWave();
    }
    void MoverWave()
    {
        Vector3 pos = this.transform.position;
        this.transform.position = pos + transform.up * Mathf.Sin(Time.time * frequencia) * magnitude;
    }
    IEnumerator Ataque1()
    {
        while (true)
        {
            yield return new WaitForSeconds(TempoAtq);
            CriarFogo();
        }
        
        
    }
    private void CriarFogo()
    {
        Instantiate(fumaca, localAtaq.transform.position, Quaternion.identity);
            Instantiate(fogo, localAtaq.transform.position, Quaternion.identity);
        
        
    }
    

}

