using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitButtonController : MonoBehaviour
{

    private int price,remainingGold;
    [SerializeField] GameObject prefab; //prefab that is created from button click
    [SerializeField] TextMeshProUGUI remainingGoldText;
    private void Awake()
    {
        price = 100;
    }
    public void InstantiateUnit() {
        if (int.TryParse(remainingGoldText.text, out remainingGold))
        {
            remainingGold -= price;
            remainingGoldText.text = remainingGold.ToString();
        }
        Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
