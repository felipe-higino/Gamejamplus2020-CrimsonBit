using System;
using UnityEngine;

namespace FelipeUtils.UIMannagement
{
    /// <summary>
    /// Must organize the screen game objects in alphabetic order
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIHidable : MonoBehaviour, IComparable<UIHidable>
    {
        private bool isHide = false;
        public bool IsHide { get => isHide; }

        CanvasGroup _canvasGroup = null;
        CanvasGroup CanvasGroup
        {
            get
            {
                if(_canvasGroup == null)
                    _canvasGroup = GetComponent<CanvasGroup>();
                return _canvasGroup;
            }
        }

        public virtual void Hide() 
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.interactable = false;
            isHide = true; 
        }

        public virtual void Show()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.interactable = true;
            isHide = false;
        }

        //sort, Icomparable
        public int CompareTo(UIHidable obj)
        {
            var otherName = obj.name;
            var thisName = name;
            return String.Compare(thisName, otherName);
        }

    }

    [ExecuteAlways]
    public class UIHidablePerformant : UIHidable
    {
        //editor variables
        [SerializeField]
        bool visible = true;
        bool lastVisible = true;

        private void Update()
        {
            if (Application.isPlaying)
            {
                return;
            }

            #region toggle visibility;
            if (lastVisible != visible)
            {
                lastVisible = visible;
                if (visible)
                    Show();
                else
                    Hide();
            }
            #endregion
        }

        public override void Show()
        {
            base.Show();
            if (Application.isPlaying)
                gameObject.SetActive(true);
        }

        public override void Hide()
        {
            base.Hide();
            if (Application.isPlaying)
                gameObject.SetActive(false);
        }
    }
}
