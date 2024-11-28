using HoloToolkit.MRDL.PeriodicTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.MRDL.PeriodicTable
{
    public class Number : MonoBehaviour
    {

        public static Number ActiveNumber;

        public TextMesh NumberDetail;


        public Renderer BoxRenderer;
        public MeshRenderer[] PanelSides;
        public MeshRenderer PanelFront;
        public MeshRenderer PanelBack;

        private PresentToPlayer present;

        [HideInInspector]
        public NumberData data;

        private BoxCollider boxCollider;
        private Material highlightMaterial;
        private Material dimMaterial;
        private Material clearMaterial;
        // Start is called before the first frame update


        public void SetActiveNumber()
        {
            Number number = gameObject.GetComponent<Number>();
            ActiveNumber = number;
        }

        public void ResetActiveNumber()
        {
            ActiveNumber = null;
        }

        public void Start()
        {
            present = GetComponent<PresentToPlayer>();
        }

        public void Highlight()
        {
            if (ActiveNumber == this)
                return;

            for (int i = 0; i < PanelSides.Length; i++)
            {
                PanelSides[i].sharedMaterial = highlightMaterial;
            }
            PanelBack.sharedMaterial = highlightMaterial;
            PanelFront.sharedMaterial = highlightMaterial;
            BoxRenderer.sharedMaterial = highlightMaterial;
        }

        public void Dim()
        {
            if (ActiveNumber == this)
                return;

            for (int i = 0; i < PanelSides.Length; i++)
            {
                PanelSides[i].sharedMaterial = dimMaterial;
            }
            PanelBack.sharedMaterial = dimMaterial;
            PanelFront.sharedMaterial = dimMaterial;
            BoxRenderer.sharedMaterial = dimMaterial;
        }

        public void SetFromElementData(NumberData data, Dictionary<string, Material> typeMaterials)
        {
            this.data = data;

            NumberDetail.text = data.number;

            // Set up our materials
            if (!typeMaterials.TryGetValue(data.category.Trim(), out dimMaterial))
            {
                Debug.Log("Couldn't find " + data.category.Trim() + " in element " + data.number);
            }

            // Create a new highlight material and add it to the dictionary so other can use it
            string highlightKey = data.category.Trim() + " highlight";
            if (!typeMaterials.TryGetValue(highlightKey, out highlightMaterial))
            {
                highlightMaterial = new Material(dimMaterial);
                highlightMaterial.color = highlightMaterial.color * 1.5f;
                typeMaterials.Add(highlightKey, highlightMaterial);
            }

            Dim();

            BoxRenderer.enabled = false;

            // Set our name so the container can alphabetize
            transform.parent.name = data.number;
        }
    }
}
