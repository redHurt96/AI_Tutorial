using UnityEngine;

namespace _Project.Common
{
    public class PositionUpdater : MonoBehaviour
    {
        private CharacterContext _characterContext;

        public void Construct(CharacterContext characterContext) => 
            _characterContext = characterContext;

        private void Update()
        {
            _characterContext.SetPosition(transform.position);
        }
    }
}