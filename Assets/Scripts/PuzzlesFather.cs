using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PuzzlesFather : MonoBehaviour
{
    [SerializeField] protected GameObject PuzzleHolder;
    [SerializeField] GameObject myCamera;
    private Vector3 previousLocation;

    public void ChangeCamera(bool entering)
    {
        if (entering)
        {
            previousLocation = Camera.main.transform.position;
            Camera.main.transform.DOMove(myCamera.transform.position, 1f, false);
            Camera.main.transform.DORotateQuaternion(myCamera.transform.rotation, 2f);
            /*Camera.main.transform.position = myCamera.transform.position;
            Camera.main.transform.rotation = myCamera.transform.rotation;*/


            Interact();
        }
        else
        {
            Camera.main.transform.DOMove(previousLocation, 1f, false);
            Camera.main.transform.DORotate(new Vector3(0f, 0f, 0f), 2f);
            Exit();

        }
    }

    public abstract void Interact();
    public abstract void Exit();


}
