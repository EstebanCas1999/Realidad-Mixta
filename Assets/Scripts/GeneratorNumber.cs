using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NumeroData
{
    public string number;
    public string category;
    public int xpos;
    public int ypos;
}

[System.Serializable]
class NumerosData
{
    public List<NumeroData> numbers;

    public static NumerosData FromJSON(string json)
    {
        return JsonUtility.FromJson<NumerosData>(json);
    }
}
public class GeneratorNumber : MonoBehaviour
{
    public GameObject numberPrefab;
    public float numberContainerSpeed;
    public int blockCount;
    public float spawnWait;
    public float starWait;
    public Material[] materials;
    private Component[] childs;
    // Start is called before the first frame update

    void Start()
    {
       
        StartCoroutine("Numbers");
    }
    IEnumerator Numbers()
    {
        TextAsset asset = Resources.Load<TextAsset>("JSON/OperationTableJSON");
        List<NumeroData> numbers = NumerosData.FromJSON(asset.text).numbers;
        while (true)
        {
            int materialRandom = Random.Range(0, 4);
            int numberRandom = Random.Range(0, 54);

            GameObject panelLeft = numberPrefab.transform.GetChild(0).gameObject;
            panelLeft.GetComponent<MeshRenderer>().material = materials[materialRandom];

            GameObject panelRight = numberPrefab.transform.GetChild(1).gameObject;
            panelRight.GetComponent<MeshRenderer>().material = materials[materialRandom];

            GameObject panelTop = numberPrefab.transform.GetChild(2).gameObject;
            panelTop.GetComponent<MeshRenderer>().material = materials[materialRandom];

            GameObject panelBottom = numberPrefab.transform.GetChild(3).gameObject;
            panelBottom.GetComponent<MeshRenderer>().material = materials[materialRandom];

            GameObject panelBack = numberPrefab.transform.GetChild(4).gameObject;
            panelBack.GetComponent<MeshRenderer>().material = materials[materialRandom];

            GameObject panelFront = numberPrefab.transform.GetChild(5).gameObject;
            panelFront.GetComponent<MeshRenderer>().material = materials[materialRandom];

            GameObject numberName = numberPrefab.transform.GetChild(7).gameObject;
            numberName.GetComponent<TextMesh>().text = numbers[numberRandom].number;

            var number = Instantiate(numberPrefab, this.transform.position, this.transform.rotation);
            childs = GetComponentsInChildren<NumberContainer>();
            number.GetComponent<Rigidbody>().velocity = -this.transform.forward * numberContainerSpeed;
            yield return new WaitForSeconds(spawnWait);
        }
    }

 




}
