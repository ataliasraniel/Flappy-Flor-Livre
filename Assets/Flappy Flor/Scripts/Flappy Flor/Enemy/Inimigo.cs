using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Inimigo : MonoBehaviour
{
    public int HP;
    public GameObject deathFX;

    public void levarDano(int quantidade)
    {
        HP -= quantidade;
    }
    public void morrer()
    {
        GameObject efeitoClone = Instantiate(deathFX, transform.position, Quaternion.identity);
        CameraShake cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        cameraShake.Shake();        
        Destroy(gameObject);
    }
}
