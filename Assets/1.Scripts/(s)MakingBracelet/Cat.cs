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

    //자동으로 애니메이션 들어가게 하려면?
    public Transform catPos; //목적지

    public Transform bodyTr;


    //목적지가 설정되면
    //body 게임 오브젝트의 scale x 값을 1혹은 -1로 설정하기 
    public float waitTimer;
    void Start()
    {


        bodyTr = transform.Find("Body");
        catPos = CatMaker.Instance.GetTransformPosition();
        SetDirection();

        moving = true;

    }
    bool moving;


    void SetDirection()
    {
        //목적지 설정
        if (catPos.position.x > transform.position.x) //오른쪽으로 간다
        {
            //하위 중 바디
            bodyTr.localScale = new Vector3(-1, 1, 1);
        }
        else
        {

            bodyTr.localScale = new Vector3(1, 1, 1);
        }
    }

    void IdleMoving()
    {
        CatPosition catPosition = catPos.GetComponent<CatPosition>();
        CatAnimation randomAnim = catPosition.catAnimations[Random.Range(0, catPosition.catAnimations.Length)];

        animator.Play(randomAnim.ToString());
        waitTimer = 10;
    }
    void RunMoving()
    {
        transform.position = Vector2.MoveTowards(transform.position, catPos.position, speed * Time.deltaTime);
        animator.Play("Run");
        float distance = Vector2.Distance(transform.position, catPos.position);
        if (distance < 0.1f) //목적지에 도착함
        {
            IdleMoving(); //목적지에 도착했을때 지정된 애니메이션
                          //판별시점
                          //그 위치가 어딘지 catposition.

            moving = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moving) //움직이는 상태 
        {
            RunMoving();

        }
        else //움직이지 않고 있음
        {
            if (waitTimer <= 0) //10초가 지났다
            {
                NextPosition();//목적지 설정

            }
            waitTimer -= Time.deltaTime;
        }

    }
    void NextPosition()
    {
        CatMaker.Instance.canSelectPositions.Add(catPos);
        catPos = CatMaker.Instance.GetTransformPosition();
        SetDirection();

        moving = true;
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
    //고양이의 행동에 따라서 달라지게 처리해야한다!

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

        else if (Time.time > 20f)
        {
            transform.position += Vector3.right * speed * 1.5f * Time.deltaTime;
            animator.Play("Jump");
        }

        else if (Time.time > 25f)
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
