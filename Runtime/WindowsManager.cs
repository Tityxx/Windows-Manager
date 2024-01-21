using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    /// <summary>
    /// Source: https://gitlab.com/syhodyb99/tools-and-mechanics
    /// Контроллер окон
    /// </summary>
    public class WindowsManager : IWindowsManager
    {
        private IInstantiator _instantiator;

        private Dictionary<WindowData, Window> _windowsDictionary = new Dictionary<WindowData, Window>();

        private List<Window> _windowsList = new List<Window>();
        private Window _currentWindow => _windowsList.LastOrDefault(w => w.gameObject.activeSelf);
        private Canvas _canvas;
        private Transform _windowsContainer;
        private bool _inited;

        public void Setup(IInstantiator instantiator, Canvas canvas)
        {
            _instantiator = instantiator;
            _canvas = canvas;
        }

        private void Init()
        {
            if (_canvas) _canvas = _instantiator.InstantiatePrefabForComponent<Canvas>(_canvas);
            else _windowsContainer = new GameObject("Windows Container").transform;
            _inited = true;
        }

        public void OpenWindow(WindowData data, bool closeCurrentWindow)
        {
            if (!_inited) Init();

            if (_windowsDictionary.TryGetValue(data, out Window window))
            {
                if (closeCurrentWindow && _windowsList.Count > 0 && _currentWindow)
                {
                    _currentWindow.Close(window.Open);
                }
                else
                {
                    window.Open();
                }
            }
            else
            {
                CreateWindow(data);
                OpenWindow(data, closeCurrentWindow);
            }
        }

        public void OpenPreviousWindow(bool closeLastWindow = true)
        {
            if (!_inited) Init();

            if (_windowsList.Count > 1)
            {
                OpenWindow(_windowsList[^2].Data, closeLastWindow);
            }
        }

        public void CloseWindow(WindowData data)
        {
            if (!_inited) Init();

            if (_windowsDictionary.TryGetValue(data, out Window window))
            {
                window.Close();
            }
            else
            {
                Debug.LogError($"Окно с именем '{data.name}' не найдено");
            }
        }

        public void CloseWindows(List<WindowData> windows)
        {
            foreach (var w in windows)
            {
                CloseWindow(w);
            }
        }

        public void CloseAllWindows()
        {
            for (int i = _windowsList.Count - 1; i >= 0; i--)
            {
                CloseWindow(_windowsList[i].Data);
            }
        }

        public bool TryGetWindowByData(WindowData data, out Window window)
        {
            return _windowsDictionary.TryGetValue(data, out window);
        }

        public void AddWindowToList(Window window)
        {
            if (_windowsList.Contains(window))
            {
                _windowsList.Remove(window);
            }
            _windowsList.Add(window);
        }

        public void RemoveWindowFromList(Window window)
        {
            _windowsList.Remove(window);
        }

        private void CreateWindow(WindowData data)
        {
            Window window = _instantiator.InstantiatePrefabForComponent<Window>(data.WindowPrefab, _canvas ? _canvas.transform : _windowsContainer);
            window.Data = data;
            window.gameObject.name = data.name;
            _windowsDictionary.Add(data, window);
        }
    }
}