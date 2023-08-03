using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

public class NoBrokenScript : MonoBehaviour
{
    public static Object NoBrokenObjectInMapScene;
    [SerializeField]
    PointsInfo pointinfocs;
    [SerializeField]
    string SelectPointName;
    [SerializeField]
    string PointName;
    [SerializeField]
    string PointTerrain;
    [SerializeField]
    string PointTemperature;
    [SerializeField]
    int PointIncome;
    bool hantei = true;
    [SerializeField]
    private Text PointNameText;
    [SerializeField]
    private Text PointTerrainText;
    [SerializeField]
    private Text PointTemperatureText;
    [SerializeField]
    private Text PointIncomeText;
    [SerializeField]
    Image BImage;
    [SerializeField]
    Sprite[] BuildingSprites;
    [SerializeField]
    GameObject Bcontent;
    [SerializeField]
    Image UImage;
    [SerializeField]
    Sprite[] UnitSprites;
    [SerializeField]
    GameObject Ucontent;




    GameObject PlayerWindowAvarable;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //PlayerWindowAvarable.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "map" && hantei == true)
        {
            
            hantei = false;
            Debug.Log(SelectPointName);
            GameObject firstgetobj = GameObject.Find(SelectPointName);
            Debug.Log(firstgetobj);
            if(firstgetobj != null)
            {
                pointinfocs = firstgetobj.GetComponent<PointsInfo>();
            }
            NoBrokenObjectInMapScene =  GameObject.Find("NoBrokenGameObject");
            
            
        }

    }
    public void Pointsclick(BaseEventData data)
    {
        PlayerWindowAvarable.SetActive(true); 
        foreach (Transform n in Bcontent.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform o in Ucontent.transform)
        {
            GameObject.Destroy(o.gameObject);
        }
        Debug.Log("ff");
        
        GameObject SelectPoint = (data as PointerEventData).pointerClick;
        SelectPointName = SelectPoint.name;
        PointName = SelectPoint.GetComponent<PointsInfo>().Name;
        PointTerrain = SelectPoint.GetComponent<PointsInfo>().pointTerrain.ToString();
        PointTemperature = SelectPoint.GetComponent<PointsInfo>().pointTemperature.ToString();
        PointIncome = SelectPoint.GetComponent<PointsInfo>().PointIncome;
        Debug.Log(PointName);
        PointNameText.text = PointName;
        PointTerrainText.text = PointTerrain;
        //PointTemperatureText.text = SelectPoint.GetComponent<PointsInfo>().pointTemperature.ToString();
        PointIncomeText.text = PointIncome.ToString();



        foreach(var buildings in SelectPoint.GetComponent<PointsInfo>().pointBuildingList)
        {
            Image BuildingImage = Instantiate(BImage, new Vector3(0, 0, 0), Quaternion.identity);
            BuildingImage.transform.SetParent(Bcontent.transform, false);

            if (buildings.ToString() == "Ki")
            {
                BuildingImage.sprite = BuildingSprites[0];
            }
            else if (buildings.ToString() == "Sougen")
            {
                BuildingImage.sprite = BuildingSprites[1];
            }
            else if (buildings.ToString() == "Ishikiriba")
            {
                BuildingImage.sprite = BuildingSprites[2];
            }
            else if (buildings.ToString() == "Kaigan")
            {
                BuildingImage.sprite = BuildingSprites[3];
            }

            
            //イメージを追加する処理を書いている途中 
        }
        foreach (var units in SelectPoint.GetComponent<PointsInfo>().pointUnitList)
        {
            Image UnitImage = Instantiate(UImage, new Vector3(0, 0, 0), Quaternion.identity);
            UnitImage.transform.SetParent(Ucontent.transform, false);

            if (units.ToString() == "Kenshi")
            {
                UnitImage.sprite = UnitSprites[0];
            }
            else if (units.ToString() == "Yarihei")
            {
                UnitImage.sprite = UnitSprites[1];
            }
            else if (units.ToString() == "Yumihei")
            {
                UnitImage.sprite = UnitSprites[2];
            }
            else if (units.ToString() == "Juhei")
            {
                UnitImage.sprite = UnitSprites[3];
            }


            //イメージを追加する処理を書いている途中 
        }
    }
    public void SentakuOnclick()
    {
        SceneManager.LoadScene("map");
    }
}