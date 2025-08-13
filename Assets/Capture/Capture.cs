using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Capture : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            Texture2D t2d = toTexture2D(Camera.main.targetTexture);

            string _imgFileName = Application.dataPath + $"/Capture/thum_{Time.deltaTime}.png"; //파일 경로
            byte[] bytes = Texture2DToByte(t2d);
            File.WriteAllBytes(_imgFileName, bytes);


#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh(); //Asset 데이터 업데이트
#endif

        }
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    byte[] Texture2DToByte(Texture2D tex2d)
    {
        RenderTexture curRenderTex = RenderTexture.active;
        RenderTexture copiedTex = new RenderTexture(tex2d.width, tex2d.height, 0);

        Graphics.Blit(tex2d, copiedTex);

        RenderTexture.active = copiedTex;
        Texture2D newTex2d = new Texture2D(tex2d.width, tex2d.height, TextureFormat.RGBA32, false);
        newTex2d.ReadPixels(new Rect(0, 0, tex2d.width, tex2d.height), 0, 0);
        newTex2d.Apply();
        RenderTexture.active = curRenderTex;

        byte[] tPNGBytes = newTex2d.EncodeToPNG();
        return tPNGBytes;
    }

}
