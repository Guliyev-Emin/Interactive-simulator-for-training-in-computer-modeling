using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GraduationProject.Construction;

namespace GraduationProject
{
    public partial class QualityControl : Form
    {
        private int _numberOfCorrectResults;

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
            if (Reader.ModelProperties == null)
                Reader.CreateTemplateModelProperties();
            if (Reader.ModelProperties != null)
                userDataRichTextBox.Text = Reader.ModelProperties.Replace("\n", Environment.NewLine);
        }

        /// <summary>
        /// Процедура проверки двумерных примитивов эскиза пользователя
        /// с правильными примитивами.
        /// </summary>
        private void Checking()
        {
            var userData = userDataRichTextBox.Text.Split(new[] {"\n\n"}, StringSplitOptions.RemoveEmptyEntries);
            var index = 0;
            var checkBreak = false;
            var benchmark = benchmarkData.Text.Split(new[] {"Имя эскиза:"},
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in benchmark)
            {
                var userDataInfo = userData[index];
                var userDataInfoArray = new List<string>(userDataInfo.Split('\n'));
                foreach (var info in data.Split('\n'))
                {
                    var info1 = info.Replace("\r", null);
                    if (info.IndexOf("Эскиз", StringComparison.Ordinal) != -1) continue;
                    foreach (var value in userDataInfoArray)
                    {
                        if(value == userDataInfoArray.First()) continue;
                        var regex = new Regex("" + value);
                        if (info1 == value)
                            foreach (Match match in regex.Matches(userDataRichTextBox.Text))
                            {
                                userDataRichTextBox.Select(match.Index, value.Length);
                                if (userDataRichTextBox.SelectionBackColor.Name.Equals("LightGreen")) continue;
                                userDataRichTextBox.SelectionBackColor = Color.LightGreen;
                                checkBreak = true;
                                _numberOfCorrectResults++;
                                var indexUserData = userDataInfoArray.FindIndex(x => x.Equals(value));
                                var newText = "";
                                for (var i = 0; i < value.Length; i++) newText += '-';
                                userDataInfoArray[indexUserData] = newText;
                                break;
                            }
                        else
                            foreach (Match match in regex.Matches(userDataRichTextBox.Text))
                            {
                                userDataRichTextBox.Select(match.Index, value.Length);
                                if (userDataRichTextBox.SelectionBackColor.Name is "LightGreen" or "White") continue;
                                userDataRichTextBox.SelectionBackColor = Color.Red;
                            }

                        if (!checkBreak) continue;
                        checkBreak = false;
                        break;
                    }
                }

                index++;
            }
        }

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.Byte[]")]
        private void button1_Click(object sender, EventArgs e)
        {
            userDataRichTextBox.Clear();
            _numberOfCorrectResults = 0;
            AddingUserData();
            Checking();
            ResultOfChecking();
        }

        /// <summary>
        /// Процедура по вычислению неверных результатов и вывода количества правильных и неправильных
        /// </summary>
        private void ResultOfChecking()
        {
            var errorIndexes = new List<int>();
            var errorCounter = 0;
            foreach (var userData in
                     userDataRichTextBox.Text.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                var regex = new Regex("" + userData);
                foreach (Match match in regex.Matches(userDataRichTextBox.Text))
                {
                    userDataRichTextBox.Select(match.Index, userData.Length);
                    if (!(userDataRichTextBox.SelectionBackColor.Name.Equals("Red") &
                          !errorIndexes.Contains(match.Index))) continue;
                    errorCounter++;
                    errorIndexes.Add(match.Index);
                    break;
                }
            }

            MessageBox.Show(
                @"Количество верных результатов: " + _numberOfCorrectResults + Environment.NewLine +
                @"Количество неверных результатов: " + errorCounter, @"Информация");
        }
    }
}