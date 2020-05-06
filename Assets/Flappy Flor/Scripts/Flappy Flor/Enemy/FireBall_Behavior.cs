using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Behavior : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(this.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
