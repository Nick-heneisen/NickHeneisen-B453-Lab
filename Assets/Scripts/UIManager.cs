using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI ammoText;

    private void Awake()
    {
        // Basic singelton pattern to ensure only one instance of UIManager exists.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            Debug.LogWarning("There is already an instance of UIManager in the scene.");
        }

        // Find the Ammo Count Text object in the scene and get the TextMeshProUGUI component.
        ammoText = GameObject.Find("Ammo Count Text").GetComponent<TextMeshProUGUI>();
    }

    // Made public so that it can be called from other scripts.
    public void UpdateAmmoUI(int currentAmmo, int ammoCapacity)
    {
        ammoText.text = $"{currentAmmo}/{ ammoCapacity}";
    }
}
