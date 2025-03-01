using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    void Start()// 처음 시작에만 
    {
        
    }

   public Transform tr;
   public float moveSpeed ;
    void Update() //매 프레임
    {
        if (Input.GetKey(KeyCode.W))
        {
         tr.position = (Vector2)tr.position + new Vector2(0,1)* moveSpeed * Time.deltaTime;
        }
    
    }
}
