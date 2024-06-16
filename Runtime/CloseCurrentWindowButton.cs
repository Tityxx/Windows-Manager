using System.Collections;
using Zenject;

namespace Tityx.WindowsManagerSystem
{
    using Utilities.UI;

    /// <summary>
    /// Закрытие окна, в котором расположена эта кнопка
    /// </summary>
    public class CloseCurrentWindowButton : AbstractButton
    {
        [Inject] private IWindowsManager _manager;
        [Inject] private Window _window;

        public override void OnButtonClick()
        {
            _manager.CloseWindow(_window.Data);
        }
    }
}