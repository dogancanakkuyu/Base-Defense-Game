using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealButtonController : MonoBehaviour
{

    [SerializeField] private LayerMask layer;
    [SerializeField] GameObject mouseIconPrefab;
    private GameObject mouseIconGameObject;






    public void HandleHealButton()
    {
        mouseIconGameObject = Instantiate(mouseIconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        HandleMouseDrag();
    }

    private void HandleMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitObject, float.MaxValue, layer))
        {
            mouseIconGameObject.transform.position = hitObject.transform.position;
        }
    }
}
