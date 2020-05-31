using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleInventory : MonoBehaviour
{
    public List<string> _items = new List<string>();

    public bool CheckItem(string name)
    {
        return !string.IsNullOrEmpty(_items.FirstOrDefault(x => x == name));
    }

    public void AddItem(string name)
    {
        if (!_items.Contains(name))
        {
            _items.Add(name);
        }
    }
}
