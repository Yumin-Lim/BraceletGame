using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class MakeBraceletButton : MonoBehaviour
{
  // Start is called before the first frame update

  public static MakeBraceletButton Instance;
  public GameObject completCanvas;

  public BeadsPlace[] beadsPlaces;

  public bool isThisSpecial = false;


  [SerializeField]
  public int countBeads;
  public string key;
  // 이거 받아서 나중에 비교할때 쓰면 좋을 것 같음 
  //근데 이렇게 하면 각각 비즈들 카운트랑 키를 어떻게 관리하지...?
  //딕셔너리를 쓰라는데 모르겠다 
  //아니면 그냥 user beads 랑 비교하면 되는거 아닌지..?
  List<string> beadsKeys = new List<string>();
  List<SetUpBeads> setUpBeads = new List<SetUpBeads>();
  public List<Beads> currentBeads;

  public List<QuestData> userQuestList = new List<QuestData>(); //이거보이게 하려면 어떻게 하더라



  //설정된 비즈들의 비율 등 이 여기 있으니까.

  //퀘스트팔찌인지
  //프리셋 팔찌인지
  //자유모드인지 

  public void Awake()
  {
    Instance = this;
    userQuestList = User.Instance.userData.userQuestList;
    currentBeads = MakingBraceletManager.Instance.currentBeads;

    Debug.Log(userQuestList);
  }
  string braceletKey;
  public void OnClickedButton()
  {


    //capture component 의 OnCapture 함수를 호출해야하는 곳
    braceletKey = DateTime.Now.ToString("yyyyMMddHHmmss");
    Capture.Instance.OnCapture(braceletKey, AfterCapture);





    //얘를 통해 캡쳐를 딴다
    //그리고 캡쳐된 이미지 파일의 이름을 설정하고
    //그 이름이 키 값으로 
    //팔찌 현재 상황에 맞게 이름을 설정해야하는데 흠
  }
  //빨간색을 세었으면 빼야하는데 !
  //빨간색이 먼지 세는거 -> 빨간색만 세고 그게 역할 끝

  void AfterCapture()
  {
    CheckQuest();

  }


  void CheckQuest()
  {
    Debug.Log("퀘스트모드 진입");


    if (userQuestList.Count == 0)
    {
      FreeMode();
      return;
    }

    BraceletData makeBraceletData = null;
    currentBeads = MakingBraceletManager.Instance.currentBeads;
    int beadsPlaceCount = BeadsBoard.Instance.beadsPlaces.Length;

    int count = BeadsBoard.Instance.beadsPlaces.Length;


    for (int i = 0; i < userQuestList.Count; i++)
    {
      Debug.Log("f1");
      bool isSame = true;

      for (int j = 0; j < userQuestList[i].beadsPlaceCorrects.Length; j++)
      {
        Debug.Log("f2");
        int questIndex = userQuestList[i].beadsPlaceCorrects[j].index;
        string questKey = userQuestList[i].beadsPlaceCorrects[j].beadKey;

        BeadsPlace bp = BeadsBoard.Instance.beadsPlaces[questIndex];

        if (bp.beads == null)
        {
          Debug.Log("f3");
          isSame = false;
          break;
        }

        string currentKey = bp.beads.beadsKey;

        if (currentKey != questKey)
        {
          Debug.Log("f4");
          isSame = false;
          break;
        }
      }

      if (isSame)
      {


        User.Instance.userData.userQuestList.Remove(userQuestList[i]);
        User.Instance.DailyQuestCounter();
        //이게 닫기 버튼 누른 후에 반영된다 왜지 
        //User.Instance.AddBracelet(1);
        //그리고 이제 여기서 퀘스트 보드 업데이트 
        // QuestComp.Instance.data(userQuestList[i]); 아진짜 뭐냐 이거 어쩌지 

        BraceletQuestView.Instance.questBoardUpdate();
        User.Instance.AddExp(1);

        CompleteBraceletCanvas.flag = true;
        CompleteBraceletCanvas completeBraceletCanvas = completCanvas.GetComponent<CompleteBraceletCanvas>();
        completeBraceletCanvas.OpenCompleteQuest(braceletKey);



        return;
      }
    }
    FreeMode();
  }



  public void CheckPrest()
  {
    Debug.Log("프리셋 모드 진입");
    beadsKeys.Clear();
    setUpBeads.Clear();

    UserBracelet userBracelet = User.Instance.GetUserBracelet(key);

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







      //User.Instance.AddBracelet(userBracelet.userBeadsPlaceDatas, userBracelet.boardKey);
      //팔찌 데이터 추가 
      //팔찌를 가지고 있는게 0 일때 아래가 실행이 안되니까 문제
      //그 후 해야할 일은 
      //씬상에 보이는 비즈를 안보이게 처리 왜냐면 만들었으니까.

      User.Instance.AddExp(1);


      //위를 가져온다고 아래는 다른것
      CompleteBraceletCanvas completeBraceletCanvas = completCanvas.GetComponent<CompleteBraceletCanvas>();




      gameObject.SetActive(false);

    }
    else
    {
      FreeMode();
    }





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
  }

  public void FreeMode()
  {

    Debug.Log("프리모드 진입");

    UserBeadsPlaceData[] userBeadsPlaceDatas = new UserBeadsPlaceData[MakingBraceletManager.Instance.beadsBoard.beadsPlaces.Length];
    for (int i = 0; i < userBeadsPlaceDatas.Length; i++)
    {
      userBeadsPlaceDatas[i] = new UserBeadsPlaceData();
      userBeadsPlaceDatas[i].beadsKey = MakingBraceletManager.Instance.beadsBoard.beadsPlaces[i].beads.beadsKey;
      userBeadsPlaceDatas[i].index = i;



    }

    User.Instance.AddBracelet(braceletKey, userBeadsPlaceDatas, MakingBraceletManager.Instance.beadsBoard.key);
    User.Instance.AddExp(1);
    //그리고 이제 여기서 퀘스트 보드 업데이트 
    CompleteBraceletCanvas completeBraceletCanvas = completCanvas.GetComponent<CompleteBraceletCanvas>();
    completeBraceletCanvas.OpenCompleteFreeMode(braceletKey);







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
