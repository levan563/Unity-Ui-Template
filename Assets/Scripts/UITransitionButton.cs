using UnityEngine.EventSystems;
using UnityEngine;

namespace UI
{
    public class UITransitionButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UIWindow next;

        private UIWindow current;
       

        private void Awake()
        {
            current = GetComponentInParent<UIWindow>();
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!current.IsClickable) return;

            current.Fold();

            UIManager.Instance.RunLater(
                () => { next.Expand(); }, current.FoldTime);
        }
    }
}
