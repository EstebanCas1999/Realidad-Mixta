using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeMatrix : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject textMeshProPrefab;
    public string matrixName = string.Empty;
    public int rows = 3;
    public int columns = 3;
    public float spacing = 0.25f;
    public Material cubeMaterial;
    public int[,] matrix;

    void Start()
    {
        CreateCubeMatrix();

    }

    public void CreateCubeMatrix()
    {

        matrix = GenerateRandomMatrix(rows, columns);
        // Elimina los cubos existentes antes de crear una nueva matriz
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Vector3 startPosition = transform.position;

        // Crear la matriz de cubos en forma vertical
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
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
                        // Asignar un número aleatorio como texto
                        textMesh.text = matrix[row, column].ToString();
                    }
                }
            }
        }

        CreateMatrixNameText();
    }

    // Método para cambiar el tamaño de la matriz
    public void SetMatrixSize(int newRows, int newColumns)
    {
        rows = newRows;
        columns = newColumns;
        CreateCubeMatrix();
    }

    void ChangeMaterialsOfPanels(GameObject cubeObject)
    {
        // Names of the panels to change
        string[] panelNames = { "PanelLeft", "PanelRight", "PanelTop", "PanelBottom", "PanelBack", "PanelFront" };

        foreach (string name in panelNames)
        {
            // Find the child object by name
            Transform panel = cubeObject.transform.Find(name);
            if (panel != null)
            {
                MeshRenderer meshRenderer = panel.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    // Change the material
                    meshRenderer.material = cubeMaterial;
                }
            }
        }
    }

    int[,] GenerateRandomMatrix(int rows, int columns)
    {
        matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = Random.Range(-10, 10);
            }
        }
        return matrix;
    }

    void CreateMatrixNameText()
    {
        GameObject textObject = Instantiate(textMeshProPrefab, transform);
        textObject.transform.localPosition = new Vector3((columns - 1) * spacing / 2, 0.174f, 0);

        TextMeshPro textMeshPro = textObject.GetComponent<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.text = matrixName;
            textMeshPro.fontSize = 36;
            textMeshPro.alignment = TextAlignmentOptions.Center;
        }
    }

    public void RegenerateMatrix()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        rows = Random.Range(2, 4);
        columns = Random.Range(2, 4);

        CreateCubeMatrix();
    }

    public void CreateCubeMatrixByOperation(string operation)
    {
        int rows = 0;
        int columns = 0;

        if (operation.Equals("Suma")) {
            rows = 5;
            columns = 5;
        }
        matrix = GenerateRandomMatrix(rows, columns);
        // Elimina los cubos existentes antes de crear una nueva matriz
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Vector3 startPosition = transform.position;

        // Crear la matriz de cubos en forma vertical
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Vector3 position = new Vector3(startPosition.x + column * spacing, startPosition.y - row * spacing, startPosition.z);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
                ChangeMaterialsOfPanels(cube);
            }
        }


    }

    public void TransposeMatrix()
    {
        int[,] transposedMatrix = new int[columns, rows];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                transposedMatrix[column, row] = matrix[row, column];
            }
        }

        matrix = transposedMatrix;

        rows = matrix.GetLength(0);
        columns = matrix.GetLength(1);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Vector3 startPosition = transform.position;

        // Crear la matriz de cubos en forma vertical
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
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
                        // Asignar un número aleatorio como texto
                        textMesh.text = matrix[row, column].ToString();
                    }
                }
            }
        }

        CreateMatrixNameText();
    }
}
