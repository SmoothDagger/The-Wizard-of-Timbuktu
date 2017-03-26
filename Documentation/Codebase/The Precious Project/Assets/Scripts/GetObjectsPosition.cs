using System;
using UnityEngine;

public class GetObjectsPosition : MonoBehaviour
{
    public GameObject[] GameObjects;
    Transform[] _transforms;
    Vector3[] _initialPositions;
    Vector3[] _initialScales;
    Quaternion[] _initialRotations;

    // Use this for initialization

    void Awake()
    {
        GameObjects = GameObject.FindGameObjectsWithTag("MovingObject");
        _transforms = Array.ConvertAll(GameObjects, x => x.transform);
        _initialPositions = new Vector3[_transforms.Length];
        _initialScales = new Vector3[_transforms.Length];
        _initialRotations = new Quaternion[_transforms.Length];

        for (int i = 0; i < _transforms.Length; i++)
	    {
	        _initialPositions[i] = _transforms[i].localPosition;
	        _initialScales[i] = _transforms[i].localScale;
            _initialRotations[i] = _transforms[i].localRotation;
        }
	}

    public void Reset()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            _transforms[i].localPosition = _initialPositions[i];
            _transforms[i].localScale = _initialScales[i];
            _transforms[i].localRotation = _initialRotations[i];
        }
    }
}
