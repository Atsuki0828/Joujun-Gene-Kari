using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowScript : MonoBehaviour
{
    [SerializeField]
    GameObject WindowAvarable;


    private Vector2 prevPos; //保存しておく初期position
    private RectTransform rectTransform; // 移動したいオブジェクトのRectTransform
    private RectTransform parentRectTransform; // 移動したいオブジェクトの親(Panel)のRectTransform

    public static bool isDragging = false;
    public float factor = 1f;

    private Vector3 firstPos;
    private Vector3 firstMousePos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = rectTransform.parent as RectTransform;
    }

    private void Start()
    {
        WindowAvarable.SetActive(false);

        //add EventTrigger
        TryGetComponent(out EventTrigger eventTrigger);

        //Pointer Downの追加
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnBeginDrag((PointerEventData)data); });

        eventTrigger.triggers.Add(entry);


        //PointerUpの追加
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry2);

        //Pointer Downの追加
        //EventTrigger.Entry entry3 = new EventTrigger.Entry();
        //entry3.eventID = EventTriggerType.PointerEnter;
        //entry3.callback.AddListener((data) => { OnDrag((PointerEventData)data); });

        //eventTrigger.triggers.Add(entry3);
    }


    private void Update()
    {
        if (isDragging)
        {
            OnDrag();
        }

    }

    // ドラッグ開始時の処理
    public void OnBeginDrag(PointerEventData eventData)
    {

        //Debug.Log("Start");
        // ドラッグ前の位置を記憶しておく
        // RectTransformの場合はpositionではなくanchoredPositionを使う
        prevPos = rectTransform.anchoredPosition;
        isDragging = true;
        firstPos = rectTransform.anchoredPosition;
        firstMousePos = Input.mousePosition;
    }

    // ドラッグ中の処理
    //public void OnDrag(PointerEventData eventData)
    public void OnDrag()
    {
        
        // eventData.positionから、親に従うlocalPositionへの変換を行う
        // オブジェクトの位置をlocalPositionに変更する

        //Vector2 localPosition = GetLocalPosition(eventData.position);

        //var fixPos = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f);
        //Debug.Log("Fix pos: " + fixPos);

        ////Vector2 localPosition = GetLocalPosition(Input.mousePosition*10);
        //Vector2 localPosition = GetLocalPosition(fixPos);
        //rectTransform.anchoredPosition = localPosition;

        var currentMousePos = Input.mousePosition;
        var delta = currentMousePos - firstMousePos;
        rectTransform.anchoredPosition = firstPos + delta * factor;
    }

    // ドラッグ終了時の処理
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");
        // オブジェクトをドラッグ前の位置に戻す
        //rectTransform.anchoredPosition = prevPos;
        isDragging = false;
    }

    // ScreenPositionからlocalPositionへの変換関数
    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;
        
        // screenPositionを親の座標系(parentRectTransform)に対応するよう変換する.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out result);

        return result;


    }
    public void WindowCloseOnclick()
    {
        WindowAvarable.SetActive(false);
    }
}
