using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    
    private float velocidade = 3;
    public GameObject efeito;
    private void Start()
    {
        Destroy(gameObject, 10);   
    }

    private void Update() 
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);    
    }
    //COLISÃO
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "player")
        {
            Game_AudioController audio = FindObjectOfType<Game_AudioController>().GetComponent<Game_AudioController>();
            audio.MoedaPickUp();
            GameObject efeitoClone = Instantiate(efeito, transform.position, Quaternion.identity);
            FindObjectOfType<Moedas_controller>().GanhaMoedas(1);
            FindObjectOfType<Game_UI_controller>().atualizaContador();
            Destroy(gameObject);
        }
    }
}
