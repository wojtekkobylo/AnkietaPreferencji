using System;
using System.Net.Mime;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AnkietaPreferencji;

public partial class MainWindow : Window
{
    private TextBox _imieTextBox;
    private Button _submitButton ;
    private TextBlock _wynikifinal;
    private String _imie;
    private String _kategoria;
    private String checkBoxPodsumowanie;
    public MainWindow()
    {
        InitializeComponent();

        _imieTextBox = this.FindControl<TextBox>("TextBoxImie");
        _submitButton = this.FindControl<Button>("SubmitButton1");
        _wynikifinal = this.FindControl<TextBlock>("PodsumowanieTextBox");

    }
    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
        _imie = $"Imie: {_imieTextBox.Text}\n";
        var comboBoxValue = (ComboBoxKategoria.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";
        _kategoria =  $"Wybrana kategoria: {comboBoxValue}\n";
        
    }

    private void Podsumowanie(object? sender, RoutedEventArgs e)
    {
        var checkBox1Value = CheckBoxPytanie1.IsChecked == true ? "Checked" : "Unchecked";
        var checkBox2Value = CheckBoxPytanie2.IsChecked == true ? "Checked" : "Unchecked";
        var checkBox3Value = CheckBoxPytanie3.IsChecked == true ? "Checked" : "Unchecked";
        var _yesCount = 0;
        if (checkBox1Value == "Checked")
        {
            _yesCount++;
        }
        if (checkBox2Value == "Checked")
        {
            _yesCount++;
        }
        if (checkBox3Value == "Checked")
        {
            _yesCount++;
        }

        checkBoxPodsumowanie = $"Wybrałeś tak: {_yesCount} razy";
        
        _wynikifinal.Text = _imie+_kategoria+checkBoxPodsumowanie;
    }
}