using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Window
{
    [CreateAssetMenu(fileName = "WindowStaticData", menuName = "Static Data/Window static data")]

    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}