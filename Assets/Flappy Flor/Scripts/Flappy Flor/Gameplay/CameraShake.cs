using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private Camera cameras;
    public float duracao = 0.25f;
    public int vibracao = 200;
    public float aleatoriedade = 60;
    public float forca = 1;
    public bool fadeOut = true;
    private void Start() {
        cameras = GetComponent<Camera>();
    }
    public void Shake(){
        cameras.DOShakePosition(duracao, forca, vibracao, aleatoriedade, fadeOut);
    }
}
