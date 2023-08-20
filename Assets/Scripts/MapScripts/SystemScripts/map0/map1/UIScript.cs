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

    [SerializeField]
    GameObject ParentSeiryokuobj;
    string MyTagName;
    void Start()
    {
        
        MyTagName = GameObject.Find(NoBrokenScript.SelectPointName).tag;
        ParentSeiryokuobj = GameObject.Find(MyTagName);
        SeiryokuNameText.text = Name;

    }

    // Update is called once per frame
    void Update()
    {
        Name = this.gameObject.GetComponent<MapSceneManager>().SeiryokuName;
        int i = -1;
        Debug.Log("POBJ : " + MyTagName);
        Debug.Log("Find : " + ParentSeiryokuobj.transform);
        while (ParentSeiryokuobj.transform.GetChild(i + 1) != null)
        {
            Income += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
            Money += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
        }
    }
}
