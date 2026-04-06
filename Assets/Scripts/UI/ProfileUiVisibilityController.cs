using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class ProfileUiVisibilityController : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        
        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame) canvas.SetActive(!canvas.activeSelf);
        }
    }
}
