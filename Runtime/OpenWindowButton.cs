using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    using Utilities.UI;

    /// <summary>
    /// Кнопка открытия окна
    /// </summary>
    public class OpenWindowButton : AbstractButton
    {
        [SerializeField] private WindowData _window;
        [SerializeField] private bool _closeCurrentWindow = true;

        [Inject] private IWindowsManager _manager;

        protected override void OnEnable()
        {
            base.OnEnable();
            _btn.interactable = true;
        }

        public override void OnButtonClick()
        {
            if (_closeCurrentWindow)
                _btn.interactable = false;
            _manager.OpenWindow(_window, _closeCurrentWindow);
        }
    }
}