namespace GameFramework
{
    using d4160.GameFramework;
    using d4160.UI.Loading;
    using UnityEngine;

    public class LoadingScreenLauncher : DefaultLoadingScreenLauncher
    {
        int _levelIndexByAdvice;

        public void SetLevelIndexByAdvice(int index)
        {
            _levelIndexByAdvice = index;
        }

        protected override void LoadLevelScene(bool setActiveAsMainScene = false, System.Action onCompleted = null)
        {
            var buildIndex = (GameFrameworkSettings.GameDatabase[3] as ILevelSceneGetter)?.GetSceneBuildIndex(m_levelScene);

            Debug.Log($"(LoadingScreen Launcher) Loading Level Scene: {buildIndex} index");

            if (!buildIndex.HasValue || buildIndex == -1)
            {
                onCompleted?.Invoke();
                return;
            }

            m_sceneLoader.LoadSceneAsync(
                buildIndex.Value,
                setActiveAsMainScene,
                null,
                () => {
                    var level = m_levelTypeToLoad == LevelType.General ? m_generalLevelToLoad : m_gameModeLevelToLoad;
                    var loadinScreen = (LoadingScreenBase.Instance as CustomLoadingScreen);

                    loadinScreen.SetAdviceInfo(_levelIndexByAdvice);

                    GameManager.Instance.LoadLevel(m_levelTypeToLoad, level);
                    loadinScreen.StartLoad();

                    onCompleted?.Invoke();
                },
                true,
                null
            );
        }
    }
}