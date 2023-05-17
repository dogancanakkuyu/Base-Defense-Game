using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObjectController : MonoBehaviour
{

    [SerializeField] private LayerMask roadLayer;
    [SerializeField] private GameObject prefab; // Game object to be created

    private void Update()
    {
        MouseDrag();
    }



    private void MouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, roadLayer))
        {
            transform.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
