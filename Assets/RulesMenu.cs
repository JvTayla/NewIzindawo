using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesMenu : MonoBehaviour
{

    public GameObject rulePanel;
    public GameObject impPanel;
    public GameObject specPanel;
    public GameObject outerPerimeter;
    public GameObject heartZone;
    public GameObject intersection;
    public GameObject trifecta;

    public void StartGame()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Rules()
    {
        if (rulePanel != null)
        {
            rulePanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Rule Panel not assigned in the Inspector.");
        }
    }

    public void Back()
    {
        if (rulePanel != null)
        {
            rulePanel.SetActive(false); // Deactivate the rule information panel
        }
        else
        {
            Debug.LogWarning("rule Panel not assigned in the Inspector.");
        }
    }
    public void CloseRules()
    {
        if (rulePanel != null)
        {
            rulePanel.SetActive(false);
        }

        if (impPanel != null)
        {
            impPanel.SetActive(false);
        }

        if (specPanel != null)
        {
            specPanel.SetActive(false);
        }
    }
    public void RulesNext()
    {
        if (impPanel == null)
        {
            Debug.LogWarning("imp Panel not assigned in the Inspector.");
        }
        else
        {
            impPanel.SetActive(true); // activate the rule information panel
        }
    }
    public void IMPBack()
    {
        // Check if impPanel is assigned
        if (impPanel != null)
        {
            // Deactivate impPanel
            impPanel.SetActive(false);
        }
        else
        {
            // Log warning if impPanel is not assigned
            Debug.LogWarning("impPanel not assigned in the Inspector.");
        }
    }
    public void IMPNext()
    {
        // Check if specPanel is assigned and not active
        if (specPanel != null && !specPanel.activeSelf)
        {
            // Activate specPanel
            specPanel.SetActive(true);
        }
        else if (specPanel == null)
        {
            // Log warning if specPanel is not assigned
            Debug.LogWarning("specPanel not assigned in the Inspector.");
        }
    }

    public void outerPerimeterOn()
    {
        if (outerPerimeter != null)
        {
            outerPerimeter.SetActive(true);
        }
        else
        {
            Debug.LogWarning("outerperimeter not assigned in the Inspector.");
        }
    }
    public void HeartZoneOn()
    {
        if (heartZone != null)
        {
            heartZone.SetActive(true);
        }
        else
        {
            Debug.LogWarning("heartzone not assigned in the Inspector.");
        }
    }
    public void IntersectionOn()
    {
        if (intersection != null)
        {
            intersection.SetActive(true);
        }
        else
        {
            Debug.LogWarning("intersection not assigned in the Inspector.");
        }
    }

    public void TrifectaOn()
    {
        if (trifecta != null)
        {
            trifecta.SetActive(true);
        }
        else
        {
            Debug.LogWarning("trifecta not assigned in the Inspector.");
        }
    }



    public void SpecBack()
    {
        // Check if specPanel is assigned
        if (specPanel != null)
        {
            // Deactivate specPanel
            specPanel.SetActive(false);
        }
        else
        {
            // Log warning if specPanel is not assigned
            Debug.LogWarning("specPanel not assigned in the Inspector.");
        }
    }

    public void CloseImpPanels()
    {
        
            if (outerPerimeter != null)
            {
                outerPerimeter.SetActive(false);
            }

            if (intersection != null)
            {
                intersection.SetActive(false);
            }

            if (heartZone != null)
            {
                heartZone.SetActive(false);
            }

            if (trifecta!= null)
        {
            trifecta.SetActive(false);
        }
        
    }
}
