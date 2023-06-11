using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
	[SerializeField]
	private ItemDataBase CWeaponsDatabase;
	[SerializeField]
	private ItemDataBase ArmorsDataBase;
	[SerializeField]
	private ItemDataBase LWeaponsDatabase;

	//　アイテム数管理
	private Dictionary<Items, int> numOfItem = new Dictionary<Items, int>();

	// Use this for initialization
	void Start()
	{

		for (int i = 0; i < CWeaponsDatabase.GetItemLists().Count; i++)
		{
			//　アイテム数を適当に設定
			numOfItem.Add(CWeaponsDatabase.GetItemLists()[i], i);
			//　確認の為データ出力
			Debug.Log(CWeaponsDatabase.GetItemLists()[i].GetItemName() + ": " + CWeaponsDatabase.GetItemLists()[i].GetInformation());
		}
		
		Debug.Log(GetCWeaponsItem("木の棒").GetInformation());
		Debug.Log(numOfItem[GetCWeaponsItem("石")]);
	}

	//　名前でアイテムを取得
	public Items GetCWeaponsItem(string searchName)
	{
		return CWeaponsDatabase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
	public Items GetArmorsItem(string searchName)
	{
		return ArmorsDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
	public Items GetLWeaponsItem(string searchName)
	{
		return LWeaponsDatabase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}

    internal float GetCWeaponsItem(object firstW)
    {
        throw new NotImplementedException();
    }
}

