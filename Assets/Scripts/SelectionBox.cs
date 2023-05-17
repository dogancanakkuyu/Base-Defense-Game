using UnityEngine;
using UnityEngine.UI;

public class SelectionBox : MonoBehaviour
{
    private Vector3 startPos;
    private RectTransform rectTransform;
    private Image image;
    private GameObject[] selectableObjects;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        selectableObjects = GameObject.FindGameObjectsWithTag("Unit");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            rectTransform.position = startPos;
            rectTransform.sizeDelta = Vector2.zero;
            image.enabled = true;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = Input.mousePosition;
            Vector3 lowerLeft = Vector3.Min(startPos, currentPos);
            Vector3 upperRight = Vector3.Max(startPos, currentPos);
            Vector3 center = (lowerLeft + upperRight) / 2f;
            rectTransform.position = center;
            rectTransform.sizeDelta = new Vector2(upperRight.x - lowerLeft.x, upperRight.y - lowerLeft.y);
            foreach(GameObject go in selectableObjects)
            {
                if (IsWithinSelectionBox(go.transform.position))
                {
                    SceneManager.selectedObjects.Add(go);
                }
                
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            image.enabled = false;
        }
    }

    bool IsWithinSelectionBox(Vector3 position)
    {
        // Convert the object's world position to screen position
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);

        // Check if the screen position is within the selection box
        Rect selectionRect = new Rect(rectTransform.position.x - rectTransform.sizeDelta.x / 2f,
                                      rectTransform.position.y - rectTransform.sizeDelta.y / 2f,
                                      rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
        return selectionRect.Contains(screenPos);
    }
}
