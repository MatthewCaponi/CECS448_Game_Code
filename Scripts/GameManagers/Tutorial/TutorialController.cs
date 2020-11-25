using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    [SerializeField] string[] texts;
    [SerializeField] TextMeshProUGUI bubble;
    [SerializeField] GameObject pressEnter;
    [SerializeField] KeyCode [] keyCodes;
    [SerializeField] int level;
    [SerializeField] GameObject startingCloud;

    bool started = false;
    bool endDialog = false;

    bool moveOn = false;
    private bool flyAway = false;
    private bool flyDown = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(TextLoop());
        if (endDialog && !moveOn)
        {
            moveOn = true;
            
            switch (level)
            {
                case 1:
                    flyAway = true; ;
                    break;
                case 2:
                    flyDown = true;
                    break;
            }
        }
    }

    private void Update()
    {
        if (flyAway)
        {
            startingCloud.transform.position += new Vector3(0, (10 * Time.deltaTime), 0);
            Invoke("Scene1", 1.5f);
        }
        else if (flyDown)
        {
            startingCloud.transform.position += new Vector3(0, (-10 * Time.deltaTime), 0);
            Invoke("Scene2", 1.5f);
        }
    }



    IEnumerator TextLoop()
    {
        if (!started)
        {
            started = true;
            int k = 0;
            for (int i = 0; i < texts.Length; i++)
            {
                if (i == 0)
                {
                    pressEnter.SetActive(true);
                }

                bubble.text = texts[i].ToString();
                Debug.Log(texts[i].ToString());
                Debug.Log(i);
                Debug.Log(texts.Length);
                
                
                yield return StartCoroutine(WaitForKeyDown(keyCodes[i]));
            }

            endDialog = true;

        }
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(keyCode));
    }

    private void Scene1()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    private void Scene2()
    {
        SceneManager.LoadScene("MainGame2");
    }


}

