using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Diagnostics;


namespace Jarvis_V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechRecognitionEngine Rengine = new SpeechRecognitionEngine();
        private void button1_Click(object sender, EventArgs e)
        {
            Choices list = new Choices();
            list.Add(new string[] { "Hello", "What time is it", "exit", "openchrome" });
            Grammar gramer = new Grammar(new GrammarBuilder(list));
            try
            {
                Rengine.RequestRecognizerUpdate ();
                Rengine.LoadGrammar(gramer);
                Rengine.SpeechRecognized += Rengine_SpeechRecognized;
                Rengine.SetInputToDefaultAudioDevice();
                Rengine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {

                return;
            }
        }
        void Rengine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "open chrome":
                    System.Diagnostics.Process.Start("C:/Program Files/Google/Chrome/Application/chrome.exe");
                    pbuilder.ClearContent();
                    pbuilder.AppendText("Okey");
                    synt.Speak(pbuilder);
                    break;

                case "exit":
                    Application.Exit();
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rengine.Dispose();
        }
    }
}
