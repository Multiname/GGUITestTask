using System;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVP.Views.ContentToggle
{
    [RequireComponent(typeof(Image))]
    public class ContentToggleView : MonoBehaviour
    {
        [Inject] private FontService _fontService;
        
        private Image _image;
        private TextMeshProUGUI _text;
        
        public event Action OnClick;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void HandleClick() => OnClick?.Invoke();

        public void SetSelected(bool selected)
        {
            var color = _image.color;
            color.a = selected ? 1f : 0f;
            _image.color = color;

            _text.font = selected ? _fontService.Bold : _fontService.Regular;
            _text.color = selected ? _fontService.Bright : _fontService.Grey;
        }
    }
}
