using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesSpawner : MonoBehaviour
{
    public List<GameObject> modules = new List<GameObject>();
    [HideInInspector] public int modulesCount;
    public List<Vector3> positions = new List<Vector3>();
    public List<Vector3> rotations = new List<Vector3>();

    private void Start()
    {
        modulesCount = PlayerPrefs.GetInt("Modules");
        for (int i = 0; i < modulesCount; i++)
        {
            GameObject ins = Instantiate(modules[Random.Range(0, modules.Count)]);
            ins.transform.parent = transform;
            int posRot = Random.Range(0, positions.Count);
            ins.transform.localPosition = positions[posRot];
            ins.transform.localRotation = Quaternion.Euler(rotations[posRot]);
            positions.RemoveAt(posRot);
            rotations.RemoveAt(posRot);
        }
    }
}
