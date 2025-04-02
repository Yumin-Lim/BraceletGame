using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;public class BraceletPlaceSys : MonoBehaviour
{
    public BeadsBoard[] beadsBoards;
    public string boardKey;

    public void Awake()
    {
    
    boardKey = User.Instance?.selectedBoardKey;
    

        OpenSelectedPanel();
    }

    public void OpenSelectedPanel()
    {
       
        for (int i = 0; i < beadsBoards.Length; i++)
        {
            if (beadsBoards[i].key == boardKey)
                beadsBoards[i].gameObject.SetActive(true);
            else
                beadsBoards[i].gameObject.SetActive(false);
        }
    }



    /*  void Start(
      {
          UpdateBraceletPlaces();
      }

      public void SetBoardKeSys(string boardKey)
      {
          this.boardKey = boardKey;
             User.Instance.selectedBoardKey = boardKey; 
           UserSelectedKey();
      UpdateBraceletPlaces();
      }
      void UserSelectedKey()
  {
      string selectedKey = User.Instance.selectedBoardKey;
      int foundIdx = System.Array.FindIndex(beadsBoards, b => b.key == selectedKey);

      if (foundIdx >= 0)
      {
          currentBoardIdx = foundIdx;
      }


  }



      private void Awake()
      {
          BeadsBoard[] bBoard = FindObjectsOfType<BeadsBoard>(true);//비활오하 되어있는것도 찾ㅡ다. 
          beadsBoards=bBoard.OrderBy(e => e.order).ToArray();

      }


  */

}

 
  
