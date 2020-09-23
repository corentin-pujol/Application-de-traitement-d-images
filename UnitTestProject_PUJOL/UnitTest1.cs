using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TD2_PUJOL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Pixel()
        {
            Pixel blanc = new Pixel(255, 255, 255); 
            Assert.AreEqual(255, blanc.Blue);
            Assert.AreEqual(255, blanc.Green);
            Assert.AreEqual(255, blanc.Red);
        }
        [TestMethod]
        public void Test_Complexe()
        {
            Complexe z = new Complexe(1, 1);
            Assert.AreEqual(1, z.Partie_réelle);
            Assert.AreEqual(1, z.Partie_imaginaire);
            Assert.AreEqual(Math.Sqrt(2), z.module_complexe());
        }
        [TestMethod]
        public void Test_MyImage_Convertir_Endian_To_Int()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            byte[] tab = { 230, 4, 0, 0 };
            Assert.AreEqual(1254,UnitTest1.Convertir_Endian_To_Int(tab));
        }
        [TestMethod]
        public void Test_MyImage_Convertir_Int_To_Endian()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            byte[] tab1 = { 230, 4, 0, 0 };
            byte[] tab2 = UnitTest1.Convertir_Int_To_Endian(1254, 4);
            for(int i = 0;i<tab1.Length;i++)
            {
                Assert.AreEqual(tab1[i], tab2[i]);
            }
        }
        [TestMethod]
        public void Test_MyImage_decimal_to_binaire()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int[] tab1 = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] tab2 = UnitTest1.decimal_to_binaire(255);
            for (int i = 0; i < tab1.Length; i++)
            {
                Assert.AreEqual(tab1[i], tab2[i]);
            }

        }
        [TestMethod]
        public void Test_MyImage_binaire_to_decimal()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int a = 255;
            int[] tab = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int b = UnitTest1.binaire_to_decimal(tab);
            Assert.AreEqual(a, b);
        }
        [TestMethod]
        public void Test_MyImage_stegano()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int[] tab1 = { 1, 1, 1, 1, 0, 0, 0, 0 };
            int[] tab2 = { 1, 1, 1, 1, 0, 0, 0, 0 };
            int[] tab3 = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] tab = UnitTest1.stegano(tab1, tab2);
            for (int i = 0; i < tab.Length; i++)
            {
                Assert.AreEqual(tab3[i], tab[i]);
            }
        }
        [TestMethod]
        public void Test_MyImage_stegano_decodage()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int[] tab1 = { 1, 1, 1, 1, 0, 0, 0, 0 };
            int[] tab2 = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] tab = UnitTest1.stegano_decodage(tab2);
            for (int i = 0; i < tab.Length; i++)
            {
                Assert.AreEqual(tab1[i], tab[i]);
            }
        }
        [TestMethod]
        public void Test_MyImage_coder_message()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int[] tab1 = { 1, 1 };
            int[] tab2 = { 1, 1, 1, 1, 1, 1, 0, 0 };
            int[] tab3 = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] tab = UnitTest1.coder_message(tab2, tab1);
            for (int i = 0; i < tab.Length; i++)
            {
                Assert.AreEqual(tab3[i], tab[i]);
            }
        }
        [TestMethod]
        public void Test_MyImage_decoder_message()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int[] tab = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] tab1 = { 7, 8 };
            int[] tab2 = UnitTest1.decoder_message(tab);
            for(int i=0;i<tab2.Length;i++)
            {
                Assert.AreEqual(tab1[i], tab2[i]);
            }
        }
        [TestMethod]
        public void Test_MyImage_trouver_index()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            char a = 'a';
            Assert.AreEqual(2, UnitTest1.trouver_index(a));
        }
        [TestMethod]
        public void Test_MyImage_cryptage()
        {
            MyImage UnitTest1 = new MyImage("Images\\coco.bmp");
            int[] tab1 = { 1, 1, 0, 1, 0, 0, 1, 0 };
            int[] tab2 = { 0, 1, 0, 0, 1, 1, 1, 0 };
            int[] tab3 = { 1, 0, 0, 1, 1, 1, 0, 0 };
            int[] tab = UnitTest1.cryptage(tab1, tab2);
            for (int i = 0; i < tab.Length; i++)
            {
                Assert.AreEqual(tab3[i], tab[i]);
            }

        }





    }
}
