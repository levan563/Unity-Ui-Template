using UnityEngine;

namespace UI
{
    public class UIWindow : MonoBehaviour
    {
        [SerializeField] private float _expandTime;
        [SerializeField] private float _foldTime;        

        private Animator _animator;
        private bool _isClickable = true;

        public bool IsClickable
        {
            get { return this._isClickable; }
            set { this._isClickable = value; }
        }
        public float ExpandTime
        {
            get { return this._expandTime; }
        }
        public float FoldTime
        {
            get { return this._foldTime; }
        }
        public bool IsOpened
        {
            get { return _animator.GetBool("isOpened"); }         
        }


        public void Fold()
        {            
            _isClickable = false;
            _animator.SetBool("isOpened", false);

            UIManager.Instance.RunLater(
                () => { gameObject.SetActive(false); }, _foldTime);
        }

        public void Expand()
        {
            gameObject.SetActive(true);
            transform.SetAsFirstSibling();

            _animator.SetBool("isOpened", true);            

            UIManager.Instance.RunLater(
                () => { _isClickable = true; }, _expandTime);
        }

        public void Initialize()
        {
            if (!_animator) _animator = GetComponent<Animator>();
        }
    }
}
