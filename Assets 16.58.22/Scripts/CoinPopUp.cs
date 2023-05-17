using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPopUp : MonoBehaviour
{

    private const float PIXEL_PER_UNIT = 100f;


    RectTransform panel;
    Camera mainCamera;
    TextMeshProUGUI remaningGoldText;


    private Vector3 remainingGoldWorldPos;
    private Vector3 localPos;
    private int remainingGold;
    private float coinMovementSpeed = 7f;

    private void Awake()
    {
        panel = GameObject.Find("RemainingGoldPanel").GetComponent<RectTransform>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        remaningGoldText = GameObject.Find("RemainingGold").GetComponent<TextMeshProUGUI>();
        localPos = panel.localPosition;
        remainingGoldWorldPos = panel.TransformPoint(localPos);
        remainingGoldWorldPos.x += panel.rect.width / (PIXEL_PER_UNIT * 2f);
        remainingGoldWorldPos.y -= panel.rect.height / (PIXEL_PER_UNIT * 2f);
        remainingGoldWorldPos.z = transform.position.z;
        
    }



    private void Update()
    {
        if(transform.position != remainingGoldWorldPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, remainingGoldWorldPos, Time.deltaTime * coinMovementSpeed);
        }
        else
        {
            if(int.TryParse(remaningGoldText.text,out remainingGold)){
                remainingGold += 100;
                remaningGoldText.text = remainingGold.ToString();
                Destroy(gameObject);
            }
        }
    }
}
