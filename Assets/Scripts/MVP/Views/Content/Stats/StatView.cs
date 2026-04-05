using System.Globalization;
using TMPro;
using UnityEngine;

namespace MVP.Views.Content.Stats
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI subheader;
        [SerializeField] private TextMeshProUGUI points;

        private NumberFormatInfo _pointsFormat;
        
        private void Awake()
        {
            _pointsFormat = new NumberFormatInfo()
            {
                NumberGroupSeparator = " ",
                NumberDecimalDigits = 0
            };
        }
        
        public void SetHeader(string text) =>  header.text = text.ToUpper();
        public void SetSubheader(string text) =>  subheader.text = text.ToUpper();
        public void SetPoints(int number) => points.text = number.ToString("N", _pointsFormat) + " PT.";
    }
}