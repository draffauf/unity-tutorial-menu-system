using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryItemList : MonoBehaviour
{
  [SerializeField]
  private GameObject _content = default;
  [SerializeField]
  private GameObject _menuItemTemplate = default;
  [SerializeField]
  private List<InventoryItem> _list = default;
  [SerializeField]
  private ActiveInventoryItemChangeEvent activeInventoryItemChangeEvent = default; 

  void Awake()
  {
    AddMenuItems();
    ActivateFirstItem();
  }

  void AddMenuItems() {
    for (int index = 0; index < _list.Count; index++) {
      AddMenuItem(_list[index]);
    }
  }

  void AddMenuItem(InventoryItem item)
  {
    GameObject newMenuItem;
    string label = $"   {item.label}";
    newMenuItem = Instantiate(_menuItemTemplate, transform.position, transform.rotation);
    newMenuItem.name = label;
    newMenuItem.transform.SetParent(_content.transform, true);
    newMenuItem.SetActive(true);
    newMenuItem.GetComponentInChildren<Text>().text = label;
    newMenuItem.GetComponent<ItemChooser>().item = item;
  }

  void ActivateFirstItem() {
    InventoryItem activeItem = _list[0];

    if (activeItem != null) {
      activeInventoryItemChangeEvent.Invoke(activeItem);
    }
  } 
}
