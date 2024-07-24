using System;
using System.Collections.Generic;

namespace Tityx.WindowsManagerSystem
{
    public interface IWindowsManager
    {
        public event Action<WindowData> onWindowOpened;
        public event Action<WindowData> onWindowClosed;

        /// <summary>
        /// Open window
        /// </summary>
        /// <param name="data">Window config</param>
        /// <param name="closeLastWindow">Should close the previous window?</param>
        public Window OpenWindow(WindowData data, bool closeLastWindow);

        /// <summary>
        /// Open the previous window
        /// </summary>
        /// <param name="closeLastWindow">Should close the previous window?</param>
        public Window OpenPreviousWindow(bool closeLastWindow = true);

        /// <summary>
        /// Close window
        /// </summary>
        /// <param name="data">Window config</param>
        public void CloseWindow(WindowData data);

        /// <summary>
        /// Close windows
        /// </summary>
        /// <param name="data">Window configs</param>
        public void CloseWindows(IEnumerable<WindowData> windows);

        /// <summary>
        /// Close opened windows
        /// </summary>
        public void CloseAllWindows();

        /// <summary>
        /// Get window by config
        /// </summary>
        /// <param name="data">Window config</param>
        /// <param name="window">Window</param>
        /// <returns>true if not null</returns>
        public bool TryGetWindowByData(WindowData data, out Window window);

        /// <summary>
        /// Get window by config
        /// </summary>
        /// <param name="data">Window config</param>
        /// <returns>Window</returns>
        public Window GetWindowByData(WindowData data);

        /// <summary>
        /// Add a window to the list of open windows
        /// </summary>
        /// <param name="window">Window</param>
        public void AddWindowToList(Window window);

        /// <summary>
        /// Remove a window to the list of open windows
        /// </summary>
        /// <param name="window"> Window </param>
        public void RemoveWindowFromList(Window window);
    }
}