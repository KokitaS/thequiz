using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class OnMouseTextChange : MonoBehaviour
{
    [SerializeField] GameObject panelOn;
    [SerializeField] GameObject panelOff;
    private EventTrigger eventTrigger;
    void Start()
    {
        EventTrigger.Entry entry_Enter = new EventTrigger.Entry();
        eventTrigger = gameObject.AddComponent<EventTrigger>();

        entry_Enter.eventID = EventTriggerType.PointerEnter;
        entry_Enter.callback.AddListener((eventDate) => OnPointEnter());
        eventTrigger.triggers.Add(entry_Enter);

        EventTrigger.Entry entry_Exit = new EventTrigger.Entry();
        entry_Exit.eventID = EventTriggerType.PointerExit;
        entry_Exit.callback.AddListener((eventDate) => OnPointExit());
        eventTrigger.triggers.Add(entry_Exit);

    }
    
    public void OnPointEnter()
    {
        panelOn.SetActive(true);
        panelOff.SetActive(false);
    }
    public void OnPointExit()
    {
        panelOff.SetActive(true);
        panelOn.SetActive(false);
    }
}
