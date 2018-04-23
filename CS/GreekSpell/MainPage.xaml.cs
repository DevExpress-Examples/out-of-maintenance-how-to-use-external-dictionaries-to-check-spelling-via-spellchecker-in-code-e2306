using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace GreekSpell
{
    public partial class MainPage : UserControl
    {
        SpellChecker checker;
        public MainPage()
        {
            InitializeComponent();

            textEdit.Text = @"Η Μάχη της Μόσχας (ρώσικα: Битва под Москвой, γερμανικά: Schlacht um Moskau) 
είναι το όνομε που έχει δοθεί από σοβιετικούς ιστορικούς σε δύο περιόδους σημαντικών μαχών κατά μήκος ενός τομέα 600 χιλιομέτρων στο Ανατολικό Μέτωπο
κατά την διάρκεια του Β' Παγκοσμίου Πολέμου. Διαδραματίστηκε μεταξύ Οκτοβρίου 1941 και Ιανουαρίου 1942. 
Ο Χίτλερ θεωρούσε την Μόσχα, πρωτεύουσα της Σοβιετικής Ένωσης και μεγαλύτερη πόλη της, κύριο στρατηγικό στόχο των δυνάμεων του Άξονα στην Επιχείρηση Μπαρμπαρόσα.";


            checker = new SpellChecker();
            // clearing the dictionaries
            //checker.Dictionaries.Clear();
            // getting the Greek dictionary and grammar from the assembly
            Stream dict = Assembly.GetExecutingAssembly().GetManifestResourceStream("GreekSpell.el_GR.dic");
            Stream grammar = Assembly.GetExecutingAssembly().GetManifestResourceStream("GreekSpell.el_GR.aff");
            // creating the dictionary
            SpellCheckerOpenOfficeDictionary dictionary = new SpellCheckerOpenOfficeDictionary();
            // creating the culture
            CultureInfo ellinika = new CultureInfo("el-GR");
            // loading the dictionary           
            dictionary.LoadFromStream(dict, grammar, null);
            // setting the dictionary culture
            dictionary.Culture = ellinika;            
            //adding the dictionary to the collection
            checker.Dictionaries.Add(dictionary);
             
            // setting the default culture of the spell checker
            checker.Culture = ellinika;
        }

  
        private void Button_Click(object sender, RoutedEventArgs e)  {
            // calling the checker to inspect the text box.
            checker.Check(textEdit);
        }
    }
}
