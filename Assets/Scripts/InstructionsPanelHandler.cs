using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelHandler : MonoBehaviour
{
    public GameObject instructionsPanel; 
    public Button exitButton; 

    void Start()
    {
       
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true); 
        }
        else
        {
            Debug.LogError("Instructions panel is not assigned!");
        }

       
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ClosePanel);
        }
        else
        {
            Debug.LogError("Exit button is not assigned!");
        }
    }

  
    public void ShowPanel()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Instructions panel is not assigned!");
        }
    }

   
    private void ClosePanel()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }
    }
}
