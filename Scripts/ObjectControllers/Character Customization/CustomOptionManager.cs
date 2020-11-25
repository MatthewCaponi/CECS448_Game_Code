using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.HeroEditor.Common.CharacterScripts;
using UnityEngine.SceneManagement;

public class CustomOptionManager : MonoBehaviour
{
    Stack<Object> leftStack;
    Stack<Object> rightStack;
    Sprite currentCustom;
    [SerializeField] public GameObject custom;

    Object[] tempList;
    Object[] reverseList;
    Stack<Object> tempStorage;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI name;
    bool left;

    //private GameObject robot;
    // Start is called before the first frame update
    void Start()
    {
        GameCharacterManager.instance.CurrentCharacter = "Player Variant";
        print("here1");
        tempList = Resources.LoadAll("CharacterCustomize/" + title.text, typeof(Sprite));

        reverseList = new Object[tempList.Length];
        for (int i = tempList.Length - 1; i >= 0; --i)
        {
            reverseList[i] = tempList[(tempList.Length - 1) - i];
        }

        print("here2");

        leftStack = new Stack<Object>();
        rightStack = new Stack<Object>();
        for (int i = 0; i < tempList.Length; ++i)
        {

            leftStack.Push(tempList[i]);

            rightStack.Push(reverseList[i]);



        }
        print("Left Stack: " + leftStack.Count);
        print("Right Stack: " + rightStack.Count);

        tempStorage = new Stack<Object>();
        currentCustom = null;

        name.text = "Default";




        //  robot = GameObject.Find("LilRobotWhite");
    }

    // Update is called once per frame

    public void leftClick()
    {
        if (tempStorage.Count > 0)
        {
            rightStack.Push(tempStorage.Pop());

        }



        if (leftStack.Count > 0)
        {
            Sprite tempCustom = (Sprite)leftStack.Pop();
            custom.GetComponent<SpriteRenderer>().sprite = tempCustom;
            name.text = tempCustom.name;
            tempStorage.Push(tempCustom);
            currentCustom = tempCustom;
            print("Left Stack: " + leftStack.Count);
            print("Right Stack: " + rightStack.Count);
        }
        else
        {
            ReplenishStack();

            Sprite tempCustom = (Sprite)leftStack.Pop();
            custom.GetComponent<SpriteRenderer>().sprite = tempCustom;
            name.text = tempCustom.name;
            tempStorage.Push(tempCustom);
            currentCustom = tempCustom;
            print("Left Stack: " + leftStack.Count);
            print("Right Stack: " + rightStack.Count);
        }

        left = true;


    }

    public void rightClick()
    {
        if (tempStorage.Count > 0)
        {

            leftStack.Push(tempStorage.Pop());


        }
        else
        {
            leftStack.Push(rightStack.Pop());
        }


        if (rightStack.Count > 0)
        {
            Sprite tempCustom = (Sprite)rightStack.Pop();
            custom.GetComponent<SpriteRenderer>().sprite = tempCustom;
            name.text = tempCustom.name;
            tempStorage.Push(tempCustom);
            currentCustom = tempCustom;
            print("Left Stack: " + leftStack.Count);
            print("Right Stack: " + rightStack.Count);
        }
        else
        {
            ReplenishStack();
            Sprite tempCustom = (Sprite)rightStack.Pop();
            custom.GetComponent<SpriteRenderer>().sprite = tempCustom;
            name.text = tempCustom.name;
            tempStorage.Push(tempCustom);
            currentCustom = tempCustom;
            print("Left Stack: " + leftStack.Count);
            print("Right Stack: " + rightStack.Count);
        }

        left = false;

    }

    private void ReplenishStack()
    {

        leftStack.Clear();
        rightStack.Clear();

        for (int i = 0; i < tempList.Length; ++i)
        {
            leftStack.Push(tempList[i]);
        }



        for (int i = 0; i < reverseList.Length; ++i)
        {
            rightStack.Push(reverseList[i]);
        }

    }

    public void Submit()
    {
        //PlayerInfo.updateColor(currentColor);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
}
