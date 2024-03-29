
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;
	private global::Gtk.Label selTestFormLabel;
	private global::Gtk.Label selTestTypeLabel;
	private global::Gtk.RadioButton radiobuttonFormB;
	private global::Gtk.RadioButton radiobuttonFormA;
	private global::Gtk.RadioButton radiobuttonPractice;
	private global::Gtk.RadioButton radiobuttonActual;
	private global::Gtk.Label labelNumOfTests;
	private global::Gtk.SpinButton spinbuttonNumPractice;
	private global::Gtk.Label labelNumActualTests;
	private global::Gtk.Label labelAnswersExpected;
	private global::Gtk.Label labelPracticeAnswersExpected;
	private global::Gtk.Label labelActualAnswersExpected;
	private global::Gtk.Label labelDelayBetweenNumbers;
	private global::Gtk.RadioButton radiobutton3seconds;
	private global::Gtk.RadioButton radiobutton2seconds;
	private global::Gtk.Label labelEstimatedTime;
	private global::Gtk.Button buttonRunTest;
	private global::Gtk.Label labelTimeEstimate;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("PASAT:  PACED  AUDITORY  SERIAL  ADDITION  TEST");
		this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-bold", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.selTestFormLabel = new global::Gtk.Label ();
		this.selTestFormLabel.Name = "selTestFormLabel";
		this.selTestFormLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Select Test Form");
		this.selTestFormLabel.Justify = ((global::Gtk.Justification)(1));
		this.selTestFormLabel.SingleLineMode = true;
		this.fixed1.Add (this.selTestFormLabel);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.selTestFormLabel]));
		w1.X = 60;
		w1.Y = 25;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.selTestTypeLabel = new global::Gtk.Label ();
		this.selTestTypeLabel.Name = "selTestTypeLabel";
		this.selTestTypeLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Select  Test  Type");
		this.selTestTypeLabel.Justify = ((global::Gtk.Justification)(1));
		this.selTestTypeLabel.SingleLineMode = true;
		this.fixed1.Add (this.selTestTypeLabel);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.selTestTypeLabel]));
		w2.X = 51;
		w2.Y = 58;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.radiobuttonFormB = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Form  B"));
		this.radiobuttonFormB.CanFocus = true;
		this.radiobuttonFormB.Name = "radiobuttonFormB";
		this.radiobuttonFormB.DrawIndicator = true;
		this.radiobuttonFormB.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.fixed1.Add (this.radiobuttonFormB);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobuttonFormB]));
		w3.X = 260;
		w3.Y = 22;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.radiobuttonFormA = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Form  A"));
		this.radiobuttonFormA.CanFocus = true;
		this.radiobuttonFormA.Name = "radiobuttonFormA";
		this.radiobuttonFormA.DrawIndicator = true;
		this.radiobuttonFormA.Group = this.radiobuttonFormB.Group;
		this.fixed1.Add (this.radiobuttonFormA);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobuttonFormA]));
		w4.X = 160;
		w4.Y = 22;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.radiobuttonPractice = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Practice"));
		this.radiobuttonPractice.CanFocus = true;
		this.radiobuttonPractice.Name = "radiobuttonPractice";
		this.radiobuttonPractice.DrawIndicator = true;
		this.radiobuttonPractice.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.fixed1.Add (this.radiobuttonPractice);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobuttonPractice]));
		w5.X = 160;
		w5.Y = 54;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.radiobuttonActual = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Actual"));
		this.radiobuttonActual.CanFocus = true;
		this.radiobuttonActual.Name = "radiobuttonActual";
		this.radiobuttonActual.DrawIndicator = true;
		this.radiobuttonActual.Group = this.radiobuttonPractice.Group;
		this.fixed1.Add (this.radiobuttonActual);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobuttonActual]));
		w6.X = 260;
		w6.Y = 52;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelNumOfTests = new global::Gtk.Label ();
		this.labelNumOfTests.Name = "labelNumOfTests";
		this.labelNumOfTests.LabelProp = global::Mono.Unix.Catalog.GetString ("Number of Tests");
		this.labelNumOfTests.Justify = ((global::Gtk.Justification)(1));
		this.labelNumOfTests.SingleLineMode = true;
		this.fixed1.Add (this.labelNumOfTests);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelNumOfTests]));
		w7.X = 56;
		w7.Y = 90;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.spinbuttonNumPractice = new global::Gtk.SpinButton (1D, 3D, 1D);
		this.spinbuttonNumPractice.CanFocus = true;
		this.spinbuttonNumPractice.Name = "spinbuttonNumPractice";
		this.spinbuttonNumPractice.Adjustment.PageIncrement = 1D;
		this.spinbuttonNumPractice.ClimbRate = 1D;
		this.spinbuttonNumPractice.Digits = ((uint)(1));
		this.spinbuttonNumPractice.Numeric = true;
		this.spinbuttonNumPractice.SnapToTicks = true;
		this.spinbuttonNumPractice.Value = 1D;
		this.spinbuttonNumPractice.Wrap = true;
		this.fixed1.Add (this.spinbuttonNumPractice);
		global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.spinbuttonNumPractice]));
		w8.X = 174;
		w8.Y = 86;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelNumActualTests = new global::Gtk.Label ();
		this.labelNumActualTests.Name = "labelNumActualTests";
		this.labelNumActualTests.LabelProp = global::Mono.Unix.Catalog.GetString ("1");
		this.labelNumActualTests.SingleLineMode = true;
		this.fixed1.Add (this.labelNumActualTests);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelNumActualTests]));
		w9.X = 288;
		w9.Y = 90;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelAnswersExpected = new global::Gtk.Label ();
		this.labelAnswersExpected.Name = "labelAnswersExpected";
		this.labelAnswersExpected.LabelProp = global::Mono.Unix.Catalog.GetString ("Answers Expected");
		this.labelAnswersExpected.Justify = ((global::Gtk.Justification)(1));
		this.fixed1.Add (this.labelAnswersExpected);
		global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelAnswersExpected]));
		w10.X = 52;
		w10.Y = 124;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelPracticeAnswersExpected = new global::Gtk.Label ();
		this.labelPracticeAnswersExpected.Name = "labelPracticeAnswersExpected";
		this.labelPracticeAnswersExpected.LabelProp = global::Mono.Unix.Catalog.GetString ("10");
		this.labelPracticeAnswersExpected.Justify = ((global::Gtk.Justification)(2));
		this.labelPracticeAnswersExpected.SingleLineMode = true;
		this.fixed1.Add (this.labelPracticeAnswersExpected);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelPracticeAnswersExpected]));
		w11.X = 190;
		w11.Y = 124;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelActualAnswersExpected = new global::Gtk.Label ();
		this.labelActualAnswersExpected.Name = "labelActualAnswersExpected";
		this.labelActualAnswersExpected.LabelProp = global::Mono.Unix.Catalog.GetString ("60");
		this.labelActualAnswersExpected.Justify = ((global::Gtk.Justification)(2));
		this.labelActualAnswersExpected.SingleLineMode = true;
		this.fixed1.Add (this.labelActualAnswersExpected);
		global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelActualAnswersExpected]));
		w12.X = 284;
		w12.Y = 124;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelDelayBetweenNumbers = new global::Gtk.Label ();
		this.labelDelayBetweenNumbers.Name = "labelDelayBetweenNumbers";
		this.labelDelayBetweenNumbers.LabelProp = global::Mono.Unix.Catalog.GetString ("Delay Between Numbers");
		this.labelDelayBetweenNumbers.Justify = ((global::Gtk.Justification)(1));
		this.labelDelayBetweenNumbers.SingleLineMode = true;
		this.fixed1.Add (this.labelDelayBetweenNumbers);
		global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelDelayBetweenNumbers]));
		w13.X = 19;
		w13.Y = 154;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.radiobutton3seconds = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("3  Seconds"));
		this.radiobutton3seconds.CanFocus = true;
		this.radiobutton3seconds.Name = "radiobutton3seconds";
		this.radiobutton3seconds.DrawIndicator = true;
		this.radiobutton3seconds.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.fixed1.Add (this.radiobutton3seconds);
		global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobutton3seconds]));
		w14.X = 160;
		w14.Y = 150;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.radiobutton2seconds = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("2  Seconds"));
		this.radiobutton2seconds.CanFocus = true;
		this.radiobutton2seconds.Name = "radiobutton2seconds";
		this.radiobutton2seconds.DrawIndicator = true;
		this.radiobutton2seconds.UseUnderline = true;
		this.radiobutton2seconds.Group = this.radiobutton3seconds.Group;
		this.fixed1.Add (this.radiobutton2seconds);
		global::Gtk.Fixed.FixedChild w15 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.radiobutton2seconds]));
		w15.X = 260;
		w15.Y = 150;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelEstimatedTime = new global::Gtk.Label ();
		this.labelEstimatedTime.Name = "labelEstimatedTime";
		this.labelEstimatedTime.LabelProp = global::Mono.Unix.Catalog.GetString ("Estimated Test Time");
		this.labelEstimatedTime.Justify = ((global::Gtk.Justification)(1));
		this.labelEstimatedTime.SingleLineMode = true;
		this.fixed1.Add (this.labelEstimatedTime);
		global::Gtk.Fixed.FixedChild w16 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelEstimatedTime]));
		w16.X = 39;
		w16.Y = 184;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.buttonRunTest = new global::Gtk.Button ();
		this.buttonRunTest.CanFocus = true;
		this.buttonRunTest.Name = "buttonRunTest";
		this.buttonRunTest.UseUnderline = true;
		this.buttonRunTest.Label = global::Mono.Unix.Catalog.GetString ("Run  Test");
		this.fixed1.Add (this.buttonRunTest);
		global::Gtk.Fixed.FixedChild w17 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.buttonRunTest]));
		w17.X = 164;
		w17.Y = 215;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.labelTimeEstimate = new global::Gtk.Label ();
		this.labelTimeEstimate.Name = "labelTimeEstimate";
		this.labelTimeEstimate.LabelProp = global::Mono.Unix.Catalog.GetString ("1  Minute   10  Seconds");
		this.labelTimeEstimate.Justify = ((global::Gtk.Justification)(2));
		this.labelTimeEstimate.SingleLineMode = true;
		this.fixed1.Add (this.labelTimeEstimate);
		global::Gtk.Fixed.FixedChild w18 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.labelTimeEstimate]));
		w18.X = 169;
		w18.Y = 184;
		this.Add (this.fixed1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 435;
		this.DefaultHeight = 313;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.buttonRunTest.Clicked += new global::System.EventHandler (this.RunTestOnClicked);
	}
}
