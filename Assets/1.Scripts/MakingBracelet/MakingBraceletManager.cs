using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    public bool haveEmptyPlace;

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
        Debug.Log(haveEmptyPlace);


        
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
                     if(place.beads!=null) //만약 비즈 플레이스가 널이 아니다 즉 차여 있다마면  //그니까 이 근처에서 이제 
                     {
                        continue;
                     }
                    GameObject beadsPrefabClone = Instantiate(beadsPrefab);
                    beadsPrefabClone.GetComponent<Transform>().position = worldPoint;
                    beadsPrefabClone.GetComponent<Beads>(). SetBeads(beadsKey);
                    place.SetBeads(beadsPrefabClone.GetComponent<Beads>());
                    User.Instance.SubBeads(beadsKey);
                   
                    currentBeads.Add(beadsPrefabClone.GetComponent<Beads>());
                   

                    bool haveEmptyPlace = false; //이 근처지 근데 이 근처에서 뭔가 이프문으로 아 엑스 버튼에서 확인을 해야겠네 회수하는 function 
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
            
            
            
            //스크린좌표랑 월드좌표랑 완전 다르다 스크린좌표 맨 왼쪽 아래가 (0,0) 
            
        }
    }


   
    public void SelectedBeads(string beadsKey) //
    {
        this.beadsKey = beadsKey;
        beadsData = BeadsManager.Instance.GetBeadsData(beadsKey);


    }



}
