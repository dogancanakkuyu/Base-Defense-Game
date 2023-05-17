using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    private GameObject parentObject;
    [SerializeField] private LayerMask unitLayer;

    public static List<GameObject> selectedObjects = new List<GameObject>();


    private void Awake()
    {
        parentObject = GameObject.Find("GameElements");
    }

    private void Update()
    {

        if(selectedObjects.Count != 0)
        {
            ShowSelectedObjects();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeleteLastCreatedItem();
        }
        if (Input.GetMouseButtonDown(0))
        {
            SelectUnits();
        }
        
    }

    void DeleteLastCreatedItem()
    {
        int numChildren = parentObject.transform.childCount;
        if (numChildren > 0)
        {
            Destroy(parentObject.transform.GetChild(numChildren - 1).gameObject);
        }
    }

    private void SelectUnits()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayer))
        {
            selectedObjects.Add(raycastHit.transform.gameObject);
        }
        else
        {
            DeselectAllObjects();
        }
    }

    private void ShowSelectedObjects()
    {
        foreach(GameObject gameObject in selectedObjects)
        {
            gameObject.transform.Find("SelectionCircle").gameObject.SetActive(true);
        }
    }

    private void DeselectAllObjects()
    {
        foreach (GameObject gameObject in selectedObjects)
        {
            gameObject.transform.Find("SelectionCircle").gameObject.SetActive(false);
        }
        selectedObjects.Clear();
    }
}
