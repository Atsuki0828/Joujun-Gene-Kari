using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDataBase : ScriptableObject
{
    public List<Items> itemList = new List<Items>();

    public List<Items> GetItemLists()
    {
        return itemList;
    } 
}
