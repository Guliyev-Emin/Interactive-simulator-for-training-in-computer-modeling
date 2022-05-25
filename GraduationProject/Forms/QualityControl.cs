using System;
using System.IO;
using System.Windows.Forms;
namespace GraduationProject
{
    public partial class QualityControl : Form
    {
        public QualityControl()
        {
            InitializeComponent();
            benchmarkData.Clear();
            benchmarkData.ReadOnly = true;
            textBox2.Clear();
            textBox2.ReadOnly = true;
            const string path = @"..\..\Files\Свойства модели.txt";
 
            var text = File.ReadAllText(path);
            text = text.Replace("\n", Environment.NewLine);
            benchmarkData.Text = text;

            // var replace = text.Replace("\r", "");
            // replace = replace.Replace("\n", "");
            // replace = replace.Replace(";", Environment.NewLine);
            //
            // textBox1.Text += replace;
            //
            // var userModelProperties = "";
            // foreach (var sketchInfo in Reader.SketchInfos)
            // {
            //     if (sketchInfo.LineStatus)
            //     {
            //         //userModelProperties = sketchInfo.LineCoordinates.Aggregate(userModelProperties, (current, lineCoordinate) => current + lineCoordinate);
            //         foreach (var VARIABLE in sketchInfo.LineCoordinates)
            //         {
            //             userModelProperties += VARIABLE;
            //         }
            //     }
            //
            //     if (sketchInfo.ArcStatus)
            //     {
            //         //userModelProperties = sketchInfo.ArcCoordinates.Aggregate(userModelProperties, (current, arcCoordinate) => current + arcCoordinate);
            //         foreach (var VARIABLE in sketchInfo.ArcCoordinates)
            //         {
            //             userModelProperties += VARIABLE;
            //         }
            //     }
            // }
            // userModelProperties = userModelProperties.Replace(";", Environment.NewLine);
            // userModelProperties = userModelProperties.Replace("Начало: ", "");
            // userModelProperties = userModelProperties.Replace("Конец: ", "");
            // userModelProperties = userModelProperties.Replace("Центр: ", "");
            // textBox2.Text += userModelProperties;
        }
    }
}