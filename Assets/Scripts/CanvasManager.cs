using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Text victimsSavedText;

    [SerializeField] private PlayerInteractions pI;

    private void Update()
    {
        UpdateVictimsSaved();
    }

    private void UpdateVictimsSaved()
    {
        victimsSavedText.text = $"Cats saved: {pI.catsSaved}\n" +
                            $"Humans saved: {pI.humansSaved}";
    }
}
