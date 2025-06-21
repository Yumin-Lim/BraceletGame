using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class CompleteBraceletCanvas : MonoBehaviour
{
    public static CompleteBraceletCanvas Instance;
    
    
    public Image thumImage;
    public TMP_Text nameText;

   public List<QuestData> userQuestList = new List<QuestData>();

    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
    }
    void OnEnable()
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
       for(int i = 0;i<mgr.beadsBoard.beadsPlaces.Length;i++)
       {
        mgr.beadsBoard.beadsPlaces[i].beads = null;
       }
    }   
}
