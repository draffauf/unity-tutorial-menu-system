using UnityEngine;
using UnityEngine.UI;

public class ItemDetail : MonoBehaviour
{
  [SerializeField]
  private InventoryItem _item = default;

  [SerializeField]
  private UnityEngine.UI.Text _text = default;

  public void SetItem(InventoryItem item) {
    _item = item;
    _text.text = _item.label;
  }
}
