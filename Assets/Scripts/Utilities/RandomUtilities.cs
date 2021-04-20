using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RandomUtilities {
    public static class Rand {
        public static bool RandomTest(float probability) {
            return RandomInt() <= (int.MaxValue * probability);
        }
        public static bool RandomTest(int probabilityInPercents) {
            return RandomInt() % 100 < probabilityInPercents;
        }
        public static int RandomInt(bool onlyPositive=true) {
            if(onlyPositive)
                return UnityEngine.Random.Range(0, int.MaxValue);
            else
                return UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        }
        public static float RandomBetween(float a, float b) {
            if (a > b) {
                return UnityEngine.Random.Range(b, a);
            }
            else {
                return UnityEngine.Random.Range(a, b);
            }
        }
        public static float RandomBetween(int a, int b) {
            if (a > b) {
                return UnityEngine.Random.Range(b, a);
            }
            else {
                return UnityEngine.Random.Range(a, b);
            }
        }
        public static int GetRandomEnum(Type @enum) {
            return (int)GetRandomItem(Enum.GetValues(@enum));
        }
        public static int GetRandomEnum(Type @enum, int from) {
            return (int)GetRandomItem(Enum.GetValues(@enum), from);
        }
        public static Vector2 GetRandomDirection2D() {
            return new Vector2(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1).normalized;
        }
        public static Vector3 GetRandomDirection3D() {
            return new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1).normalized;
        }
        public static Vector2 GetRandomDirectionInRange(float angleA, float angleB) {
            while (angleA < angleB) {
                angleA += 2 * Mathf.PI;
            }
            float angle = RandomBetween(angleA, angleB);
            return new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
        }
        public static Quaternion GetRandom2DQuaternion() {
            return Quaternion.Euler(0f, 0f, RandomBetween(0f, 360f));
        }
        public static Vector2 GetRandomDirectionInRange(Vector2 A, Vector2 B) {
            return GetRandomDirectionInRange(GetAngle(A), GetAngle(B));
        }
        public static Vector2 GetRandomDirectionInRange(Vector2 A, float angle) {
            float sin = Mathf.Sin(angle);
            float cos = Mathf.Cos(angle);
            float sinX = sin * A.x;
            float cosX = cos * A.x;
            float sinY = sin * A.y;
            float cosY = cos * A.y;
            //float x1 = cosX - sinY;
            //float x2 = cosX + sinY;
            //float y1 = sinX + cosY;
            //float y2 = cosY - cosX;
            return new Vector3(RandomBetween(cosX - sinY, cosX + sinY), RandomBetween(sinX + cosY, cosY - sinX));
        }
        public static Vector2 GetRandomVector2(float length) {
            return GetRandomDirection2D() * length;
        }
        public static Vector2 GetRandomPosition(Vector2 center, float radius) {
            return center + GetRandomDirection2D() * RandomBetween(0f, radius);
        }
        public static Vector3 GetRandomVector3(float length) {
            return GetRandomDirection3D() * length;
        }
        public static Vector3 GetRandomPosition(Vector3 center, float radius) {
            return center + GetRandomDirection3D() * RandomBetween(0f, radius);
        }
        private static float GetAngle(Vector2 V) {
            return Mathf.Atan(V.y / V.x);
        }
        public static T GetRandomItem<T>(T[] array) {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
        public static object GetRandomItem(Array array, int from=0) {
            return array.GetValue(UnityEngine.Random.Range(from, array.Length));
        }
        public static void ShuffleArray<T>(T[] array) {
            //Generate new order
            int[] newOrder = new int[array.Length];
            RandomFill(newOrder);
            ArrangeArray(array, newOrder);
        }
        public static void RandomFill(int[] array) {
            List<int> pool = new List<int>(array.Length);
            for(int i = 0; i < array.Length; i++) {
                pool.Add(i);
            }
            for (int i = 0; i < array.Length; i++) {
                array[i] = GetRandomFromCollection(pool, array.Length);
                pool.Remove(array[i]);
            }
            
        }
        public static T GetRandomFromCollection<T>(IEnumerable<T> collection, int size) {
            var enumerator = collection.GetEnumerator();
            var c = enumerator.Current;
            int moves = UnityEngine.Random.Range(0, size);
            if (moves == 0)
                return c;
            while (enumerator.MoveNext()) {
                moves--;
                if (moves <= 0) {
                    return enumerator.Current;
                }
            }
            return c;
        }
        public static void ArrangeArray<T>(T[] array, int[] indexArray) {
            T[] copyArray = new T[array.Length];
            for(int i = 0; i < array.Length; i++) {
                copyArray[i] = array[i];
            }
            for (int i = 0; i < array.Length; i++) {
                array[i] = copyArray[indexArray[i]];
            }
            
        }
        private static int FindIndex<T>(T[] array, T element) {
            int index = 0;
            foreach (T t in array) {                
                if (element.Equals(t))
                    return index;
                index++;
            }
            return index;
        }
        private static void Swap<T>(T[] array, int i0, int i1) {
            T tmp = array[i0];
            array[i0] = array[i1];
            array[i1] = tmp;
        }
        public static Vector2 GetRandomPosition(Rect r) {
            return new Vector2(RandomBetween(r.position.x - r.width / 2f, r.position.x + r.width / 2f), RandomBetween(r.position.y - r.height / 2f, r.position.y + r.height / 2f));
        }
    }
}

