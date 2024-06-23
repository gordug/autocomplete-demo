using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Autocomplete.Demo.Components.Pages.DeviceUser;

public class ViewModel : INotifyPropertyChanged
{
    private string _forename = string.Empty;
    private string _surname = string.Empty;
    private string _keypadId = string.Empty;
    private string _cardId = string.Empty;
    private string _enrolmentId = string.Empty;
    private string _pin = string.Empty;
    public int Id { get; init; }

    public string Forename
    {
        get => _forename;
        set
        {
            if (value == _forename) return;
            _forename = value;
            OnPropertyChanged();
            OnPropertyChanged();
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            if (value == _surname) return;
            _surname = value;
            OnPropertyChanged();
            OnPropertyChanged();
        }
    }

    public string KeypadId
    {
        get => _keypadId;
        set
        {
            if (value == _keypadId) return;
            _keypadId = value;
            OnPropertyChanged();
        }
    }

    public string CardId
    {
        get => _cardId;
        set
        {
            if (value == _cardId) return;
            _cardId = value;
            OnPropertyChanged();
        }
    }

    public string EnrolmentId
    {
        get => _enrolmentId;
        set
        {
            if (value == _enrolmentId) return;
            _enrolmentId = value;
            OnPropertyChanged();
        }
    }

    public string Pin
    {
        get => _pin;
        set
        {
            if (value == _pin) return;
            _pin = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}