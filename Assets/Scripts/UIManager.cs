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
            get {
                if (!_uiManager)
                {
                    GameObject gm = new GameObject("UIManager", typeof(UIManager));
                    gm.transform.SetAsFirstSibling();
                    DontDestroyOnLoad(gm);

                    _uiManager = gm.GetComponent<UIManager>();                    
                }
                return _uiManager;
            }
        }
        

        private void Awake()
        {
            if (!_uiManager) _uiManager = this;
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
