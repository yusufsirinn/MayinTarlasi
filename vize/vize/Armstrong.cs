using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace vize
{
    class Armstrong
    {
        static List<int> armstrongNumbers= new List<int>();
        public static List<int> ArmstrongNumbersBetweenLimits(int upperLimit,int lowerLimit)
        {
            armstrongNumbers.Clear();
            for (int i = lowerLimit; i < upperLimit; i++)
            {
                double total = 0;
                string number = i.ToString();
                for (int j = 0; j < number.Length; j++)
                {
                    string temp =number[j].ToString();
                    total += Math.Pow(Convert.ToInt32(temp),3);
                }
                if ((int)total == i)
                {
                    armstrongNumbers.Add(i);
                }
            }
            return armstrongNumbers;
        }
    }
}
