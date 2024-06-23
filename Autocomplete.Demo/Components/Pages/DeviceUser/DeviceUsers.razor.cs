
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autocomplete.Demo.Service;
using Microsoft.AspNetCore.Components;

namespace Autocomplete.Demo.Components.Pages.DeviceUser;

public partial class DeviceUsers : ComponentBase, INotifyPropertyChanged
{
    private IEnumerable<ViewModel> _deviceUsers = new List<ViewModel>();
    private ViewModel? _selectedDeviceUser = null;
    private string  IsEditDialogVisible => _selectedDeviceUser is not null ? "" : "disabled";
    private string _searchText = string.Empty;

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetField(ref _searchText, value))
            {
                StateHasChanged();
            }
        }
    }
    
    public IEnumerable<ViewModel> DeviceUsersFiltered => FilterDeviceUsers();
    
    [Inject]
    private DeviceUserService DeviceUserService { get; set; } = null!;
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;
    
    protected override async Task OnInitializedAsync()
    {
        _deviceUsers = from user in  await DeviceUserService.GetDeviceUsersAsync()
                       select new ViewModel
                       {
                           Id = user.Id,
                           Forename = user.Forename,
                           Surname = user.Surname,
                           KeypadId = user.KeypadId,
                           CardId = user.CardId,
                           EnrolmentId = user.EnrolmentId,
                           Pin = user.Pin
                       };
    }
    
    public void UserSelected(int userId)
    {
        _selectedDeviceUser = _deviceUsers.FirstOrDefault(user => user.Id == userId);
    }
    
    private void OnDeviceUserSelected(ViewModel deviceUser)
    {
        _selectedDeviceUser = deviceUser;
    }


    protected IEnumerable<ViewModel> FilterDeviceUsers()
    {
        if (string.IsNullOrWhiteSpace(_searchText))
        {
            return _deviceUsers;
        }

        return _deviceUsers.Where(deviceUser =>
            deviceUser.Forename.Contains(_searchText, StringComparison.OrdinalIgnoreCase) 
            || deviceUser.Surname.Contains(_searchText, StringComparison.OrdinalIgnoreCase));
    }
    
    private void OnClearSearch()
    {
        _searchText = string.Empty;
    }
    
    private void OnClearSelectedDeviceUser()
    {
        _selectedDeviceUser = null;
    }

    private void OnSearchChangedCallback(ChangeEventArgs obj)
    {
        if (obj.Value is string searchText)
        {
            _searchText = searchText;
        }
        StateHasChanged();
    }

    public Task OnClearSearchCallback()
    {
        OnClearSearch();
        StateHasChanged();
        return Task.CompletedTask;
    }

    public Task OnAddDeviceUser()
    {
        NavigationManager.NavigateTo("deviceUsers/add");
        return Task.CompletedTask;
    }

    public Task OnEditDeviceUser()
    {
        NavigationManager.NavigateTo($"deviceUsers/edit/{_selectedDeviceUser?.Id}");
        return Task.CompletedTask;
    }

    public Task OnDeleteDeviceUser()
    {
        NavigationManager.NavigateTo($"deviceUsers/delete/{_selectedDeviceUser?.Id}");
        return Task.CompletedTask;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}