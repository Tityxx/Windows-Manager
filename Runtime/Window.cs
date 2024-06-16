using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.WindowsManagerSystem
{
    public class Window : MonoBehaviour
    {
        protected IWindowsManager _windowsManager;
        protected WindowData _data;
        protected IWindowAnimation _anim;
        protected bool _isOpen;

        protected Action _actionOnClose;

        public WindowData Data => _data;

        [Inject]
        private void Construct(IWindowsManager windowsManager, WindowData data)
        {
            _windowsManager = windowsManager;
            _data = data;
            gameObject.name = data.name;
        }

        protected virtual void Awake()
        {
            _anim = GetComponent<IWindowAnimation>();
        }

        public virtual void Open()
        {
            if (_isOpen)
                return;

            _isOpen = true;
            gameObject.SetActive(true);
            _windowsManager.AddWindowToList(this);
            OpenInner();
        }

        public virtual void Close(Action action = null)
        {
            if (!_isOpen)
                return;

            _isOpen = false;
            _actionOnClose = action;

            if (_anim != null)
                _anim.Close(CloseInner);
            else
                CloseInner();
        }

        protected virtual void OpenInner() { }

        protected virtual void CloseInner()
        {
            _windowsManager.RemoveWindowFromList(this);
            gameObject.SetActive(false);
            _actionOnClose?.Invoke();
        }
    }
}