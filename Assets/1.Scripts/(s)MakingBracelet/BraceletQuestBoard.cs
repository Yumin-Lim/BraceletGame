using UnityEngine.UI;
using UnityEngine;


public class BraceletQuestBoard : MonoBehaviour
{

    public Image thumImage;
    //   public TMP_Text titleText;

    public QuestData questForBraceletBoard;


    // Start is called before the first frame update

    public void OnclickedButton()
    {



            ShopQuestPreviewBoard.Instance.curradsBoardData = questForBraceletBoard;

            ShopQuestPreviewBoard.Instance.UpdatePreviewBoard();

            ShopQuestCanvas.Instance.Show();


        





        
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
