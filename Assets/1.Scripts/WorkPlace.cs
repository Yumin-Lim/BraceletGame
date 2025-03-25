using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkPlace : MonoBehaviour
{
   public GameObject userBoardCanvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스를 누를때만 하도록 
        {

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPosition);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "WorkPlace")
                {
                    //씬전환 코드
                    
                    //SceneManager.LoadScene("MakingBracelet");
                     userBoardCanvas.SetActive(true);
                    
                }
            }
        }


        //
    }
}
