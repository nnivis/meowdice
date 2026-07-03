using CodeBase.Services.Interaction;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.Domain.Dice
{
    public class DiceView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private DiceViewContent _diceViewContent;
        [SerializeField] private Image _stateImage;
        [SerializeField] private Image _pointImage;
        
        private IDiceDragHandler _dragHandler;
        
        public void Bind(IDiceDragHandler dragHandler)
        {
            _dragHandler = dragHandler;
        }

        public void Render(DiceStateType stateType, DicePointType pointType)
        {
            SetStateSprite(stateType);
            SetPointSprite(pointType);
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("BeginDrag");
    
            if (_dragHandler == null)
                return;

            _dragHandler.BeginDrag(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("Dragging");

            if (_dragHandler == null)
                return;

            _dragHandler.Drag(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
           // Debug.Log("EndDrag");

            if (_dragHandler == null)
                return;

            _dragHandler.EndDrag(eventData.position);
        }

        private void SetStateSprite(DiceStateType state) =>
            _stateImage.sprite = _diceViewContent.GetSprite(state);

        private void SetPointSprite(DicePointType pointType) =>
            _pointImage.sprite = _diceViewContent.GetSprite(pointType);
    }
}