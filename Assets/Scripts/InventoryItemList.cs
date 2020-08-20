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

    string spacer = "   ";
    string label = $"{spacer}{item.label}";
    menuItem.name = label;
    menuItem.transform.Find("Name").GetComponent<Text>().text = label;
    menuItem.transform.Find("Value").GetComponent<Text>().text = $"{item.value}{spacer}";
    menuItem.GetComponent<ItemChooser>().item = item;
  }

  public void SortInventoryItems(string property = "value")
  {
    switch (property) {
      case "value":
        _inventoryItems = _inventoryItems.OrderBy(item => item.value).ToList();
        break;
      default:
        _inventoryItems = _inventoryItems.OrderBy(item => item.label).ToList();
        break;
    }

    SetMenuItems();
  }
}
