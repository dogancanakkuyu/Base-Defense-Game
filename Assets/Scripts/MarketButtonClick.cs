using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketButtonClick : MonoBehaviour
{
    [SerializeField] private GameObject marketPanel;

    [System.Obsolete]
    public void ShowMarketPanel()
    {
        if (marketPanel.active)
        {
            marketPanel.SetActive(false);
        }
        else
        {
            marketPanel.SetActive(true);
        }
        
    }
}
