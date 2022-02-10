using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

   [SerializeField] private GameObject[] _panels;

   
    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>().GetComponent<Camera>();

        for (int i=0; i<_panels.Length; i++)
        {
           
                if (i != 0)
                {
                    _panels[i].SetActive(false);
                }
                else
                {
                    _panels[i].SetActive(true);
                }
            
        }

        
    }

    private void Update()
    {
        ActivateCubePanel();
    }



    private void ActivateCubePanel()
    {
        if (Input.GetMouseButton(0))
        {

            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit _hitInfo;

            if (Physics.Raycast(_ray, out _hitInfo, 1000))
            {

                if (_hitInfo.collider != null)
                {
                    if (_hitInfo.collider.gameObject.CompareTag("Cube"))
                    {

                        for (int i = 0; i < _panels.Length; i++)
                        {
                            if(i != 0)
                            {
                                _panels[i].SetActive(false);
                            }
                            else
                            {
                                _panels[i].SetActive(true);
                            }
                        }

                       

                    }
                }

            }


        }
    }
}
