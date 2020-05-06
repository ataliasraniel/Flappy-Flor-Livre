using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControlle : MonoBehaviour
{

    public GameObject Obstacle1, Obstacle2;

    public float Speed;
    public float TimeToSpawn;
    public Vector3 Spawn1Pos, Spawn2Pos;
    
    // Start is called before the first frame update
    void Start()
    {
        //Obstacle1 = GameObject.FindGameObjectWithTag("obstacle1").GetComponent<
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
                
        
    }
    

    IEnumerator SpawnObstacle(){
        
        while(true){
            yield return new WaitForSeconds(TimeToSpawn);
            //Instantiate(Obstacle1, Spawn1Pos, Quaternion.identity);
            Instantiate(Obstacle2, Spawn2Pos, Quaternion.identity);
        }
    }
    
}
