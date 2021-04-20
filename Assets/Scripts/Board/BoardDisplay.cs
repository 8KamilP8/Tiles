using UnityEngine;

public class BoardDisplay : MonoBehaviour
{
    [SerializeField] private int columns;
    [SerializeField] private int rows;
    [SerializeField] private float scale;
    [SerializeField] private float baseScale;

    private void Start() {
        UIGridLayout gridLayout = GetComponent<UIGridLayout>();
        RectTransform rectTransform = GetComponent<RectTransform>();

        float squareLength = scale * baseScale;

        float width = squareLength * columns;
        float height = squareLength * rows;

        rectTransform.localScale = new Vector3(1, 1);
        
        rectTransform.sizeDelta = new Vector3(width, height);

        gridLayout.rows = rows;
        gridLayout.columns = columns;
    }

    
}
