namespace d4160.UI.Loading
{
    using d4160.Core;
#if NAUGHTY_ATTRIBUTES
    using NaughtyAttributes;
#endif
    using UnityEngine;
    using UnityEngine.UI;
#if UNITY_INPUT_SYSTEM
    using TMPro;
#endif

    public class CustomLoadingScreen : LoadingScreenBase
    {
        public CanvasGroup canvasGroup;
        public AdvicesSO advicesSO;
        public bool setRandomAdviceAtStart;

        [Header("TITLES")]
#if NAUGHTY_ATTRIBUTES
        [ShowIf("enableTitle")]
#endif
        public TextMeshProUGUI title;
#if NAUGHTY_ATTRIBUTES
        [ShowIf("enableTitle")]
#endif
        public string titleText;
#if NAUGHTY_ATTRIBUTES
        [ShowIf("enableTitleDesc")]
#endif
        public TextMeshProUGUI description;
#if NAUGHTY_ATTRIBUTES
        [ShowIf("enableTitleDesc")]
#endif
        public string titleDescText;
        public Image image;

        public float fadingAnimationSpeed = 2f;

        [Header("CONTINUE")]
        public bool enableTapToContinue = true;
#if NAUGHTY_ATTRIBUTES
        [ShowIf("enablePressAnyKey")]
#endif

        private bool _externalTapProcess;

        public bool ExternalTapProcess
        {
            get => _externalTapProcess;
            set => _externalTapProcess = value;
        }

        private void Start()
        {
            if (setRandomAdviceAtStart)
            {
                SetAdviceInfo(advicesSO.advices.RandomIndex());
            }
        }

        public void SetAdviceInfo(int idx)
        {
            SetTitleText(advicesSO.GetAdviceTitle(idx));
            SetDescriptionText(advicesSO.GetAdvice(idx));
            SetSprite(advicesSO.GetAdviceSprite(idx));
        }

        public void SetTitleText(string text)
        {
            title.text = text;
        }

        public void SetDescriptionText(string text)
        {
            description.text = text;
        }

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        protected override void UpdateCallback(float dt)
        {
            //Debug.Log($"Elapsed: {m_elapsedLoadingTime}, LoadCompleted? {m_sceneAsyncLoadCompleted}, AsyncLoadingProgress? {m_sceneAsyncLoadingProgress}");

            UpdateElapsedLoadingTime();

            if (ReadyToContinue)
            {
                if (!enableTapToContinue)
                {
                    // Fade out
                    canvasGroup.alpha -= fadingAnimationSpeed * Time.deltaTime;

                    // If fade out is complete, then disable the object
                    if (canvasGroup.alpha <= 0)
                    {
                        FinishAndContinue();
                    }
                }
                else
                {
                    if (ProcessTap())
                    {
                        FinishAndContinue();
                    }
                }
            }
        }

        protected virtual bool ProcessTap()
        {
#if UNITY_INPUT_SYSTEM
            if (_externalTapProcess)
            {
                return true;
            }
#endif
            return false;
        }
    }
}


