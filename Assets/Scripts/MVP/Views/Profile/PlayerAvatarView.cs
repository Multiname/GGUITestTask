using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views.Profile
{
    [RequireComponent(typeof(Image))]
    public class PlayerAvatarView : MonoBehaviour
    {
        private Image _avatar;

        private void Awake()
        {
            _avatar = GetComponent<Image>();
        }
        
        public void SetAvatar(Sprite sprite) => _avatar.sprite = sprite;
    }
}
