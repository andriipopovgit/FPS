using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private GameObject fireballPrefab;
    private bool possibleToShoot = true;
    public float delay = 0.5f;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (possibleToShoot)
            {
                possibleToShoot = false;
                StartCoroutine(Shoot());
            }
            //Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            //Ray ray = _camera.ScreenPointToRay(point);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    GameObject hitObject = hit.transform.gameObject;
            //    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            //    if (target != null)
            //        target.ReactToHit();
            //    else
            //        StartCoroutine(SphereIndicator(hit.point));
            //}
        }
    }

    //private IEnumerator SphereIndicator(Vector3 pos)
    //{
    //    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    sphere.transform.position = pos;
    //    yield return new WaitForSeconds(1);
    //    Destroy(sphere);
    //}

    private IEnumerator Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab) as GameObject;
        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
        fireball.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(delay);

        possibleToShoot = true;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
