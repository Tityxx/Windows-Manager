using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Tityx.WindowsManagerSystem
{
    public class WindowsManager : IWindowsManager
    {
        public event Action<WindowData> onWindowOpened = delegate { };
        public event Action<WindowData> onWindowClosed = delegate { };

        private readonly IInstantiator _instantiator;
        private readonly Transform _windowsContainer;
        private readonly Dictionary<WindowData, Window> _windowsDictionary;
        private readonly HashSet<Window> _openedWindows;

        private Window _lastClosedWindow;

        private Window _currentWindow => _openedWindows.Last();

        public WindowsManager(IInstantiator instantiator, Transform windowsContainer)
        {
            _instantiator = instantiator;
            _windowsContainer = windowsContainer;
            _windowsDictionary = new();
            _openedWindows = new();
        }

        public Window OpenWindow(WindowData data, bool closeLastWindow)
        {
            if (!_windowsDictionary.TryGetValue(data, out Window window))
            {
                CreateWindow(data);
                return OpenWindow(data, closeLastWindow);
            }
            if (closeLastWindow && _openedWindows.Count > 0 && _currentWindow)
                _currentWindow.Close(window.Open);
            else
                window.Open();

            return window;
        }

        public Window OpenPreviousWindow(bool closeLastWindow)
        {
            if (_lastClosedWindow == null)
                return null;
            return OpenWindow(_lastClosedWindow.Data, closeLastWindow);
        }

        public void CloseWindow(WindowData data)
        {
            if (_windowsDictionary.TryGetValue(data, out Window window))
            {
                _lastClosedWindow = window;
                window.Close();
            }
            else
            {
                Debug.LogError($"Window with name '{data.name}' not found!");
            }
        }

        public void CloseWindows(IEnumerable<WindowData> windows)
        {
            foreach (var w in windows)
            {
                CloseWindow(w);
            }
        }

        public void CloseAllWindows()
        {
            for (int i = _openedWindows.Count - 1; i >= 0; i--)
            {
                CloseWindow(_openedWindows.ElementAt(i).Data);
            }
        }

        public bool TryGetWindowByData(WindowData data, out Window window)
        {
            return _windowsDictionary.TryGetValue(data, out window);
        }

        public Window GetWindowByData(WindowData data)
        {
            return _windowsDictionary[data];
        }

        public void AddWindowToList(Window window)
        {
            _openedWindows.Add(window);
        }

        public void RemoveWindowFromList(Window window)
        {
            _openedWindows.Remove(window);
        }

        private void CreateWindow(WindowData data)
        {
            Window window = _instantiator.InstantiatePrefabForComponent<Window>(data.WindowPrefab, _windowsContainer,
                new object[] {this, data});
            _windowsDictionary.Add(data, window);
        }
    }
}