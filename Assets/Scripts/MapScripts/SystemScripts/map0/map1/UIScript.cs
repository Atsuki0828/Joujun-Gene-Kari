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
        Name = this.gameObject.GetComponent<MapSceneManager>().SeiryokuName;
        MyTagName = GameObject.Find(NoBrokenScript.SelectPointName).tag;
        ParentSeiryokuobj = GameObject.Find(MyTagName);
        SeiryokuNameText.text = Name;

        int i = 0;
        Debug.Log("POBJ : " + MyTagName);//ParentOBJ
        Debug.Log("Find : " + ParentSeiryokuobj.transform);
        while (ParentSeiryokuobj.transform.GetChild(i).gameObject != null)
        {
            Income += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
            Money += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
            i += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
       /* Name = this.gameObject.GetComponent<MapSceneManager>().SeiryokuName;
        int i = 0;
        Debug.Log("POBJ : " + MyTagName);//ParentOBJ
        Debug.Log("Find : " + ParentSeiryokuobj.transform);
        while (ParentSeiryokuobj.transform.GetChild(i).gameObject != null)
        {
            Income += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
            Money += ParentSeiryokuobj.transform.GetChild(i).GetComponent<PointsInfo>().PointIncome;
            i += 1;
            Debug.Log(i);
        }*/
    }
}
