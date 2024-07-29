using UnityEngine;

namespace _Project.Common.Ui
{
    public class CanvasRotator : MonoBehaviour
    {
        private Camera _camera;

        private void Awake() => 
            _camera = Camera.main;

        private void Update() => 
            transform.LookAt(_camera.transform.position);
    }
}