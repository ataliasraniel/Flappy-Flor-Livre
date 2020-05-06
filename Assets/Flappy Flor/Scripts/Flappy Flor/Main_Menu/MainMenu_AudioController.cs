using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_AudioController : MonoBehaviour
{
    [Header("Efeitos Sonoros")]
    public AudioSource audioSource;
    public AudioClip somClick;
    public AudioClip somCancela;
    public AudioClip somComprou;
    public AudioClip somSkin;
    

    public void SomInteragir(){
        audioSource.PlayOneShot(somClick);
    }
    public void Cancela(){
        audioSource.PlayOneShot(somCancela);
    }
    public void Comprou(){
        audioSource.PlayOneShot(somComprou);

    }
    public void Skin(){
        audioSource.PlayOneShot(somSkin);
    }
}
