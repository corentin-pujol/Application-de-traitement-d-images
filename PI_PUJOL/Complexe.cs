using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2_PUJOL
{
    public class Complexe
    {
        double partie_réelle;
        double partie_imaginaire;

        public Complexe(double x,double y)
        {
            this.partie_réelle = x;
            this.partie_imaginaire = y;
        }

        public double Partie_réelle
        { get { return this.partie_réelle; } set { this.partie_réelle = value; } }
        public double Partie_imaginaire
        { get { return this.partie_imaginaire; } set { this.partie_imaginaire = value; } }
        public override string ToString()
        {
            return this.partie_réelle+"i"+this.partie_imaginaire;
        }
        /// <summary>
        /// Calcul du module d'un complexe
        /// </summary>
        /// <returns>module</returns>
        public double module_complexe()
        {
            double somme_pr_pi_carré = (double)(Math.Pow(this.partie_réelle, 2) + Math.Pow(this.partie_imaginaire, 2));
            double module = (double)(Math.Sqrt(somme_pr_pi_carré));
            return module;
        }
    }
}
