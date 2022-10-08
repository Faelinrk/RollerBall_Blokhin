using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollerBall.HomeWork
{
    
    public class OrderByHw : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            #region Original
            //Dictionary<string, int> dict = new Dictionary<string, int>()
            //{
            //    {"four",4 },
            //    {"two",2 },
            //    { "one",1 },
            //    {"three",3 },
            //};

            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair)
            //{
            //    return pair.Value;
            //});
            //foreach (var pair in d)
            //{
            //    Debug.Log(($"{pair.Key} - {pair.Value}"));
            //}
            #endregion

            #region Lambda
            //Dictionary<string, int> dict = new Dictionary<string, int>()
            //{
            //    {"four",4 },
            //    {"two",2 },
            //    { "one",1 },
            //    {"three",3 },
            //};

            //var d = dict.OrderBy(p => p.Value);
            //foreach (var pair in d)
            //{
            //    Debug.Log(($"{pair.Key} - {pair.Value}"));
            //}
            #endregion
        }

    }
}
