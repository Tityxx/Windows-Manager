using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    using Utilities.UI;

    /// <summary>
    /// Кнопка закрытия окна
    /// </summary>
    public class CloseWindowButton : AbstractButton
    {
        [SerializeField] private WindowData _window;

        [Inject] private IWindowsManager _manager;

        public override void OnButtonClick()
        {
            _manager.CloseWindow(_window);
        }
    }
}