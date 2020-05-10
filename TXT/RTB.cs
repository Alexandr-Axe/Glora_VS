using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

using System.IO;
using Microsoft.Win32;

namespace TXT
{
    public class RTB
    {
        public static RichTextBox SetText(RichTextBox RTB, string Text)
        {
            RTB.Document.Blocks.Clear();
            RTB.Document.Blocks.Add(new Paragraph(new Run(Text)));
            return RTB;
        }
        public static string GetText(RichTextBox RTB)
        {
            return new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd).Text;
        }
        public static RichTextBox GetTime(RichTextBox RichTB)
        {
            string min = string.Empty;
            if (DateTime.Now.Minute < 10) min = $"0{DateTime.Now.Minute}";
            else min = $"{DateTime.Now.Minute}";
            //.Replace(Environment.NewLine, string.Empty);
            string nove = ($"{RTB.GetText(RichTB)}{DateTime.Today.Day}.{DateTime.Today.Month}.{DateTime.Today.Year} {DateTime.Now.Hour}:{min} ");
            return RTB.SetText(RichTB, nove);

            //TextSouboru.Text += $"{DateTime.Today.Day}.{DateTime.Today.Month}.{DateTime.Today.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute} ";
            //RichTB.CaretIndex = TextSouboru.Text.Length;
            //RichTB.ScrollToHorizontalOffset(double.MaxValue); // Horní část vypíše datum a čas v mém formátu, tyhle dva řádky nastaví kurzor po napsání na konec
        }
        public static FlowDocument SearchText(RichTextBox RichTB, string Word)
        {
            Paragraph asd = new Paragraph(new Run(""));
            Run BarevnyText;
            string zac;
            string[] VsechenText = RTB.GetText(RichTB).Split(' ');
            for (int i = 0; i < VsechenText.Length; i++)
            {
                zac = VsechenText[i];//.Replace(Environment.NewLine, string.Empty);
                if (i == VsechenText.Length - 1) zac = VsechenText[i].Replace(Environment.NewLine, string.Empty);
                if (zac == Word)
                {
                    BarevnyText = new Run($"{VsechenText[i]}");
                    BarevnyText.Background = new SolidColorBrush(Colors.Red);
                    asd.Inlines.Add(BarevnyText);
                    asd.Inlines.Add(new Run(" "));
                }
                else
                {
                    BarevnyText = new Run($"{VsechenText[i]} ");
                    asd.Inlines.Add(BarevnyText);
                }
            }
            FlowDocument Novy = new FlowDocument(asd);
            Novy.PageWidth = 2000;
            return Novy;
        }
        public static FlowDocument Experiment(RichTextBox RichTB, string Word)
        {
            Paragraph asd = new Paragraph(new Run(""));
            Run BarevnyText;
            int PocetPismen = Word.ToCharArray().Length;
            char[] ZnakySlova = Word.ToCharArray();
            string ZachytnyString = string.Empty;
            string VsechenText = RTB.GetText(RichTB);
            char[] ZnakyTextu = VsechenText.ToCharArray();
            try
            {
                for (int i = 0; i < ZnakyTextu.Length; i++)
                {
                    for (int a = 0; a < ZnakySlova.Length; a++)
                    {
                         if (ZnakyTextu[i] == ZnakySlova[a])
                         {
                                 BarevnyText = new Run(ZnakySlova[a].ToString());
                                 BarevnyText.Background = new SolidColorBrush(Colors.Red);
                                 asd.Inlines.Add(BarevnyText);
                                 a = ZnakySlova.Length - 1;
                         }
                        else
                        {
                            if (a == ZnakySlova.Length - 1) asd.Inlines.Add(ZnakyTextu[i].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return new FlowDocument(asd);
        }
        public static FlowDocument ReplaceWord(RichTextBox RichTB, string PuvodniSlovo, string NoveSlovo)
        {
            Paragraph asd = new Paragraph(new Run(""));
            Run ZmenenyText;
            string zac;
            string[] VsechenText = GetText(RichTB).Split(' ');
            for (int i = 0; i < VsechenText.Length; i++)
            {
                zac = VsechenText[i];
                if (i == VsechenText.Length - 1) zac = VsechenText[i].Replace(Environment.NewLine, string.Empty);
                if (zac == PuvodniSlovo)
                {
                    asd.Inlines.Add(new Run($"{NoveSlovo}"));
                    asd.Inlines.Add(new Run(" "));
                }
                else
                {
                    ZmenenyText = new Run($"{VsechenText[i]} ");
                    asd.Inlines.Add(ZmenenyText);
                }
            }
            return new FlowDocument(asd);
        }
    }
}
