using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Player.Input
{
    public class InputListener : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        private Vector2 _touchPosition = Vector3.zero;

        public event Action<Vector2> OnPlayerDrag; 

        public void OnPointerDown(PointerEventData eventData)
        {
            _touchPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 position = eventData.position - _touchPosition;
            _touchPosition = eventData.position;
            OnPlayerDrag?.Invoke(position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _touchPosition = Vector2.zero;
        }
    }
}