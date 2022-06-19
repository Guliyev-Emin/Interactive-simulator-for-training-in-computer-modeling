using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using GraduationProject.Construction;
using GraduationProject.Controllers;

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

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH",
            MessageId = "type: System.Byte[]")]
        private void button1_Click(object sender, EventArgs e)
        {
            userDataRichTextBox.Clear();
            _numberOfCorrectResults = 0;
            AddingUserData();
            Controller.Comparison(benchmarkData, ref userDataRichTextBox, ref _numberOfCorrectResults);
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
                var regex = new Regex(userData);
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