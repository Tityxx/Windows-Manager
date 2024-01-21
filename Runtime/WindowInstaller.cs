using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    /// <summary>
    /// Инсталлер для окна. Используется в GameObjectContext
    /// </summary>
    [RequireComponent(typeof(Window))]
    public class WindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var window = GetComponent<Window>();
            Container.Bind(window.GetType()).FromInstance(window).AsSingle();
        }
    }
}