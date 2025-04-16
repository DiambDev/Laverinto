using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFactory : MonoBehaviour
{
  
        private Wall wallPrefab;

        public WallFactory(Wall prefab)
        {
            wallPrefab = prefab;
        }

        public Wall CreateWall(Vector3 position)
        {
            Wall newWall = wallPrefab.Clone();
            newWall.transform.position = position;
            return newWall;
        }
    }
