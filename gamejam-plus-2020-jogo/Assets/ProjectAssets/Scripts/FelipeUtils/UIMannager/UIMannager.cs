using System;
using System.Collections;
using System.Collections.Generic;
using FelipeUtils.Singleton;

namespace FelipeUtils.UIMannagement
{
    public abstract class UIMannager : Singleton<UIMannager>
    {
        private UIHidable[] _screens = null;
        protected UIHidable[] Screens 
        {
            get
            {
                if(_screens == null)
                {
                    _screens = FindObjectsOfType<UIHidable>();
                    Array.Sort(_screens);
                }
                return _screens;
            }
        }

        protected void HideAll()
        {
            foreach (var screen in Screens)
                screen.Hide();
        }
    }
}
