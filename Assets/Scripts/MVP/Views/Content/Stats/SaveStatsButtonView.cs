using System;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVP.Views.Content.Stats
{
    [RequireComponent(typeof(Button))]
    public class SaveStatsButtonView : MonoBehaviour
    {
        [SerializeField] private Sprite activeButtonSprite;
        [SerializeField] private Sprite inactiveButtonSprite;

        [Inject] private FontService _fontService;

        public event Action OnClick;
        
        private Button _button;
        private TextMeshProUGUI _buttonText;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleClick);
        }

        public void SetActive(bool active)
        {
            _button.interactable = active;

            if (active)
            {
                _button.image.sprite = activeButtonSprite;
                _buttonText.color = _fontService.Bright;
            }
            else
            {
                _button.image.sprite = inactiveButtonSprite;
                _buttonText.color = _fontService.Dark;
            }
        }

        public void HandleClick() => OnClick?.Invoke();
    }
}