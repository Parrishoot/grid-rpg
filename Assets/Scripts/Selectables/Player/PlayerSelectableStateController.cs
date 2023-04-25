using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectableStateController : MonoBehaviour, ISelectableStateController
{

    public Material unselectedMaterial;

    public Material selectedMaterial;

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
    }

    public void SetSelected()
    {
        meshRenderer.material = selectedMaterial;
    }
}
