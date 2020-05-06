using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollisionHandler : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int lives;
    public float forcaPulo;
    private Bird_Control _birdControl;
    private PlayerLifeSystem _lifeSystem;

    private void Start() {
        _lifeSystem = GetComponent<PlayerLifeSystem>();
        _rb = GetComponent<Rigidbody2D>();
        _birdControl = GetComponent<Bird_Control>();
    }
    private void Update() {
        
    }
    private void FixedUpdate() {
        
    }
    private void Rodar(){
        _rb.AddForce(Vector2.up * forcaPulo * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        _rb.DORotate(-360, 1f);
        
    }
    private IEnumerator CortaControle(){
        _birdControl.cortarControle = true;
        yield return new WaitForSeconds(0.5f);
        _birdControl.cortarControle = false;
    }
    #region COLISÕES

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 10){
            lives--;
            if(lives <=0)
            {
                _lifeSystem.Morte();
            }
       }
        if(other.gameObject.CompareTag("fogo"))
        {
            _lifeSystem.Morte();
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 11){
           StartCoroutine(CortaControle());           
            Rodar();
       }
    }
    
    
    #endregion
}
