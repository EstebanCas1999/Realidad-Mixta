using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatrixOperations : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject textMeshProPrefab;
    public GameObject gameObjectMatrixOne;
    public GameObject gameObjectMatrixTwo;
    public GameObject textMeshTitle;
    public GameObject textMeshDescription;
    public float spacing = 0.25f;
    private int[,] resultMatrix;
    public Material cubeMaterial;
    public string operationName;

    public GameObject panelInformation;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void AddMatrices()
    {
        int[,] matrixOne = gameObjectMatrixOne.GetComponent<CubeMatrix>().matrix;
        int[,] matrixTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>().matrix;

        Text title = textMeshTitle.GetComponent<Text>();
        Text description = textMeshDescription.GetComponent<Text>();

        title.text = "Descripción de la adiccion";
        description.text = "Aseguresé que las matrices sean de la mismas dimensiones tanto como filas y columnas";
        operationName = "suma";

        if (matrixOne.GetLength(0) == matrixTwo.GetLength(0) && matrixOne.GetLength(1) == matrixTwo.GetLength(1))
        {

            resultMatrix = new int[matrixOne.GetLength(0), matrixOne.GetLength(1)];
            for (int i = 0; i < matrixOne.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTwo.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrixOne[i, j] + matrixTwo[i, j];
                }
            }

            description.text = "La unión de dos o más matrices solo puede hacerse si dichas matrices tienen la misma dimensión. Cada elemento de las matrices puede sumarse con los elementos que coincidan en posición en diferentes matrices.\n En otras palabras, cuando sumamos o restamos matrices nos vamos a fijar en las matrices compartan la misma dimensión.";

            CreateCubeMatrix();
        }
        else
        {
            description.text = "Aseguresé que las matrices sean de la mismas dimensiones tanto como filas y columnas";
            DestroyResultMatrix();
        }

        panelInformation.SetActive(true);
        
    }

    public void SubtractMatrices()
    {
        int[,] matrixOne = gameObjectMatrixOne.GetComponent<CubeMatrix>().matrix;
        int[,] matrixTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>().matrix;
        int rows = matrixOne.GetLength(0);
        int columns = matrixOne.GetLength(1);
        Text title = textMeshTitle.GetComponent<Text>();
        Text description = textMeshDescription.GetComponent<Text>();

        title.text = "Descripción de la resta";
        description.text = "Aseguresé que las matrices sean de la mismas dimensiones tanto como filas y columnas";
        operationName = "resta";

        resultMatrix = new int[rows, columns];

        if (matrixOne.GetLength(0) == matrixTwo.GetLength(0) && matrixOne.GetLength(1) == matrixTwo.GetLength(1))
        {

            for (int i = 0; i < matrixTwo.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTwo.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrixOne[i, j] - matrixTwo[i, j];
                }
            }

            description.text = "La unión de dos o más matrices solo puede hacerse si dichas matrices tienen la misma dimensión. Cada elemento de las matrices puede restarse con los elementos que coincidan en posición en diferentes matrices.\n En otras palabras, cuando sumamos o restamos matrices nos vamos a fijar en las matrices compartan la misma dimensión.";

            CreateCubeMatrix();
        }
        else
        {
            description.text = "Aseguresé que las matrices sean de la mismas dimensiones tanto como filas y columnas";
            DestroyResultMatrix();
        }

        panelInformation.SetActive(true);
    }

    public void MultiplyMatrices()
    {
        int[,] matrixOne = gameObjectMatrixOne.GetComponent<CubeMatrix>().matrix;
        int[,] matrixTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>().matrix;

        int rows = matrixOne.GetLength(0);
        int columns = matrixTwo.GetLength(1);
        int commonDim = matrixOne.GetLength(1);
        resultMatrix = new int[rows, columns];

        Text title = textMeshTitle.GetComponent<Text>();
        Text description = textMeshDescription.GetComponent<Text>();

        title.text = "Descripción de la multiplicacion";
        description.text = "Aseguresé que el número de columnas de la primera matriz sea igual al número de filas de la segunda matriz.";
        operationName = "producto";

        if (matrixOne.GetLength(1) == matrixTwo.GetLength(0))
        {

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < commonDim; k++)
                    {
                        resultMatrix[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                    }
                }
            }

            description.text = "Generalmente, la multiplicación de matrices cumple la propiedad no conmutativa, es decir, importa el orden de los elementos durante la multiplicación. Existen casos llamados matrices conmutativas que sí cumplen la propiedad. \n Para multiplicar dos matrices necesitamos que el número de columnas de la primera matriz sea igual al número de filas de la segunda matriz.";

            CreateCubeMatrix();
        }
        else
        {
            description.text = "Aseguresé que las matrices sean de la mismas dimensiones tanto como filas y columnas";
            DestroyResultMatrix();
        }

        panelInformation.SetActive(true);
    }

    public void DivideMatrices()
    {
        int[,] matrixOne = gameObjectMatrixOne.GetComponent<CubeMatrix>().matrix;
        int[,] matrixTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>().matrix;
        int rows = matrixOne.GetLength(0);
        int columns = matrixOne.GetLength(1);
        resultMatrix = new int[rows, columns];

        Text title = textMeshTitle.GetComponent<Text>();
        Text description = textMeshDescription.GetComponent<Text>();

        title.text = "Descripción de la division";
        operationName = "division";

        if (matrixOne.GetLength(0) == matrixTwo.GetLength(0) && matrixOne.GetLength(1) == matrixTwo.GetLength(1))
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Evita la división por cero
                    resultMatrix[i, j] = matrixTwo[i, j] != 0 ? matrixOne[i, j] / matrixTwo[i, j] : 0;
                }
            }

            description.text = "La división de matrices se puede expresar como la multiplicación entre la matriz que iría en el numerador multiplicada por la matriz inversa que iría como denominador.";
            CreateCubeMatrix();

        }
        else {
            description.text = "Aseguresé que las matrices sean de la mismas dimensiones tanto como filas y columnas";
            DestroyResultMatrix();
        }

        panelInformation.SetActive(true);


    }

    public void TransposeMatrix() {
        gameObjectMatrixOne.GetComponent<CubeMatrix>().TransposeMatrix();
        gameObjectMatrixTwo.GetComponent<CubeMatrix>().TransposeMatrix();
        DestroyResultMatrix();
        panelInformation.SetActive(false);
    }

    void CreateCubeMatrix()
    {
        // Elimina los cubos existentes antes de crear una nueva matriz

        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        DestroyResultMatrix();

 
        Vector3 startPosition = transform.position;

        // Crear la matriz de cubos
        for (int row = 0; row < resultMatrix.GetLength(0); row++)
        {
            for (int column = 0; column < resultMatrix.GetLength(1); column++)
            {
                Vector3 position = new Vector3(startPosition.x + column * spacing, startPosition.y - row * spacing, startPosition.z);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
                ChangeMaterialsOfPanels(cube);

                Transform numberName = cube.transform.Find("NumberName");
                if (numberName != null)
                {
                    TextMesh textMesh = numberName.GetComponent<TextMesh>();
                    if (textMesh != null)
                    {
                        textMesh.text = resultMatrix[row, column].ToString();
                    }
                }
            }
        }


        transform.rotation = Quaternion.Euler(0, 90, 0);

        CreateMatrixNameText();

       


    }

    void CreateMatrixNameText()
    {
        GameObject textObject = Instantiate(textMeshProPrefab, transform);
        textObject.transform.localPosition = new Vector3((resultMatrix.GetLength(1) - 1) * spacing / 2, 0.180f, 0);

        TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.text = "Resultado " + operationName;
            textMeshPro.fontSize = 36;
            textMeshPro.alignment = TextAlignmentOptions.Center;
        }
    }

    void ChangeMaterialsOfPanels(GameObject cubeObject)
    {
        // Nombres de los paneles a cambiar
        string[] panelNames = { "PanelLeft", "PanelRight", "PanelTop", "PanelBottom", "PanelBack", "PanelFront" };

        foreach (string name in panelNames)
        {
            Transform panel = cubeObject.transform.Find(name);
            if (panel != null)
            {
                MeshRenderer meshRenderer = panel.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.material = cubeMaterial;
                }
            }
        }
    }

    public void RegenerateMatrix() { 
        gameObjectMatrixOne.GetComponent<CubeMatrix>().RegenerateMatrix();
        gameObjectMatrixTwo.GetComponent<CubeMatrix>().RegenerateMatrix();
        DestroyResultMatrix();
        panelInformation.SetActive(false);
    }

    public void CreateMatrixByOperation() {
        if (operationName.Equals("suma"))
        {
            CubeMatrix matrizOne = gameObjectMatrixOne.GetComponent<CubeMatrix>();
            CubeMatrix matrizTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>();
            matrizOne.columns = 4;
            matrizOne.rows = 4;
            matrizOne.CreateCubeMatrix();
            matrizTwo.columns = 4;
            matrizTwo.rows = 4;
            matrizTwo.CreateCubeMatrix();
            AddMatrices();
        }
        else if (operationName.Equals("resta"))
        {
            CubeMatrix matrizOne = gameObjectMatrixOne.GetComponent<CubeMatrix>();
            CubeMatrix matrizTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>();
            matrizOne.columns = 5;
            matrizOne.rows = 5;
            matrizOne.CreateCubeMatrix();
            matrizTwo.columns = 5;
            matrizTwo.rows = 5;
            matrizTwo.CreateCubeMatrix(); 
            SubtractMatrices();

        }
        else if (operationName.Equals("producto")) {
            CubeMatrix matrizOne = gameObjectMatrixOne.GetComponent<CubeMatrix>();
            CubeMatrix matrizTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>();
            matrizOne.columns = 3;
            matrizOne.rows = 2;
            matrizOne.CreateCubeMatrix();
            matrizTwo.columns = 2;
            matrizTwo.rows = 3;
            matrizTwo.CreateCubeMatrix();
            MultiplyMatrices();
        }

        else if (operationName.Equals("division"))
        {
            CubeMatrix matrizOne = gameObjectMatrixOne.GetComponent<CubeMatrix>();
            CubeMatrix matrizTwo = gameObjectMatrixTwo.GetComponent<CubeMatrix>();
            matrizOne.columns = 2;
            matrizOne.rows = 2;
            matrizOne.CreateCubeMatrix();
            matrizTwo.columns = 2;
            matrizTwo.rows = 2;
            matrizTwo.CreateCubeMatrix();
            DivideMatrices();
        }

    }

    void DestroyResultMatrix() {

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


}
