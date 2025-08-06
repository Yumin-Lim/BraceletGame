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

    public AnimationClip[] christmasCatAni;
//자동으로 애니메이션 들어가게 하려면?
    public Transform catPos;

    void Start()
    {
        catPos = CatMaker.Instance.GetTransformPosition();

    }






    // Update is called once per frame
    void Update()
    {
        //캣포지션중 하나를 뽑아서 하나를 랜덤하게 
        //그쪽으로 이동하면
        //다시 다른 위치를 뽑아서 이동 시키게 반복한다 



        transform.position = Vector2.MoveTowards(transform.position, catPos.position, speed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, catPos.position);
        if (distance < 0.1f)
        {
            CatMaker.Instance.canSelectPositions.Add(catPos);
            catPos = CatMaker.Instance.GetTransformPosition();



        }



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
        //걷기/뛰기/앉기
        //걸었다가-뛰었다가-앉았다가-잔다.

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
            animator.Play("idle");

        }

        if (Time.time > 10f)
        {
            animator.Play("Run");
        }

        if (Time.time > 15f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            animator.Play("Run");
        }
      
        else if ( Time.time> 20f)
        {
            transform.position += Vector3.right * speed * 1.5f * Time.deltaTime;
            animator.Play("Jump");
        }

        else if (Time.time >25f)
        {
            animator.Play("Sit");
        }
       
      else
       {
          animator.Play("Sleep");
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
