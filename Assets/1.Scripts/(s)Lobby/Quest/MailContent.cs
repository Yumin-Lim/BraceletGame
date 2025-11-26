using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailContent : MonoBehaviour
{
    
  public MailContentData[] data = new MailContentData[]
    {
        new MailContentData { id = 0, text = "안녕" },
        new MailContentData { id = 1, text = "반가워" },
        new MailContentData { id = 2, text = "테스트" }
    };

       public string GetText(int id)
    {
        foreach (var item in data)
        {
            if (item.id == id)
                return item.text;
        }
        return "없음";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


 