using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image buttonHighlightedEffect;
    [SerializeField] private Image waterSpirit;
    [SerializeField] private AudioClip pointerEnterSound;
    [SerializeField] private AudioClip pointerClickSound;

    private void Awake()
    {
        buttonHighlightedEffect.enabled = false;
        waterSpirit.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHighlightedEffect.transform.position = this.transform.position;
        buttonHighlightedEffect.enabled = true;
        waterSpirit.transform.position = this.transform.position + new Vector3(-450, 0, 0);
        waterSpirit.enabled = true;
        SoundManager.instance.PlaySound(pointerEnterSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonHighlightedEffect.enabled = false;
        waterSpirit.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlaySound(pointerClickSound);
    }
}
