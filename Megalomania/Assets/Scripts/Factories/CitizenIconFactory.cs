
using UnityEngine;

public class CitizenIconFactory : MonoBehaviour
{
    [SerializeField] private GameObject CitizenIcon;
    [SerializeField] private Transform ParentObject;





    public void Create()
    {
       var icon =  Instantiate(CitizenIcon, ParentObject);
        icon.transform.position = Input.mousePosition;
    }




}
