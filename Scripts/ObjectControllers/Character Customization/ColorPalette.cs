using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPalette : MonoBehaviour
{
    public List<ColorButton> colors;
    public ColorButton selectedColor;
    public GameObject colorPanel;
    public Button current;
    public CustomOptionManager customManager;

    public void Start()
    {
        current.GetComponent<Image>().color = customManager.custom.GetComponent<SpriteRenderer>().color;
    }

    public void Subscribe(ColorButton color)
    {
        if (colors == null)
        {
            colors = new List<ColorButton>();
        }

        colors.Add(color);
    }


    public void OnColorEnter(ColorButton color)
    {
        if (selectedColor == null || color != selectedColor)
        {
            selectedColor = color;
        }
    }

    public void OnColorSelected(ColorButton color)
    {
        selectedColor = color;
        colorPanel.SetActive(false);
        current.GetComponent<Image>().color = selectedColor.button.GetComponent<Image>().color;
        customManager.custom.GetComponent<SpriteRenderer>().color = selectedColor.button.GetComponent<Image>().color;
    }

    public void ShowColors()
    {
        colorPanel.SetActive(true);
    }

}
