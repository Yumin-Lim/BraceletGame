using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CompleteBraceletCanvas : MonoBehaviour
{
  
    public Image thumImage;
    public TMP_Text nameText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedClose()
    {
        gameObject.SetActive(false);
      
       MakingBraceletManager mgr = FindObjectOfType<MakingBraceletManager>();
      // mgr.currentBeads
       for(int i = 0; i < mgr.currentBeads.Count; i++)
       {
            Destroy(mgr.currentBeads[i].gameObject);
       }  
       mgr.currentBeads.Clear();
       for(int i = 0;i<mgr.beadsPlaces.Length;i++)
       {
        mgr.beadsPlaces[i].beads = null;
       }
    }   
}
