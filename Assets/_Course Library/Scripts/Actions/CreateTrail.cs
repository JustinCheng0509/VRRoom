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

    // Method to bake the trail renderer's mesh
    public void BakeTrailMesh(GameObject trailObject)
    {
        TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
        Mesh bakedMesh = new Mesh();
        trailRenderer.BakeMesh(bakedMesh, true);

        // Here, you can decide what to do with the baked mesh
        // For example, attach it to a new GameObject with a MeshFilter and MeshRenderer,
        // or save it for later use
        GameObject meshObject = new GameObject("BakedTrailMesh");
        meshObject.AddComponent<MeshFilter>().mesh = bakedMesh;
        meshObject.AddComponent<MeshRenderer>().material = trailRenderer.material; // Use the same material as the trail for visual consistency
    }
}
