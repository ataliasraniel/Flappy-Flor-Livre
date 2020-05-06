using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour
{
    public GameObject deathFX;
    private Game_controller game_Controller;
    private void Start() {
        game_Controller = FindObjectOfType<Game_controller>();
    }
    public void Morte(){
        
        Game_AudioController audio = FindObjectOfType<Game_AudioController>().GetComponent<Game_AudioController>();
        audio.Explosao();
        CameraShake cameraShake = GameObject.FindObjectOfType<Camera>().GetComponent<CameraShake>();
        cameraShake.Shake();
        Instantiate(deathFX, this.transform.position, Quaternion.identity);
        game_Controller.abrirMenu();
        Destroy(this.gameObject);
    }

    
}
