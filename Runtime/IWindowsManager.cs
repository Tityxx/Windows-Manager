using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    public interface IWindowsManager
    {
        /// <summary>
        /// Прокидывание ссылок для инициализации
        /// </summary>
        /// <param name="canvas"> Канвас, на котором будут окна </param>
        public void Setup(IInstantiator instantiator, Canvas canvas);

        /// <summary>
        /// Открыть выбранное окно
        /// </summary>
        /// <param name="data">Дата окна</param>
        /// <param name="closeLastWindow"> Нужно ли закрывать предыдущее окно </param>
        public void OpenWindow(WindowData data, bool closeLastWindow);

        /// <summary>
        /// Открыть предыдущее окно
        /// </summary>
        /// <param name="closeLastWindow"> Нужно ли закрывать выбранное окно </param>
        public void OpenPreviousWindow(bool closeLastWindow = true);

        /// <summary>
        /// Закрыть выбранное окно
        /// </summary>
        /// <param name="data">Дата окна</param>
        public void CloseWindow(WindowData data);

        /// <summary>
        /// Закрыть выбранные окна
        /// </summary>
        /// <param name="data">Окна</param>
        public void CloseWindows(List<WindowData> windows);

        /// <summary>
        /// Закрыть активные окна
        /// </summary>
        public void CloseAllWindows();

        /// <summary>
        /// Получить префаб окна по дате
        /// </summary>
        /// <param name="data">Дата окна</param>
        public bool TryGetWindowByData(WindowData data, out Window window);

        /// <summary>
        /// Добавить окно в список открытых окон
        /// </summary>
        /// <param name="window"> Окно </param>
        public void AddWindowToList(Window window);

        /// <summary>
        /// Удалить окно из списка открытых окон
        /// </summary>
        /// <param name="window"> Окно </param>
        public void RemoveWindowFromList(Window window);
    }
}