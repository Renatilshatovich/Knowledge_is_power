using UnityEngine;

namespace CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3Data AsVectorData(this Vector3 vector) => 
            new Vector3Data(vector.x, vector.y, vector.z);
    }
}