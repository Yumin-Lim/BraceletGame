using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveFurniture : MonoBehaviour
{
    //Furniture 컴포넌트 

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
       btn.onClick.AddListener(OnClikedRemove);
    }

    void OnClikedRemove()
    {
        Furniture furniture = GetComponentInParent<Furniture>();
        furniture.OnclikedRemove();

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
