using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.WindowsManagerSystem
{
    /// <summary>
    /// Данные об окне
    /// </summary>
    [CreateAssetMenu(menuName = "Tityx/Windows Manager/Window Data", fileName = "New Window")]
    public class WindowData : ScriptableObject
    {
        public Window WindowPrefab => _windowPrefab;

        [SerializeField] private Window _windowPrefab;
    }
}