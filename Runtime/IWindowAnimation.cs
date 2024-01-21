using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.UserInterfaceManager
{
    /// <summary>
    /// Интерфейс для анимации открытия/закрытия окон
    /// </summary>
    public interface IWindowAnimation
    {
        /// <summary>
        /// Открытие окна
        /// </summary>
        public void Open();

        /// <summary>
        /// Закрытие окна
        /// </summary>
        public void Close(Action action);
    }
}