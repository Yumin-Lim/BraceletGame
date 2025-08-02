using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    public string catKey;
    public float speed = 2f;

    public float position = 1;
    public Animator animator;

    public Animation[] christmasCatAni;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (catKey == "Christmas")
        {
            christmasCatMoving();
        }

        if (catKey == "Brown")
        {
            brownCatMoving();

        }

         if (catKey == "Black")
        {
            blackCatMoving();
            
        }




    }






    public void CatMovingPattern1()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (Time.time > 5f)
        {
            transform.position = new Vector3(0, 2, 0);
        }
    }

    public void christmasCatMoving()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (Time.time > 5f)
        {
            transform.position = new Vector3(0, position * 2, 0);
        }
        
         if (Time.time > 10f)
        {
           animator.Play("Christmas_Run");
        }
    }


    public void brownCatMoving()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

       
    }
    public void blackCatMoving()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

    }

}
