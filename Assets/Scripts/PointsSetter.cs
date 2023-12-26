using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsSetter : MonoBehaviour
{
    //自動イベントトリガー設定スクリプト
    private void Start()
    {
        EventTrigger[] eventTriggers = GetComponentsInChildren<EventTrigger>();
        PointsclickScript noBroken = FindObjectOfType<PointsclickScript>();
        Debug.Log(noBroken == null);
        for (int i = 0; i < eventTriggers.Length; i++) {
            //var c = new EventTrigger.TriggerEvent();
            //c.AddListener(noBroken.MapPointsclick);
            //var triggers = eventTriggers[i].triggers;
            var entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener(noBroken.MapPointsclick);
            eventTriggers[i].triggers = new List<EventTrigger.Entry>();
            eventTriggers[i].triggers.Add(entry);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
