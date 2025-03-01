using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakingBraceletManager : MonoBehaviour
{
   
   
   
    public BeadsData beadsData;
    public GameObject beadsPrefab;
    public string beadsKey;

    public BeadsPlace[] beadsPlaces;

    public MakeBraceletButton makeBraceletButton;
    
    public List<Beads> currentBeads = new List<Beads>();

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //비즈객체를 담을 수 있는 리스트를 선언하고 생성해주새요.
    //스크립트가 결국 컴포넌트가 되어서 어떻게 동작하는지 생각하는게 중요하다.
    // Update is called once per frame
    void Update() //11/19
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(string.IsNullOrEmpty(beadsKey) == true) 
            {
                return;
            }
            
        User user = User.Instance;
        //List<UserBeads> userBeads = user.userBeads;

        UserBeads userBeadsGet = user.GetUserBeads(beadsKey);

        
        if(userBeadsGet.count <=0)
        {
            Debug.Log("no more beads ");
        }
        else //Q1 왜 누를때마다 no more beads 나오는지
        {
            Vector2 screenPoint = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint);
            //유니티가 제공하는 함수로 클릭한 위치에 충돌 가능한게 있으면 일단 가져와서 처리를 할 수 있게 
            //일단 콜라이더가 있다면 그걸 골라와야하는데 그걸 할 수 있게 일단 
            //클릭한좌표가 

            if(cols.Length<=0) //아무데나 누름 
            {
                return;
            }

            for (int i=0 ; i<cols.Length;i++)
            {
                if(cols[i].tag=="BeadsPlace")
            
                {

                    Debug.Log("in the spot");
                    BeadsPlace place = cols[i].gameObject.GetComponent<BeadsPlace>();
                     if(place.beads!=null)
                     {
                        continue;
                     }
                    GameObject beadsPrefabClone = Instantiate(beadsPrefab);
                    beadsPrefabClone.GetComponent<Transform>().position = worldPoint;
                    beadsPrefabClone.GetComponent<Beads>(). SetBeads(beadsKey);
                    place.SetBeads(beadsPrefabClone.GetComponent<Beads>());
                    User.Instance.SubBeads(beadsKey);
                   
                    currentBeads.Add(beadsPrefabClone.GetComponent<Beads>());
                   

                    bool haveEmptyPlace = false;
                    for(int j=0; j<beadsPlaces.Length;j++)
                    {
                       if(beadsPlaces[j].beads==null)
                       {
                            haveEmptyPlace=true;
                            break;
                       }

        
                    }
                    if(haveEmptyPlace==false)
                    {
                        makeBraceletButton.gameObject.SetActive(true);
                    }
                   else
                   {
                     makeBraceletButton.gameObject.SetActive(false);
                   }
                   
                   
                   
                    break;
                }
                
            }

            Debug.Log("screenPoint: "+ screenPoint); //스크린 위치 
            Debug.Log("worldPoint: "+ worldPoint); //클릭한위치

                
        
        
        
        }



        //Q3 왜 아래처럼 하면 안되는지 
           /* if(User.Instance.userBeads.Count>0) 리트 갯수이다
            {
                
            Vector2 screenPoint = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            Debug.Log("screenPoint: "+ screenPoint);
            Debug.Log("worldPoint: "+ worldPoint);

            GameObject beadsPrefabClone = Instantiate(beadsPrefab);

            beadsPrefabClone.GetComponent<Transform>().position = worldPoint;
            beadsPrefabClone.GetComponent<Beads>(). SetBeads(beadsKey);

            User.Instance.SubBeads(beadsKey);//11/19
            
            }
            if(User.Instance.userBeads.Count<=0)
            {
                Debug.Log("no more beads ");
            }

            return;*/
        //비즈 없을때 비즈 안나오게 숫자도 소모하면 줄어들고 !!
        //다시 만들기 버튼누르면 창위에 모든 비즈 회수하고 ui 갱신 



            
            
            
            //스크린좌표랑 월드좌표랑 완전 다르다 스크린좌표 맨 왼쪽 아래가 (0,0) 
            
        }
    }


   
    public void SelectedBeads(string beadsKey) //
    {
        this.beadsKey = beadsKey;
        beadsData = BeadsManager.Instance.GetBeadsData(beadsKey);


    }



}
