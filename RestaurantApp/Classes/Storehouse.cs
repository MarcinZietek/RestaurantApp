using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Storehouse
    {
       
        private MeatEnum meat;
        private VegetableEnum vegetable;
        private string liquids;
        private FishEnum fish;
        private DairyEnum dairy;

        public Storehouse() { }
        public Storehouse(MeatEnum meat, VegetableEnum vegetable, string liquids, FishEnum fish)
        {
            
            Meat = meat;
            Vegetable = vegetable;
            Liquids = liquids;
            Fish = fish;
        }

        public Storehouse(MeatEnum meat)
        {
            Meat = meat;
        }

        public Storehouse(VegetableEnum vegetable, FishEnum fish)
        {
            Vegetable = vegetable;
            Fish = fish;
        }

        public MeatEnum Meat { get { return meat; } set { meat = value; } }
        public VegetableEnum Vegetable { get { return vegetable; } set { vegetable = value; } }
        public string Liquids { get { return liquids; } set { liquids = value; } }
        public FishEnum Fish { get { return fish; } set { fish = value; } }

        public override string ToString()
        {
            return $"Mięso: {Meat}\tRyby: {Fish}\tWarzywa: {Vegetable}\tPłyny: {Liquids}\n";
        }

    }

    public enum MeatEnum
    {
        Wołowina, Drób, Wieprzowina, Dziczyzna
    }

    public enum FishEnum 
    {
        Sandacz, Szczupak, Dorsz, Łosoś, Halibut
    }

    public enum VegetableEnum
    {
        Pomidor, Ogórek, Sałata, Cebula, Papryka
    }

    public enum DairyEnum
    {
        Jajko, Ser_żółty, Ser_Biały, Jogurt, Śmietana, Mkleko
    }
}
