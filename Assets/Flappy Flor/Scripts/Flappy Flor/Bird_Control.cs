using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bird_Control : MonoBehaviour
{
    public float JumpForce;
    public bool IsJump;
    public static bool morreu;

    private Rigidbody2D _rig;
    public bool cortarControle;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        InputTeclado();
        InputMouse();
        
        
    }
    void InputMouse()
    {
        if (Input.GetMouseButton(0))
        {
            IsJump = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsJump = false;
        }
    }
    void InputTeclado()
    {
        if(cortarControle == true){
            return;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            IsJump = true;
        }
        else
        {
            IsJump = false;
        }
        
    }

    private void FixedUpdate()
    {
        if(IsJump == true)
        {
            Jump();
        }
    }   
    

    IEnumerator Normalizar()
    {

        yield return new WaitForSeconds(0.9f);
        _rig.DORotate(0, 1f);
    }

    void Jump(){
                    
         _rig.AddForce(Vector2.up * JumpForce * Time.fixedDeltaTime * 100, ForceMode2D.Impulse);
        return;
                
    }
   
    


}
