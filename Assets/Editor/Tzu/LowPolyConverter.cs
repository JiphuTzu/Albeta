using UnityEngine;
using UnityEditor;

namespace Tzu
{
    public class LowPolyConverter
    {
        [MenuItem("Tools/Tzu/ToLowPoly")]
        private static void LowPoly()
        {
            Transform[] transforms = Selection.transforms;

            for (int i = 0; i < transforms.Length; i++)
            {
                LowPoly(transforms[i].GetComponent<MeshFilter>());
            }
        }

        private static void LowPoly(MeshFilter meshFilter)
        {
            if (meshFilter == null) return;
            Mesh mesh = meshFilter.sharedMesh;

            Vector3[] oldVerts = mesh.vertices;//保存当前Mesh顶点  
            int[] triangles = mesh.triangles;//三角索引数组  
            Vector2[] olduvs = mesh.uv;
            BoneWeight[] oldBoneWeights = mesh.boneWeights;

            int triangleCount = triangles.Length;

            Vector3[] verts = new Vector3[triangleCount];//用于保存新的顶点信息 
            Vector2[] uvs = new Vector2[triangleCount];//用于保存新的uv信息 
            BoneWeight[] boneWeights = new BoneWeight[triangleCount];//用于保存新的骨骼信息 

            for (int i = 0; i < triangles.Length; i++)
            {
                int index = triangles[i];
                verts[i] = oldVerts[index];
                uvs[i] = olduvs[index];
                boneWeights[i] = oldBoneWeights[index];
                triangles[i] = i;
            }

            mesh.vertices = verts;//更新Mesh顶点  
            mesh.triangles = triangles;//更新索引 
            mesh.uv = uvs;//更新uv信息
            mesh.boneWeights = boneWeights;//更新骨骼信息

            mesh.RecalculateBounds();//重新计算边界  
            mesh.RecalculateNormals();//重新计算法线  
        }
    }
}