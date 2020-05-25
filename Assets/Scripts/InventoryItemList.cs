using System.Collections.Generic;
using System.Linq;
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
  private List<InventoryItem> _inventoryItems = default;
  [SerializeField]
  private ActiveInventoryItemChangeEvent activeInventoryItemChangeEvent = default; 

  private List<GameObject> _menuItems = new List<GameObject>();

  void Awake()
  {
    AddMenuItems();
    SortInventoryItems();
    SetMenuItems();
    ActivateFirstItem();
  }

  void AddMenuItems() {
    for (int index = 0; index < _inventoryItems.Count; index++) {
      AddMenuItem(_inventoryItems[index]);
    }
  }

  void AddMenuItem(InventoryItem item)
  {
    GameObject newMenuItem;
    newMenuItem = Instantiate(_menuItemTemplate, transform.position, transform.rotation);
    newMenuItem.SetActive(true);
    newMenuItem.transform.SetParent(_content.transform, true);
    _menuItems.Add(newMenuItem);
  }

  void ActivateFirstItem() {
    InventoryItem activeItem = _inventoryItems[0];

    if (activeItem != null) {
      activeInventoryItemChangeEvent.Invoke(activeItem);
    }
  } 

  void SetMenuItems() {
    for (int index = 0; index < _inventoryItems.Count; index++) {
      SetMenuItem(index);
    }
  }

  void SetMenuItem(int index) 
  {
    InventoryItem item = _inventoryItems[index];
    GameObject menuItem = _menuItems[index];

    string label = $"   {item.label}";
    menuItem.name = label;
    menuItem.GetComponentInChildren<Text>().text = label;
    menuItem.GetComponent<ItemChooser>().item = item;
  }

  void SortInventoryItems(string property = "name")
  {
    if (property == "name")
      _inventoryItems = _inventoryItems.OrderBy(item => item.name).ToList();
  }
}
