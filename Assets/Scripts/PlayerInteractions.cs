using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the player's interactions with objects in their
/// line of sight.
/// </summary>
public class PlayerInteractions : MonoBehaviour
{

    private const float MAX_INTERACTION_DISTANCE = 50000.0f;

    [SerializeField] private Transform cameraTransform;
    private Interactable currentInteractive;

    public int catsSaved = 0;
    public int humansSaved = 0;

    private int platHumanCapacity = 1;
    private int levelCatCount = 5;


    private int humanCount = 0;
    private int catCount = 0;

    private float catHeight = 0.4f;


    [SerializeField] private Transform savedVictimParent;

    [SerializeField] private Transform platform;


    /// <summary>
    /// Checks for an item in the line of sight and range, as well as 
    /// checking for an interaction input from the player every frame.
    /// </summary>
    public void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
        CheckForSave();
    }

    /// <summary>
    /// Uses raycasting to find the closest Interacteable in the center
    /// of the player's screen that is in range.
    /// </summary>
    private void CheckForInteractive()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward,
                out RaycastHit hitInfo, MAX_INTERACTION_DISTANCE))
        {
            Interactable newInteractive =
                hitInfo.collider.GetComponent<Interactable>() == null ?
                hitInfo.collider.GetComponentInParent<Interactable>() :
                hitInfo.collider.GetComponent<Interactable>();

            if (newInteractive != null && newInteractive != currentInteractive
                && !newInteractive.IsActive)
                SetCurrentInteractive(newInteractive);

            else if (newInteractive == null) ClearCurrentInteractive();
        }

        else ClearCurrentInteractive();
    }

    private void SetCurrentInteractive(Interactable newInteractive)
    {
        currentInteractive = newInteractive;
    }

    private void ClearCurrentInteractive()
    {
        if (currentInteractive != null)
        {
            currentInteractive = null;
        }
    }

    private void CheckForInteraction()
    {

        if (Input.GetKeyDown(KeyCode.E) && currentInteractive != null)
        {
            if ((currentInteractive as Human) != null && catCount == 0)
            {
                if (humanCount < platHumanCapacity)
                {
                    Instantiate(currentInteractive.gameObject, savedVictimParent.position, savedVictimParent.rotation, savedVictimParent);

                    currentInteractive.gameObject.SetActive(false);

                    humanCount++;
                }
            }
            else if ((currentInteractive as Cat) != null && humanCount == 0)
            {
                Vector3 instPos = new Vector3(savedVictimParent.position.x, savedVictimParent.position.y + catHeight * catCount, savedVictimParent.position.z);

                Instantiate(currentInteractive.gameObject, instPos, savedVictimParent.rotation, savedVictimParent);

                currentInteractive.gameObject.SetActive(false);

                catCount++;
            }
        }
    }

    private void CheckForSave()
    {
        if (platform.position.y <= 3.3f)
        {
            bool areVictimsSafe = false;

            if (humanCount > 0 )
            {
                humansSaved += humanCount;
                humanCount = 0;
                areVictimsSafe = true;
            }

            else if (catCount == levelCatCount)
            {
                catsSaved = catCount;
                catCount = 0;
                areVictimsSafe = true;
            }

            if (areVictimsSafe)
            {
                foreach (Transform child in savedVictimParent)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}