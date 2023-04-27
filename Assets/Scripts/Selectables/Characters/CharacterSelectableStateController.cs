using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectableStateController : MonoBehaviour, ISelectableStateController
{

    public Material unselectedMaterial;

    public Material selectedMaterial;

    [SerializeField]
    private UIController statsUIController;

    private MeshRenderer meshRenderer;

    public void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = unselectedMaterial;
    }

    public void SetHover()
    {

    }

    public void SetIdle()
    {
        meshRenderer.material = unselectedMaterial;
        statsUIController.Close();
    }

    public void SetSelected()
    {
        meshRenderer.material = selectedMaterial;
        statsUIController.Open();
    }
}
