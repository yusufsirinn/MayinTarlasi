using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vize
{
    class Minefield
    {
        static private int numberMines;
        static private int total = 0;
        static private List<bool> mines = new List<bool>();
        static private List<int> neighboringMines = new List<int>();
        static public int NumberMines
        {
            get { return numberMines; } 
            set {
                if(value > 0 || value < 25)
                {
                    numberMines = value;
                }
                else
                {
                    
                }
            } 
        }
        
        static public List<bool> PlaceMines()
        {
            mines.Clear();
            for (int i = 0; i < 25; i++)
            {
                if (numberMines > i)
                {
                    mines.Add(true);
                }
                else
                {
                    mines.Add(false);
                }
            }
            Shuffle(mines);
            return mines;
        }
        
        static private void Shuffle(List<bool> arrays)
        {
            Random rnd = new Random();
            for (int i = 0; i < arrays.Count; i++)
            {
                int j = rnd.Next(i, arrays.Count);
                bool temp = arrays[i];
                arrays[i] = arrays[j];
                arrays[j] = temp;
            }
        }
        static private void FindAndCalculateLimits(int i,bool center)
        {
            if (i % 5 != 0)
            {
                if (mines[i-1] == true)
                {
                    total++;
                }
            }
            if (i % 5 != 4)
            {
                if (mines[i + 1] == true)
                {
                    total++;
                }
            }
            if (center==false) 
            {
                if (mines[i] == true)
                {
                    total++;
                }
            }
        }
        static public List<int> FindNeighboringMines()
        {
            neighboringMines.Clear();
            total = 0;
            for (int i = 0; i < mines.Count; i++)
            {
                if (i > 4)
                {
                    FindAndCalculateLimits(i-5,false);
                }
                if (i < 20)
                {
                    FindAndCalculateLimits(i + 5,false);
                }
                FindAndCalculateLimits(i,true);
                neighboringMines.Add(total);
                total = 0;
            }
            return neighboringMines;
        }
    }
}
