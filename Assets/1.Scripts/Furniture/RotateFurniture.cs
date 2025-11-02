using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateFurniture : MonoBehaviour
{
    // Start is called before the first frame update
        void Start()
    {
        Button btn = GetComponent<Button>();
       btn.onClick.AddListener(OnClikedRotate);
    }

    void OnClikedRotate()
    {
        Furniture furniture = GetComponentInParent<Furniture>();
        furniture.OnClickedRotate();

        
    }
}
