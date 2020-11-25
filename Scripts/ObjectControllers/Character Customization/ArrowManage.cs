using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowManage : MonoBehaviour
{
   
    Stack<Object> leftStack;
    Stack<Object> rightStack;
    Stack<Object> tempLeftStack;
    Stack<Object> tempRightStack;
    GameObject currentCharacter;
    [SerializeField] GameObject character;
    [SerializeField] GameObject parentCharacter;

    Object[] tempList;
    Object[] reverseList;
    Stack<Object> tempStorage;
    [SerializeField] TextMeshProUGUI title;
    bool left;


    //private GameObject robot;
    // Start is called before the first frame update
    void Start()
    {
        GameCharacterManager.instance.CurrentCharacter = "Player Variant";
        print("here1");
        tempList = Resources.LoadAll("Characters");

        reverseList = new GameObject[tempList.Length];
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
        currentCharacter = null; 

        
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
            print("here");
            GameObject tempCharacter = (GameObject) leftStack.Pop();
            print("changed color to : " + tempCharacter.name);
       
            

            Destroy(character);
            character = Instantiate(tempCharacter, parentCharacter.transform, false);
            character.transform.position = parentCharacter.transform.position;
            tempStorage.Push(tempCharacter);
            currentCharacter = tempCharacter;
            GameCharacterManager.instance.CurrentCharacter = tempCharacter.name;
            Debug.Log("Saved: " + GameCharacterManager.instance.CurrentCharacter);
            title.text = character.GetComponent<Character>().CharacterName;
            print("Left Stack: " + leftStack.Count);
            print("Right Stack: " + rightStack.Count);
        }
        else
        {
            ReplenishStack();

            GameObject tempCharacter = (GameObject)leftStack.Pop();
            print("changed color to : " + tempCharacter.name);
            Destroy(character);
            character = Instantiate(tempCharacter, parentCharacter.transform, false);
            character.transform.position = parentCharacter.transform.position;
            tempStorage.Push(tempCharacter);
            currentCharacter = tempCharacter;
            GameCharacterManager.instance.CurrentCharacter = tempCharacter.name;
            Debug.Log("Saved: " + GameCharacterManager.instance.CurrentCharacter);
            title.text = character.GetComponent<Character>().CharacterName;
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
            print("here");
            GameObject tempCharacter = (GameObject) rightStack.Pop();
     
            print("changed color to : " + tempCharacter.name);
            
            Destroy(character);
            character = Instantiate(tempCharacter, parentCharacter.transform, false);
            character.transform.position = parentCharacter.transform.position;
            tempStorage.Push(tempCharacter);
            currentCharacter = tempCharacter;
            GameCharacterManager.instance.CurrentCharacter = tempCharacter.name;
            Debug.Log("Saved: " + GameCharacterManager.instance.CurrentCharacter);
            title.text = character.GetComponent<Character>().CharacterName;
            print("Left Stack: " + leftStack.Count);
            print("Right Stack: " + rightStack.Count);
        }
        else
        {
            ReplenishStack();
            print("here");
            GameObject tempCharacter = (GameObject) rightStack.Pop();
            print("changed color to : " + tempCharacter.name);
            Destroy(character);
            character = Instantiate(tempCharacter, parentCharacter.transform, false);
            character.transform.position = parentCharacter.transform.position;
            GameCharacterManager.instance.CurrentCharacter = tempCharacter.name;
            Debug.Log("Saved: " + GameCharacterManager.instance.CurrentCharacter);
            tempStorage.Push(tempCharacter);
            currentCharacter = tempCharacter;
            title.text = character.GetComponent<Character>().CharacterName;
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
