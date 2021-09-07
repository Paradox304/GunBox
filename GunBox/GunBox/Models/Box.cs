using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunBox.Models
{
    public class Box
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Gun> Guns { get; set;}

        public Box()
        {

        }

        public Box(string name, int price, List<Gun> guns)
        {
            Name = name;
            Price = price;
            Guns = guns;
        }

        public Gun GetRandomGun()
        {
            int poolSize = 0;
            foreach (Gun gun in Guns) poolSize += gun.Weight;
            int randInt = UnityEngine.Random.Range(0, poolSize) + 1;

            int accumulatedProbability = 0;
            for (int i = 0; i < Guns.Count; i++)
            {
                accumulatedProbability += Guns[i].Weight;
                if (randInt <= accumulatedProbability)
                    return Guns[i];
            }
            return Guns[UnityEngine.Random.Range(0, Guns.Count)];
        }
    }
}
