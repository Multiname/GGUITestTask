using TMPro;
using UnityEngine;

namespace MVP.Views.Profile
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PlayerNicknameView : MonoBehaviour
    {
        private TextMeshProUGUI _nickname;

        private void Awake()
        {
            _nickname = GetComponent<TextMeshProUGUI>();
        }

        public void SetNickname(string nickname)
        {
            _nickname.text = nickname.ToUpper();
        }
    }
}
