using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Behavior : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obstacleBH();
        DestroyObj();
    }

    void obstacleBH(){
        this.transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
    void DestroyObj(){
        if(this.transform.position.x <= -12){
            Destroy(this.gameObject);
        }
    }
}
