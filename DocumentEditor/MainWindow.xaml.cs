using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DocumentEditor
{
    internal sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(startIndexTextBox.Text, out int startIndex) && int.TryParse(endIndexTextBox.Text, out int endIndex))
            {
                if (IsValidRange(startIndex, endIndex))
                {
                    TextRange textRange = new TextRange(
                    tB.ContentStart.GetPositionAtOffset(startIndex),
                    tB.ContentStart.GetPositionAtOffset(endIndex));
                    textRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                }
                else
                {
                    MessageBox.Show("Некорректный диапазон");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для индексов");
            }
        }

        private bool IsValidRange(int startIndex, int endIndex)
        {
            return startIndex <= endIndex;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(startIndexTextBox.Text, out int startIndex) && int.TryParse(endIndexTextBox.Text, out int endIndex))
            {
                if (IsValidRange(startIndex, endIndex))
                {
                    TextRange textRange = new TextRange(
                        tB.ContentStart.GetPositionAtOffset(startIndex),
                        tB.ContentStart.GetPositionAtOffset(endIndex));

                    textRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                }
                else
                {
                    MessageBox.Show("Некорректный диапазон");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для индексов");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(startIndexTextBox.Text, out int startIndex) && int.TryParse(endIndexTextBox.Text, out int endIndex))
            {
                if (IsValidRange(startIndex, endIndex))
                {
                    TextRange textRange = new TextRange(
                        tB.ContentStart.GetPositionAtOffset(startIndex),
                        tB.ContentStart.GetPositionAtOffset(endIndex));

                    textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                }
                else
                {
                    MessageBox.Show("Некорректный диапазон");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для индексов");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(startIndexTextBox.Text, out int startIndex) && int.TryParse(endIndexTextBox.Text, out int endIndex))
            {
                if (IsValidRange(startIndex, endIndex))
                {
                    TextRange textRange = new TextRange(
                        tB.ContentStart.GetPositionAtOffset(startIndex),
                        tB.ContentStart.GetPositionAtOffset(endIndex));
                    textRange.ClearAllProperties();
                }
                else
                {
                    MessageBox.Show("Некорректный диапазон");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для индексов");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (int.TryParse(startIndexTextBox.Text, out int startIndex) && int.TryParse(endIndexTextBox.Text, out int endIndex))
            {
                if (IsValidRange(startIndex, endIndex))
                {
                    TextPointer startPointer = tB.ContentStart.GetPositionAtOffset(startIndex);
                    TextPointer endPointer = tB.ContentStart.GetPositionAtOffset(endIndex);
                    TextRange textRange = new TextRange(startPointer, endPointer);

                    if (sizeComboBox.SelectedItem != null)
                    {
                        string selectedSize = ((ComboBoxItem)sizeComboBox.SelectedItem).Content.ToString();

                        if (double.TryParse(selectedSize, out double fontSize))
                        {
                            textRange.ApplyPropertyValue(TextElement.FontSizeProperty, fontSize);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка преобразования размера шрифта");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный диапазон");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для индексов");
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (int.TryParse(startIndexTextBox.Text, out int startIndex) && int.TryParse(endIndexTextBox.Text, out int endIndex))
            {
                if (IsValidRange(startIndex, endIndex))
                {
                    TextPointer startPointer = tB.ContentStart.GetPositionAtOffset(startIndex);
                    TextPointer endPointer = tB.ContentStart.GetPositionAtOffset(endIndex);

                    TextRange textRange = new TextRange(startPointer, endPointer);

                    if (colorComboBox.SelectedItem != null)
                    {
                        if (colorComboBox.SelectedItem is ComboBoxItem selectedItem)
                        {
                            if (selectedItem.Content is StackPanel stackPanel)
                            {
                                if (stackPanel.Children[1] is TextBlock textBlock)
                                {
                                    string selectedColor = textBlock.Text.ToLower();
                                    try {
                                        var color = (Color)ColorConverter.ConvertFromString(selectedColor);
                                        textRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(color));
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show("Ошибка преобразования цвета");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный диапазон");
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для индексов");
            }
        }
    }
}