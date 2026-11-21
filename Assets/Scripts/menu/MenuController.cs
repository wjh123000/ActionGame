using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public SkinnedMeshRenderer headRenderer;
    public Mesh[] headMeshArray;
    private int headMeshIndex = 0;
    public SkinnedMeshRenderer handRenderer;
    public Mesh[] handMeshArray;
    private int handMeshIndex = 0;

    public SkinnedMeshRenderer lowerBodyRenderer;
    public Mesh[] lowerBodyMeshArray;
    private int lowerBodyMeshIndex = 0;

    public SkinnedMeshRenderer upperBodyRenderer;
    public Mesh[] upperBodyMeshArray;
    private int upperBodyMeshIndex = 0;
    public SkinnedMeshRenderer footRenderer;
    public Mesh[] footMeshArray;
    private int footMeshIndex = 0;

    public SkinnedMeshRenderer[] bodyArray;

    public void OnHeadMeshNext()
    {
        headMeshIndex++;
        headMeshIndex %= headMeshArray.Length;
        headRenderer.sharedMesh = headMeshArray[headMeshIndex];
        OnClickButtonSound();
    }

    public void OnHandMeshNext()
    {
        handMeshIndex++;
        handMeshIndex %= handMeshArray.Length;
        handRenderer.sharedMesh = handMeshArray[handMeshIndex];
        OnClickButtonSound();
    }

    public void OnLowerBodyMeshNext()
    {
        lowerBodyMeshIndex++;
        lowerBodyMeshIndex %= lowerBodyMeshArray.Length;
        lowerBodyRenderer.sharedMesh = lowerBodyMeshArray[lowerBodyMeshIndex];
        OnClickButtonSound();
    }

    public void  OnUpperBodyMeshNext()
    {
        upperBodyMeshIndex++;
        upperBodyMeshIndex %= upperBodyMeshArray.Length;
        upperBodyRenderer.sharedMesh = upperBodyMeshArray[upperBodyMeshIndex];
        OnClickButtonSound();
    }

    public void OnFootMeshNext()
    {
        footMeshIndex++;
        footMeshIndex %= footMeshArray.Length;
        footRenderer.sharedMesh = footMeshArray[footMeshIndex];
        OnClickButtonSound();
    }

    public void OnChangeColorBlue()
    {
        OnChangeColor(Color.blue);
        OnClickButtonSound();
    }

    public void OnChangeColorCyan()
    {
        OnChangeColor(Color.cyan);
        OnClickButtonSound();
    }

    public void OnChangeColorGreen()
    {
        OnChangeColor(Color.green);
        OnClickButtonSound();
    }

    public void OnChangeColorPurple()
    {
        OnChangeColor(new Color(0.5f, 0f, 0.5f));
        OnClickButtonSound();
    }

    public void OnChangeColorRed()
    {
        OnChangeColor(Color.red);
        OnClickButtonSound();
    }
    private void OnChangeColor(Color c)
    {
        foreach (var item in bodyArray)
        {
            item.material.color = c;
        }

    }

    public void OnPlay()
    {
        OnClickButtonSound();
    }

    private void OnClickButtonSound()
    {
        AudioManager.Instance.PlayButtonClickSound();
    }
}
