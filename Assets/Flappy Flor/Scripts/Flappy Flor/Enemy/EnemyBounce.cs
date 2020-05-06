using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    public CollisionHandler col;
    public Inimigo inimigo;
   private void OnCollisionEnter2D(Collision2D other) {
        inimigo = GetComponentInParent<Inimigo>();
        col = FindObjectOfType<CollisionHandler>();
        inimigo.morrer();
   }
}
