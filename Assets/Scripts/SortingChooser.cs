using UnityEngine;
using UnityEngine.Events;

public class SortingChooser : MonoBehaviour
{
  [SerializeField]
  private InventoryItemListSortingChangeEvent inventoryItemListSortingChangeEvent = default;

  public string property;

  public void ChooseSort()
  {
    inventoryItemListSortingChangeEvent.Invoke(property);
  }
}