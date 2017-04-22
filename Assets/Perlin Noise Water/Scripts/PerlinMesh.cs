using UnityEngine;

public class PerlinMesh : MonoBehaviour
{
    private Mesh mesh;
    public float perlinScale = 4.56f;
    public float waveHeight = 2f;
    public float waveSpeed = 1f;

    private void Update()
    {
        AnimateMesh();
    }

    private void AnimateMesh()
    {
        if (!mesh)
            mesh = GetComponent<MeshFilter>().mesh;

        var vertices = mesh.vertices;

        for (var i = 0; i < vertices.Length; i++)
        {
            var pX = (vertices[i].x*perlinScale) + (Time.timeSinceLevelLoad*waveSpeed);
            var pZ = (vertices[i].z*perlinScale) + (Time.timeSinceLevelLoad*waveSpeed);

            vertices[i].y = (Mathf.PerlinNoise(pX, pZ) - 0.5f)*waveHeight;
        }

        mesh.vertices = vertices;
    }
}