using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.WindowsManagerSystem
{
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