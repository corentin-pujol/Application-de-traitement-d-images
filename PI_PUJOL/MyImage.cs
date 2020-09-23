using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace TD2_PUJOL
{
    public class MyImage
    {
        //Lecture et ecriture de l'image TD2

        //Champs

        string typeImage;
        int tailleFiles;
        int tailleOffset;
        int tailleheaderinfo;
        int largeurImage;
        int hauteurImage;
        int nbrBitsPC;
        Pixel[,] matriceRGB;

        //Constructeur (From file to image)
        public MyImage(string filename)
        {
            byte[] myfile = File.ReadAllBytes(filename);
            int tailleF = 0;
            for (int i = 2; i < 6; i++) // recherche taille fichier
            {
                tailleF += myfile[i] * ((int)Math.Pow(256, (i - 2)));
            }
            this.tailleFiles = tailleF;
            //Console.WriteLine("La taille du fichier est : " + tailleF);

            int tailleO = 0;
            for (int i = 10; i < 14; i++) // recherche taille offset
            {
                tailleO += myfile[i] * ((int)Math.Pow(256, (i - 10)));
            }
            this.tailleOffset = tailleO;
            //Console.WriteLine("La taille du offset est : " + tailleO);
            int tailleH = 0;
            for (int i = 14; i < 18; i++) // recherche taille header info
            {
                tailleH += myfile[i] * ((int)Math.Pow(256, (i - 14)));
            }
            this.tailleheaderinfo = tailleH;
            //Console.WriteLine("La taille du header info est : " + tailleH);
            int largeur = 0;
            for (int i = 18; i < 22; i++) //recherche largeur
            {
                largeur += myfile[i] * ((int)Math.Pow(256, (i - 18)));
            }
            this.largeurImage = largeur;
            //Console.WriteLine("La largeur this est : " + largeur);
            int hauteur = 0;
            for (int i = 22; i < 26; i++) //recherche hauteur
            {
                hauteur += myfile[i] * ((int)Math.Pow(256, (i - 22)));
            }
            this.hauteurImage = hauteur;
            //Console.WriteLine("La hauteur this est : " + hauteur);
            int octets = 0;
            for (int i = 28; i < 30; i++) //recherche nbrbits
            {
                octets += myfile[i] * ((int)Math.Pow(256, (i - 28)));
            }
            this.nbrBitsPC = octets;
            //Console.WriteLine("Le nombre de bits est : " + octets);

            int debut = 54;
            Pixel[,] matrice = new Pixel[hauteur, largeur];
            for (int i = 0; i < this.hauteurImage; i++)
            {
                for (int j = 0; j < this.largeurImage; j++)
                {
                    matrice[i, j] = new Pixel(myfile[debut], myfile[debut + 1], myfile[debut + 2]); //création de chaque pixel a l'aide la classe pixel
                    debut += 3;
                }
            }
            this.matriceRGB = matrice;
        }

        //propriétés
        public string TypeImage
        { get { return this.typeImage; } set { this.typeImage = value; } }
        public int TailleFiles
        { get { return this.tailleFiles; } set { this.tailleFiles = value; } }
        public int TailleOffset
        { get { return this.tailleOffset; } set { this.tailleOffset = value; } }
        public int Taillerheaderinfo
        { get { return this.tailleheaderinfo; } set { this.tailleheaderinfo = value; } }
        public int LargeurImage
        { get { return this.largeurImage; } set { this.largeurImage = value; } }
        public int HauteurImage
        { get { return this.hauteurImage; } set { this.hauteurImage = value; } }
        public int NbrBitsPC
        { get { return this.nbrBitsPC; } set { this.nbrBitsPC = value; } }
        public Pixel[,] MatriceRGB
        { get { return this.matriceRGB; } set { this.matriceRGB = value; } }

        //Méthodes

        /// <summary>
        /// Il s'agit de la méthode ToString nécessaire dans chaque classe
        /// </summary>
        /// <returns>Description de la fonction</returns>
        public override string ToString()
        {
            return "L'this est de type " + this.typeImage + ", de taille " + this.tailleFiles + ", de dimension " + this.largeurImage + "x" + this.hauteurImage + " et possède " + this.nbrBitsPC + " bites par couleur";
        }

        /// <summary>
        /// Traduction d'une image dans un fichier
        /// </summary>
        /// <param name="nomfichier">On rentre l'emplacement du fichier</param>
        public void From_Image_To_File(string nomfichier)
        {
            byte[] myfile = new byte[this.tailleFiles];
            myfile[0] = (byte)66; //Format du fichier ici B & M car nous manipulons des fichers bitmaps
            myfile[1] = (byte)77; 
            for (int i = 2; i < myfile.Length; i++)
            {
                if ((i > 1) && (i < 6)) //taille du fichier
                {
                    byte[] taillef = Convertir_Int_To_Endian(this.tailleFiles, 4);
                    for (int j = 0; j < taillef.Length; j++)
                    {
                        myfile[j + 2] = taillef[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 5;
                }

                else if ((i > 9) && (i < 14)) //taille offset
                {
                    byte[] tailleo = Convertir_Int_To_Endian(this.tailleOffset, 4);
                    for (int j = 0; j < tailleo.Length; j++)
                    {
                        myfile[j + 10] = tailleo[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 13;
                }
                else if ((i > 13) && (i < 18)) //taille du headerinfo
                {
                    byte[] tailleh = Convertir_Int_To_Endian(this.tailleheaderinfo, 4);
                    for (int j = 0; j < tailleh.Length; j++)
                    {
                        myfile[j + 14] = tailleh[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 17;
                }
                else if ((i > 17) && (i < 22)) //largeur de l'image
                {
                    byte[] l = Convertir_Int_To_Endian(this.largeurImage, 4);
                    for (int j = 0; j < l.Length; j++)
                    {
                        myfile[j + 18] = l[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 21;
                }
                else if ((i > 21) && (i < 26)) //hauteur de l'image
                {
                    byte[] h = Convertir_Int_To_Endian(this.hauteurImage, 4);
                    for (int j = 0; j < h.Length; j++)
                    {
                        myfile[j + 22] = h[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 25;
                }
                else if (i == 26) //Nombre de plan (1)
                {
                    myfile[i] = (byte)1;
                    //Console.Write(myfile[i]);
                    //Console.WriteLine();
                }
                else if ((i > 27) && (i < 30)) //Nombre de bits par pixel
                {
                    byte[] nb = Convertir_Int_To_Endian(this.nbrBitsPC, 2);
                    for (int j = 0; j < nb.Length; j++)
                    {
                        myfile[j + 28] = nb[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 29;
                }
                else if ((i > 33) && (i < 38)) //Taille image
                {
                    int taille_image_int = this.hauteurImage * this.largeurImage * 3;
                    byte[] taille_image = Convertir_Int_To_Endian(taille_image_int, 4);
                    for (int j = 0; j < taille_image.Length; j++)
                    {
                        myfile[j + 34] = taille_image[j];
                        //Console.Write(myfile[i]);
                    }
                    //Console.WriteLine();
                    i = 37;
                }
                else if (i > 53) //Image
                {
                    for (int ligne = 0; ligne < this.matriceRGB.GetLength(0); ligne++)
                    {
                        for (int colonne = 0; colonne < this.matriceRGB.GetLength(1); colonne++)
                        {
                            myfile[i] = this.matriceRGB[ligne, colonne].Blue;
                            myfile[i + 1] = this.matriceRGB[ligne, colonne].Green;
                            myfile[i + 2] = this.matriceRGB[ligne, colonne].Red;
                            //Console.Write(myfile[i]);
                            //Console.Write(myfile[i+1]);
                            //Console.Write(myfile[i+2]);
                            i += 3;
                        }
                    }
                    //Console.WriteLine();
                    i = myfile.Length;
                }
            }
            //for(int i = 0; i < myfile.Length; i++)
            //{
            //    Console.WriteLine(myfile[i]);
            //}
            File.WriteAllBytes(nomfichier, myfile);
        }

        /// <summary>
        /// Convertion Endian/Int 
        /// </summary>
        /// <param name="tab"></param>
        /// <returns>Int</returns>
        public int Convertir_Endian_To_Int(byte[] tab)
        {
            int entier = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                entier += tab[i] * ((int)Math.Pow(256, i));
            }
            return entier;
        }

        /// <summary>
        /// Convertion Int/Endian
        /// </summary>
        /// <param name="entier"></param>
        /// <param name="nombre_d_octets"></param>
        /// <returns>Endian</returns>
        public byte[] Convertir_Int_To_Endian(int entier, int nombre_d_octets)
        {
            byte[] tab = new byte[nombre_d_octets];
            int reste = entier % 256;
            tab[0] = (byte)reste;
            entier -= reste;
            for (int i = 1; i < nombre_d_octets; i++)
            {
                int quotient = entier / ((int)Math.Pow(256, (nombre_d_octets - i)));
                tab[tab.Length - i] = (byte)quotient;
                entier -= (quotient * ((int)Math.Pow(256, (nombre_d_octets - i))));
            }
            return tab;
        }

        //Traiter une image TD3

        /// <summary>
        /// Modifie les couleurs de l'image et enregistre une image en nuance de gris
        /// </summary>
        public void Nuance_de_gris()
        {
            for (int i = 0; i < this.matriceRGB.GetLength(0); i++)
            {
                for (int j = 0; j < this.matriceRGB.GetLength(1); j++)
                {
                    byte gray = (byte)((this.matriceRGB[i, j].Red + this.matriceRGB[i, j].Blue + this.matriceRGB[i, j].Green) / 3); //Moyenne des 3 niveaux de couleurs que l'on affecte a chaque couleur du pixel
                    this.matriceRGB[i, j].Red = gray;
                    this.matriceRGB[i, j].Blue = gray;
                    this.matriceRGB[i, j].Green = gray;
                }
            }
        }

        /// <summary>
        /// Modifie l'image et enregistre son Negatif
        /// </summary>
        public void Negatif()
        {
            for(int ligne = 0;ligne<this.hauteurImage; ligne++)
            {
                for(int colonne = 0; colonne < this.largeurImage; colonne++)
                {
                    matriceRGB[ligne, colonne].Red = (byte)(255 - matriceRGB[ligne, colonne].Red);
                    matriceRGB[ligne, colonne].Blue = (byte)(255 - matriceRGB[ligne, colonne].Blue);
                    matriceRGB[ligne, colonne].Green = (byte)(255 - matriceRGB[ligne, colonne].Green);
                }
            }
        }
        
        /// <summary>
        /// Modifie l'image et enregistre le miroir de l'image 
        /// </summary>
        public void Miroir()
        {
            Pixel[,] matricemiroir = new Pixel[this.hauteurImage, this.largeurImage];
            for (int ligne = 0; ligne < hauteurImage; ligne++)
            {
                for (int colonne = 0; colonne < largeurImage; colonne++)
                {
                    matricemiroir[ligne, colonne] = this.matriceRGB[ligne, largeurImage - colonne - 1]; //On prend les elements de la matrice RGB sur la meme ligne mais en partant des colonnes de la fin
                }
            }
            this.matriceRGB = matricemiroir;
        }

        /// <summary>
        ///  Modifie les couleurs de l'image et enregistre une image en noir et en blanc
        /// </summary>
        public void Noir_Blanc()
        {
            Pixel[,] matrice_noir_blanc = new Pixel[this.hauteurImage, this.largeurImage];
            for (int ligne = 0; ligne < hauteurImage; ligne++)
            {
                for (int colonne = 0; colonne < largeurImage; colonne++)
                {
                    byte mediane = (0 + 255) / 2;  //Définition de la médiane afin de comparer si la moyenne des 3 couleurs du pixel est au dessus ou en dessous
                    byte gray = (byte)((this.matriceRGB[ligne, colonne].Red + this.matriceRGB[ligne, colonne].Blue + this.matriceRGB[ligne, colonne].Green) / 3);
                    Pixel Noir = new Pixel(0, 0, 0);
                    Pixel Blanc = new Pixel(255, 255, 255);
                    if (gray > mediane) //au dessus, il s'agit d'une couleur clair, donc on met du blanc
                    {
                        matrice_noir_blanc[ligne, colonne] = Blanc;
                    }
                    else //en dessous, on met du noir
                    {
                        matrice_noir_blanc[ligne, colonne] = Noir;

                    }
                }
            }
            this.matriceRGB = matrice_noir_blanc;
        }

        /// <summary>
        /// Agrandie l'image avec un coefficient choisi par l'utilisateur
        /// </summary> 
        public void Agrandir()
        {
            Console.WriteLine("Entrez le coefficient d'agrandissement :");
            int coef = Convert.ToInt32(Console.ReadLine());

            if (coef >= 2)
            {
                Pixel[,] newmat = new Pixel[this.hauteurImage * coef, this.largeurImage * coef]; //Définition de la taille de la matrice

                for (int i = 0; i < this.hauteurImage; i++)
                {

                    for (int j = 0; j < this.largeurImage; j++)
                    {

                        Pixel[,] pixelagrandi = new Pixel[coef, coef]; //Agrandissement de chaque pixel
                        for (int ligne = 0; ligne < coef; ligne++)
                        {

                            for (int colonne = 0; colonne < coef; colonne++)
                            {

                                pixelagrandi[ligne, colonne] = this.matriceRGB[i, j]; 

                            }

                        }

                        for (int k = i * coef; k <= i * coef + coef - 1; k++) //On boucle ensuite afin de remplir la matrice agrandie avec chaque pixel agrandi
                        {
                            for (int l = j * coef; l <= j * coef + coef - 1; l++)
                            {
                                newmat[k, l] = pixelagrandi[k - i * coef, l - j * coef];
                            }
                        }
                    }

                }
                this.largeurImage = this.largeurImage * coef; //Mise a jour des parametres de l'image
                this.hauteurImage = this.hauteurImage * coef;
                this.tailleFiles = 54 + hauteurImage * largeurImage * 3;
                this.matriceRGB = newmat;

            }
            else if (coef == 1)
            {
                Console.WriteLine("L'image n'est pas modifiée");
            }
            else
            {
                Console.WriteLine("Le coefficient choisit n'est pas supérieur a 2");
            }
        }

        /// <summary>
        /// Rétrécie l'image avec un coefficient choisi par l'utilisateur
        /// </summary>
        public void Retrecir()
        {
            Console.WriteLine("Entrez le coefficient de diminution :");
            int coef = Convert.ToInt32(Console.ReadLine());

            while ((this.hauteurImage % coef != 0) && (this.largeurImage % coef != 0) && (coef <= 0 )) //Verification que la diminution est valable
            {
                Console.WriteLine("Le coefficient de dimiution n'est pas valable, veuillez entrez un autre coefficient de diminution :");
                coef = Convert.ToInt32(Console.ReadLine());
            }
            if (coef >= 2)
            {
                Pixel[,] newmat = new Pixel[this.hauteurImage / coef, this.largeurImage / coef];
                int a = 0;
                for (int i = 0; i < (this.hauteurImage / coef); i++) //On remplit l'image en prenant un pixel sur (coef) dans la matrice de pixel
                {
                    int b = 0;
                    for (int j = 0; j < (this.largeurImage / coef); j++)
                    {

                        newmat[a, b] = this.matriceRGB[i * coef, j * coef];
                        b++;
                    }
                    a++;
                }
                this.largeurImage = this.largeurImage / coef; 
                this.hauteurImage = this.hauteurImage / coef;
                this.tailleFiles = 54 + hauteurImage * largeurImage * 3;
                this.matriceRGB = newmat;
            }
            else if (coef == 1)
            {
                Console.WriteLine("L'image n'est pas modifiée");
            }
            else
            {
                Console.WriteLine("Le coefficient choisit n'est pas supérieur a 2, l'image n'a pas pu être modifiée...");
            }
        }

        /// <summary>
        /// Effectue les rotations classiques (90, 180, 270, 360 degrés etc)
        /// </summary>
        /// <param name="angle_multiple_de_90"></param>
        public void Rotation(int angle_multiple_de_90)
        {
            if (angle_multiple_de_90 % 90 != 0)
            {
                Console.WriteLine("L'angle choisi n'est pas un multiple de 90, la rotation est impossible");
            }

            else
            {
                int nombre_de_rotation_de_90_degres_a_effectuer = angle_multiple_de_90 / 90; 
                int x = 0; //compteur afin de verifier le nombre de rotation que nous appliquons a l'image

                while (x != nombre_de_rotation_de_90_degres_a_effectuer) //Tant que le nombre de rotation défini n'est pas atteint
                {
                    Pixel[,] newmat = new Pixel[this.largeurImage, this.hauteurImage]; //Nouvelle taille de la matrice (la largeur devient la hauteur et la hauteur devient la largeur sur une rotation de 90 degrés)
                    for (int i = 0; i < this.largeurImage; i++)
                    {
                        for (int j = 0; j < this.hauteurImage; j++)
                        {
                            newmat[i, j] = this.matriceRGB[j, this.largeurImage - i - 1]; //Déplacement d'un pixel de 90 degrés de,la matrice vers la nouvelle matrice
                        }
                    }
                    x++;
                    this.hauteurImage = newmat.GetLength(0); //Mise a jour de chaque parametre a chaque rotation
                    this.largeurImage = newmat.GetLength(1);
                    this.tailleFiles = 54 + hauteurImage * largeurImage * 3;
                    this.matriceRGB = newmat;
                }
            }
        }

        //Matrice de convolution TD4

        /// <summary>
        /// Effectue l'algorithme de convolution en utilisant la matrice Kernel et les elements voisins du pixel etudié
        /// </summary>
        /// <param name="Kernel">Matrice de Kernel</param>
        /// <param name="mat_intermediaire">Pixel et ses voisins</param>
        /// <returns>Le pixel mis a jour</returns>
        public Pixel convolution(int[,] Kernel, Pixel[,] mat_intermediaire)
        {
            Pixel pixel_convolution = new Pixel(0, 0, 0);
            int newpixelbleu = 0;
            int newpixelrouge = 0;
            int newpixelvert = 0;
            int somme_elem_kernel = 0; //Initialisation d'un entier pour faire la somme des elements de la matrice de kernel

            for (int i = 0; i < Kernel.GetLength(0); i++)
            {
                for (int j = 0; j < Kernel.GetLength(1); j++)
                {
                    newpixelbleu += Kernel[i, j] * mat_intermediaire[i, j].Blue; //Somme des produits des elements de kernel avec chaque niveau de bleus des elements de la matrice intermediaire
                    //Console.WriteLine("b :"+newpixelbleu);
                    newpixelrouge += Kernel[i, j] * mat_intermediaire[i, j].Red; //Idem avec les niveaux de rouges
                    //Console.WriteLine("r :" + newpixelrouge);
                    newpixelvert += Kernel[i, j] * mat_intermediaire[i, j].Green; //Idem avec les niveaux de verts
                    //Console.WriteLine("v :" + newpixelvert);
                    //Console.WriteLine("\n");
                    somme_elem_kernel += Kernel[i, j]; //somme des elements de la matrice de kernel
                }
            }
            if (newpixelbleu > 255) //superieur => on affecte au niveau de bleu la limite superieur soit 255 
            {
                pixel_convolution.Blue = 255;
            }
            else
            {
                if (newpixelbleu < 0) //meme raisonnement pour la limite inferieur
                {
                    pixel_convolution.Blue = 0;
                }

                else //sinon intervalle [0;255]
                {
                    pixel_convolution.Blue = (byte)newpixelbleu;
                }
            }

            if (newpixelrouge > 255) //superieur => on affecte au niveau de bleu la limite superieur soit 255 
            {
                pixel_convolution.Red = 255;
            }
            else
            {
                if (newpixelrouge < 0) //meme raisonnement pour la limite inferieur
                {
                    pixel_convolution.Red = 0;
                }

                else //sinon intervalle [0;255]
                {
                    pixel_convolution.Red = (byte)newpixelrouge;
                }
            }

            if (newpixelvert > 255) //superieur => on affecte au niveau de bleu la limite superieur soit 255 
            {
                pixel_convolution.Green = 255;
            }
            else
            {
                if (newpixelvert < 0) //meme raisonnement pour la limite inferieur
                {
                    pixel_convolution.Green = 0;
                }

                else //sinon intervalle [0;255]
                {
                    pixel_convolution.Green = (byte)newpixelvert;
                }
            }
            if((somme_elem_kernel != 0) && (somme_elem_kernel != 1))//Division de chaque nouveaux niveau de couleur par la somme des elements de kernel
            {
                int b = newpixelbleu / somme_elem_kernel;
                int r = newpixelrouge / somme_elem_kernel;
                int v = newpixelvert / somme_elem_kernel;
                pixel_convolution.Blue = (byte)(b);
                pixel_convolution.Red = (byte)(r);
                pixel_convolution.Green = (byte)(v);
            }
            return pixel_convolution;
        }

        /// <summary>
        /// applique un filtre flou a l'image
        /// </summary>
        public void floutter()
        {
            int[,] Kernel = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }; //Matrice de Kernel afin de floutter une image

            Pixel[,] matrice_floue = new Pixel[this.hauteurImage,this.largeurImage]; //Copie de la matriceRGB

            for (int ligne = 0; ligne < this.hauteurImage; ligne++) //sauvegarde de la matrice rgb 
            {
                for (int colonne = 0; colonne < this.largeurImage; colonne++)
                {
                    matrice_floue[ligne, colonne] = matriceRGB[ligne, colonne];
                }
            }

            for (int ligne = 1; ligne < hauteurImage - 1; ligne++) //on applique ensuite la convolution en negligeant les bords 
            {
                for (int colonne = 1; colonne < largeurImage - 1; colonne++)
                {
                    Pixel[,] mat_intermediaire = new Pixel[3, 3];

                    for(int i = ligne-1; i<ligne+2; i++) //Construction d'une matrice intermediaire contenant le pixel avec ses voisins
                    {
                        for(int j = colonne-1; j< colonne+2;j++)
                        {
                            mat_intermediaire[i - ligne + 1, j - colonne + 1] = matriceRGB[i, j];
                        }
                    }

                    matrice_floue[ligne, colonne] = convolution(Kernel, mat_intermediaire);

                }
            }

            this.matriceRGB = matrice_floue;
        }

        /// <summary>
        /// Detecte les contours et lignes importantes de l'image et renvoie une image avec les contours accentués
        /// </summary>
        public void detection_contour()
        {
            int[,] Kernel = { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } }; //Matrice de Kernel afin de detecter les bords

            Pixel[,] matrice_detection_cont = new Pixel[this.hauteurImage, this.largeurImage]; //Copie de la matriceRGB

            for (int ligne = 0; ligne < this.hauteurImage; ligne++) //sauvegarde de la matrice rgb
            {
                for (int colonne = 0; colonne < this.largeurImage; colonne++)
                {
                    matrice_detection_cont[ligne, colonne] = matriceRGB[ligne, colonne];
                }
            }

            for (int ligne = 1; ligne < hauteurImage - 1; ligne++) //on applique ensuite la convolution en negligeant les bords 
            {
                for (int colonne = 1; colonne < largeurImage - 1; colonne++)
                {
                    Pixel[,] mat_intermediaire = new Pixel[3, 3];

                    for (int i = ligne - 1; i < ligne + 2; i++) //Construction d'une matrice intermediaire contenant le pixel avec ses voisins
                    {
                        for (int j = colonne - 1; j < colonne + 2; j++)
                        {
                            mat_intermediaire[i - ligne + 1, j - colonne + 1] = matriceRGB[i, j];
                        }
                    }

                    matrice_detection_cont[ligne, colonne] = convolution(Kernel, mat_intermediaire);
                }
            }
            this.matriceRGB = matrice_detection_cont;
        }

        /// <summary>
        /// Renforce les bords
        /// </summary>
        public void renforcement_des_bords()
        {
            int[,] Kernel = { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } }; //Matrice de Kernel afin de renforcer les bords
            Pixel[,] matrice_bords = new Pixel[this.hauteurImage, this.largeurImage];

            for (int ligne = 0; ligne < hauteurImage; ligne++) //on remplit la matrice avec les elements de matrice rgb
            {
                for (int colonne = 0; colonne < largeurImage; colonne++)
                {
                    matrice_bords[ligne, colonne] = this.matriceRGB[ligne, colonne];
                }
            }

            for (int ligne = 1; ligne < hauteurImage - 1; ligne++) //on applique ensuite la convolution en negligeant les bords 
            {
                for (int colonne = 1; colonne < largeurImage - 1; colonne++)
                {

                    Pixel[,] mat_intermediaire = new Pixel[3, 3];

                    for (int i = ligne - 1; i < ligne + 2; i++) //Construction d'une matrice intermediaire contenant le pixel avec ses voisins
                    {
                        for (int j = colonne - 1; j < colonne + 2; j++)
                        {
                            mat_intermediaire[i - ligne + 1, j - colonne + 1] = matriceRGB[i, j];
                        }
                    }

                    matrice_bords[ligne, colonne] = convolution(Kernel, mat_intermediaire);

                }
            }

            this.matriceRGB = matrice_bords;
        }

        /// <summary>
        /// Filtre repoussage
        /// </summary>
        public void repoussage()
        {
            int[,] Kernel = { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } }; //Matrice de Kernel afin d'effectuer un repoussage 
            Pixel[,] matrice_repoussage = new Pixel[this.hauteurImage, this.largeurImage];

            for (int ligne = 0; ligne < hauteurImage; ligne++) //on remplit la matrice avec les elements de matrice rgb
            {
                for (int colonne = 0; colonne < largeurImage; colonne++)
                {
                    matrice_repoussage[ligne, colonne] = this.matriceRGB[ligne, colonne];
                }
            }

            for (int ligne = 1; ligne < hauteurImage - 1; ligne++) //on applique ensuite la convolution en negligeant les bords 
            {
                for (int colonne = 1; colonne < largeurImage - 1; colonne++)
                {

                    Pixel[,] mat_intermediaire = new Pixel[3, 3];

                    for (int i = ligne - 1; i < ligne + 2; i++) //Construction d'une matrice intermediaire contenant le pixel avec ses voisins
                    {
                        for (int j = colonne - 1; j < colonne + 2; j++)
                        {
                            mat_intermediaire[i - ligne + 1, j - colonne + 1] = matriceRGB[i, j];
                        }
                    }

                    matrice_repoussage[ligne, colonne] = convolution(Kernel, mat_intermediaire);

                }
            }

            this.matriceRGB = matrice_repoussage;
        }

        //Matrices de convolution supplémentaires 

        /// <summary>
        /// Embossage de l'image
        /// </summary>
        public void embossage()
        {
            int[,] Kernel = { { -2, -1, 0 }, { -1, 0, 1 }, { 0, 1, 2 } }; //Matrice de Kernel afin de floutter une image

            Pixel[,] matrice_embossage = new Pixel[this.hauteurImage, this.largeurImage]; //Copie de la matriceRGB

            for (int ligne = 0; ligne < this.hauteurImage; ligne++) //sauvegarde de la matrice rgb 
            {
                for (int colonne = 0; colonne < this.largeurImage; colonne++)
                {
                    matrice_embossage[ligne, colonne] = matriceRGB[ligne, colonne];
                }
            }

            for (int ligne = 1; ligne < hauteurImage - 1; ligne++) //on applique ensuite la convolution en negligeant les bords 
            {
                for (int colonne = 1; colonne < largeurImage - 1; colonne++)
                {
                    Pixel[,] mat_intermediaire = new Pixel[3, 3];

                    for (int i = ligne - 1; i < ligne + 2; i++) //Construction d'une matrice intermediaire contenant le pixel avec ses voisins
                    {
                        for (int j = colonne - 1; j < colonne + 2; j++)
                        {
                            mat_intermediaire[i - ligne + 1, j - colonne + 1] = matriceRGB[i, j];
                        }
                    }

                    matrice_embossage[ligne, colonne] = convolution(Kernel, mat_intermediaire);

                }
            }

            this.matriceRGB = matrice_embossage;
        }

        /// <summary>
        /// Réhausse le contraste de l'image
        /// </summary>
        public void rehausseur_contraste()
        {
            int[,] Kernel = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }; //Matrice de Kernel afin d'effectuer un repoussage 
            Pixel[,] matrice_rc = new Pixel[this.hauteurImage, this.largeurImage];

            for (int ligne = 0; ligne < hauteurImage; ligne++) //on remplit la matrice avec les elements de matrice rgb
            {
                for (int colonne = 0; colonne < largeurImage; colonne++)
                {
                    matrice_rc[ligne, colonne] = this.matriceRGB[ligne, colonne];
                }
            }

            for (int ligne = 1; ligne < hauteurImage - 1; ligne++) //on applique ensuite la convolution en negligeant les bords 
            {
                for (int colonne = 1; colonne < largeurImage - 1; colonne++)
                {

                    Pixel[,] mat_intermediaire = new Pixel[3, 3];

                    for (int i = ligne - 1; i < ligne + 2; i++) //Construction d'une matrice intermediaire contenant le pixel avec ses voisins
                    {
                        for (int j = colonne - 1; j < colonne + 2; j++)
                        {
                            mat_intermediaire[i - ligne + 1, j - colonne + 1] = matriceRGB[i, j];
                        }
                    }

                    matrice_rc[ligne, colonne] = convolution(Kernel, mat_intermediaire);

                }
            }

            this.matriceRGB = matrice_rc;
            
        }

        //TD5

        /// <summary>
        /// Fractale de Mandelbrot
        /// </summary>
        public void fractale()
        {
            int zoom = 500;
            int nombre_d_itération = 50;

            double x1 = -2.1; //Définition de l’ensemble de Mandelbrot qui est toujours compris entre -2.1 et 0.6 sur l’axe des abscisses et entre - 1.2 et 1.2 sur l’axe des ordonnées.
            double x2 = 0.6;
            double y1 = -1.2;
            double y2 = 1.2;

            //On recalcule donc la taille de l'image 

            int new_largeur_image = (int)((y2 - y1) * zoom);
            this.largeurImage = new_largeur_image;
            int new_hauteur_image = (int)((x2 - x1) * zoom);
            this.hauteurImage = new_hauteur_image;
            this.tailleFiles = 3 * this.hauteurImage * this.largeurImage + 54;

            Pixel[,] matrice_fractale = new Pixel[this.hauteurImage, this.largeurImage]; //Matrice de pixel correspondant a la creation de la nouvelle fractale

            Pixel blanc = new Pixel(255, 255, 255);
            Pixel noir = new Pixel(0, 0, 0);
            Pixel bleu = new Pixel(255, 0, 0);
            Pixel vert = new Pixel(0, 255, 0);
            Pixel rouge = new Pixel(0, 0, 255);

            double z_x = (x2 - x1) / (double)new_hauteur_image;
            double z_y = (y2 - y1) / (double)new_largeur_image;

            int i = 0;
            for (int x = 0; x < hauteurImage; x++) //Boucle sur l'image
            {
                double partie_reelle = (z_x * x) - Math.Abs(x1);
                for (int y = 0; y < largeurImage; y++)
                {

                    Complexe c = new Complexe(partie_reelle, (z_y * y) - Math.Abs(y1));
                    Complexe z = new Complexe(0, 0);
                    i = 0;
                    while ((z.module_complexe() <= 2) && (i < nombre_d_itération)) //Suite complexe de Mandelbrot
                    {
                        //Tant que la condition ci-dessus n'est pas respectée, nous effectuons l'operation z = z^2 + c qui correspond a la suite complexe de l'ensemble de Mandelbrot 

                        double save_z_r = z.Partie_réelle; //Sauvegarde de la partie réelle pour le calcul de la nouvelle partie imaginaire

                        //Les calculs sur les parties reelles et imaginaires sont séparées pour plus de lisibilité

                        z.Partie_réelle = Math.Pow(z.Partie_réelle,2) - Math.Pow(z.Partie_imaginaire,2) + c.Partie_réelle;

                        z.Partie_imaginaire = 2 * z.Partie_imaginaire * save_z_r + c.Partie_imaginaire;
                       

                        i++;
                    }
                    //Console.WriteLine(i);
                    if (i == nombre_d_itération)
                    {
                        matrice_fractale[x, y] = bleu;
                    }
                    else
                    {
                        if(i<=Math.Sqrt(nombre_d_itération))
                        {
                            matrice_fractale[x, y] = rouge;
                        }
  
                        else
                        {
                            matrice_fractale[x, y] = vert;
                        }
                    }

                }
            }
            this.tailleFiles = 3 * this.hauteurImage * this.largeurImage + 54;
            this.matriceRGB = matrice_fractale;
        }

        /// <summary>
        /// Histogramme d'une image
        /// </summary>
        public void histogramme()
        {
            Pixel[,] histogramme = new Pixel[255, this.largeurImage];
            Pixel blanc = new Pixel(255, 255, 255);
            Pixel rouge = new Pixel(0, 0, 255);
            Pixel bleu = new Pixel(255, 0, 0);
            Pixel vert = new Pixel(0, 255, 0);

            for (int ligne = 0; ligne < histogramme.GetLength(0); ligne++) //Création de l'histogramme sur fond blanc
            {
                for (int colonne = 0; colonne < histogramme.GetLength(1); colonne++)
                {
                    histogramme[ligne, colonne] = blanc;
                }
            }

            for (int colonne = 0; colonne < this.largeurImage; colonne++)
            {
                int blue = 0;
                int red = 0;
                int green = 0;

                for (int ligne = 0; ligne < this.hauteurImage; ligne++) //Moyenne du niveau de chaque couleur sur chaque colonne
                {
                    blue += (int)(matriceRGB[ligne, colonne].Blue);
                    red += (int)(matriceRGB[ligne, colonne].Red);
                    green += (int)(matriceRGB[ligne, colonne].Green);
                }

                histogramme[blue / this.hauteurImage, colonne] = bleu; //a la fin de chaque colonne on remplace chaque pixel correspondant par la moyenne de chaque couleur sur la colonne. Ainsi,on obtient un point rouge, vert et bleu par colonne et a la fin on obtiendra un graphique avec chaque courbe de couleur
                histogramme[red / this.hauteurImage, colonne] = rouge;
                histogramme[green / this.hauteurImage, colonne] = vert;

            }
            this.hauteurImage = 255;
            this.tailleFiles = 54 + hauteurImage * largeurImage * 3;
            this.matriceRGB = histogramme;
        }

        /// <summary>
        /// Conversion decimal/binaire
        /// </summary>
        /// <param name="entier"></param>
        /// <returns>tableau binaire</returns>
        public int[] decimal_to_binaire(int entier)
        {
            int[] nombre_en_binaire = new int[8];
            for (int i = 0; i < 8; i++)
            {
                int reste = entier % 2;
                entier = entier / 2;
                nombre_en_binaire[7 - i] = reste;
            }
            return nombre_en_binaire;
        }

        /// <summary>
        /// Conversion binaire/décimal
        /// </summary>
        /// <param name="tab">tableau binaire</param>
        /// <returns>nombre décimal</returns>
        public int binaire_to_decimal(int[] tab)
        {
            int entier = 0;
            for (int i = 0; i < 8; i++)
            {
                entier += tab[i] * (int)(Math.Pow(2, 7 - i));
            }
            return entier;
        }

        /// <summary>
        /// Applique le procédé de stéganographie (image cachée dans une autre image)
        /// </summary>
        /// <param name="tab1">tableau du niveau de couleur d'un pixel de l'image primaire</param>
        /// <param name="tab2">tableau du niveau de couleur d'un pixel de l'image secondaire (celle que l'on souhaite cacher)</param>
        /// <returns>nouveau tableau adapté a la stéganographie</returns>
        public int[] stegano(int[] tab1, int[] tab2)
        {
            int[] tab = new int[8];
            for (int i = 0; i < 8; i++) //Dans le nouveau tableau on place les 4 premiers chiffres du tableau 1 au debut et les 4 premiers chiffres du tableau 2 a la fin (les 4 premiers chiffres d'un nombre en binaire sont les plus importants)
            {
                if (i < 4)
                {
                    tab[i] = tab1[i];
                }
                else
                {
                    tab[i] = tab2[i - 4];
                }
            }
            return tab;
        }

        /// <summary>
        /// Applique le procédé de décodage d'une stéganographie (image cachée dans une autre image)
        /// </summary>
        /// <param name="tab1">tableau binaire du niveau de couleur d'un pixel de l'image contenant une image cachée</param>
        /// <returns>tableau binaire du niveau de couleur d'un pixel de l'image cachée</returns>
        public int[] stegano_decodage(int[] tab1)
        {
            int[] tab = new int[8];
            for (int i = 0; i < 8; i++) //Récupération des 4 derniers chiffres du tableau, car ils correspondent aux 4 chiffres les plus importants du tableau 2 codé précédemment
            {
                if (i < 4)
                {
                    tab[i] = tab1[i + 4];
                }
                else //Et on complete par des 0
                {
                    tab[i] = 0;
                }
            }
            return tab;
        }

        /// <summary>
        /// Cache une image dans une image
        /// </summary>
        /// <param name="image">image à cacher</param>
        public void coder_image_in_image(MyImage image)
        {
            Pixel[,] matrice_stegano = matriceRGB;
            for (int ligne = 0; ligne < image.HauteurImage; ligne++) 
            {
                for (int colonne = 0; colonne < image.LargeurImage; colonne++)
                {
                    //Pixel rouge

                    int[] red1 = decimal_to_binaire((int)matriceRGB[ligne, colonne].Red); //Pour chaque niveau de couleur de chaque pixel, on convertit en binaire le chiffre (pour l'image primaire et pour l'image secondaire que l'on souhaite dissimuler dans l'image primaire)
                    int[] red2 = decimal_to_binaire((int)image.MatriceRGB[ligne, colonne].Red);
                    int[] new_red = stegano(red1, red2); //On applique ensuite le procédé de steganographie

                    matrice_stegano[ligne, colonne].Red = (byte)(binaire_to_decimal(new_red)); //Puis on obtient et on enregistre le nouveau niveau de couleur, reconvertit en decimal

                    //Pixel Vert

                    int[] green1 = decimal_to_binaire((int)matriceRGB[ligne, colonne].Green);
                    int[] green2 = decimal_to_binaire((int)image.MatriceRGB[ligne, colonne].Green);
                    int[] new_green = stegano(green1, green2);

                    matrice_stegano[ligne, colonne].Green = (byte)(binaire_to_decimal(new_green));

                    //Pixel Bleu

                    int[] blue1 = decimal_to_binaire((int)matriceRGB[ligne, colonne].Blue);
                    int[] blue2 = decimal_to_binaire((int)image.MatriceRGB[ligne, colonne].Blue);
                    int[] new_blue = stegano(blue1, blue2);

                    matrice_stegano[ligne, colonne].Blue = (byte)(binaire_to_decimal(new_blue));
                }
            }
            this.matriceRGB = matrice_stegano;
        }

        /// <summary>
        /// Détache l'image cachée dans une stéganographie
        /// </summary>
        public void decoder_image_in_image()
        {
            Pixel[,] matrice_stegano = matriceRGB;
            for (int ligne = 0; ligne < hauteurImage; ligne++) 
            {
                for (int colonne = 0; colonne < largeurImage; colonne++)
                {
                    //Pixel rouge

                    int[] red = decimal_to_binaire((int)matriceRGB[ligne, colonne].Red); ////Pour chaque niveau de couleur de chaque pixel, on convertit en binaire le chiffre
                    int[] new_red = stegano_decodage(red); //Puis on applique le procédé de décodage de la stéganographie

                    matrice_stegano[ligne, colonne].Red = (byte)(binaire_to_decimal(new_red)); //On reconvertit ensuite le nouveau niveau de couleur afin de faire apparaitre l'image décodé

                    //Pixel Vert

                    int[] green = decimal_to_binaire((int)matriceRGB[ligne, colonne].Green);
                    int[] new_green = stegano_decodage(green);

                    matrice_stegano[ligne, colonne].Green = (byte)(binaire_to_decimal(new_green));

                    //Pixel Bleu

                    int[] blue = decimal_to_binaire((int)matriceRGB[ligne, colonne].Blue);
                    int[] new_blue = stegano_decodage(blue);

                    matrice_stegano[ligne, colonne].Blue = (byte)(binaire_to_decimal(new_blue));
                }
            }
            this.matriceRGB = matrice_stegano;
        }

        //QR Code



        //Innovation

        /// <summary>
        /// Cette fonction permait de placer deux nombres du tableau binaire du message a cacher a la fin d'un tableau binaire d'un niveau de couleur d'un pixel de l'image
        /// </summary>
        /// <param name="tab1">tableau binaire d'un niveau de couleur d'un pixel de l'image</param>
        /// <param name="tab2">tableau binaire du message a cacher</param>
        /// <returns></returns>

        //Rajouter le maximum de caractère et de ponctuation dans les deux programmes en s'aidant du code ASCII 

        public int[] coder_message(int[] tab1, int[] tab2) 
        {
            int[] newtab = new int[8];
            for (int i = 0; i < 8; i++) //On place a la fin du tableau (correspondant a la traduction binaire d'un niveau de couleur d'un pixel), deux chiffres correspondant a une suite binaire caractérisant le message a coder
            {
                if (i < 6)
                {
                    newtab[i] = tab1[i];
                }
                else
                {
                    newtab[i] = tab2[i - 6];
                }
            }
            return newtab;
        }

        /// <summary>
        /// Cette fonction permait de récupérer les deux nombres du tableau binaire du message a cacher a la fin d'un tableau binaire d'un niveau de couleur d'un pixel de l'image
        /// </summary>
        /// <param name="tab1"> tableau binaire d'un niveau de couleur d'un pixel de l'image a décoder</param>
        /// <returns></returns>
        public int[] decoder_message(int[] tab1)
        {
            int[] newtab = new int[2];
            for (int i = 0; i < 2; i++) //Récupération des deux chiffres à la fin de la traduction binaire, deux chiffres appartenant a la suite binaire caractérisant le message a coder que l'on souhaite reconstruire afin de décoder le message
            {
                newtab[i] = tab1[i + 6];
            }
            return newtab;
        }

        /// <summary>
        /// Trouve l'index d'une lettre minuscule dans un tableau
        /// </summary>
        /// <param name="lettre">lettre a etudier</param>
        /// <returns></returns>
        public int trouver_index(char lettre)
        {
            char[] table_lettre_minuscule_ASCII = { ' ', '.', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };  
            int index = 0;
            bool trouver_index = false;

            while (trouver_index == false)
            {
                trouver_index = lettre.Equals(table_lettre_minuscule_ASCII[index]);
                if (trouver_index == false)
                {
                    index++;
                }
            }

            return index;
        }

        /// <summary>
        /// Cache un message en lettre minsucule et sans ponctuation dans une image
        /// </summary>
        public void coder_message_in_image()
        {
            //ON ne prend que les lettres minuscules du code ASCII

            int[] table_nombre_associe_lettremin = new int[28]; 
            table_nombre_associe_lettremin[0] = 32; //Valeur numérique d'un espace
            table_nombre_associe_lettremin[1] = 46; //Valeur numérique d'un point
            for (int i = 2; i < 28; i++) //Valeurs numériques associées aux lettres minuscules dans le code ASCII rassemblées dans un tableau  (D'après la table de code ASCII)
            {
                table_nombre_associe_lettremin[i] = i + 97;
            }

            Console.WriteLine("Veuillez saisir un message à cacher (ATTENTION EN MINUSCULE ET SANS PONCTUATION) : ");
            string message = Console.ReadLine() + '.'; //Le point sevira de repère pour stopper le décryptage de l'image dans la fonction servant a decoder le message cacher dans l'image
            int clé_décodage = message.Length;

            int[] message_binaire = new int[8 * clé_décodage]; //Traduction du message en binaire (chaque caractère sera défini par 8 chiffres en binaire)
            for(int m = 0;m<clé_décodage;m++)
            {
                int index = trouver_index(message[m]); //On récupère l'index de la lettre dans le code ASCII que l'on va ensuite convertir en binaire et insérer dans le tableau_binaire
                int[] binaire = decimal_to_binaire(table_nombre_associe_lettremin[index]);

                for(int n = 0; n < binaire.Length;n++)
                {
                    message_binaire[8 * m + n] = binaire[n];
                }
            }

            Pixel[,] matrice_codee = matriceRGB;
            int cpt = 0;
            for (int ligne = 0; ligne < matrice_codee.GetLength(0); ligne++) //Puis on boucle sur l'image et pour chaque couleur de chaque pixel, on applique la fonction coder_message afin de placer deux chiffres du tableau message_binaire caracteisant le message codé en binaire.
            {
                for (int colonne = 0; colonne < matrice_codee.GetLength(1); colonne++)
                {
                    //Blue
                    int[] binaire1 = new int[2];
                    if(cpt < message_binaire.Length-1)
                    {
                        binaire1[0] = message_binaire[cpt];
                        binaire1[1] = message_binaire[cpt+1];

                        matrice_codee[ligne, colonne].Blue = (byte)(binaire_to_decimal(coder_message(decimal_to_binaire(matriceRGB[ligne, colonne].Blue), binaire1)));

                        cpt += 2;
                    }

                    //Green
                    int[] binaire2 = new int[2];
                    if (cpt < message_binaire.Length - 1)
                    {
                        binaire2[0] = message_binaire[cpt];
                        binaire2[1] = message_binaire[cpt + 1];

                        matrice_codee[ligne, colonne].Green = (byte)(binaire_to_decimal(coder_message(decimal_to_binaire(matriceRGB[ligne, colonne].Green), binaire2)));

                        cpt += 2;
                    }

                    //Red
                    int[] binaire3 = new int[2];
                    if (cpt < message_binaire.Length - 1)
                    {
                        binaire3[0] = message_binaire[cpt];
                        binaire3[1] = message_binaire[cpt + 1];

                        matrice_codee[ligne, colonne].Red = (byte)(binaire_to_decimal(coder_message(decimal_to_binaire(matriceRGB[ligne, colonne].Red), binaire3)));

                        cpt += 2;
                    }
                }
            }

        }

        /// <summary>
        /// Décrypte un message en lettre minsucule et sans ponctuation dans une image
        /// </summary>
        public void decoder_message_in_image()
        {
            char[] table_lettre_minuscule_ASCII = { ' ', '.', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int[] table_nombre_associe_lettremin = new int[28];
            table_nombre_associe_lettremin[0] = 32; //Valeur numérique d'un espace
            table_nombre_associe_lettremin[1] = 46; //Valeur numérique d'un point 
            for (int i = 2; i < 28; i++) //Valeurs numériques associées aux lettres minuscules dans le code ASCII rassemblées dans un tableau  (D'après la table de code ASCII)
            {
                table_nombre_associe_lettremin[i] = i + 97;
            }
            string message = "";
            int cpt = 0;
            int[] message_binaire = new int[3 * 2 * hauteurImage * largeurImage];
            for (int ligne = 0; ligne < this.hauteurImage; ligne++) //Boucle sur l'image pour aller récupérer tous les deux derniers chiffres sur chaque couleur de chaque pixel
            {
                for (int colonne = 0; colonne < this.largeurImage; colonne++)
                {
                    //Bleu
                    int[] blue = decimal_to_binaire((int)matriceRGB[ligne, colonne].Blue);
                    int[] binaire_bleu = decoder_message(blue);
                    message_binaire[cpt] = binaire_bleu[0];
                    message_binaire[cpt+1] = binaire_bleu[1];
                    cpt += 2;

                    //Vert
                    int[] green = decimal_to_binaire((int)matriceRGB[ligne, colonne].Green);
                    int[] binaire_vert = decoder_message(green);
                    message_binaire[cpt] = binaire_vert[0];
                    message_binaire[cpt + 1] = binaire_vert[1];
                    cpt += 2;
                    //Rouge
                    int[] red = decimal_to_binaire((int)matriceRGB[ligne, colonne].Red);
                    int[] binaire_rouge = decoder_message(red);
                    message_binaire[cpt] = binaire_rouge[0];
                    message_binaire[cpt + 1] = binaire_rouge[1];
                    cpt += 2;

                }
            }
            int cpt2 = 0;
            while(cpt2 +8 < message_binaire.Length) //On reconvertit ensuite 8 chiffres par 8 chiffres les chiffres du tableau binaire afin d'avoir tous les chiffres du code ASCII correspondant a chaque lettre du message
            {
                int[] char_binaire = new int[8];
                for(int i = cpt2;i<cpt2+8;i++)
                {
                    char_binaire[i - cpt2] = message_binaire[i];
                }
                cpt2 += 8;
                int char_decimal = binaire_to_decimal(char_binaire); //application de la conversion binare to decimal
                //Console.WriteLine(char_decimal);
                int index = 0;
                for(int j = 0;j< table_nombre_associe_lettremin.Length;j++) //Recherche de l'index afin de retrouver la lettre dans le tableau des lettres minuscules
                {
                    if(char_decimal== table_nombre_associe_lettremin[j])
                    {
                        index = j;
                    }
                }
                message += table_lettre_minuscule_ASCII[index];
                //Console.WriteLine(table_lettre_minuscule_ASCII[index]);
                if (table_lettre_minuscule_ASCII[index].Equals('.')==true) //Un point est inséré dans le codage du message, cela sert donc de repère pour mettre fin à l'algorithme
                {
                    cpt2 = message_binaire.Length - 1; 
                }
            }
            Console.WriteLine("Le message caché dans l'image est : " +message); //On affcihe ensuite le message
        }

        /// <summary>
        /// Rogne une image 
        /// </summary>
        public void rogner()
        {
            Console.WriteLine("Choisissez la longueur du haut à rogner : "); //On demande à l'utilisateur les dimensions qu'il souhaite rogner
            int longueur_du_haut = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisissez la longueur du bas à rogner : ");
            int longueur_du_bas = Convert.ToInt32(Console.ReadLine());

            while(this.hauteurImage - longueur_du_bas -longueur_du_haut <= 0)
            {
                Console.WriteLine("Choisissez la longueur du haut à rogner : ");
                longueur_du_haut = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choisissez la longueur du bas à rogner : ");
                longueur_du_bas = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Choisissez la largeur de gauche à rogner : ");
            int largeur_de_gauche = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choisissez la largeur de droite à rogner : ");
            int largeur_de_droite = Convert.ToInt32(Console.ReadLine());

            while(this.largeurImage - largeur_de_gauche - largeur_de_droite <= 0)
            {
                Console.WriteLine("Choisissez la largeur de gauche à rogner : ");
                largeur_de_gauche = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choisissez la largeur de droite à rogner : ");
                largeur_de_droite = Convert.ToInt32(Console.ReadLine());
            }

            int hauteur = this.hauteurImage - longueur_du_haut - longueur_du_bas;
            int largeur = this.largeurImage - largeur_de_droite - largeur_de_gauche;
            Pixel[,] matrice_rognee = new Pixel[hauteur, largeur];
            for(int i = 0; i < hauteur; i++)
            {
                for(int j = 0; j < largeur; j++)
                {
                    matrice_rognee[i, j] = matriceRGB[i + longueur_du_haut, j + largeur_de_gauche];
                }
            }
            this.largeurImage = largeur;
            this.hauteurImage = hauteur;
            this.tailleFiles = 54 + hauteurImage * largeurImage * 3;
            this.matriceRGB = matrice_rognee;
        }

        /// <summary>
        /// Fonction XOR pour le cryptage
        /// </summary>
        /// <param name="tab1">tableau binaire 1</param>
        /// <param name="tab2">tableau binaire 2</param>
        /// <returns>nouveau tableau binaire</returns>
        public int[] cryptage(int[]tab1,int[]tab2)
        {
            int[] new_tab = new int[8];
            for(int i = 0; i<8; i++)
            {
                
                if(tab1[i]==1) //On applique les règles logiques d'addition en binaire : 0+1 ou 1+0 donne 1, 1+1 donne 0 et enfin 0+0 donne 0
                {
                    if(tab2[i]==1)
                    {
                        new_tab[i] = 0;
                    }
                    else
                    {
                        new_tab[i] = 1;
                    }
                }

                else
                {
                    if (tab2[i] == 1)
                    {
                        new_tab[i] = 1;
                    }
                    else
                    {
                        new_tab[i] = 0;
                    }
                }
            }
            return new_tab;
        }

        /// <summary>
        /// Brouille une image
        /// </summary>
        public void cryptage_image()
        {
            Pixel[,] matrice_cryptee = new Pixel[this.hauteurImage,this.largeurImage];
            Pixel[,] matriceRGB_copie = new Pixel[this.hauteurImage,this.largeurImage];
            for (int ligne = 0; ligne < this.hauteurImage; ligne++) //sauvegarde de la matrice rgb
            {
                for (int colonne = 0; colonne < this.largeurImage; colonne++)
                {
                    matriceRGB_copie[ligne, colonne] = matriceRGB[ligne, colonne];
                    matrice_cryptee[ligne,colonne] = matriceRGB[ligne, colonne];
                }
            }

            Random aleatoire = new Random();

            Pixel[,] image_clef = new Pixel[this.hauteurImage, this.largeurImage];

            Pixel Noir = new Pixel(0, 0, 0);
            Pixel Blanc = new Pixel(255, 255, 255);

            for (int ligne = 0; ligne < image_clef.GetLength(0); ligne++) //On génère l'image clef composé aleatoirement de pixel blanc ou noir (Méthode du masque jetable)
            {
                for (int colonne = 0; colonne < image_clef.GetLength(1); colonne++)
                {
                    int entier = aleatoire.Next(0,2); //Génère un entier aléatoire positif entre 0 et 1

                    if(entier==1)
                    {
                        image_clef[ligne, colonne] = Noir;
                    }
                    else
                    {
                        image_clef[ligne, colonne] = Blanc;
                    }

                }
            }
            this.matriceRGB = image_clef;
            From_Image_To_File("Images\\image_clef.bmp"); //Sauvegarde de l'image clef pour ensuite procéder au decryptage

            for (int ligne = 0; ligne < matrice_cryptee.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < matrice_cryptee.GetLength(1); colonne++)
                {
                    //Pixel rouge

                    int[] red1 = decimal_to_binaire((int)matriceRGB_copie[ligne, colonne].Red); //Pour chaque niveau de couleur de chaque pixel, on convertit en binaire le chiffre (pour l'image primaire et pour l'image_clef)
                    int[] red2 = decimal_to_binaire((int)image_clef[ligne,colonne].Red);
                    int[] new_red = cryptage(red1, red2); //On applique ensuite le procédé de cryptage

                    matrice_cryptee[ligne, colonne].Red = (byte)(binaire_to_decimal(new_red)); //Puis on obtient et on enregistre le nouveau niveau de couleur, reconvertit en decimal

                    //Pixel Vert

                    int[] green1 = decimal_to_binaire((int)matriceRGB_copie[ligne, colonne].Green);
                    int[] green2 = decimal_to_binaire((int)image_clef[ligne, colonne].Green);
                    int[] new_green = cryptage(green1, green2);

                    matrice_cryptee[ligne, colonne].Green = (byte)(binaire_to_decimal(new_green));

                    //Pixel Bleu

                    int[] blue1 = decimal_to_binaire((int)matriceRGB_copie[ligne, colonne].Blue);
                    int[] blue2 = decimal_to_binaire((int)image_clef[ligne, colonne].Blue);
                    int[] new_blue = cryptage(blue1, blue2);

                    matrice_cryptee[ligne, colonne].Blue = (byte)(binaire_to_decimal(new_blue));
                }
            }
            this.matriceRGB = matrice_cryptee;
        }

        /// <summary>
        /// Décrypte une image brouillée
        /// </summary>
        public void decryptage_image()
        {
            Pixel[,] matrice_decryptee = matriceRGB;
            MyImage image_clef = new MyImage("Images\\image_clef.bmp");

            if(image_clef.tailleFiles!=this.tailleFiles)
            {
                Console.WriteLine("L'image clef n'est pas valide, car elle ne correspond pas a l'image qeue vous souhaitez décrypter");
            }

            else
            {
                for (int ligne = 0; ligne < this.hauteurImage; ligne++)
                {
                    for (int colonne = 0; colonne < this.largeurImage; colonne++)
                    {
                        //Pixel rouge

                        int[] red2 = decimal_to_binaire((int)matriceRGB[ligne, colonne].Red); //Pour chaque niveau de couleur de chaque pixel, on convertit en binaire le chiffre (pour l'image primaire et pour l'image_clef)
                        int[] red1 = decimal_to_binaire((int)image_clef.MatriceRGB[ligne, colonne].Red);
                        int[] new_red = cryptage(red1, red2); //On applique ensuite le procédé de cryptage

                        matrice_decryptee[ligne, colonne].Red = (byte)(binaire_to_decimal(new_red)); //Puis on obtient et on enregistre le nouveau niveau de couleur, reconvertit en decimal

                        //Pixel Vert

                        int[] green2 = decimal_to_binaire((int)matriceRGB[ligne, colonne].Green);
                        int[] green1 = decimal_to_binaire((int)image_clef.MatriceRGB[ligne, colonne].Green);
                        int[] new_green = cryptage(green1, green2);

                        matrice_decryptee[ligne, colonne].Green = (byte)(binaire_to_decimal(new_green));

                        //Pixel Bleu

                        int[] blue2 = decimal_to_binaire((int)matriceRGB[ligne, colonne].Blue);
                        int[] blue1 = decimal_to_binaire((int)image_clef.MatriceRGB[ligne, colonne].Blue);
                        int[] new_blue = cryptage(blue1, blue2);

                        matrice_decryptee[ligne, colonne].Blue = (byte)(binaire_to_decimal(new_blue));
                    }
                }
                this.matriceRGB = matrice_decryptee;
            }
            
        }
    }
}
