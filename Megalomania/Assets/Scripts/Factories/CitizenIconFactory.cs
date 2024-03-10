using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenIconFactory : MonoBehaviour
{
    [SerializeField] private GameObject CitizenIcon;
    [SerializeField] private GameObject ParentGameObject;




    public void Create()
    {
       var icon =  Instantiate(CitizenIcon, ParentGameObject.transform);
        icon.transform.position = Input.mousePosition;
    }




}
