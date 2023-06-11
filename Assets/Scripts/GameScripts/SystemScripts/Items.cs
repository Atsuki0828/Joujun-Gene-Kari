using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Items : ScriptableObject
{

	public enum KindOfItem
	{
		close_range_weapon,
		long_range_weapon,
		armor
	}

	//　アイテムの種類
	[SerializeField]
	private KindOfItem kindOfItem;
	//　アイテムが使用可能な技術レベル
	[SerializeField]
	private int have_tech_level;
	//　アイテムのアイコン
	[SerializeField]
	private Sprite icon;
	//　アイテムの名前
	[SerializeField]
	private string itemName;
	//　アイテムの攻撃力
	[SerializeField]
	private int ATK;
	//　アイテムの攻撃頻度　ｘ/100sに1回
	[SerializeField]
	private float ATKSpeed;
	//　アイテムの防御力
	[SerializeField]
	private int guard;
	//　アイテム装備して必要なコスト
	[SerializeField]
	private int unitcost = 2;
	//　防弾可能性
	[SerializeField]
	private float bulletproofness;
	//　銃弾攻撃力
	[SerializeField]
	private int bulletATK;
	//　銃弾攻撃頻度
	[SerializeField]
	private float bulletATKSpeed;
	//　弾速
	[SerializeField]
	private float bulletSpeed;
	//　弾の飛距離
	[SerializeField]
	private float bulletrange;
	//　弾の命中率
	[SerializeField]
	private float bulletAccuracy;
	//　弾のgameobject
	[SerializeField]
	private GameObject bulletgameobject;
	//　移動速度減少（重量）
	[SerializeField]
	private float unitspeeddown;
	//　アイテムの説明
	[SerializeField]
	private string information;

	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}
	public int GetKindOfTech()
    {
		return have_tech_level;
    }
	public Sprite GetIcon()
	{
		return icon;
	}

	public string GetItemName()
	{
		return itemName;
	}

	public int GetATK()
    {
		return ATK;
    }
	public float GetATKSpeed()
    {
		return ATKSpeed;
    }

	public int GetGuard()
    {
		return guard;
    }

	public int GetUnitcost()
    {
		return unitcost;
    }
	public float GetBulletproofness()
    {
		return bulletproofness;
    }
	public int GetBulletATK()
    {
		return bulletATK;
    }
	public float GetBulletATKSpeed()
	{
		return bulletATKSpeed;
	}
	public float GetBulletSpeed()
    {
		return bulletSpeed;
    }
	public float GetBulletRange()
    {
		return bulletrange;
    }
	public float GetBulletAccuracy()
	{
		return bulletAccuracy;
	}
	public float GetUnitspeeddown()
	{
		return unitspeeddown;
	}
	public GameObject Getbulletgameobject()
    {
		return bulletgameobject;
    }
	public string GetInformation()
	{
		return information;
	}
}
