using System;

namespace Tityx.WindowsManagerSystem
{
    /// <summary>
    /// Interface for animation of opening/closing windows
    /// </summary>
    public interface IWindowAnimation
    {
        /// <summary>
        /// Window opening
        /// </summary>
        public void Open();

        /// <summary>
        /// Window closing
        /// </summary>
        public void Close(Action action);
    }
}