using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ColorButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public ColorPalette colorPalette;
    public Button button;

    public void OnPointerClick(PointerEventData eventData)
    {
        colorPalette.OnColorSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        colorPalette.OnColorEnter(this);
    }

    void Start()
    {
        button = GetComponent<Button>();
        colorPalette.Subscribe(this);
    }

    void Update()
    {

    }

}
