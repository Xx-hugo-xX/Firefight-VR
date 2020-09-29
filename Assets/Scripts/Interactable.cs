using UnityEngine;
using System.Collections;

/// <summary>
/// DO NOT USE THIS COMPONENT DIRECTLY.
/// USE THE SCRIPTS THAT INHERIT FROM THIS,     
///  Like torches, doors and things the player activates directly
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    // if the current interacteable is in its active state
    [HideInInspector] public bool IsActive { get; set; } = false;
    //public bool Active {get; set;}
}

