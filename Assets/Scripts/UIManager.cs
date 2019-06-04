using System.Collections;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour, UI.Data.IRunLater
    {
        private static UIManager _uiManager;
        private UIWindow[] _windows;


        public static UIManager Instance
        {
            get { return _uiManager ?? (_uiManager = new UIManager()); }
        }


        private void Awake()
        {
            if (!_uiManager)
            {
                _uiManager = this;
                _windows = Resources.FindObjectsOfTypeAll<UIWindow>();

                for (int i = 0; i < _windows.Length; i++)
                {
                    _windows[i].Initialize();
                }
            }
        }


        public void RunLater(System.Action method, float waitSeconds)
        {
            if (waitSeconds < 0 || method == null)
            {
                return;
            }
            StartCoroutine(RunLaterCoroutine(method, waitSeconds));
        }

        public IEnumerator RunLaterCoroutine(System.Action method, float waitSeconds)
        {
            yield return new WaitForSeconds(waitSeconds);
            method();
        }
    }
}
