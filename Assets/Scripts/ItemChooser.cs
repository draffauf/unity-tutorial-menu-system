using UnityEngine;
using UnityEngine.Events;

public class ItemChooser : MonoBehaviour
{
  [SerializeField]
  private ActiveInventoryItemChangeEvent activeInventoryItemChangeEvent = default;

  public InventoryItem item;

  public void ChooseItem()
  {
    activeInventoryItemChangeEvent.Invoke(item);
  }
}
