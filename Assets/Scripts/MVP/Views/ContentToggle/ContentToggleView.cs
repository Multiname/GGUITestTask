using System;
using Configs;
using DG.Tweening;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace MVP.Views.ContentToggle
{
    [RequireComponent(typeof(Image))]
    public class ContentToggleView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private FontService _fontService;
        [Inject] private UiEffectsConfig _effectsConfig;
        
        private Image _image;
        private TextMeshProUGUI _text;
        
        public event Action OnClick;

        private bool _selected;
        private bool _hovered;
        private bool _fadingOut;
        
        private Tween _fadeTween;
        private Sequence _flickerSequence;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void HandleClick() => OnClick?.Invoke();

        public void SetSelected(bool selected)
        {
            if (_selected == selected) return;
            _selected = selected;
            
            _flickerSequence.Kill();
            _fadeTween.Kill();
            _fadingOut = true;
            _fadeTween = _image.DOFade(
                selected ? 1f : 0f,
                _effectsConfig.ToggleSelectTransitionDuration
            )
                .SetEase(Ease.Linear)
                .OnComplete(HandleFadeTweenComplete);

            _text.DOColor(
                selected ? _fontService.Bright : _fontService.Grey,
                _effectsConfig.ToggleSelectTransitionDuration
            ).SetEase(Ease.Linear);

            _text.font = selected ? _fontService.Bold : _fontService.Regular;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _hovered = true;
            if (_selected || _fadingOut) return;
            
            StartFlicker();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _hovered = false;
            if (_selected || _fadingOut) return;
            
            _flickerSequence.Kill();
            _fadingOut = true;
            var alphaPercentage = _image.color.a / _effectsConfig.ToggleHoverMaxAlpha;
            _fadeTween = _image.DOFade(0f, _effectsConfig.ToggleHoverFlickerDuration * alphaPercentage)
                .SetEase(Ease.Linear)
                .OnComplete(HandleFadeTweenComplete);
        }

        private void StartFlicker()
        {
            _flickerSequence = DOTween.Sequence();
            _flickerSequence
                .Append(_image.DOFade(
                        _effectsConfig.ToggleHoverMaxAlpha,
                        _effectsConfig.ToggleHoverFlickerDuration)
                    .SetEase(Ease.Linear))
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void HandleFadeTweenComplete()
        {
            _fadingOut = false;
            if (_hovered && !_selected) StartFlicker();
        }
    }
}
