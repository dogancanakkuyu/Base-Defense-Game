using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MarketItems
{

    

    [SerializeField] private GameObject prefab;
    void Update()
    {
        if (!isGrounded)
        {
            base.MouseDrag();
        }
        if (Input.GetMouseButtonDown(0) && !isGrounded)
        {
            isGrounded = true;
            if(createItemEvent != null)
            {
                createItemEvent.Invoke(transform.position,prefab);
            }
        }
        
    }
}
