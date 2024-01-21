using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    using Utilities.UI;

    /// <summary>
    /// Закрытие списка окон
    /// </summary>
    public class CloseWindowsButton : AbstractButton
    {
        [SerializeField] private List<WindowData> _windows;

        [Inject] private IWindowsManager _manager;

        public override void OnButtonClick()
        {
            _manager.CloseWindows(_windows);
        }
    }
}