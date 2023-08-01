using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx;

public class NoBrokenScript : MonoBehaviour
{
    
    PointsInfo pointinfocs;
    public string PointName;
    bool hantei = true;
    [SerializeField]
    private Text PointNameText;
    [SerializeField]
    private Text PointTerrainText;
    [SerializeField]
    private Text PointTemperatureText;
    [SerializeField]
    private Text PointIncomeText;
    Image BImage;
    [SerializeField]
    Sprite[] BuildingSprites;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "map" && hantei == true)
        {
            hantei = false;
            GameObject firstgetobj = GameObject.Find(PointName);
            pointinfocs = firstgetobj.GetComponent<PointsInfo>();
        }

    }
    void Pointsclick()
    {
        PointNameText.text = pointinfocs.Name;
        PointTerrainText.text = pointinfocs.pointTerrain.ToString();
        PointTemperatureText.text = pointinfocs.pointTemperature.ToString();
        PointIncomeText.text = pointinfocs.PointIncome.ToString();
        foreach(var buildings in pointinfocs.pointBuildingList)
        {
            Image BuildingImage = Instantiate(BImage, new Vector3(0, 0, 0), Quaternion.identity);
            
            if (BuildingImage.name == "")
            {
                BuildingImage.sprite = BuildingSprites[0];
            }
            else if (BuildingImage.name == "")
            {
                BuildingImage.sprite = BuildingSprites[1];
            }
            else if (BuildingImage.name == "")
            {
                BuildingImage.sprite = BuildingSprites[2];
            }
            else if (BuildingImage.name == "")
            {
                BuildingImage.sprite = BuildingSprites[3];
            }




            //イメージを追加する処理を書いている途中 
        }
    }
}