using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject marketPanel;
    private Vector3 mousePosition;
    private Vector3 itemPosition;

    public void CreateMarketItem()
    {
        marketPanel.SetActive(false);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        itemPosition = new(mousePosition.x, 0.2f, mousePosition.z);
        Instantiate(prefab, itemPosition, Quaternion.identity);
    }

}
