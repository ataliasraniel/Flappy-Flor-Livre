using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float Tempo;
    public float Rate;
    private void Start()
    {
        InvokeRepeating("SpawnaInimigo", Tempo, Rate);
    }



    public GameObject Inimigo1, Inimigo2;
    public int chanceMin, chanceMax;
    public int chance;
    private Vector2 LocalSpawn;
    public float AlturaMin, AlturaMax;
    void SpawnaInimigo()
    {
        chance = Random.Range(chanceMin, chanceMax);
        Rate = Random.Range(5, 7.6f);
        LocalSpawn = new Vector2(10, Random.Range(AlturaMin, AlturaMax));
        if (Bird_Control.morreu == true)
        {
            Destroy(this.gameObject);
        }
        if (chance == 0)
        {
            
            Instantiate(Inimigo1, LocalSpawn, Quaternion.identity);
        }
        else if(chance == 1)
        {

            Instantiate(Inimigo2, LocalSpawn, Quaternion.identity);
        }
        

    }
}
