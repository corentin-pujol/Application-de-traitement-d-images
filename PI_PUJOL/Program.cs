using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace TD2_PUJOL
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Titre de l'application
            Console.WriteLine("Application console de traitement d'images\r");
            Console.WriteLine("------------------------------------------\n");

            //Menu et option de l'application console
            bool fermer_application = false;
            while (fermer_application == false)
            {
                // Demande à l'utilisateur de choisir une image
                Console.Clear();
                Console.WriteLine("Choisissez une image dans la liste suivante :\n");

                Console.WriteLine("1 - coco");
                Console.WriteLine("2 - Test003");
                Console.WriteLine("3 - tiger");
                Console.WriteLine("4 - ou une autre image (dans la limite des images enregistrées dans le dossier image au sein du debug)");
                Console.WriteLine("\n");
                Console.Write("Votre choix ? \n");
                string coco = "";
                string test003 = "";
                string tiger = "";
                string autre = "";
                bool operation_terminee = false;
                switch (Console.ReadLine())
                {
                    case "1":
                        while (operation_terminee == false)
                        {
                            coco = "Images\\coco.bmp";
                            MyImage Coco = new MyImage(coco);
                            Console.Clear();
                            Console.WriteLine("Quelle transformation voulez vous effectuer ?\n");
                            Console.WriteLine("1 - Appliquer un filtre");
                            Console.WriteLine("2 - Modifier la taille ou l'orientation");
                            Console.WriteLine("3 - Effectuer une cryptographie");
                            Console.WriteLine("4 - Obtenir l'histogramme");
                            Console.WriteLine("5 - Obtenir une fractale");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Quel filtre voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Nuance de gris");
                                    Console.WriteLine("2 - Noir & Blanc");
                                    Console.WriteLine("3 - Floutter");
                                    Console.WriteLine("4 - Détection de contours");
                                    Console.WriteLine("5 - Renforcement des bords");
                                    Console.WriteLine("6 - Repoussage");
                                    Console.WriteLine("7 - Negatif de l'image");
                                    Console.WriteLine("8 - Embossage de l'image");
                                    Console.WriteLine("9 - Réhausser le contraste de l'image");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Coco.Nuance_de_gris();
                                            Coco.From_Image_To_File("Images\\coco_Nuance_de_gris.bmp");
                                            Process.Start("Images\\coco_Nuance_de_gris.bmp");
                                            break;
                                        case "2":
                                            Coco.Noir_Blanc();
                                            Coco.From_Image_To_File("Images\\coco_Noir_Blanc.bmp");
                                            Process.Start("Images\\coco_Noir_Blanc.bmp");
                                            break;
                                        case "3":
                                            Coco.floutter();
                                            Coco.From_Image_To_File("Images\\coco_flou.bmp");
                                            Process.Start("Images\\coco_flou.bmp");
                                            break;
                                        case "4":
                                            Coco.detection_contour();
                                            Coco.From_Image_To_File("Images\\coco_detection_contour.bmp");
                                            Process.Start("Images\\coco_detection_contour.bmp");
                                            break;
                                        case "5":
                                            Coco.renforcement_des_bords();
                                            Coco.From_Image_To_File("Images\\coco_renforcement_des_bords.bmp");
                                            Process.Start("Images\\coco_renforcement_des_bords.bmp");
                                            break;
                                        case "6":
                                            Coco.repoussage();
                                            Coco.From_Image_To_File("Images\\coco_repoussage.bmp");
                                            Process.Start("Images\\coco_repoussage.bmp");
                                            break;
                                        case "7":
                                            Coco.Negatif();
                                            Coco.From_Image_To_File("Images\\coco_negatif.bmp");
                                            Process.Start("Images\\coco_negatif.bmp");
                                            break;
                                        case "8":
                                            Coco.embossage();
                                            Coco.From_Image_To_File("Images\\coco_embossage.bmp");
                                            Process.Start("Images\\coco_embossage.bmp");
                                            break;
                                        case "9":
                                            Coco.rehausseur_contraste();
                                            Coco.From_Image_To_File("Images\\coco_rc.bmp");
                                            Process.Start("Images\\coco_rc.bmp");
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Quel modification voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Agrandissement");
                                    Console.WriteLine("2 - Retrecissement");
                                    Console.WriteLine("3 - Miroir");
                                    Console.WriteLine("4 - Rotation");
                                    Console.WriteLine("5 - Rogner");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Coco.Agrandir();
                                            Coco.From_Image_To_File("Images\\coco_agrandi.bmp");
                                            Process.Start("Images\\coco_agrandi.bmp");
                                            break;
                                        case "2":
                                            Coco.Retrecir();
                                            Coco.From_Image_To_File("Images\\coco_retreci.bmp");
                                            Process.Start("Images\\coco_retreci.bmp");
                                            break;
                                        case "3":
                                            Coco.Miroir();
                                            Coco.From_Image_To_File("Images\\coco_miroir.bmp");
                                            Process.Start("Images\\coco_miroir.bmp");
                                            break;
                                        case "4":
                                            Console.Clear();
                                            Console.WriteLine("Quel angle de rotation choisissez vous ?\n");
                                            Console.WriteLine("1 - tourner de 90°");
                                            Console.WriteLine("2 - tourner de 180°");
                                            Console.WriteLine("3 - tourner de 270°");
                                            Console.WriteLine("4 - tourner de 360°");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    Coco.Rotation(90);
                                                    Coco.From_Image_To_File("Images\\coco_rotation_90.bmp");
                                                    Process.Start("Images\\coco_rotation_90.bmp");
                                                    break;
                                                case "2":
                                                    Coco.Rotation(180);
                                                    Coco.From_Image_To_File("Images\\coco_rotation_180.bmp");
                                                    Process.Start("Images\\coco_rotation_180.bmp");
                                                    break;
                                                case "3":
                                                    Coco.Rotation(270);
                                                    Coco.From_Image_To_File("Images\\coco_rotation_270.bmp");
                                                    Process.Start("Images\\coco_rotation_270.bmp");
                                                    break;
                                                case "4":
                                                    Coco.Rotation(360);
                                                    Coco.From_Image_To_File("Images\\coco_rotation_360.bmp");
                                                    Process.Start("Images\\coco_rotation_360.bmp");
                                                    break;
                                            }
                                            break;
                                        case "5":
                                            Coco.rogner();
                                            Coco.From_Image_To_File("Images\\coco_rogné.bmp");
                                            Process.Start("Images\\coco_rogné.bmp");
                                            break;
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Quel codage voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Cacher une image dans une image");
                                    Console.WriteLine("2 - Cacher un message dans une image");
                                    Console.WriteLine("3 - Crypter une image (application d'un brouillage)");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Console.WriteLine("Entrez le nom de l'image que vous souhaitez cacher (avec le .bmp) : \n");
                                            string image_a_cacher = "Images\\" + Console.ReadLine();
                                            MyImage i = new MyImage(image_a_cacher);
                                            while (i.TailleFiles != Coco.TailleFiles)
                                            {
                                                Console.WriteLine("Veuillez choisir une image qui fait la meme taille que l'image primaire :\n");
                                                image_a_cacher = "Images\\" + Console.ReadLine();
                                                i = new MyImage(image_a_cacher);
                                            }
                                            Coco.coder_image_in_image(i);
                                            Coco.From_Image_To_File("Images\\coco_image_cachée.bmp");
                                            Process.Start("Images\\coco_image_cachée.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre l'image cachée ? \n");
                                            Console.WriteLine("1 - Faire apparaitre l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_image = new MyImage("Images\\coco_image_cachée.bmp");
                                                    decodage_image.decoder_image_in_image();
                                                    decodage_image.From_Image_To_File("Images\\coco_image_décodée.bmp");
                                                    Process.Start("Images\\coco_image_décodée.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "2":
                                            Coco.coder_message_in_image();
                                            Coco.From_Image_To_File("Images\\coco_message_caché.bmp");
                                            Process.Start("Images\\coco_message_caché.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre le message caché ? \n");
                                            Console.WriteLine("1 - Faire apparaitre le message");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_message = new MyImage("Images\\coco_message_caché.bmp");
                                                    decodage_message.decoder_message_in_image();
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "3":
                                            Coco.cryptage_image();
                                            Coco.From_Image_To_File("Images\\coco_crypté.bmp");
                                            Process.Start("Images\\coco_crypté.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous décrypter l'image ? \n");
                                            Console.WriteLine("1 - Décrypter l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decryptage_image = new MyImage("Images\\coco_crypté.bmp");
                                                    decryptage_image.decryptage_image();
                                                    decryptage_image.From_Image_To_File("Images\\coco_décrypté.bmp");
                                                    Process.Start("Images\\coco_décrypté.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case "4":
                                    Coco.histogramme();
                                    Coco.From_Image_To_File("Images\\coco_histogramme.bmp");
                                    Process.Start("Images\\coco_histogramme.bmp");
                                    break;
                                case "5":
                                    Coco.fractale();
                                    Coco.From_Image_To_File("Images\\Fractale.bmp");
                                    Process.Start("Images\\Fractale.bmp");
                                    break;
                            }
                            Console.WriteLine("Voulez vous effectuer une autre opération ?\n");
                            Console.WriteLine("1 - Oui, voir le menu");
                            Console.WriteLine("2 - Non, fin des opérations");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    operation_terminee = false;
                                    break;
                                case "2":
                                    operation_terminee = true;
                                    break;
                            }
                        }
                        break;
                    case "2":
                        while (operation_terminee == false)
                        {
                            test003 = "Images\\Test003.bmp";
                            MyImage Test003 = new MyImage(test003);
                            Console.Clear();
                            Console.WriteLine("Quelle transformation voulez vous effectuer ?\n");
                            Console.WriteLine("1 - Appliquer un filtre");
                            Console.WriteLine("2 - Modifier la taille ou l'orientation");
                            Console.WriteLine("3 - Effectuer une cryptographie");
                            Console.WriteLine("4 - Obtenir l'histogramme");
                            Console.WriteLine("5 - Obtenir une fractale");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("Quel filtre voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Nuance de gris");
                                    Console.WriteLine("2 - Noir & Blanc");
                                    Console.WriteLine("3 - Floutter");
                                    Console.WriteLine("4 - Détection de contours");
                                    Console.WriteLine("5 - Renforcement des bords");
                                    Console.WriteLine("6 - Repoussage");
                                    Console.WriteLine("7 - Negatif de l'image");
                                    Console.WriteLine("8 - Embossage de l'image");
                                    Console.WriteLine("9 - Réhausser le contraste de l'image");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Test003.Nuance_de_gris();
                                            Test003.From_Image_To_File("Images\\Test003_Nuance_de_gris.bmp");
                                            Process.Start("Images\\Test003_Nuance_de_gris.bmp");
                                            break;
                                        case "2":
                                            Test003.Noir_Blanc();
                                            Test003.From_Image_To_File("Images\\Test003_Noir_Blanc.bmp");
                                            Process.Start("Images\\Test003_Noir_Blanc.bmp");
                                            break;
                                        case "3":
                                            Test003.floutter();
                                            Test003.From_Image_To_File("Images\\Test003_flou.bmp");
                                            Process.Start("Images\\Test003_flou.bmp");
                                            break;
                                        case "4":
                                            Test003.detection_contour();
                                            Test003.From_Image_To_File("Images\\Test003_detection_contour.bmp");
                                            Process.Start("Images\\Test003_detection_contour.bmp");
                                            break;
                                        case "5":
                                            Test003.renforcement_des_bords();
                                            Test003.From_Image_To_File("Images\\Test003_renforcement_des_bords.bmp");
                                            Process.Start("Images\\Test003_renforcement_des_bords.bmp");
                                            break;
                                        case "6":
                                            Test003.repoussage();
                                            Test003.From_Image_To_File("Images\\Test003_repoussage.bmp");
                                            Process.Start("Images\\Test003_repoussage.bmp");
                                            break;
                                        case "7":
                                            Test003.Negatif();
                                            Test003.From_Image_To_File("Images\\Test003_negatif.bmp");
                                            Process.Start("Images\\Test003_negatif.bmp");
                                            break;
                                        case "8":
                                            Test003.embossage();
                                            Test003.From_Image_To_File("Images\\Test003_embossage.bmp");
                                            Process.Start("Images\\Test003_embossage.bmp");
                                            break;
                                        case "9":
                                            Test003.rehausseur_contraste();
                                            Test003.From_Image_To_File("Images\\Test003_rc.bmp");
                                            Process.Start("Images\\Test003_rc.bmp");
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Quel modification voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Agrandissement");
                                    Console.WriteLine("2 - Retrecissement");
                                    Console.WriteLine("3 - Miroir");
                                    Console.WriteLine("4 - Rotation");
                                    Console.WriteLine("5 - Rogner");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Test003.Agrandir();
                                            Test003.From_Image_To_File("Images\\Test003_agrandi.bmp");
                                            Process.Start("Images\\Test003_agrandi.bmp");
                                            break;
                                        case "2":
                                            Test003.Retrecir();
                                            Test003.From_Image_To_File("Images\\Test003_retreci.bmp");
                                            Process.Start("Images\\Test003_retreci.bmp");
                                            break;
                                        case "3":
                                            Test003.Miroir();
                                            Test003.From_Image_To_File("Images\\Test003_miroir.bmp");
                                            Process.Start("Images\\Test003_miroir.bmp");
                                            break;
                                        case "4":
                                            Console.Clear();
                                            Console.WriteLine("Quel angle de rotation choisissez vous ?\n");
                                            Console.WriteLine("1 - tourner de 90°");
                                            Console.WriteLine("2 - tourner de 180°");
                                            Console.WriteLine("3 - tourner de 270°");
                                            Console.WriteLine("4 - tourner de 360°");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    Test003.Rotation(90);
                                                    Test003.From_Image_To_File("Images\\Test003_rotation_90.bmp");
                                                    Process.Start("Images\\Test003_rotation_90.bmp");
                                                    break;
                                                case "2":
                                                    Test003.Rotation(180);
                                                    Test003.From_Image_To_File("Images\\Test003_rotation_180.bmp");
                                                    Process.Start("Images\\Test003_rotation_180.bmp");
                                                    break;
                                                case "3":
                                                    Test003.Rotation(270);
                                                    Test003.From_Image_To_File("Images\\Test003_rotation_270.bmp");
                                                    Process.Start("Images\\Test003_rotation_270.bmp");
                                                    break;
                                                case "4":
                                                    Test003.Rotation(360);
                                                    Test003.From_Image_To_File("Images\\Test003_rotation_360.bmp");
                                                    Process.Start("Images\\Test003_rotation_360.bmp");
                                                    break;
                                            }
                                            break;
                                        case "5":
                                            Test003.rogner();
                                            Test003.From_Image_To_File("Images\\Test003_rogné.bmp");
                                            Process.Start("Images\\Test003_rogné.bmp");
                                            break;
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Quel codage voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Cacher une image dans une image");
                                    Console.WriteLine("2 - Cacher un message dans une image");
                                    Console.WriteLine("3 - Crypter une image (application d'un brouillage)");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Console.WriteLine("Entrez le nom de l'image que vous souhaitez cacher (avec le .bmp) : \n");
                                            string image_a_cacher = "Images\\" + Console.ReadLine();
                                            MyImage i = new MyImage(image_a_cacher);
                                            while (i.TailleFiles != Test003.TailleFiles)
                                            {
                                                Console.WriteLine("Veuillez choisir une image qui fait la meme taille que l'image primaire :\n");
                                                image_a_cacher = "Images\\" + Console.ReadLine();
                                                i = new MyImage(image_a_cacher);
                                            }
                                            Test003.coder_image_in_image(i);
                                            Test003.From_Image_To_File("Images\\Test003_image_cachée.bmp");
                                            Process.Start("Images\\Test003_image_cachée.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre l'image cachée ? \n");
                                            Console.WriteLine("1 - Faire apparaitre l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_image = new MyImage("Images\\Test003_image_cachée.bmp");
                                                    decodage_image.decoder_image_in_image();
                                                    decodage_image.From_Image_To_File("Images\\Test003_image_décodée.bmp");
                                                    Process.Start("Images\\Test003_image_décodée.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "2":
                                            Test003.coder_message_in_image();
                                            Test003.From_Image_To_File("Images\\Test003_message_caché.bmp");
                                            Process.Start("Images\\Test003_message_caché.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre le message caché ? \n");
                                            Console.WriteLine("1 - Faire apparaitre le message");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_message = new MyImage("Images\\Test003_message_caché.bmp");
                                                    decodage_message.decoder_message_in_image();
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "3":
                                            Test003.cryptage_image();
                                            Test003.From_Image_To_File("Images\\Test003_crypté.bmp");
                                            Process.Start("Images\\Test003_crypté.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous décrypter l'image ? \n");
                                            Console.WriteLine("1 - Décrypter l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decryptage_image = new MyImage("Images\\Test003_crypté.bmp");
                                                    decryptage_image.decryptage_image();
                                                    decryptage_image.From_Image_To_File("Images\\Test003_décrypté.bmp");
                                                    Process.Start("Images\\Test003_décrypté.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case "4":
                                    Test003.histogramme();
                                    Test003.From_Image_To_File("Images\\Test003_histogramme.bmp");
                                    Process.Start("Images\\Test003_histogramme.bmp");
                                    break;
                                case "5":
                                    Test003.fractale();
                                    Test003.From_Image_To_File("Images\\Fractale.bmp");
                                    Process.Start("Images\\Fractale.bmp");
                                    break;
                            }
                            Console.WriteLine("Voulez vous effectuer une autre opération ?\n");
                            Console.WriteLine("1 - Oui, voir le menu");
                            Console.WriteLine("2 - Non, fin des opérations");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    operation_terminee = false;
                                    break;
                                case "2":
                                    operation_terminee = true;
                                    break;
                            }
                        }
                        break;
                    case "3":
                        while (operation_terminee == false)
                        {
                            tiger = "Images\\tiger.bmp";
                            MyImage Tiger = new MyImage(tiger);
                            Console.Clear();
                            Console.WriteLine("Quelle transformation voulez vous effectuer ?\n");
                            Console.WriteLine("1 - Appliquer un filtre");
                            Console.WriteLine("2 - Modifier la taille ou l'orientation");
                            Console.WriteLine("3 - Effectuer une cryptographie");
                            Console.WriteLine("4 - Obtenir l'histogramme");
                            Console.WriteLine("5 - Obtenir une fractale");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Quel filtre voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Nuance de gris");
                                    Console.WriteLine("2 - Noir & Blanc");
                                    Console.WriteLine("3 - Floutter");
                                    Console.WriteLine("4 - Détection de contours");
                                    Console.WriteLine("5 - Renforcement des bords");
                                    Console.WriteLine("6 - Repoussage");
                                    Console.WriteLine("7 - Negatif de l'image");
                                    Console.WriteLine("8 - Embossage de l'image");
                                    Console.WriteLine("9 - Réhausser le contraste de l'image");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Tiger.Nuance_de_gris();
                                            Tiger.From_Image_To_File("Images\\Tiger_Nuance_de_gris.bmp");
                                            Process.Start("Images\\Tiger_Nuance_de_gris.bmp");
                                            break;
                                        case "2":
                                            Tiger.Noir_Blanc();
                                            Tiger.From_Image_To_File("Images\\Tiger_Noir_Blanc.bmp");
                                            Process.Start("Images\\Tiger_Noir_Blanc.bmp");
                                            break;
                                        case "3":
                                            Tiger.floutter();
                                            Tiger.From_Image_To_File("Images\\Tiger_flou.bmp");
                                            Process.Start("Images\\Tiger_flou.bmp");
                                            break;
                                        case "4":
                                            Tiger.detection_contour();
                                            Tiger.From_Image_To_File("Images\\Tiger_detection_contour.bmp");
                                            Process.Start("Images\\Tiger_detection_contour.bmp");
                                            break;
                                        case "5":
                                            Tiger.renforcement_des_bords();
                                            Tiger.From_Image_To_File("Images\\Tiger_renforcement_des_bords.bmp");
                                            Process.Start("Images\\Tiger_renforcement_des_bords.bmp");
                                            break;
                                        case "6":
                                            Tiger.repoussage();
                                            Tiger.From_Image_To_File("Images\\Tiger_repoussage.bmp");
                                            Process.Start("Images\\Tiger_repoussage.bmp");
                                            break;
                                        case "7":
                                            Tiger.Negatif();
                                            Tiger.From_Image_To_File("Images\\Tiger_negatif.bmp");
                                            Process.Start("Images\\Tiger_negatif.bmp");
                                            break;
                                        case "8":
                                            Tiger.embossage();
                                            Tiger.From_Image_To_File("Images\\Tiger_embossage.bmp");
                                            Process.Start("Images\\Tiger_embossage.bmp");
                                            break;
                                        case "9":
                                            Tiger.rehausseur_contraste();
                                            Tiger.From_Image_To_File("Images\\Tiger_rc.bmp");
                                            Process.Start("Images\\Tiger_rc.bmp");
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Quel modification voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Agrandissement");
                                    Console.WriteLine("2 - Retrecissement");
                                    Console.WriteLine("3 - Miroir");
                                    Console.WriteLine("4 - Rotation");
                                    Console.WriteLine("5 - Rogner");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Tiger.Agrandir();
                                            Tiger.From_Image_To_File("Images\\Tiger_agrandi.bmp");
                                            Process.Start("Images\\Tiger_agrandi.bmp");
                                            break;
                                        case "2":
                                            Tiger.Retrecir();
                                            Tiger.From_Image_To_File("Images\\Tiger_retreci.bmp");
                                            Process.Start("Images\\Tiger_retreci.bmp");
                                            break;
                                        case "3":
                                            Tiger.Miroir();
                                            Tiger.From_Image_To_File("Images\\Tiger_miroir.bmp");
                                            Process.Start("Images\\Tiger_miroir.bmp");
                                            break;
                                        case "4":
                                            Console.Clear();
                                            Console.WriteLine("Quel angle de rotation choisissez vous ?\n");
                                            Console.WriteLine("1 - tourner de 90°");
                                            Console.WriteLine("2 - tourner de 180°");
                                            Console.WriteLine("3 - tourner de 270°");
                                            Console.WriteLine("4 - tourner de 360°");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    Tiger.Rotation(90);
                                                    Tiger.From_Image_To_File("Images\\Tiger_rotation_90.bmp");
                                                    Process.Start("Images\\Tiger_rotation_90.bmp");
                                                    break;
                                                case "2":
                                                    Tiger.Rotation(180);
                                                    Tiger.From_Image_To_File("Images\\Tiger_rotation_180.bmp");
                                                    Process.Start("Images\\Tiger_rotation_180.bmp");
                                                    break;
                                                case "3":
                                                    Tiger.Rotation(270);
                                                    Tiger.From_Image_To_File("Images\\Tiger_rotation_270.bmp");
                                                    Process.Start("Images\\Tiger_rotation_270.bmp");
                                                    break;
                                                case "4":
                                                    Tiger.Rotation(360);
                                                    Tiger.From_Image_To_File("Images\\Tiger_rotation_360.bmp");
                                                    Process.Start("Images\\Tiger_rotation_360.bmp");
                                                    break;
                                            }
                                            break;
                                        case "5":
                                            Tiger.rogner();
                                            Tiger.From_Image_To_File("Images\\Tiger_rogné.bmp");
                                            Process.Start("Images\\Tiger_rogné.bmp");
                                            break;
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Quel codage voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Cacher une image dans une image");
                                    Console.WriteLine("2 - Cacher un message dans une image");
                                    Console.WriteLine("3 - Crypter une image (application d'un brouillage)");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Console.WriteLine("Entrez le nom de l'image que vous souhaitez cacher (avec le .bmp) : \n");
                                            string image_a_cacher = "Images\\" + Console.ReadLine();
                                            MyImage i = new MyImage(image_a_cacher);
                                            while (i.TailleFiles != Tiger.TailleFiles)
                                            {
                                                Console.WriteLine("Veuillez choisir une image qui fait la meme taille que l'image primaire :\n");
                                                image_a_cacher = "Images\\" + Console.ReadLine();
                                                i = new MyImage(image_a_cacher);
                                            }
                                            Tiger.coder_image_in_image(i);
                                            Tiger.From_Image_To_File("Images\\Tiger_image_cachée.bmp");
                                            Process.Start("Images\\Tiger_image_cachée.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre l'image cachée ? \n");
                                            Console.WriteLine("1 - Faire apparaitre l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_image = new MyImage("Images\\Tiger_image_cachée.bmp");
                                                    decodage_image.decoder_image_in_image();
                                                    decodage_image.From_Image_To_File("Images\\Tiger_image_décodée.bmp");
                                                    Process.Start("Images\\Tiger_image_décodée.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "2":
                                            Tiger.coder_message_in_image();
                                            Tiger.From_Image_To_File("Images\\Tiger_message_caché.bmp");
                                            Process.Start("Images\\Tiger_message_caché.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre le message caché ? \n");
                                            Console.WriteLine("1 - Faire apparaitre le message");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_message = new MyImage("Images\\Tiger_message_caché.bmp");
                                                    decodage_message.decoder_message_in_image();
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "3":
                                            Tiger.cryptage_image();
                                            Tiger.From_Image_To_File("Images\\Tiger_crypté.bmp");
                                            Process.Start("Images\\Tiger_crypté.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous décrypter l'image ? \n");
                                            Console.WriteLine("1 - Décrypter l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decryptage_image = new MyImage("Images\\Tiger_crypté.bmp");
                                                    decryptage_image.decryptage_image();
                                                    decryptage_image.From_Image_To_File("Images\\Tiger_décrypté.bmp");
                                                    Process.Start("Images\\Tiger_décrypté.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case "4":
                                    Tiger.histogramme();
                                    Tiger.From_Image_To_File("Images\\Tiger_histogramme.bmp");
                                    Process.Start("Images\\Tiger_histogramme.bmp");
                                    break;
                                case "5":
                                    Tiger.fractale();
                                    Tiger.From_Image_To_File("Images\\Fractale.bmp");
                                    Process.Start("Images\\Fractale.bmp");
                                    break;

                            }
                            Console.WriteLine("Voulez vous effectuer une autre opération ?\n");
                            Console.WriteLine("1 - Oui, voir le menu");
                            Console.WriteLine("2 - Non, fin des opérations");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    operation_terminee = false;
                                    break;
                                case "2":
                                    operation_terminee = true;
                                    break;
                            }
                        }
                        break;
                    case "4":
                        while (operation_terminee == false)
                        {
                            Console.WriteLine("Entrez le nom de l'image (avec .bmp) ?");
                            string nom_image = Console.ReadLine();
                            string verif = "";
                            for(int i = nom_image.Length-4; i<nom_image.Length; i++)
                            {
                                verif += nom_image[i];
                            }
                            while(verif.Equals(".bmp")==false)
                            {
                                Console.Clear();
                                Console.WriteLine("L'image n'existe pas, n'oubliez pas de rentrer le nom de l'image (avec .bmp), saisissez de nouveau le nom de l'image ?");
                                nom_image = Console.ReadLine();
                                verif = "";
                                for (int i = nom_image.Length - 4; i < nom_image.Length; i++)
                                {
                                    verif += nom_image[i];
                                }
                            }
                            autre = "Images\\" + nom_image;
                            MyImage Autre = new MyImage(autre);
                            Console.Clear();
                            Console.WriteLine("Quelle transformation voulez vous effectuer ?\n");
                            Console.WriteLine("1 - Appliquer un filtre");
                            Console.WriteLine("2 - Modifier la taille ou l'orientation");
                            Console.WriteLine("3 - Effectuer une cryptographie");
                            Console.WriteLine("4 - Obtenir l'histogramme");
                            Console.WriteLine("5 - Obtenir une fractale");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Quel filtre voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Nuance de gris");
                                    Console.WriteLine("2 - Noir & Blanc");
                                    Console.WriteLine("3 - Floutter");
                                    Console.WriteLine("4 - Détection de contours");
                                    Console.WriteLine("5 - Renforcement des bords");
                                    Console.WriteLine("6 - Repoussage");
                                    Console.WriteLine("7 - Negatif de l'image");
                                    Console.WriteLine("8 - Embossage de l'image");
                                    Console.WriteLine("9 - Réhausser le contraste de l'image");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Autre.Nuance_de_gris();
                                            Autre.From_Image_To_File("Images\\Nuance_de_gris.bmp");
                                            Process.Start("Images\\Nuance_de_gris.bmp");
                                            break;
                                        case "2":
                                            Autre.Noir_Blanc();
                                            Autre.From_Image_To_File("Images\\Noir_Blanc.bmp");
                                            Process.Start("Images\\Noir_Blanc.bmp");
                                            break;
                                        case "3":
                                            Autre.floutter();
                                            Autre.From_Image_To_File("Images\\flou.bmp");
                                            Process.Start("Images\\flou.bmp");
                                            break;
                                        case "4":
                                            Autre.detection_contour();
                                            Autre.From_Image_To_File("Images\\detection_contour.bmp");
                                            Process.Start("Images\\detection_contour.bmp");
                                            break;
                                        case "5":
                                            Autre.renforcement_des_bords();
                                            Autre.From_Image_To_File("Images\\renforcement_des_bords.bmp");
                                            Process.Start("Images\\renforcement_des_bords.bmp");
                                            break;
                                        case "6":
                                            Autre.repoussage();
                                            Autre.From_Image_To_File("Images\\repoussage.bmp");
                                            Process.Start("Images\\repoussage.bmp");
                                            break;
                                        case "7":
                                            Autre.Negatif();
                                            Autre.From_Image_To_File("Images\\Negatif.bmp");
                                            Process.Start("Images\\Negatif.bmp");
                                            break;
                                        case "8":
                                            Autre.embossage();
                                            Autre.From_Image_To_File("Images\\embossage.bmp");
                                            Process.Start("Images\\embossage.bmp");
                                            break;
                                        case "9":
                                            Autre.rehausseur_contraste();
                                            Autre.From_Image_To_File("Images\\rc.bmp");
                                            Process.Start("Images\\rc.bmp");
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Quel modification voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Agrandissement");
                                    Console.WriteLine("2 - Retrecissement");
                                    Console.WriteLine("3 - Miroir");
                                    Console.WriteLine("4 - Rotation");
                                    Console.WriteLine("5 - Rogner");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Autre.Agrandir();
                                            Autre.From_Image_To_File("Images\\agrandi.bmp");
                                            Process.Start("Images\\agrandi.bmp");
                                            break;
                                        case "2":
                                            Autre.Retrecir();
                                            Autre.From_Image_To_File("Images\\retreci.bmp");
                                            Process.Start("Images\\retreci.bmp");
                                            break;
                                        case "3":
                                            Autre.Miroir();
                                            Autre.From_Image_To_File("Images\\miroir.bmp");
                                            Process.Start("Images\\miroir.bmp");
                                            break;
                                        case "4":
                                            Console.Clear();
                                            Console.WriteLine("Quel angle de rotation choisissez vous ?\n");
                                            Console.WriteLine("1 - tourner de 90°");
                                            Console.WriteLine("2 - tourner de 180°");
                                            Console.WriteLine("3 - tourner de 270°");
                                            Console.WriteLine("4 - tourner de 360°");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    Autre.Rotation(90);
                                                    Autre.From_Image_To_File("Images\\rotation_90.bmp");
                                                    Process.Start("Images\\rotation_90.bmp");
                                                    break;
                                                case "2":
                                                    Autre.Rotation(180);
                                                    Autre.From_Image_To_File("Images\\rotation_180.bmp");
                                                    Process.Start("Images\\rotation_180.bmp");
                                                    break;
                                                case "3":
                                                    Autre.Rotation(270);
                                                    Autre.From_Image_To_File("Images\\rotation_270.bmp");
                                                    Process.Start("Images\\rotation_270.bmp");
                                                    break;
                                                case "4":
                                                    Autre.Rotation(360);
                                                    Autre.From_Image_To_File("Images\\rotation_360.bmp");
                                                    Process.Start("Images\\rotation_360.bmp");
                                                    break;
                                            }
                                            break;
                                        case "5":
                                            Autre.rogner();
                                            Autre.From_Image_To_File("Images\\rogné.bmp");
                                            Process.Start("Images\\rogné.bmp");
                                            break;
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Quel codage voulez vous appliquer ?\n");
                                    Console.WriteLine("1 - Cacher une image dans une image");
                                    Console.WriteLine("2 - Cacher un message dans une image");
                                    Console.WriteLine("3 - Crypter une image (application d'un brouillage)");
                                    Console.WriteLine("\n");
                                    Console.Write("Votre choix ? \n");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Console.WriteLine("Entrez le nom de l'image que vous souhaitez cacher (avec le .bmp) : \n");
                                            string image_a_cacher = "Images\\" + Console.ReadLine();
                                            MyImage i = new MyImage(image_a_cacher);
                                            while (i.TailleFiles != Autre.TailleFiles)
                                            {
                                                Console.WriteLine("Veuillez choisir une image qui fait la meme taille que l'image primaire :\n");
                                                image_a_cacher = "Images\\" + Console.ReadLine();
                                                i = new MyImage(image_a_cacher);
                                            }
                                            Autre.coder_image_in_image(i);
                                            Autre.From_Image_To_File("Images\\image_cachée.bmp");
                                            Process.Start("Images\\image_cachée.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre l'image cachée ? \n");
                                            Console.WriteLine("1 - Faire apparaitre l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_image = new MyImage("Images\\image_cachée.bmp");
                                                    decodage_image.decoder_image_in_image();
                                                    decodage_image.From_Image_To_File("Images\\image_décodée.bmp");
                                                    Process.Start("Images\\image_décodée.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "2":
                                            Autre.coder_message_in_image();
                                            Autre.From_Image_To_File("Images\\message_caché.bmp");
                                            Process.Start("Images\\message_caché.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous faire apparaitre le message caché ? \n");
                                            Console.WriteLine("1 - Faire apparaitre le message");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decodage_message = new MyImage("Images\\message_caché.bmp");
                                                    decodage_message.decoder_message_in_image();
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                        case "3":
                                            Autre.cryptage_image();
                                            Autre.From_Image_To_File("Images\\crypté.bmp");
                                            Process.Start("Images\\crypté.bmp");
                                            Console.Clear();
                                            Console.WriteLine("Souhaitez vous décrypter l'image ? \n");
                                            Console.WriteLine("1 - Décrypter l'image");
                                            Console.WriteLine("2 - Continuer");
                                            Console.WriteLine("\n");
                                            Console.Write("Votre choix ? \n");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    MyImage decryptage_image = new MyImage("Images\\crypté.bmp");
                                                    decryptage_image.decryptage_image();
                                                    decryptage_image.From_Image_To_File("Images\\décrypté.bmp");
                                                    Process.Start("Images\\décrypté.bmp");
                                                    break;
                                                case "2":
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case "4":
                                    Autre.histogramme();
                                    Autre.From_Image_To_File("Images\\histogramme.bmp");
                                    Process.Start("Images\\histogramme.bmp");
                                    break;
                                case "5":
                                    Autre.fractale();
                                    Autre.From_Image_To_File("Images\\Fractale.bmp");
                                    Process.Start("Images\\Fractale.bmp");
                                    break;

                            }
                            Console.WriteLine("Voulez vous effectuer une autre opération ?\n");
                            Console.WriteLine("1 - Oui, voir le menu");
                            Console.WriteLine("2 - Non, fin des opérations");
                            Console.WriteLine("\n");
                            Console.Write("Votre choix ? \n");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    operation_terminee = false;
                                    break;
                                case "2":
                                    operation_terminee = true;
                                    break;
                            }
                        }
                        break;
                }
                Console.WriteLine("\n");
                Console.WriteLine("Voulez vous effectuer une manipulation sur une autre image ?\n");
                Console.WriteLine("1 - Oui, voir les images disponibles.");
                Console.WriteLine("2 - Non, fermer l'application.");
                Console.WriteLine("\n");
                Console.Write("Votre choix ? \n");

                switch (Console.ReadLine())
                {
                    case "1":
                        fermer_application = false;
                        break;
                    case "2":
                        fermer_application = true;
                        break;
                }
            }
            Console.WriteLine("Presser n'importe quelle touche pour fermer l'application...");
            Console.ReadKey();
        }
    }

    
}
