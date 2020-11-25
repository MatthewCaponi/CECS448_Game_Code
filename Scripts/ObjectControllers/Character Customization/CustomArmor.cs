using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.HeroEditor.Common.CharacterScripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.U2D;
using HeroEditor.Common;

public class CustomArmor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI classType;
    [SerializeField] Character character;
    Object[] list;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TextMeshProUGUI armorName;
    [SerializeField] SpriteCollection spriteCollection;
    [SerializeField] GameObject cape;

    void Start()
    {
        GameCharacterManager.instance.CurrentCharacter = "Player Variant";
        list = Resources.LoadAll("CharacterCustomize/Armor/" + classType.text, typeof(SpriteAtlas));

        List<string> names = new List<string>();
        names.Add("Default");
        foreach (SpriteAtlas atlas in list)
        {
            names.Add(atlas.name);
        }

        dropdown.AddOptions(names);
    }

    public void changeArmor()
    {
        int size = spriteCollection.Armor.Count;
        for (int i = 0; i <= size; i++)
        {
            if (spriteCollection.Armor[i].Name == armorName.text)
            {
                List<Sprite> sprites = spriteCollection.Armor[i].Sprites;
                character.EquipArmor(sprites);
                character.EquipHelmet(null);
                cape.GetComponent<SpriteRenderer>().sprite = null;
                break;
            }
        }
    }
}
