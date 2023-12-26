using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

[RequireComponent(typeof(Button))]
[DisallowMultipleComponent]
public class ShojihinButtonData : MonoBehaviour
{
    //public int Cost;
    public Items item;
    public int SellValue;

    private Button button;

    private void Start()
    {
        TryGetComponent(out button);
        button.OnClickAsObservable()
            .Subscribe(_ => OnClick())
            .AddTo(this);
    }

    public void OnClick()
    {
        // CoreScript.Instance.income
        //CoreScript.Instance.TryBuy(Cost, item);
        CoreScript.Instance.TrySell(SellValue, item);

    }
}
