using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OOBRenderer : MonoBehaviour
{
    void Start()
    {
        int r = Random.Range(0, 16);
        if (r > 3)
        {
            r %= 2;
        }
        int rot = Random.Range(0, 4);
        float bottomLeft = 0.25f * r;
        float bottomRight = bottomLeft + 0.25f;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector2[] UVs = new Vector2[mesh.vertices.Length];
        // Front
        UVs[0] = new Vector2(0.0f, 0.0f);
        UVs[1] = new Vector2(0.0f, 0.0f);
        UVs[2] = new Vector2(0.0f, 0.0f);
        UVs[3] = new Vector2(0.0f, 0.0f);
        // Top
        switch (rot)
        {
            case 0:
                UVs[4] = new Vector2(bottomLeft, 0.0f);
                UVs[5] = new Vector2(bottomLeft, 1.0f);
                UVs[9] = new Vector2(bottomRight, 1.0f);
                UVs[8] = new Vector2(bottomRight, 0.0f);
                break;
            case 1:
                UVs[5] = new Vector2(bottomLeft, 0.0f);
                UVs[9] = new Vector2(bottomLeft, 1.0f);
                UVs[8] = new Vector2(bottomRight, 1.0f);
                UVs[4] = new Vector2(bottomRight, 0.0f);
                break;
            case 2:
                UVs[9] = new Vector2(bottomLeft, 0.0f);
                UVs[8] = new Vector2(bottomLeft, 1.0f);
                UVs[4] = new Vector2(bottomRight, 1.0f);
                UVs[5] = new Vector2(bottomRight, 0.0f);
                break;
            case 3:
                UVs[8] = new Vector2(bottomLeft, 0.0f);
                UVs[4] = new Vector2(bottomLeft, 1.0f);
                UVs[5] = new Vector2(bottomRight, 1.0f);
                UVs[9] = new Vector2(bottomRight, 0.0f);
                break;
        }
        // Back
        UVs[6] = new Vector2(0.0f, 0.0f);
        UVs[7] = new Vector2(0.0f, 0.0f);
        UVs[10] = new Vector2(0.0f, 0.0f);
        UVs[11] = new Vector2(0.0f, 0.0f);
        // Bottom
        UVs[12] = new Vector2(0.0f, 0.0f);
        UVs[13] = new Vector2(0.0f, 0.0f);
        UVs[14] = new Vector2(0.0f, 0.0f);
        UVs[15] = new Vector2(0.0f, 0.0f);
        // Left
        UVs[16] = new Vector2(0.0f, 0.0f);
        UVs[17] = new Vector2(0.0f, 0.0f);
        UVs[18] = new Vector2(0.0f, 0.0f);
        UVs[19] = new Vector2(0.0f, 0.0f);
        // Right        
        UVs[20] = new Vector2(0.0f, 0.0f);
        UVs[21] = new Vector2(0.0f, 0.0f);
        UVs[22] = new Vector2(0.0f, 0.0f);
        UVs[23] = new Vector2(0.0f, 0.0f);
        mesh.uv = UVs;
    }
}