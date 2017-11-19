using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class Cell : MonoBehaviour
    {
        public GameObject build_menu_prefab;
        private GameObject upgrade_menu_prefab;

        public GameObject tower_prefab;
        public GameObject upgraded_tower_prefab;
        

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            

        }


        void OnMouseDown()
        {
            if (!FindObjectOfType<Build_Menu>() && !FindObjectOfType<Upgrade_Menu>() && !CheckForTower())
            {
                build_menu_prefab = Resources.Load("Build Menu") as GameObject;
                GameObject new_menu = Instantiate(build_menu_prefab);

                new_menu.transform.SetParent(FindObjectOfType<Canvas>().transform, false);
                new_menu.GetComponent<Build_Menu>().cell_called_from = gameObject;

            }
            else if (!FindObjectOfType<Build_Menu>() && !FindObjectOfType<Upgrade_Menu>() && CheckForTower())
            {
                upgrade_menu_prefab = Resources.Load("Upgrade Menu") as GameObject;
                GameObject new_menu = Instantiate(upgrade_menu_prefab);

                new_menu.transform.SetParent(FindObjectOfType<Canvas>().transform, false);
                new_menu.GetComponent<Upgrade_Menu>().cell_called_from = gameObject;
            }

            
        }

        public void BuildTowerOnTop()
        {
            tower_prefab = Resources.Load("DefTower") as GameObject;

            GameObject new_tower = Instantiate(tower_prefab, transform);
        }

        public bool CheckForTower()
        {
            if (transform.childCount > 0)
            {
                return true;
            }
         
            return false;
            
        }

        public void UpgradeTowerOnTop()
        {
            Destroy(transform.GetChild(0).gameObject);

            upgraded_tower_prefab = Resources.Load("UpgradedDefTower") as GameObject;

            GameObject new_tower = Instantiate(upgraded_tower_prefab, transform);
        }

        public void SellTowerOnTop()
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

}

