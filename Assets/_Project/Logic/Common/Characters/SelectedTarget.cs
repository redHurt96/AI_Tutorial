using UnityEngine;

namespace _Project.Common.Characters
{
    public class SelectedTarget : MonoBehaviour
    {
        public bool Any => Value != null;
        
        [field:SerializeField] public Character Value;

        public void Select(Character value)
        {
            Value = value;
        }

        public void Clear()
        {
            Value = null;
        }
    }
}