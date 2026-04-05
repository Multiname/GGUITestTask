using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class AdjustContentMargin : MonoBehaviour
{
    [SerializeField] private float margin1920;
    [SerializeField] private float margin1440;
    [SerializeField] private RectTransform canvasRectTransform;
    
    private RectTransform _rectTransform;

    private int _currentWidth;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _currentWidth = GetWidth();
        AdjustMargin(_currentWidth);
    }

    private void LateUpdate()
    {
        CheckWidth();
    }
    
    private int GetWidth() => (int)canvasRectTransform.rect.width;

    private void CheckWidth()
    {
        var width = GetWidth();
        if (_currentWidth == width) return;
        _currentWidth = width;
        
        AdjustMargin(width);
    }

    private void AdjustMargin(int width)
    {
        var t = Mathf.InverseLerp(1440f, 1920f, width);
        var margin = Mathf.Lerp(margin1440, margin1920, t);
        
        var position = _rectTransform.anchoredPosition;
        position.x = margin;
        _rectTransform.anchoredPosition = position;
    }
}
