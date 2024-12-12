using UnityEngine;
using UnityEngine.UI;          // If using built-in Text
using TMPro;
using UnityEngine.SceneManagement;                   // If using TextMeshPro

public class TextCycler : MonoBehaviour
{
    // Reference to Text or TMP_Text component
    public TMP_Text displayText; // If using TextMeshPro
    // public Text displayText;  // If using legacy UI Text, uncomment this and comment above

    // Array or list of lines to show
    [TextArea(2,5)]
    public string[] lines;

    private int currentIndex = 0;

    void Start()
    {
        // Start by showing the first line if any
        if (lines.Length > 0)
            displayText.text = lines[0];
        else
            displayText.text = "";
    }

    void Update()
    {
        // If the user clicks the left mouse button or presses the space key, advance the text
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceText();
        }
    }

    void AdvanceText()
    {
        currentIndex++;
        if (currentIndex < lines.Length)
        {
            displayText.text = lines[currentIndex];
        }
        else
        {
            // If we’re at the end of the lines, you can loop back or clear text
            // displayText.text = "";
            // currentIndex = -1; // Uncomment to loop from start next click
            
            // For now, just leave it blank once you reach the end.
            // displayText.text = "";
            SceneManager.LoadScene("Level");
        }
    }
}
