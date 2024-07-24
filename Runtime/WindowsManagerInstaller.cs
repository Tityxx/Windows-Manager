using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tityx.WindowsManagerSystem
{
    [CreateAssetMenu(menuName = "Tityx/Windows Manager/Installer", fileName = "Windows Manager Installer")]
    public class WindowsManagerInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WindowsManager>().AsSingle().WithArguments(Container, new GameObject("Windows Container").transform);
        }
    }
}