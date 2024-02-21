using UnityEngine;

/// <summary>
/// This script creates a trail at the location of a gameobject with a particular width and color.
/// </summary>

public class CreateTrail : MonoBehaviour
{
    public GameObject trailPrefab = null;
    private float width = 0.05f;
    private Color color = Color.white;

    private GameObject currentTrail = null;

    public void StartTrail()
    {
        if (!currentTrail)
        {
            currentTrail = Instantiate(trailPrefab, transform.position, transform.rotation, transform);
            ApplySettings(currentTrail);
        }
    }

    private void ApplySettings(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        trailRenderer.widthMultiplier = width;
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }

    public void EndTrail()
    {
        if (currentTrail)
        {
            currentTrail.transform.parent = null;
            currentTrail = null;
        }
    }

    public void SetWidth(float value)
    {
        width = value;
    }

    public void SetColor(Color value)
    {
        color = value;
    }

public TrailRenderer trailRenderer; // Assign this in the inspector
public GameObject targetObject; // GameObject to hold the new mesh
public void BakeTrailAndApplyMesh()
{
    if (trailRenderer == null)
    {
        Debug.LogError("TrailRenderer not assigned.");
        return;
    }

    if (targetObject == null)
    {
        Debug.LogError("TargetObject not assigned.");
        return;
    }

    Mesh bakedMesh = new Mesh();
    // Ensure the camera parameter correctly captures the trail. If not, adjust accordingly.
    trailRenderer.BakeMesh(bakedMesh, Camera.main, true); // Consider changing to true or false based on your needs

    MeshFilter meshFilter = targetObject.GetComponent<MeshFilter>();
    if (meshFilter == null)
    {
        meshFilter = targetObject.AddComponent<MeshFilter>();
    }
    meshFilter.mesh = bakedMesh;

    MeshRenderer meshRenderer = targetObject.GetComponent<MeshRenderer>();
    if (meshRenderer == null)
    {
        meshRenderer = targetObject.AddComponent<MeshRenderer>();
    }
    // Assign a material to make sure the mesh is visible
    meshRenderer.material = new Material(Shader.Find("Standard")); // Customize the material as needed
}
}