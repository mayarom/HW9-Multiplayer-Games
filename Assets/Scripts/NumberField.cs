using TMPro;
using UnityEngine;

/**
 * This component should be attached to any TextMeshPro component
 * (either TextMeshPro or TextMeshProUGUI). It allows feeding an
 * integer number to the text field.
 */
public class NumberField : MonoBehaviour
{
    private int number;
    private TMP_Text textComponent;

    private void Awake()
    {
        // Works for both TextMeshPro and TextMeshProUGUI
        textComponent = GetComponent<TMP_Text>();
        if (textComponent == null)
        {
            Debug.LogError("NumberField requires a TMP_Text component (TextMeshPro or TextMeshProUGUI).", this);
        }
    }

    public int GetNumber()
    {
        return number;
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;

        if (textComponent == null)
            textComponent = GetComponent<TMP_Text>();

        if (textComponent != null)
        {
            textComponent.text = newNumber.ToString();
        }
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(number + toAdd);
    }
}
