using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image buttonHighlightedEffect;
    [SerializeField] private Image waterSpirit;

    private void Awake()
    {
        buttonHighlightedEffect.enabled = false;
        waterSpirit.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHighlightedEffect.transform.position = this.transform.position;
        buttonHighlightedEffect.enabled = true;
        waterSpirit.transform.position = this.transform.position + new Vector3(-300, 0, 0);
        waterSpirit.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonHighlightedEffect.enabled = false;
        waterSpirit.enabled = false;
    }
}
