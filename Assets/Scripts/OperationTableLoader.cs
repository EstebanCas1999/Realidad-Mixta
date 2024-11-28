using HoloToolkit.MRDL.PeriodicTable;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class NumberData
{
    public string number;
    public string category;
    public int xpos;
    public int ypos;
}

[System.Serializable]
class NumbersData
{
    public List<NumberData> numbers;

    public static NumbersData FromJSON(string json)
    {
        return JsonUtility.FromJson<NumbersData>(json);
    }
}
public class OperationTableLoader : MonoBehaviour
{
    public Transform Parent;
    public GameObject NumberPrefab;
    public float NumberSeperationDistance;

    public Material IrrationalNumber;
    public Material RationalNumber;
    public Material IntegerNumber;
    public Material NaturalNumber;
    public TextMeshProUGUI Category;


    private bool isFirstRun = true;
    // Start is called before the first frame update
    void Start()
    {
        InitializeData();
    }

    public void InitializeData()
    {
        //if (Collection.transform.childCount > 0)
        //    return;

        // Parse the elements out of the json file
        TextAsset asset = Resources.Load<TextAsset>("JSON/OperationTableJSON");
        List<NumberData> numbers = NumbersData.FromJSON(asset.text).numbers;

        Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
    {
        { "IrrationalNumber", IrrationalNumber },
        { "RationalNumber", RationalNumber },
        { "IntegerNumber", IntegerNumber },
        { "NaturalNumber", NaturalNumber },

    };


        if (isFirstRun == true)
        {
            // Insantiate the element prefabs in their correct locations and with correct text
            foreach (NumberData number in numbers)
            {
                GameObject newNumber = Instantiate<GameObject>(NumberPrefab, Parent);
                newNumber.GetComponentInChildren<Number>().SetFromElementData(number, typeMaterials);
                newNumber.transform.localPosition = new Vector3(number.xpos * NumberSeperationDistance - NumberSeperationDistance * 18 / 2, NumberSeperationDistance * 9 - number.ypos * NumberSeperationDistance, 2.0f);
                newNumber.transform.localRotation = Quaternion.identity;
            }

            isFirstRun = false;
        }
        else
        {
            int i = 0;
            // Update position and data of existing element objects
            foreach (Transform existingElementObject in Parent)
            {
                existingElementObject.parent.GetComponentInChildren<Number>().SetFromElementData(numbers[i], typeMaterials);
                existingElementObject.localPosition = new Vector3(numbers[i].xpos * NumberSeperationDistance - NumberSeperationDistance * 18 / 2, NumberSeperationDistance * 9 - numbers[i].ypos * NumberSeperationDistance, 2.0f);
                existingElementObject.localRotation = Quaternion.identity;
                i++;
            }
            Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
            //LegendTransform.localPosition = new Vector3(0.0f, 0.15f, 1.8f);

        }
    }
}

