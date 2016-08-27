using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public static class TransformExtensions
    {
        public static IEnumerable<Transform> Children(this Transform instance)
        {
            for (int i = 0; i < instance.childCount; i++)
                yield return instance.GetChild(i);
        }

        /// <summary>
        /// Includes self in response
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static IEnumerable<Transform> ChildrenDeep(this Transform instance)
        {
            return new[] { instance }.Concat(instance.Children().SelectMany(x => ChildrenDeep(x))).ToArray();
        }

        public static IEnumerable<T> AllComponents<T>(this Transform instance) where T : Component
        {
            var comp = instance.GetComponent<T>();
            if (comp != null)
                yield return comp;

            foreach (var child in instance.ChildrenDeep())
            {
                var c = child.GetComponent<T>();
                if (c != null)
                    yield return c;
            }
        }

        public static void MoveWithoutChildren(this Transform transform, Vector3 position)
        {
            var children = transform.Children().ToArray();
            children.Each(x => x.parent = null);
            transform.position = position;
            children.Each(x => x.parent = transform);
        }
        public static void RotateWithoutChildren(this Transform transform, Quaternion rotation)
        {
            var children = transform.Children().ToArray();
            children.Each(x => x.parent = null);
            transform.rotation = rotation;
            children.Each(x => x.parent = transform);
        }
    }
}
