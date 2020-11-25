using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] GameObject character;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(character);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            string path = "Characters/" + GameCharacterManager.instance.CurrentCharacter;
            Debug.Log("Path: " + path);
            Debug.Log("Char:" + GameCharacterManager.instance.CurrentCharacter);
            started = true;
            character = Instantiate((GameObject) Resources.Load(path), gameObject.transform, false);
            
            character.transform.position = transform.position;
            character.GetComponent<WeaponControls>().enabled = true;
        }
        
    }
}
