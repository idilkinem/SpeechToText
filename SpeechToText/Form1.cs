using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using Vosk;
using Newtonsoft.Json.Linq;

namespace SpeechToText
{
    public partial class Form1 : Form
    {
        private WaveInEvent waveIn;
        private VoskRecognizer recognizer;
        private Model model;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string modelPath = Path.Combine(Application.StartupPath, "vosk-model-small-tr-0.3");
                if (!Directory.Exists(modelPath))
                {
                    MessageBox.Show("Model klasörü bulunamadı!\nLütfen 'vosk-model-small-tr-0.3' klasörünü proje içine kopyalayın.",
                                    "Model Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                model = new Model(modelPath);
                recognizer = new VoskRecognizer(model, 16000.0f);

                lblStatus.Text = "Hazır";
                lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                waveIn = new WaveInEvent();
                waveIn.WaveFormat = new WaveFormat(16000, 1);
                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.StartRecording();

                lblStatus.Text = "Dinleniyor...";
                lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mikrofon başlatılamadı: " + ex.Message);
            }
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            try
            {
                if (recognizer != null && recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded))
                {
                    var result = recognizer.Result();
                    var text = JObject.Parse(result)["text"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        // UI güvenli biçimde güncellensin
                        if (txtSpeech.InvokeRequired)
                        {
                            txtSpeech.Invoke(new MethodInvoker(delegate
                            {
                                txtSpeech.AppendText(text + " ");
                            }));
                        }
                        else
                        {
                            txtSpeech.AppendText(text + " ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ses işleme hatası: " + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.StopRecording();
                    waveIn.Dispose();
                    lblStatus.Text = "Durduruldu";
                    lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Durdurulurken hata: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Metin Dosyası|*.txt";
                save.Title = "Konuşmayı Kaydet";
                save.FileName = "KonusmaMetni.txt";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, txtSpeech.Text);
                    MessageBox.Show("Metin başarıyla kaydedildi!", "Kayıt Başarılı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt hatası: " + ex.Message);
            }
        }
    }
}
