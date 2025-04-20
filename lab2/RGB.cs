using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stp_lab2
{
    public class RGB
    {
        private int R;
        private int G;
        private int B;

        public RGB() { }
        public RGB(int r,int g,int b)
        {
            R = r;
            G = g;
            B = b;
        }
        public int r
        {
            get
            {
                return R; 
            }
            set
            {
                if (value >= 0 && value < 256)
                {
                    R = value;
                }
                else if(value<0)
                {
                    R = 0;
                }
                else { R = 255; }
            }
        }
        public int g
        {
            get
            {
                return G;
            }
            set
            {
                if (value >= 0 && value < 256)
                {
                    G = value;
                }
                else if (value < 0)
                {
                    G = 0;
                }
                else { G = 255; }
            }
        }
        public int b
        {
            get
            {
                return B;
            }
            set
            {
                if (value >= 0 && value < 256)
                {
                    B = value;
                }
                else if (value < 0)
                {
                    B = 0;
                }
                else
                {
                    B = 255;
                }
            }
        }

        public void Init(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public void Display()
        {
            string s, s1,s2;
            s1 = Convert.ToString(R);
            s = "R: " + s1 + " ";
            s1 = Convert.ToString(G);
            s1 = s + "G:" + s1 + " ";
            s2 = Convert.ToString(B);
            s2 = s1 + "B:" + s2;
            Console.WriteLine(s2);
        }

        public void Read()
        {
            string s = "";
            s = Console.ReadLine();
            string[] s1;
            s1 = s.Split(new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
            R = Convert.ToInt32(s1[0]);
            G = Convert.ToInt32(s1[1]);
            B = Convert.ToInt32(s1[2]);
        }

        public double white_black_point()
        {
            return (0.3 * R + 0.59 * G + 0.11 * B);
        }

        public RGB Add(RGB a, RGB b)
        {
            RGB intermediate = new RGB();
            int r;
            int g;
            int bb;
            r = a.R + b.R;
            g = a.G + b.G;
            bb = a.B + b.B;
            if (r > 255) { r = 255; }
            if (g > 255) { g = 255; }
            if (bb > 255) { bb = 255; }
            intermediate.R = r;
            intermediate.G = g;
            intermediate.B = bb;
            return intermediate;


        }
    }
}
