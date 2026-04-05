using TMPro;
using UnityEngine;

namespace MVP.Views.Content.Matches
{
    public class MatchView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI details;
        
        public void SetHeader(string text) =>  header.text = text.ToUpper();
        
        public void SetDetails(string text) =>  details.text = text.ToUpper();
    }
}
