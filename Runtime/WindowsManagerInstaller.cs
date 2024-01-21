using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.UserInterfaceManager
{
    [CreateAssetMenu(menuName = "ToolsAndMechanics/Windows Manager/Installer")]
    public class WindowsManagerInstaller : ScriptableObjectInstaller
    {
        [SerializeField, Tooltip("Optional")] private Canvas _canvas;

        public override void InstallBindings()
        {
            var m = new WindowsManager();
            m.Setup(Container, _canvas);
            Container.Bind<IWindowsManager>().To<WindowsManager>().FromInstance(m).AsSingle();
        }
    }
}