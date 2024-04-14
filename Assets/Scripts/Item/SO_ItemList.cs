using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SO_ItemList", menuName ="Scriptable Objects/Item/Item List")]
public class SO_ItemList : ScriptableObject
{
    [SerializeField]
    public List<ItemDetails> itemDetails;
}
