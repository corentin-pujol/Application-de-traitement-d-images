using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2_PUJOL
{
    public class Pixel
    {
        //Champs
        byte red;
        byte green;
        byte blue;

        //Constructeur
        public Pixel(byte bleu, byte vert, byte rouge)
        {
            this.red = rouge;
            this.green = vert;
            this.blue = bleu;
        }

        //Propriétés

        public byte Red
        { get { return this.red; } set { this.red = value; } }

        public byte Green
        { get { return this.green; } set { this.green = value; } }

        public byte Blue
        { get { return this.blue; } set { this.blue = value; } }

        //Méthode
        public override string ToString()
        {
            return "Le pixel est composé de :" + "/n" + "Red : " + this.red + "/n" + "Green : " + this.green + "/n" + "Blue : " + this.blue;
        }
        
    }
}
