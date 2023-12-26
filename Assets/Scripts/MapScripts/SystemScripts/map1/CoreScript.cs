using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Linq;
using System;

public class CoreScript : SingletonMonoBehaviour<CoreScript>
{
    [SerializeField]
    public Text turncountstext;
    [SerializeField]
    Text moneytext;
    [SerializeField]
    Text powerpointstext;
    [SerializeField]
    Text incometext;
    [SerializeField]
    //public int turncounts = 1;
    public ReactiveProperty<int> turncounts = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> money = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> powerpoints = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> income = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> unitsamount = new ReactiveProperty<int>(0);

    public ItemDataBase ArmorsDatabase;
    public ItemDataBase CWeaponsDatabase;
    public ItemDataBase LWeaponsDatabase;

    public ShojihinButtonSet weaponsButtonSet;
    public ShojihinButtonSet armorsButtonSet;

    public int[] ArmorsCountArray;
    public int[] CWeaponsCountArray;
    public int[] LWeaponsCountArray;

    // Start is called before the first frame update
    void Start()
    {
        //ArmorsCountArray = new int[ArmorsDatabase.itemList.Count];
        //CWeaponsCountArray = new int[CWeaponsDatabase.itemList.Count];
        //LWeaponsCountArray = new int[LWeaponsDatabase.itemList.Count];

        powerpoints.Subscribe(newPowerpoints => powerpointstext.text = "勢力値:" + newPowerpoints.ToString())
            .AddTo(this);
        money.Subscribe(newMoney => moneytext.text = "所持金:" + newMoney.ToString())
            .AddTo(this);
        income.Subscribe(newIncome => incometext.text = "収入:" + newIncome.ToString())
            .AddTo(this);

        for (int i = 0; i < ArmorsCountArray.Length; i++)
        {
            armorsButtonSet.shojihinButtons[i].GetComponentsInChildren<Text>()[1].text = ArmorsCountArray[i].ToString();
        }
        for (int i = 0; i < CWeaponsCountArray.Length; i++)
        {
            weaponsButtonSet.shojihinButtons[i].GetComponentsInChildren<Text>()[1].text = CWeaponsCountArray[i].ToString();
        }
        for (int i = CWeaponsCountArray.Length; i < CWeaponsCountArray.Length + LWeaponsCountArray.Length; i++)
        {
            weaponsButtonSet.shojihinButtons[i].GetComponentsInChildren<Text>()[1].text = LWeaponsCountArray[i - CWeaponsCountArray.Length].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    //アイテム行動メソッド
    //public bool TryBuy(int cost, Items item)
    //{
    //    int afterMoney = money.Value - cost;
    //    if (afterMoney >= 0)
    //    {
    //        // 購入成功
    //        money.Value = afterMoney;

    //        for (int i = 0; i < ArmorsCountArray.Length; i++)
    //        {
    //            if (ArmorsDatabase.itemList[i] == item)
    //            {
    //                ArmorsCountArray[i]++;
    //                break;
    //            }
    //            if (CWeaponsDatabase.itemList[i] == item)
    //            {
    //                CWeaponsCountArray[i]++;
    //            }
    //            if (LWeaponsDatabase.itemList[i] == item)
    //            {
    //                LWeaponsCountArray[i]++;
    //            }
    //        }

    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    public bool TrySell(int sellvalue, Items item)
    {
        
        for (int i = 0; i < ArmorsCountArray.Length; i++)
        {
            if (ArmorsDatabase.itemList[i+1] == item)
            {
                int afterCount = ArmorsCountArray[i] - 1;
                if (afterCount < 0)
                {
                    return false;
                }
                ArmorsCountArray[i]--;
                money.Value = money.Value + sellvalue;
                armorsButtonSet.shojihinButtons[i].GetComponentsInChildren<Text>()[1].text = ArmorsCountArray[i].ToString();
                return true;
            }
        }
        for (int i = 0; i < CWeaponsCountArray.Length; i++)
        {
            if (CWeaponsDatabase.itemList[i+1] == item)
            {
                int afterCount = CWeaponsCountArray[i] - 1;
                if (afterCount < 0)
                {
                    return false;
                }
                CWeaponsCountArray[i]--;
                money.Value = money.Value + sellvalue;
                weaponsButtonSet.shojihinButtons[i].GetComponentsInChildren<Text>()[1].text = CWeaponsCountArray[i].ToString();
                return true;
            }
        }
        //for (int i = 0; i < LWeaponsCountArray.Length; i++)
        for (int i = CWeaponsCountArray.Length; i < CWeaponsCountArray.Length + LWeaponsCountArray.Length; i++)
        {
            int slideIndex = i - CWeaponsCountArray.Length;
            if (LWeaponsDatabase.itemList[slideIndex] == item)
            {
                int afterCount = LWeaponsCountArray[slideIndex] - 1; //CWeaponsArrayの一番上のitemは売却処理に含めない事による処理。
                if (afterCount < 0)
                {
                    return false;
                }
                LWeaponsCountArray[slideIndex]--;
                money.Value = money.Value + sellvalue;
                weaponsButtonSet.shojihinButtons[i].GetComponentsInChildren<Text>()[1].text = LWeaponsCountArray[slideIndex].ToString();
                return true;
            }
        }

        return false;
    }
}
