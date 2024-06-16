using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.WindowsManagerSystem
{
    public class OpenWindowOnAwake : MonoBehaviour
    {
        [SerializeField] private WindowData _window;

        [Inject] private IWindowsManager _manager;

        private void Awake()
        {
            _manager.OpenWindow(_window, false);
        }
    }
}