using UnityEngine;

namespace _Project.Common
{
    [RequireComponent(typeof(PositionUpdater))]
    public class CharacterView : MonoBehaviour
    {
        public void Install(CharacterContext character)
        {
            GetComponent<PositionUpdater>().Construct(character);
        }
    }
}