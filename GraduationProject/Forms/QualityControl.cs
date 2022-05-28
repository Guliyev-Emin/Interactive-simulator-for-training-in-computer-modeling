using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GraduationProject.Construction;

namespace GraduationProject
{
    public partial class QualityControl : Form
    {
        private int _numberOfCorrectResults;
        private int _numberOfIncorrectResults;

        public QualityControl()
        {
            InitializeComponent();
            benchmarkData.Clear();
            userDataRichTextBox.Clear();

            AddingInitialData(@"..\..\Files\Свойства модели.txt");
            AddingUserData();
        }

        private void AddingInitialData(string path)
        {
            var text = File.ReadAllText(path);
            benchmarkData.Text = text.Replace("\n", Environment.NewLine);
        }

        private void AddingUserData()
        {
            foreach (var sketchInfo in Reader.SketchInfos)
            {
                if (userDataRichTextBox.Text != "") userDataRichTextBox.Text += Environment.NewLine;
                userDataRichTextBox.Text += sketchInfo.SketchName + Environment.NewLine;
                userDataRichTextBox.Text += @"Количество линий: " + sketchInfo.LineCount + Environment.NewLine;
                var counter = 0;
                if (sketchInfo.LineStatus)
                    foreach (var lineLength in sketchInfo.LineLengths)
                        if (sketchInfo.LineTypes[counter] != 4)
                        {
                            userDataRichTextBox.Text += @"Линия: " + lineLength + @" мм" + Environment.NewLine;
                            counter++;
                        }
                        else
                        {
                            counter++;
                        }

                if (sketchInfo.ArcStatus)
                    foreach (var arcRadius in sketchInfo.ArcRadius)
                        userDataRichTextBox.Text += @"Радиус: " + arcRadius + @" мм" + Environment.NewLine;

                userDataRichTextBox.Text += @"Глубина: " + sketchInfo.Deepth + @" мм" + Environment.NewLine;
            }
        }

        private void Checking()
        {
            var userData = userDataRichTextBox.Text.Split(new[] {"\n\n"}, StringSplitOptions.RemoveEmptyEntries);
            var index = 0;
            var checkBreak = false;
            foreach (var data in benchmarkData.Text.Split(new[] {"\r\r\n\r\r\n"},
                         StringSplitOptions.RemoveEmptyEntries))
            {
                var userDataInfo = userData[index];
                var userDataInfoArray = new List<string>(userDataInfo.Split('\n'));
                foreach (var info in data.Split('\n'))
                {
                    var info1 = info.Replace("\r", null);
                    if (info.IndexOf("Эскиз", StringComparison.Ordinal) != -1) continue;
                    foreach (var value in userDataInfoArray)
                    {
                        if (info1 == value)
                        {
                            var regex = new Regex("" + value);
                            foreach (Match match in regex.Matches(userDataRichTextBox.Text))
                            {
                                userDataRichTextBox.Select(match.Index, value.Length);
                                if (userDataRichTextBox.SelectionBackColor.Name == "Green") continue;
                                userDataRichTextBox.SelectionBackColor = Color.Green;
                                checkBreak = true;
                                _numberOfCorrectResults++;
                                var indexUserData = userDataInfoArray.FindIndex(x => x.Equals(value));
                                var newText = "";
                                for (var i = 0; i < value.Length; i++)
                                {
                                    newText += '-';
                                }
                                userDataInfoArray[indexUserData] = newText;
                                break;
                            }
                        }
                        else
                        {
                            var regex = new Regex("" + value);
                            foreach (Match match in regex.Matches(userDataRichTextBox.Text))
                            {
                                userDataRichTextBox.Select(match.Index, value.Length);
                                if (userDataRichTextBox.SelectionBackColor.Name is "Green" or "White") continue;
                                _numberOfIncorrectResults++;
                                userDataRichTextBox.SelectionBackColor = Color.Red;
                            }
                        }

                        if (!checkBreak) continue;
                        checkBreak = false;
                        break;
                    }
                }

                index++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userDataRichTextBox.Clear();
            _numberOfCorrectResults = 0;
            _numberOfIncorrectResults = 0;
            AddingUserData();
            Checking();
            CorrectMessage();
        }

        private void CorrectMessage()
        {
            MessageBox.Show(@"Количество верных результатов: " + _numberOfCorrectResults, @"Информация");
        }
    }
}