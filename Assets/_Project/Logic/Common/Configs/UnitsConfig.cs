using UnityEngine;

namespace _Project.Logic.Common.Configs
{
    [CreateAssetMenu(menuName = "Create UnitsConfig", fileName = "UnitsConfig", order = 0)]
    public class UnitsConfig : ScriptableObject
    {
        public UnitConfig Melee;
        public UnitConfig Range;
        public UnitConfig Tower;
    }
}