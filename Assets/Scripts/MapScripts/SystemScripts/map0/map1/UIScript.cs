using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    Text SeiryokuNameText;
    [SerializeField]
    Text PowerValueText;
    [SerializeField]
    Text MoneyText;
    [SerializeField]
    Text incomeText;

    public string Name;
    public int PowerValue;
    public int Money;
    public int Income;


    GameObject ParentSeiryokuobj;
    void Start()
    {
        Name = this.gameObject.GetComponent<MapSceneManager>().SeiryokuName;
        ParentSeiryokuobj = GameObject.Find(GameObject.Find(Name).tag);
        SeiryokuNameText.text = Name;

    }

    // Update is called once per frame
    void Update()
    {
        int i = -1;
        
        while (ParentSeiryokuobj.transform.GetChild(i + 1) != null)
        {
            Income += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
            Money += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
        }
    }
}
