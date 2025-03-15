using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq; //정리필요 

public class MakeBraceletButton : MonoBehaviour
{
  // Start is called before the first frame update


  public GameObject completCanvas;

  public BeadsPlace[] beadsPlaces;
  [SerializeField]
  public int countBeads;
  public string key;
  // 이거 받아서 나중에 비교할때 쓰면 좋을 것 같음 
  //근데 이렇게 하면 각각 비즈들 카운트랑 키를 어떻게 관리하지...?
  //딕셔너리를 쓰라는데 모르겠다 
  //아니면 그냥 user beads 랑 비교하면 되는거 아닌지..?
  List<string> beadsKeys = new List<string>();
  List<SetUpBeads> setUpBeads = new List<SetUpBeads>();
  //설정된 비즈들의 비율 등 이 여기 있으니까.

  public void OnClickedButton()
  {
    beadsKeys.Clear();
    setUpBeads.Clear();
    Debug.Log("on clicked1");

    MakingBraceletManager mgr = FindObjectOfType<MakingBraceletManager>();
    countBeads = 0;
    key = "";



    for (int i = 0; i < mgr.currentBeads.Count; i++) //모든비즈
    {
      SetUpBeads setUp = GetSetUpBeads(mgr.currentBeads[i].beadsKey);
      setUp.count++;

    }


    //비율을 생각하기 
    for (int i = 0; i < setUpBeads.Count; i++)
    {
      setUpBeads[i].rate = (float)setUpBeads[i].count / (float)mgr.currentBeads.Count;
      //정수 나누기 정수는 정수값 그럼 0나옴 그래서 float로 형변환 해준다 ~
      //1/10 은 정수 범위에선 0.1이 아니고 0이다 !
      //특정 색깔 주머니에 든 비즈를 씬상에 배치된 비즈로 나눈다.

    }

    BraceletData[] braceletDatas = BraceletManager.Instance.braceletDatas; //싹 참조하기 
                                                                           //Linq 정리 꼭 필요 !
    List<BraceletData> braceletList = braceletDatas.Where(e =>
    {

      for (int i = 0; i < e.braceletNeeds.Length; i++)
      {
        if (beadsKeys.Contains(e.braceletNeeds[i].beadsKey) == false)
        {
          return false;
        }
      }
      //e.braceletNeeds; //필요조건
      return true; //모든애가 다 선택? 찾아짐


    }).ToList(); //윗 과정을 해보니까 추려졌다 내가 만들 수 있는것만 이 리스트로 들어옴

    //여기서 이제 부합한것들을 찾기 이것도 정리 필요 문법 

    BraceletData makeBraceletData = null;
    for (int i = 0; i < braceletList.Count; i++)
    {
      for (int j = 0; j < braceletList[i].braceletNeeds.Length; j++)
      {
        SetUpBeads setUp = GetSetUpBeads(braceletList[i].braceletNeeds[j].beadsKey);
        //set up 이 10 이면 지금 보고있는 비즈의 갯수니까 

        //if(); 여기부터 시작! (12/3)
        //
        if (setUp.count < braceletList[i].braceletNeeds[j].count)
        {
          break; //
        }
        if (braceletList[i].braceletNeeds[j].count == 0)
        {
          if (setUp.rate < braceletList[i].braceletNeeds[j].rate)
          {
            break;
          }
        }
        makeBraceletData = braceletList[i];
        break;

      }
      if (makeBraceletData != null)
      {
        break;
      }
    }
    if (makeBraceletData != null) //이게 참이면
    {


      User.Instance.AddBracelet(makeBraceletData.key, 1);
      //팔찌 데이터 추가 
      //팔찌를 가지고 있는게 0 일때 아래가 실행이 안되니까 문제
      //그 후 해야할 일은 
      //씬상에 보이는 비즈를 안보이게 처리 왜냐면 만들었으니까.

        User.Instance.exp++;

      completCanvas.SetActive(true);
      //위를 가져온다고 아래는 다른것
      CompleteBraceletCanvas completeBraceletCanvas = completCanvas.GetComponent<CompleteBraceletCanvas>();
      completeBraceletCanvas.thumImage.sprite = makeBraceletData.thum;
      completeBraceletCanvas.nameText.text = makeBraceletData.name;

      gameObject.SetActive(false);
    }
    else
    {
      //현재 비즈로 만들 수 있는 팔찌가 없다.
    }


  }
  //빨간색을 세었으면 빼야하는데 !
  //빨간색이 먼지 세는거 -> 빨간색만 세고 그게 역할 끝




  SetUpBeads GetSetUpBeads(string beadsKey)
  {
    MakingBraceletManager mgr = FindObjectOfType<MakingBraceletManager>();
    SetUpBeads setUp = null;
    for (int j = 0; j < setUpBeads.Count; j++)
    {
      if (setUpBeads[j].key == beadsKey)
      {
        setUp = setUpBeads[j];
        break;
      }
    }

    if (setUp == null)
    {
      setUp = new SetUpBeads();
      setUp.key = beadsKey;
      setUpBeads.Add(setUp);
      beadsKeys.Add(beadsKey);
    }
    return setUp;

  }


  /*
  원래코드
    public BeadsPlace[] beadsPlaces;
  [SerializeField]
  public int countBeads;
  public string key;


  public void OnClickedButton()
  {
     MakingBraceletManager mgr =FindObjectOfType<MakingBraceletManager>();



     for (int i=0; i<mgr.currentBeads.Count;i++ )
     {
       int countBeads = 0;
       string key = mgr.currentBeads[i].beadsKey;

      for (int j = 0; j<mgr.currentBeads.Count;j++ )   
      {
        if(mgr.currentBeads[j].beadsKey== key)
        {
          countBeads++;
        }
      }  


     }

      Debug.Log(countBeads);
      Debug.Log(key);           
  }*/


  void Start()
  {
    beadsPlaces = FindObjectsByType<BeadsPlace>(FindObjectsSortMode.None);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public class SetUpBeads
  {
    public string key;
    public int count;
    public float rate;
  }





}
