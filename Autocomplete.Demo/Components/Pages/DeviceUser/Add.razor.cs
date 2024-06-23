using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Autocomplete.Demo.Data.DeviceUser;
using Autocomplete.Demo.Service;
using Microsoft.AspNetCore.Components;

namespace Autocomplete.Demo.Components.Pages.DeviceUser;

public partial class Add : ComponentBase, INotifyPropertyChanged
{
    private DeviceUserModel? _deviceUser = null;
    private ViewModel _viewModel = new ViewModel();
    private string _visiblePin = "";
    private string _validationMessage = "";

    private ViewModel ViewModel
    {
        get => _viewModel;
        set
        {
            if (SetField(ref _viewModel, value))
            {
                StateHasChanged();
            }
        }
    }

    [Inject]
    private DeviceUserService DeviceUserService { get; set; } = null!;
    
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;
    
    private async Task OnSaveCallback()
    {
        if (!await CanSave() || _deviceUser is null)
            return;
        await DeviceUserService.AddDeviceUserAsync(_deviceUser);
        NavigationManager.NavigateTo("/device-user/list");
    }
    
    private async Task<bool> CanSave()
    {
        if (string.IsNullOrWhiteSpace(_viewModel.Forename))
        {
            _validationMessage = "Forename is required";
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(_viewModel.Surname))
        {
            _validationMessage = "Surname is required";
            return false;
        }
        _deviceUser = new DeviceUserModel(_viewModel.Forename, _viewModel.Surname, _viewModel.KeypadId, _viewModel.CardId, _viewModel.EnrolmentId, _viewModel.Pin);

        if (await DeviceUserService.ValidateDeviceUserAsync(_deviceUser) is not { } validationResult)
            return true;
        
        var validationMessage = new StringBuilder();
            
        validationMessage.AppendLine(validationResult.ErrorMessage);
        foreach (var member in validationResult.MemberNames)
        {
            validationMessage.AppendLine(member);
        }
        return false;

    }
    
    private void OnCancelCallback()
    {
        NavigationManager.NavigateTo("/device-user/list");
    }
    
    private void OnForenameChanged(string forename)
    {
        _viewModel.Forename = forename;
    }
    
    private void OnSurnameChanged(string surname)
    {
        _viewModel.Surname = surname;
    }
    
    private void OnKeypadIdChanged(string keypadId)
    {
        _viewModel.KeypadId = keypadId;
    }
    
    private void OnCardIdChanged(string cardId)
    {
        _viewModel.CardId = cardId;
    }
    
    private void OnEnrolmentIdChanged(string enrolmentId)
    {
        _viewModel.EnrolmentId = enrolmentId;
    }
    
    private void OnPinChanged(string pin)
    {
        _viewModel.Pin = pin;
        _visiblePin = pin;
    }
    
    private void OnPinVisibilityChanged(bool isVisible)
    {
        _viewModel.Pin = isVisible ? _visiblePin : "********";
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