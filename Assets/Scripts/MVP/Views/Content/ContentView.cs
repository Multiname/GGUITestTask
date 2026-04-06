using Configs;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Sequence = DG.Tweening.Sequence;

namespace MVP.Views.Content
{
    public class ContentView : MonoBehaviour
    {
        private const string OverviewContentHeader = "OVERVIEW";
        private const string AchievementsContentHeader = "ACHIEVEMENTS";
        private static readonly int DividerTransitionProperty = Shader.PropertyToID("_Divider");
        
        [SerializeField] private TextMeshProUGUI contentHeader;

        [SerializeField] private GameObject overviewScrollView;
        [SerializeField] private GameObject achievementsScrollView;
        
        [SerializeField] private Image overviewTransitionMask;
        [SerializeField] private Image achievementsTransitionMask;
        
        [Inject] private UiEffectsConfig _effectsConfig;

        private Tween _transitionTween;
        private Sequence _transitionSequence;

        public void ShowOverview()
        {
            contentHeader.text = OverviewContentHeader;
            
            PlayTransition(true);
        }
        
        public void ShowAchievements()
        {
            contentHeader.text = AchievementsContentHeader;
            
            PlayTransition(false);
        }

        private void PlayTransition(bool showOverview)
        {
            if (showOverview) overviewScrollView.SetActive(true);
            else achievementsScrollView.SetActive(true);
            
            _transitionSequence.Kill();
            _transitionSequence = DOTween.Sequence();
            
            _transitionSequence.Join(BuildHorizontalTransition(showOverview, true));
            _transitionSequence.Join(BuildHorizontalTransition(showOverview, false));

            _transitionSequence.OnComplete(() =>
            {
                if (showOverview) achievementsScrollView.SetActive(false);
                else overviewScrollView.SetActive(false);
            });
        }

        private Tween BuildHorizontalTransition(bool showOverview, bool overviewMask)
        {
            var mask = overviewMask ? overviewTransitionMask : achievementsTransitionMask;
            return DOTween.To(
                () => mask.material.GetFloat(DividerTransitionProperty),
                d =>
                {
                    var mat = new Material(mask.material);
                    mat.SetFloat(DividerTransitionProperty, d);
                    mask.material = mat;
                },
                showOverview ? 1 : 0,
                _effectsConfig.ContentTransitionDuration);
        }
    }
}
