using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using Zenject;

namespace MVP.Views.Content.Stats
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI subheader;
        [SerializeField] private TMP_InputField points;

        public Action<long> PointsChangedCallback { private get; set; }

        private NumberFormatInfo _pointsFormat;
        
        private void Awake()
        {
            _pointsFormat = new NumberFormatInfo()
            {
                NumberGroupSeparator = " ",
                NumberDecimalDigits = 0
            };
        }

        private void OnEnable()
        {
            points.onValueChanged.AddListener(HandleValueChanged);
            points.onEndEdit.AddListener(HandleEndEdit);
        }

        private void OnDisable()
        {
            points.onValueChanged.RemoveListener(HandleValueChanged);
            points.onEndEdit.RemoveListener(HandleEndEdit);
        }

        public void SetHeader(string text) =>  header.text = text.ToUpper();
        public void SetSubheader(string text) =>  subheader.text = text.ToUpper();
        public void SetPoints(long number) => points.text = ConvertPointsLongToString(number);

        private void HandleValueChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                points.text = "0 PT.";
                return;
            }

            var rawPoints = Regex.Replace(value, "[^0-9]", "");

            if (!rawPoints.Any(char.IsDigit))
            {
                points.text = "0 PT.";
                return;
            }
            
            var newPoints = long.Parse(rawPoints);
            
            SetPoints(newPoints);
        }

        private void HandleEndEdit(string value)
        {
            var newPoints = long.Parse(Regex.Replace(value, "[^0-9]", ""));
            PointsChangedCallback?.Invoke(newPoints);
        }
        
        private string ConvertPointsLongToString(long number) => number.ToString("N", _pointsFormat) + " PT.";
        
        public class Factory : PlaceholderFactory<StatView> {}
    }
}