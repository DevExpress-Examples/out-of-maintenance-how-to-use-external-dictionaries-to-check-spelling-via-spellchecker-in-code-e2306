Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker
Imports System.IO
Imports System.Reflection
Imports System.Globalization

Namespace GreekSpell
	Partial Public Class MainPage
		Inherits UserControl
		Private checker As SpellChecker
		Public Sub New()
			InitializeComponent()

			textEdit.Text = "Η Μάχη της Μόσχας (ρώσικα: Битва под Москвой, γερμανικά: Schlacht um Moskau) " & ControlChars.CrLf & "είναι το όνομε που έχει δοθεί από σοβιετικούς ιστορικούς σε δύο περιόδους σημαντικών μαχών κατά μήκος ενός τομέα 600 χιλιομέτρων στο Ανατολικό Μέτωπο" & ControlChars.CrLf & "κατά την διάρκεια του Β' Παγκοσμίου Πολέμου. Διαδραματίστηκε μεταξύ Οκτοβρίου 1941 και Ιανουαρίου 1942. " & ControlChars.CrLf & "Ο Χίτλερ θεωρούσε την Μόσχα, πρωτεύουσα της Σοβιετικής Ένωσης και μεγαλύτερη πόλη της, κύριο στρατηγικό στόχο των δυνάμεων του Άξονα στην Επιχείρηση Μπαρμπαρόσα."


			checker = New SpellChecker()
			' clearing the dictionaries
			'checker.Dictionaries.Clear();
			' getting the Greek dictionary and grammar from the assembly
			Dim dict As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("el_GR.dic")
			Dim grammar As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("el_GR.aff")
			' creating the dictionary
			Dim dictionary As New SpellCheckerOpenOfficeDictionary()
			' creating the culture
			Dim ellinika As New CultureInfo("el-GR")
			' loading the dictionary           
			dictionary.LoadFromStream(dict, grammar, Nothing)
			' setting the dictionary culture
			dictionary.Culture = ellinika
			'adding the dictionary to the collection
			checker.Dictionaries.Add(dictionary)

			' setting the default culture of the spell checker
			checker.Culture = ellinika
		End Sub


		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' calling the checker to inspect the text box.
			checker.Check(textEdit)
		End Sub
	End Class
End Namespace
