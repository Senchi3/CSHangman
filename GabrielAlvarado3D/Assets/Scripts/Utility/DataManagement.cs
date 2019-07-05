using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace GameUtilities {
    public static class DataManagement {

        const string DATA_PATH = "D:/game3D.sav";

        public static void WriteDataToFile(object saveData) {
            using (FileStream fs = new FileStream(DATA_PATH, FileMode.Create)) {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, saveData);
            }
        }

        public static object ReadDataFromFile() {
            if (File.Exists(DATA_PATH)) {
                using (FileStream fs = new FileStream(DATA_PATH, FileMode.Open)) {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(fs);
                }
            } else {
                return null;
            }

        }
    }

}