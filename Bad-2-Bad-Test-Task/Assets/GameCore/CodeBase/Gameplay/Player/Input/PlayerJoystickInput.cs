using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCore.CodeBase.Gameplay.Player.Input
{
    public class PlayerJoystickInput : PlayerInputDevice, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private RectTransform _background;
        [SerializeField] private RectTransform _pointer;
        private Vector2 _initialPointerPosition;

        private void Awake() => _initialPointerPosition = _pointer.anchoredPosition;

        public void OnPointerDown(PointerEventData eventData) =>
            OnDrag(eventData);

        public void OnPointerUp(PointerEventData eventData)
        {
            SetInputVector(InputVectorDefaultValue);
            _pointer.anchoredPosition = _initialPointerPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _background, eventData.position, eventData.pressEventCamera, out var point))
                SetInputVector(CalculateInputVector(point));
        }

        private Vector2 CalculateInputVector(Vector2 point)
        {
            var sizeDelta = _background.sizeDelta;

            point.x /= sizeDelta.x;
            point.y /= sizeDelta.y;

            var inputVector = point * 2;

            if (inputVector.magnitude > 1)
                inputVector = inputVector.normalized;

            _pointer.anchoredPosition = inputVector * sizeDelta / 2.5f;
            return inputVector;
        }
    }
}