using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class TurnManager : MonoBehaviour
{
    
    List<GameObject> mypointslist = new List<GameObject>();
    
    

    // Start is called before the first frame update
    void Start()
    {
        //mypointslist.AddRange(GameObject.FindGameObjectsWithTag(NoBrokenScript.SelectPointTag));
        var pointsInfoList = GameObject
            // SelectPointTagをもつシーン内のGameObjectを全て取得（配列形式）
            .FindGameObjectsWithTag(NoBrokenScript.SelectPointTag)
            // 中身のオブジェクトを全て以下の式にしたがって変換　： GameObject → PointsInfo
            .Select(o => o.GetComponent<PointsInfo>())
            // IEnumerable → Listに変換
            .ToList();
        /*int n = pointsInfoList.Count;
        for (int i = 0; i <= n; i++)
        {
            income += pointsInfoList[i].PointIncome;
        }
        */
        /*foreach (PointsInfo element in pointsInfoList)
        {
            income += element.PointIncome;
        }
        */
        //上記二つのメソッドと下のメソッドは等価
        pointsInfoList.ForEach(element => CoreScript.Instance.income.Value += element.PointIncome);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        

    }
    public void TurnContinue()
    {
        CoreScript.Instance.turncounts.Value += 1;
        CoreScript.Instance.money.Value += CoreScript.Instance.income.Value - CoreScript.Instance.unitsamount.Value * 10;
        //CoreScript.Instance.turncountstext

    }
}
