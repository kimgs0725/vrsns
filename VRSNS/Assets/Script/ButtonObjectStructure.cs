using UnityEngine;
using System.Collections;

public class ButtonObjectStructure : MonoBehaviour {

    public int objID;
    public string name;
    public GameObject prefab;
    public string tab;
    public static ArrayList ButtenList = new ArrayList();

    public ButtonObjectStructure(int objID, string name, GameObject obj, string tab)
    {
        this.objID = objID;
        this.name = name;
        this.prefab = obj;
        this.tab = tab;
    }

    public static void init() {
        ButtonObjectStructure[] gbs =  {
            new ButtonObjectStructure(1, "testObj", Resources.Load ("resource/TESTOBJ") as GameObject, "ETC"),
            new ButtonObjectStructure(2, "Wall_1", Resources.Load ("resource/Wall") as GameObject, "ETC"),
            new ButtonObjectStructure(3, "Chair_1", Resources.Load ("Furniture_Pack_1_Free/Prefabs/chair_7106") as GameObject, "Funiture"),
            new ButtonObjectStructure(4, "Table_1", Resources.Load ("Furniture_Pack_1_Free/Prefabs/table_7103") as GameObject, "Funiture"),
            new ButtonObjectStructure(5, "Bed_1", Resources.Load ("Assets_Beds/prefabs/bed1") as GameObject, "Funiture"),
            new ButtonObjectStructure(6, "Bed_2", Resources.Load ("Assets_Beds/prefabs/bed2") as GameObject, "Funiture"),
            new ButtonObjectStructure(7, "Piano_1", Resources.Load ("piano/piano_prefab") as GameObject, "Funiture"),
            new ButtonObjectStructure(8, "arm_chair_1", Resources.Load ("Next-gen_armchair/Prefabs/Armchair") as GameObject, "Funiture"),
            //new ButtonObjectStructure(9, "Table_2", Resources.Load ("Wooden_table_and_chair/FBX/table_and_chair_prefab") as GameObject, "Funiture"),
            new ButtonObjectStructure(10, "Flower_1", Resources.Load ("Furniture01/FurniturePrefab/Furniture_foliageplant_08_lod_set") as GameObject, "ETC"),
            new ButtonObjectStructure(11, "Flower_2", Resources.Load ("Furniture01/FurniturePrefab/Furniture_foliageplant_09_lod_set") as GameObject, "ETC"),
            new ButtonObjectStructure(12, "Flower_3", Resources.Load ("Furniture01/FurniturePrefab/Furniture_foliageplant_10_lod_set") as GameObject, "ETC"),
            new ButtonObjectStructure(13, "Flower_4", Resources.Load ("Furniture01/FurniturePrefab/Furniture_foliageplant_11_lod_set") as GameObject, "ETC")
            /* add object button list */
        };
        foreach (ButtonObjectStructure obj in gbs) {
            ButtenList.Add(obj);
        }
    }
    

}