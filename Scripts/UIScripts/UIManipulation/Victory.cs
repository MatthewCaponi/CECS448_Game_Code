using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<RectTransform>().localScale.x > .085f)
        {
            transform.localScale -= (new Vector3(5, 5, 0) * Time.deltaTime);
        }
                

        
        
    }
}
