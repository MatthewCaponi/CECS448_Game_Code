using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    private GameObject score;
    private Vector3 scale;
    public ScoreItem(GameObject score)
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += (new Vector3(.02f, .02f, 0) * Time.deltaTime);
    }

    public void TimeDestruction()
    {
        Invoke("DestroyScoreItem", .5f);
    }

    private void DestroyScoreItem()
    {
        Destroy(gameObject);
    }
}
