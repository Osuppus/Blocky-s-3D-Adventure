using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 45; 
    public bool creatingSection = false;
    public int secNum;   

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection()); 
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3); 
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity); 
        zPos += 45; 
        yield return new WaitForSeconds(4); 
        creatingSection = false; 
    }
}
