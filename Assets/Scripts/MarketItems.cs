using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class CreateItemEvent : UnityEvent<Vector3,GameObject>{}

public class MarketItems : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    protected bool isGrounded = false;


    protected CreateItemEvent createItemEvent;
    protected GameObject parentGameObject;

    private void Awake()
    {
        if(createItemEvent == null)
        {
            createItemEvent = new CreateItemEvent();
        }
        createItemEvent.AddListener(CreateItem);
        parentGameObject = GameObject.Find("GameElements");
    }

    protected void CreateItem(Vector3 position,GameObject prefab)
    {
        Instantiate(prefab, parentGameObject.transform, true);
       
    }

    protected void MouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit, float.MaxValue, groundLayer))
        {
            transform.position = raycastHit.point;
        }
    }
}
