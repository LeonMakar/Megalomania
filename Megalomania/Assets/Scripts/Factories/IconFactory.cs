using UnityEngine;

public class IconFactory
{
    private GameObject _icon;

    public IconFactory(GameObject iconPrefab)
    {
        _icon = iconPrefab;

    }


    public GameObject Create()
    {
        return GameObject.Instantiate(_icon);
    }
}
