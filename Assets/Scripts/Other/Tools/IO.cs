using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class IO {

    ///<summary>folder байгааг шалгана</summary>
    public static bool IsDirExists(string path) {
        return Directory.Exists(path);
    }

    ///<summary>folder-уудын замыг авна</summary>
    public static string[] GetDirs(string path) {
        return Directory.GetDirectories(path);
    }

    ///<summary>folder үүсгэнэ</summary>
    public static void CrtDir(string path) {
        Directory.CreateDirectory(path);
    }

    ///<summary>шалгаад folder үүсгэнэ</summary>
    public static void CheckCrtDir(string path) {
        if (!IsDirExists(path))
            CrtDir(path);
    }

    ///<summary>file байгааг шалгана</summary>
    public static bool IsFileExists(string path) {
        return File.Exists(path);
    }

    ///<summary>file-уудын замыг авна</summary>
    public static string[] GetFiles(string path) {
        return Directory.GetFiles(path);
    }

    ///<summary>file-уудын замыг авна</summary>
    public static string[] GetFiles(string path, params string[] exts) {
        return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(s => exts.Contains(Path.GetExtension(s))).ToArray();
    }

    ///<summary>file үүсгэнэ</summary>
    public static void CrtFile(string path, string data) {
        File.WriteAllText(path, data);
    }

    ///<summary>file уншина</summary>
    public static string ReadFile(string path) {
        try {
            return File.ReadAllText(path);
        } catch (FileNotFoundException) {
            return "";
        }
    }

    ///<summary>одоогийн замыг авна</summary>
    public static string GetCurPath() {
        return Directory.GetCurrentDirectory() + "/";
    }

    ///<summary>assets-н замыг авна</summary>
    public static string GetAssPath() {
        return GetCurPath() + "Assets/";
    }

    ///<summary>assets-н замыг авна</summary>
    public static string GetMainPath() {
        return GetAssPath() + "";
    }

    ///<summary>ProjectSettings-н замыг авна</summary>
    public static string GetPsPath() {
        return GetCurPath() + "ProjectSettings/";
    }

    ///<summary>Extensions-н замыг авна</summary>
    public static string GetExtPath() {
        return GetMainPath() + "Scripts/Other/Extentions/";
    }

    ///<summary>Data-н замыг авна</summary>
    public static string GetDataPath() {
        return GetMainPath() + "Scripts/Other/Data/";
    }

    ///<summary>file-г regex хийнэ</summary>
    public static void FileReplaceStrings(string path, string regex, string replace) {
        CrtFile(path, Rgx.Replace(ReadFile(path), regex, replace));
    }

    ///<summary>meta-г өөрчилнэ</summary>
    public static void SetMetaLine(string path, string name, string line) {
        FileReplaceStrings(GetCurPath() + path, name + ":.+", line);
    }

    ///<summary>ExtensionGameObject.cs file-г өөрчилж ExtensionComponent, ExtensionCollision, ExtensionCollision2D-д хуулна</summary>
    public static void ExtensionGameObject() {
        string extDataPath = GetDataPath() + "ExtensionGameObject", extData = "";
        List<string> names = new List<string>() { "", "Rb", "Tf" };
        names.ForEach(x => extData += ReadFile(GetExtPath() + "ExtensionGameObject" + x + ".cs"));
        if (extData != ReadFile(extDataPath)) {
            Debug.Log("ExtensionGameObject");
            CrtFile(extDataPath, extData);
            string data = "", line, prvPath = GetExtPath() + "ExtensionGameObject";
            foreach (string name in names) {
                bool isStart = false;
                StreamReader file = new StreamReader(prvPath + name + ".cs");
                while ((line = file.ReadLine()).NotNull()) {
                    if (isStart) {
                        line = line.Trim();
                        if (line.StartsWith("///<summary>")) {
                            data += "\t" + line + "\n";
                        } else if (line.StartsWith("// ")) {
                            data += "\t" + line + "\n\n";
                        } else if (line.StartsWith("public static")) {
                            data += "\t" + line.Replace("this GameObject a", "this NAME a") + "\n";
                            int idx = line.IndexOf('(');
                            string[] arr2 = line.SubStr(0, idx).Split(' ');
                            string functionName = arr2[arr2.Length - 1];
                            data += "\t\t";
                            if (arr2[2] != "void")
                                data += "return ";
                            data += "a.gameObject." + functionName + "(";
                            string[] arr3 = line.SubStr(idx + 1, line.LastIndexOf(')') - idx - 1).Split(',');
                            string tmp = "";
                            for (int i = 1; i < arr3.Length; i++) {
                                string[] arr4 = arr3[i].Trim().Split(' ');
                                tmp += (arr4[0] == "params" || arr4[0][0] == '[' ? arr4[2] : arr4[1]) + ", ";
                            }
                            if (tmp.Length > 2)
                                tmp = tmp.SubStr(0, tmp.Length - 2);
                            data += tmp + ");";
                            data += "\n\t}\n\n";
                        }
                    } else if (line.Trim().StartsWith("public static partial class"))
                        isStart = true;
                }
                file.Close();
            }
            data = "using System.Collections.Generic;\nusing UnityEngine;\nusing UnityEngine.Internal;\n\npublic static class ExtensionNAME {\n\n" + data + "}";
            CrtFile(GetExtPath() + "ExtensionComponent.cs", data.Replace("NAME", "Component"));
            CrtFile(GetExtPath() + "ExtensionCollision.cs", data.Replace("NAME", "Collision"));
            CrtFile(GetExtPath() + "ExtensionCollision2D.cs", data.Replace("NAME", "Collision2D"));
        }
    }

    ///<summary>ExtensionGameObjectTf.cs үүсгэнэ</summary>
    public static void ExtensionGameObjectTf() {
        Debug.Log("ExtensionGameObjectTf");
        List<string> names = new List<string>(){
            "transform.position", "transform.localPosition", "transform.rotation", "transform.localRotation",
            "transform.lossyScale", "transform.localScale", "transform.eulerAngles", "transform.localEulerAngles"
        };
        List<string> funcNames = new List<string> { "Tp", "Tlp", "Tr", "Tlr", "Ts", "Tls", "Te", "Tle" };
        string data = "using UnityEngine;\n\npublic static partial class ExtensionGameObject {\n\n";
        for (int i = 0; i < names.Count; i++) {
            data += "\t// ############### " + names[i].ToUpper() + " ###############\n\n" +
                "\t///<summary>" + names[i] + "-г авна</summary>\n" +
                "\tpublic static " + (i == 2 || i == 3 ? "Quaternion" : "Vector3") + " " + funcNames[i] + "(this GameObject a) {\n" +
                    "\t\treturn a." + names[i] + ";\n" +
                "\t}\n\n" + (funcNames[i] == "Ts" ? "" :
                "\t///<summary>" + names[i] + "-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "(this GameObject a, " + (i == 2 || i == 3 ? "Quaternion" : "Vector3") + " v) {\n" +
                    "\t\ta." + names[i] + " = v;\n" +
                "\t}\n\n" + (i == 2 || i == 3 ? "" :
                "\t///<summary>" + names[i] + "-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "(this GameObject a, float x, float y, float z) {\n" +
                    "\t\ta." + names[i] + " = new Vector3(x, y, z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-н x-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "X(this GameObject a, float x) {\n" +
                    "\t\ta." + names[i] + " = V3.X(a." + names[i] + ", x);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-н y-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Y(this GameObject a, float y) {\n" +
                    "\t\ta." + names[i] + " = V3.Y(a." + names[i] + ", y);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-н z-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Z(this GameObject a, float z) {\n" +
                    "\t\ta." + names[i] + " = V3.Z(a." + names[i] + ", z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-н x, y-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Xy(this GameObject a, float x, float y) {\n" +
                    "\t\ta." + names[i] + " = V3.Xy(a." + names[i] + ", x, y);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-н x, z-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Xz(this GameObject a, float x, float z) {\n" +
                    "\t\ta." + names[i] + " = V3.Xz(a." + names[i] + ", x, z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-н y, z-г өөрчилнө</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Yz(this GameObject a, float y, float z) {\n" +
                    "\t\ta." + names[i] + " = V3.Yz(a." + names[i] + ", y, z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д v-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "D(this GameObject a, Vector3 v) {\n" +
                    "\t\ta." + names[i] + " += v;\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д x, y, z-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "D(this GameObject a, float x, float y, float z) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(x, y, z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д x-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Dx(this GameObject a, float x) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(x, 0, 0);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д y-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Dy(this GameObject a, float y) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(0, y, 0);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д z-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Dz(this GameObject a, float z) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(0, 0, z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д x, y-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Dxy(this GameObject a, float x, float y) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(x, y, 0);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д x, z-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Dxz(this GameObject a, float x, float z) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(x, 0, z);\n" +
                "\t}\n\n" +
                "\t///<summary>" + names[i] + "-д y, z-г нэмнэ</summary>\n" +
                "\tpublic static void " + funcNames[i] + "Dyz(this GameObject a, float y, float z) {\n" +
                    "\t\ta." + names[i] + " += new Vector3(0, y, z);\n" +
                "\t}\n\n"));
        }
        data += "}";
        CrtFile(GetExtPath() + "ExtensionGameObjectTf.cs", data);
    }

    ///<summary>ExtensionGameObjectRb.cs үүсгэнэ</summary>
    public static void ExtensionGameObjectRb() {
        string extDataPath = GetDataPath() + "ExtensionGameObjectRb", extData = ReadFile(GetExtPath() + "ExtensionGameObjectRb.cs");
        if (extData != ReadFile(extDataPath)) {
            Debug.Log("ExtensionGameObjectRb");
            CrtFile(extDataPath, extData);
            string data = "using UnityEngine;\n\n" +
                "public static partial class ExtensionGameObject {\n\n" +
                "\t///<summary>rigidbody-г авна</summary>\n" +
                "\tpublic static Rigidbody Rb(this GameObject a) {\n" +
                "\t\treturn a.Gc<Rigidbody>();\n" +
                "\t}\n\n", line;
            bool isStart = false;
            StreamReader file = new StreamReader(GetExtPath() + "ExtensionRigidbody.cs");
            while ((line = file.ReadLine()).NotNull()) {
                if (isStart) {
                    line = line.Trim();
                    if (line.StartsWith("///<summary>")) {
                        data += "\t" + line + "\n";
                    } else if (line.StartsWith("// ")) {
                        data += "\t" + line + "\n\n";
                    } else if (line.StartsWith("public static")) {
                        int idx = line.IndexOf('(');
                        string[] arr2 = line.SubStr(0, idx).Split(' ');
                        string functionName = arr2[arr2.Length - 1];
                        data += "\t" + line.Replace(functionName, "Rb" + functionName).Replace("this Rigidbody a", "this GameObject a") + "\n";
                        data += "\t\t";
                        if (arr2[2] != "void")
                            data += "return ";
                        data += "a.Rb()." + functionName + "(";
                        string[] arr3 = line.SubStr(idx + 1, line.LastIndexOf(')') - idx - 1).Split(',');
                        string tmp = "";
                        for (int i = 1; i < arr3.Length; i++) {
                            string[] arr4 = arr3[i].Trim().Split(' ');
                            tmp += (arr4[0] == "params" || arr4[0][0] == '[' ? arr4[2] : arr4[1]) + ", ";
                        }
                        if (tmp.Length > 2)
                            tmp = tmp.SubStr(0, tmp.Length - 2);
                        data += tmp + ");";
                        data += "\n\t}\n\n";
                    }
                } else if (line.Trim().StartsWith("public static class"))
                    isStart = true;
            }
            file.Close();
            data += "}";
            CrtFile(GetExtPath() + "ExtensionGameObjectRb.cs", data);
        }
    }

    ///<summary>Enum.cs-н ExtensionEnum.cs file-г үүсгэнэ</summary>
    public static void ExtensionEnum() {
        string extDataPath = GetDataPath() + "ExtensionEnum", extData = ReadFile(GetMainPath() + "Scripts/Main/Enum.cs");
        if (extData != ReadFile(extDataPath)) {
            Debug.Log("ExtensionEnum");
            CrtFile(extDataPath, extData);
            StreamReader file = new StreamReader(GetMainPath() + "Scripts/Main/Enum.cs");
            string line, s = "public static class ExtensionEnum {\n\n";
            while ((line = file.ReadLine()).NotNull()) {
                line = line.Trim();
                if (line.StartsWith("public enum")) {
                    string[] arr = line.RgxSplit("\\W+");
                    for (int i = 3; i < arr.Length - 1; i++) {
                        s += "\t///<summary>" + arr[2] + " нь " + arr[i] + " байна уу шалгана</summary>\n" +
                            "\tpublic static bool Is" + arr[i] + "(this " + arr[2] + " a) {\n" +
                            "\t\treturn a == " + arr[2] + "." + arr[i] + ";\n" +
                            "\t}\n\n";
                    }
                }
            }
            s += "}";
            file.Close();
            CrtFile(GetExtPath() + "ExtensionEnum.cs", s);
        }
    }

    ///<summary>Resources/UI-с EditorMenuItem.cs file-г үүсгэнэ</summary>
    public static void EditorMenuItem() {
        string[] dirs = GetDirs(GetMainPath() + "Resources/UI");
        List<string> paths = new List<string>();
        foreach (string dir in dirs)
            paths.Add(GetFiles(dir, ".prefab"));
        string s = "using UnityEditor;\n\n" +
            "public partial class EditorMenuItem : Editor {\n\n";
        for (int i = 0; i < paths.Count; i++) {
            string path = paths[i].SubStrLast(paths[i].IndexOf("Resources") + 10, 7);
            string[] arr = path.Split('/');
            string name = arr[1] == arr[2] ? arr[1] : arr[2].Replace(arr[1], "");
            if (!arr[2].Contains("Stage", "StageLevel"))
                s += "\t[MenuItem (\"GameObject/" + arr[0] + "/" + arr[1] + "/" + name + "\")]\n" +
                "\tpublic static void " + arr[2] + " () {\n" +
                    "\t\tCreate" + (arr[2].Contains("Hud", "GameSettings", "CanvasController", "Menu") ? "" : "Prefab") +
                    " (\"" + path + "\", \"" + (arr[1].Contains("Hud", "GameSettings", "UI") ? name : arr[1]) + "\");\n" +
                "\t}\n\n";
        }
        s += "}";
        CrtFile("Assets/Scripts/Other/Editor/EditorMenuItem.cs", s);
    }

    public static void Vector() {
        CrtFile("Assets/Scripts/Other/Tools/VectorColorQuaternion/Vector2.cs", Vector(2));
        CrtFile("Assets/Scripts/Other/Tools/VectorColorQuaternion/Vector2Int.cs", Vector(2, true));
        CrtFile("Assets/Scripts/Other/Tools/VectorColorQuaternion/Vector3.cs", Vector(3));
        CrtFile("Assets/Scripts/Other/Tools/VectorColorQuaternion/Vector3Int.cs", Vector(3, true));
        CrtFile("Assets/Scripts/Other/Tools/VectorColorQuaternion/Vector4.cs", Vector(4));
    }

    static string Vector(int n, bool isInt = false) {
        string s = "using UnityEngine;\n\npublic " + (n == 3 && !isInt ? "partial " : "") + "class V" + n + (isInt ? "I" : "") + " {\n\n",
            f = "\t///<summary>{0}</summary>\n\tpublic static readonly {1} {2} = {3};\n\n",
            v = "Vector" + n + (isInt ? "Int" : "");
        if (n != 4) {
            s += string.Format(f, v + ".left", v, "l", v + ".left");
            s += string.Format(f, v + ".right", v, "r", v + ".right");
            s += string.Format(f, v + ".down", v, "d", v + ".down");
            s += string.Format(f, v + ".up", v, "u", v + ".up");
        }
        if (n == 3) {
            s += string.Format(f, v + ".back", v, "b", isInt ? "new " + v + "(0, 0, -1)" : v + ".back");
            s += string.Format(f, v + ".forward", v, "f", isInt ? "new " + v + "(0, 0, 1)" : v + ".forward");
        }
        s += string.Format(f, v + ".zero", v, "O", v + ".zero");
        s += string.Format(f, v + ".one", v, "I", v + ".one");
        if (!isInt) {
            s += string.Format(f, v + ".negativeInfinity", v, "negInf", v + ".negativeInfinity");
            s += string.Format(f, v + ".positiveInfinity", v, "posInf", v + ".positiveInfinity");
        }
        s += VectorNzp(n, isInt);
        string[] arr = (n == 2 ? "x y" : n == 3 ? "x y z xy xz yz" : "x y z w xy xz xw yz yw zw xyz xyw xzw yzw").Split(' ');
        string type = isInt ? "int " : "float", xyzw = "xyzw";
        for (int i = 0; i < arr.Length; i++) {
            s += "\t///<summary>" + v + " " + string.Join(" ", arr[i].ToCharArray()) + "</summary>\n" +
                "\tpublic static " + v + " " + arr[i][0].ToString().ToUpper() + arr[i].Substring(1) + "(" + v + " v";
            for (int j = 0; j < arr[i].Length; j++)
                s += ", " + type + " " + arr[i][j];
            s += ") {\n\t\treturn new " + v + "(";
            for (int j = 0; j < n; j++)
                s += (j > 0 ? ", " : "") + (arr[i].Contains(xyzw[j].ToString()) ? "" : "v.") + xyzw[j];
            s += ");\n\t}\n\n";
        }
        s += "\t///<summary>" + v + "-г " + v + "-д үржинэ</summary>\n" +
            "\tpublic static " + v + " Mul(" + v + " a, " + v + " b) {\n" +
            "\t\treturn " + v + ".Scale(a, b);\n\t}\n\n" +
            "\t///<summary>" + v + "-г " + v + "-д хуваана</summary>\n" +
            "\tpublic static " + v + " Div(" + v + " a, " + v + " b) {\n" +
            "\t\treturn new " + v + "(";
        for (int i = 0; i < n; i++)
            s += (i > 0 ? ", " : "") + "a." + xyzw[i] + " / b." + xyzw[i];
        s += ");\n\t}\n\n}";
        return s;
    }

    static string VectorNzp(int n, bool isInt = false, string s = "", int c = 0, List<string> lis = null) {
        if (c == 0)
            lis = new List<string>();
        if (c == n) {
            string type = "Vector" + n + (isInt ? "Int" : ""), vec = type + "(";
            for (int i = 0; i < s.Length; i++)
                vec += (s[i] == 'n' ? "-1" : s[i] == 'z' ? "0" : "1") + ", ";
            vec = vec.Substring(0, vec.Length - 2) + ")";
            lis.Add("\t///<summary>" + vec + "</summary>\n\tpublic static readonly " + type + " " + s + " = new " + vec + ";\n\n");
            return "";
        }
        for (int i = -1; i <= 1; i++)
            VectorNzp(n, isInt, s + (i == -1 ? "n" : i == 0 ? "z" : "p"), c + 1, lis);
        return c == 0 ? string.Join("", lis) : "";
    }

    static string[] charDataArr = new string[] {
        "                                     ▀ ▀                     ▀▄▀                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ",
        "▄▀▀▀▄ █▀▀▀▀ █▀▀▀▄ █▀▀▀▀  █▀█  █▀▀▀▀ █▀▀▀▀ █ █ █ ▄▀▀▀▄ █   █ █   █ █  ▄▀  █▀▀█ █▄ ▄█ █   █ ▄▀▀▀▄ ▄▀▀▀▄ █▀▀▀█ █▀▀▀▄ ▄▀▀▀▄ ▀▀█▀▀ █   █ █   █ ▄▀█▀▄ █   █ █  █  █   █ █ █ █ █ █ █ ▀█    █   █ █     ▀▀▀▀▄ █ ▄▀▄ ▄▀▀▀█        ▄▄▄▀                          ▀ ▀                     ▀▄▀                                                                                                                                                  ▄▀▀▀▄ █▀▀▀▄ ▄▀▀▀▄ █▀▀▀▄ █▀▀▀▀ █▀▀▀▀ ▄▀▀▀▄ █   █  ▀█▀    ▀█▀ █  ▄▀ █     █▄ ▄█ █   █ ▄▀▀▀▄ █▀▀▀▄ ▄▀▀▀▄ █▀▀▀▄ ▄▀▀▀▀ ▀▀█▀▀ █   █ █   █ █   █ █   █ █   █ ▀▀▀▀█       █               █         ▄▀▄       █       ▄      ▀   █     ▀█                                               █                                        ▀▄    ▄█   ▄▀▀▀▄ ▀▀▀█▀   ▄█  █▀▀▀▀  ▄▀▀  ▀▀▀▀█ ▄▀▀▀▄ ▄▀▀▀▄ ▄▀▀▀▄              ▄▄▄▀   █   ▄▀▀▀▄  █ █   ▄█▄▄ ██  ▄  ▄▀▄  ▄▀▀▄    ▄     ▄▀   ▀▄           ▄     █▀   ▀█   ▄      ▄▄    ▀█                   ▄  ▄▀▀   ▀▀▄    █    ▄▄    █ █    ▄▀   ▀▄   ▄▀▀▀▄       ",
        "█▄▄▄█ █▄▄▄  █▄▄▄▀ █      █ █  █▄▄▄  █▄▄▄  ▀▄█▄▀  ▄▄▄▀ █ ▄▀█ █ ▄▀█ █▄▀    █  █ █ █ █ █▄▄▄█ █   █ █▄▄▄█ █   █ █▄▄▄▀ █       █   ▀▄▄▄█  ▀▄▀  ▀▄█▄▀  ▀▄▀  █  █  ▀▄▄▄█ █ █ █ █ █ █  █▄▄  █▄  █ █▄▄▄   ▄▄▄█ █▄█ █ ▀▄▄▄█  ▀▀▀▄ █▄▄▄  █▀▀▀▄ █▀▀▀▀  █▀█  ▄▀▀▀▄ ▄▀▀▀▄ █ █ █ ▀▀▀▀▄ █  ▄█ █  ▄█ █  ▄▀  █▀▀█ █▄ ▄█ █   █ ▄▀▀▀▄ ▄▀▀▀▄ █▀▀▀█ █▀▀▀▄ ▄▀▀▀▀ ▀▀█▀▀ █   █ █   █ ▄▀█▀▄ ▀▄ ▄▀ █  █  █   █ █ █ █ █ █ █ ▀█    █   █ █     ▀▀▀▀▄ █ ▄▀▄  ▄▀▀█ █▄▄▄█ █▄▄▄▀ █     █   █ █▄▄▄  █▄▄▄  █     █▄▄▄█   █      █  █▄▀   █     █ █ █ █▀▄ █ █   █ █▄▄▄▀ █   █ █▄▄▄▀ ▀▄▄▄    █   █   █ █   █ █ ▄ █  ▀▄▀   ▀▄▀    ▄▀   ▀▀▀▄ █▄▄▄  ▄▀▀▀▀  ▄▄▄█ ▄▀▀▀▄  ▄█▄  ▄▀▀▀█ █▄▄▄    ▄      █   █ ▄▀   █   █▀▄▀█ █▄▀▀▄ ▄▀▀▀▄ █▀▀▀▄ ▄▀▀▀█ █▄▀▀▄ ▄▀▀▀▀ ▀▀█▀▀ █   █ █   █ █   █ ▀▄ ▄▀ ▀▄ ▄▀ ▀▀▀█▀    ▀    █      ▄▀   ▀▄  ▄▀ █  ▀▀▀▀▄ █▄▄▄    ▄▀  ▀▄▄▄▀ ▀▄▄▄█ █ ▄▀█ ▄▄▄▄▄ ▀▀▀▀▀ ▀       █    ▄▄ █ ▀█▀█▀ ▀▄█▄    ▄▀  ▀   ▀ ▀▄▀   ▀▄█▄▀  █       █        ▄▄█▄▄   █     █    ▀▄    ▀▀    ▀                  ▄▀  ▄▀       ▀▄   █    ▀▀    ▀ ▀  ▄▀       ▀▄    ▄▀       ",
        "█   █ █   █ █   █ █      █ █  █     █     █ █ █ ▄   █ █▀  █ █▀  █ █ ▀▄   █  █ █   █ █   █ █   █ █   █ █   █ █     █   ▄   █   ▄   █   █     █   ▄▀ ▀▄ █  █      █ █ █ █ █ █ █  █  █ █ █ █ █   █     █ █ █ █  ▄▀ █ ▄▀▀▀█ █   █ █▀▀▀▄ █      █ █  █▀▀▀  █▀▀▀  ▄▀█▀▄  ▀▀▀▄ █▄▀ █ █▄▀ █ █▀▀▄   █  █ █ ▀ █ █▀▀▀█ █   █ █▀▀▀█ █   █ █▀▀▀  █       █    ▀▀▀█  ▀▄▀  ▀▄█▄▀  ▄▀▄  █  █   ▀▀▀█ █ █ █ █ █ █  █▀▀▄ █▀▄ █ █▀▀▀▄  ▀▀▀█ █▀█ █  ▄▀▀█ █   █ █   █ █   ▄ █   █ █     █     █  ▀█ █   █   █   ▄  █  █ ▀▄  █     █   █ █  ▀█ █   █ █     █ ▀▄▀ █ ▀▄      █   █   █   █  █ █  █ █ █ ▄▀ ▀▄   █   ▄▀    ▄▀▀▀█ █   █ █     █   █ █▀▀▀▀   █    ▀▀▀█ █   █   █   ▄  █   █▀▄    █   █ █ █ █   █ █   █ █▀▀▀   ▀▀▀█ █      ▀▀▀▄   █ ▄ █   █ ▀▄ ▄▀ █ █ █  ▄▀▄    █    ▄▀           █    ▄▀   ▄   █ ▀▀▀█▀ ▄   █ █   █  █    █   █    ▄▀ █▀  █       ▀▀▀▀▀             █ █ █ ▀█▀█▀ ▄▄█▄▀ ▄▀ ▄▄       █ ▀▄▀ ▀ █ ▀  ▀▄     ▄▀          █     █     █      ▀▄  ▀█          ▀█    ▄▄   ▄▀     █       █    █    ██          ▀▄     ▄▀    ▀         ",
        "▀   ▀ ▀▀▀▀  ▀▀▀▀  ▀     █▀▀▀█ ▀▀▀▀▀ ▀▀▀▀▀ ▀ ▀ ▀  ▀▀▀  ▀   ▀ ▀   ▀ ▀   ▀ ▀   ▀ ▀   ▀ ▀   ▀  ▀▀▀   ▀▀▀  ▀   ▀ ▀      ▀▀▀    ▀    ▀▀▀    ▀     ▀   ▀   ▀ ▀▀▀▀█     ▀ ▀▀▀▀▀ ▀▀▀▀█  ▀▀▀  ▀▀  ▀ ▀▀▀▀  ▀▀▀▀  ▀  ▀  ▀   ▀  ▀▀▀▀  ▀▀▀  ▀▀▀▀  ▀     █▀▀▀█  ▀▀▀▀  ▀▀▀▀ ▀ ▀ ▀ ▀▀▀▀  ▀   ▀ ▀   ▀ ▀   ▀ ▀   ▀ ▀   ▀ ▀   ▀  ▀▀▀   ▀▀▀  ▀   ▀ ▀      ▀▀▀▀   ▀    ▀▀▀    ▀     ▀   ▀   ▀ ▀▀▀▀█     ▀ ▀▀▀▀▀ ▀▀▀▀█  ▀▀▀  ▀▀  ▀ ▀▀▀▀  ▀▀▀▀  ▀  ▀  ▀   ▀ ▀   ▀ ▀▀▀▀   ▀▀▀  ▀▀▀▀  ▀▀▀▀▀ ▀      ▀▀▀  ▀   ▀  ▀▀▀   ▀▀   ▀   ▀ ▀▀▀▀▀ ▀   ▀ ▀   ▀  ▀▀▀  ▀      ▀▀ ▀ ▀   ▀ ▀▀▀▀    ▀    ▀▀▀    ▀    ▀ ▀  ▀   ▀   ▀   ▀▀▀▀▀  ▀▀▀▀ ▀▀▀▀   ▀▀▀▀  ▀▀▀▀  ▀▀▀▀   ▀   ▀▀▀▀  ▀   ▀   ▀    ▀▀    ▀  ▀  ▀▀▀  ▀   ▀ ▀   ▀  ▀▀▀  ▀         ▀ ▀     ▀▀▀▀     ▀   ▀▀▀    ▀    ▀ ▀  ▀   ▀  ▀    ▀▀▀▀▀        ▀▀▀  ▀▀▀▀▀  ▀▀▀     ▀   ▀▀▀   ▀▀▀   ▀     ▀▀▀   ▀▀    ▀▀▀                      ▀    ▀▀▀   ▀ ▀    ▀      ▀▀        ▀▀ ▀          ▀   ▀    ▀▀▀▀▀         ▀▀   ▀▀          ▀           ▀     ▀▀           ▀▀   ▀▀     ▀                  ▀   ▀      ▀         ",
    };
    static string charDataStr = "АБВГДЕЁЖЗИЙКЛМНОӨПРСТУҮФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмноөпрстуүфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz`1234567890-=~!@#$%^&*()_+[]\\;',./{}|:\"<>? ";
    public static string GetComment(string str, int tabSize = 4) {
        string res = "";
        string[] arr = str.Split('\n');
        int startIdx = str.Contains("Ё") || str.Contains("Й") ? 0 : 1;
        foreach (string s in arr) {
            for (int i = startIdx; i < charDataArr.Length; i++) {
                res += "\n\t// ";
                for (int j = 0, k = 0; j < s.Length; j++) {
                    if (s[j] == '\t') {
                        for (int it = 0, t = tabSize - k % tabSize; it < t; it++) {
                            res += charDataArr[i].SubStr(charDataStr.IndexOf(' ') * 6, 6);
                            k++;
                        }
                    } else if (charDataStr.Contains("" + s[j])) {
                        res += charDataArr[i].SubStr(charDataStr.IndexOf(s[j]) * 6, 6);
                        k++;
                    }
                }
            }
        }
        return res;
    }
}