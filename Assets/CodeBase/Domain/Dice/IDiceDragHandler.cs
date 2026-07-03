using UnityEngine;

namespace CodeBase.Domain.Dice
{
    public interface IDiceDragHandler
    {
          void BeginDrag(DiceView view);
          void Drag(Vector2 screenPosition);
          void EndDrag(Vector2 screenPosition);
    }
}